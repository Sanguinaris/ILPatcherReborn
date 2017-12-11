using Mono.Cecil;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;

namespace ILPatcherReborn.Manager
{
    //Creedz to simplity
    class PatchException : Exception
    {
        public PatchException(string msg) : base(msg) { }
    }

    class PatchManager
    {
        //TODO setup progress callback
        public static void PatchAsync(string origFile, string patchFile, Action<AssemblyDefinition, PatchException> callback)
        {
            new Thread (() => {
                PatchException exception = null;
                AssemblyDefinition asmDef = null;
                try
                {
                    Patch(origFile, patchFile, out asmDef);
                }catch(PatchException e)
                {
                    exception = e;
                }
                finally
                {
                    callback(asmDef, exception);
                }
            }).Start();
        }

        public static void GenerateLibAsync(string origFile, Action<PatchException> callback)
        {
            new Thread(() => {
                PatchException exception = null;
                try
                {
                    GenerateLib(origFile);
                }
                catch (PatchException e)
                {
                    exception = e;
                }
                finally
                {
                    callback(exception);
                }
            }).Start();
        }

        public static void Patch(string origFile, string patchFile, out AssemblyDefinition patchedFileDef)
        {
            GetAssemblyDefinition(origFile, out patchedFileDef);
            GetAssemblyDefinition(patchFile, out var patchAsmDef);

            InjectAssembly(ref patchedFileDef, patchAsmDef);
        }

        public static void GenerateLib(string origFile)
        {
            GetAssemblyDefinition(origFile, out var asmDef);

            foreach(var typeDef in asmDef.MainModule.Types)
            {
                typeDef.IsAbstract = false;
                typeDef.IsSealed = false;
                typeDef.IsBeforeFieldInit = false;

                foreach(var method in typeDef.Methods)
                {
                    //TODO make getters n setters methods
                    if(!(method.IsGetter || method.IsSetter))
                        method.IsVirtual = true;
                    if (method.IsPrivate)
                        method.IsFamily = true;
                }

                foreach(var field in typeDef.Fields)
                {
                    if (field.IsPrivate)
                        field.IsFamily = true;
                }
            }

            asmDef.Write(Path.GetDirectoryName(origFile) + '\\' + Path.GetFileNameWithoutExtension(origFile) + "-lib" + Path.GetExtension(origFile));
        }

        private static void GetAssemblyDefinition(string file, out AssemblyDefinition asmDef)
        {
            asmDef = null;
            DefaultAssemblyResolver resolver = new DefaultAssemblyResolver();
            resolver.AddSearchDirectory(Path.GetDirectoryName(file));

            ReaderParameters parameters = new ReaderParameters { AssemblyResolver = resolver };

            try
            {
                asmDef = AssemblyDefinition.ReadAssembly(file, parameters);
            }
            catch (BadImageFormatException)
            {
                throw new PatchException(file + " is not a valid .NET Assembly");
            }
        }


        //TODO CODEQUALITY make method class or something to rip this shit apart
        private static void CopyMethod(MethodDefinition templateMethod, string newName, TypeDefinition targetType, MethodDefinition newMethod = null, bool copyAttribs = true)
        {
            var module = targetType.Module;

            if(newMethod == null)
            {
                //TODO figure that shit out
                newMethod = new MethodDefinition(templateMethod.Name, templateMethod.Attributes, module.ImportReference(templateMethod.ReturnType));
            }

            if(copyAttribs)
            {
                foreach(var attrib in templateMethod.CustomAttributes)
                {
                    var item = new CustomAttribute(module.ImportReference(attrib.Constructor));
                    foreach (CustomAttributeArgument argument in attrib.ConstructorArguments)
                    {
                        CustomAttributeArgument newArg = new CustomAttributeArgument(module.ImportReference(argument.Type), argument.Value);
                        item.ConstructorArguments.Add(newArg);
                    }
                    foreach (CustomAttributeNamedArgument argument in attrib.Fields)
                    {
                        CustomAttributeNamedArgument newArg = new CustomAttributeNamedArgument(argument.Name, new CustomAttributeArgument(module.ImportReference(argument.Argument.Type), argument.Argument.Value));
                        item.Fields.Add(newArg);
                    }
                    newMethod.CustomAttributes.Add(item);
                }
            }

            foreach(var parameter in templateMethod.Parameters)
            {
                parameter.ParameterType = module.ImportReference(parameter.ParameterType);
                newMethod.Parameters.Add(parameter);
            }

            foreach (var handler in templateMethod.Body.ExceptionHandlers)
            {
                var catchType = handler.CatchType;
                if (catchType != null)
                    handler.CatchType = module.ImportReference(catchType);
                newMethod.Body.ExceptionHandlers.Add(handler);
            }

            foreach (var variable in templateMethod.Body.Variables)
            {
                variable.VariableType = module.ImportReference(variable.VariableType);
                newMethod.Body.Variables.Add(variable);
            }

            foreach(var instruction in templateMethod.Body.Instructions)
            {
                if (instruction.Operand is MethodReference)
                {
                    MethodReference method = null;
                    if (instruction.Operand.ToString() == newMethod.ToString())
                    {
                        method = targetType.Methods.FirstOrDefault<MethodDefinition>(func => (func.Name == newName));
                    }
                    method = method ?? ((MethodReference)instruction.Operand);
                    instruction.Operand = module.Import(method);
                }
                else if (instruction.Operand is TypeReference)
                {
                    instruction.Operand = module.ImportReference((TypeReference)instruction.Operand);
                }
                else if (instruction.Operand is FieldReference)
                {
                    instruction.Operand = module.ImportReference((FieldReference)instruction.Operand);
                }
                newMethod.Body.Instructions.Add(instruction);
            }

            newMethod.Body.InitLocals = templateMethod.Body.InitLocals;

            if(targetType.Methods.FirstOrDefault<MethodDefinition>(func => func.Name == newName) == null)
            {
                targetType.Methods.Add(newMethod);
            }
        }

        private static string GenerateName(string origName, TypeDefinition targetType)
        {
            int num = 1;
            while (true)
            {
                string name = string.Format("__{0}_{1}", origName, num);
                if (targetType.Methods.FirstOrDefault<MethodDefinition>(func => func.Name == name) == null)
                {
                    return name;
                }
                num++;
            }
        }

        private static void ClearMethod(ref MethodDefinition method)
        {
            method.Body.Instructions.Clear();
            method.Body.ExceptionHandlers.Clear();
            method.Body.Variables.Clear();
            method.Parameters.Clear();
            method.CustomAttributes.Clear();
        }

        private static void OverrideMethod(MethodDefinition templateMethod, TypeDefinition targetType, ref AssemblyDefinition asmDef)
        {
            MethodDefinition definition = targetType.Methods.FirstOrDefault<MethodDefinition>(func => func.Name == templateMethod.Name);

            string genName = GenerateName(templateMethod.Name, targetType);
            MethodDefinition newMethod = new MethodDefinition(genName, definition.Attributes, targetType.Module.ImportReference(definition.ReturnType));

            CopyMethod(definition, genName, targetType, newMethod, false);
            ClearMethod(ref definition);
            CopyMethod(templateMethod, genName, targetType, definition, true);
        }

        private static void InjectAssembly(ref AssemblyDefinition asmDef, AssemblyDefinition patchAsmDef)
        {
            foreach(var typeDef in patchAsmDef.MainModule.Types)
            {
                if (typeDef.BaseType == null)
                    continue;

                foreach(var method in typeDef.Methods)
                {
                    string customMethodHandling = method.HasCustomAttributes ? method.CustomAttributes[0].Constructor.DeclaringType.Name : "";
                    var foundBaseClass = asmDef.MainModule.Types.FirstOrDefault<TypeDefinition>(tDef => (tDef.FullName == typeDef.BaseType.FullName));

                    if (foundBaseClass != null) //IF any of the patch classes overrides one of the original classes
                    {
                        if(method.IsVirtual || customMethodHandling == "OverrideMethod")
                        {
                            OverrideMethod(method, foundBaseClass, ref asmDef);
                        }else if(customMethodHandling == "CopyMethod")
                        {
                            CopyMethod(method, method.Name, foundBaseClass);
                        }
                    }
                }
            }
        }
    }
}
