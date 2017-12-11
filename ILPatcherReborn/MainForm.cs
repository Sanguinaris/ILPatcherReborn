using ILPatcherReborn.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILPatcherReborn
{
    public partial class MainForm : MaterialSkin.Controls.MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;


        }

        //TODO Handle progressbar stuff
        private void createLibButton_Click(object sender, EventArgs e)
        {
            createLibButton.Enabled = false;
            statusLabel.ForeColor = Color.LightGray;
            statusLabel.Text = "Creating Library...";
            Manager.PatchManager.GenerateLibAsync(mainFileTextField.Text, (Manager.PatchException exception) =>
            {
                createLibButton.BeginInvoke((MethodInvoker)delegate () { createLibButton.Enabled = true; });
                if (exception != null)
                {
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.BeginInvoke((MethodInvoker)delegate () { statusLabel.Text = exception.Message; });
                }
                else
                {
                    statusLabel.ForeColor = Color.LimeGreen;
                    statusLabel.BeginInvoke((MethodInvoker)delegate () { statusLabel.Text = "Created Library"; });
                }
            });
        }

        private void createPatchButton_Click(object sender, EventArgs e)
        {
            createPatchButton.Enabled = false;
            statusLabel.ForeColor = Color.LightGray;
            statusLabel.Text = "Patching Assembly...";
            Manager.PatchManager.PatchAsync(mainFileTextField.Text, patchFileTextField.Text, (Mono.Cecil.AssemblyDefinition asmDef, Manager.PatchException exception) => {

                createPatchButton.BeginInvoke((MethodInvoker)delegate () { createPatchButton.Enabled = true; });
            if (exception != null)
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.BeginInvoke((MethodInvoker)delegate () { statusLabel.Text = exception.Message; });
            }
            else
            {
                statusLabel.ForeColor = Color.LimeGreen;
                statusLabel.BeginInvoke((MethodInvoker)delegate () { statusLabel.Text = "Patching Succeeded"; });

                    if(acNewFileRadioBtn.Checked)
                    {
                        asmDef.Write(Path.GetDirectoryName(mainFileTextField.Text) + '\\' + Path.GetFileNameWithoutExtension(mainFileTextField.Text) +
                            ".Patched" + Path.GetExtension(mainFileTextField.Text));
                    }else if(overrideOldFileRadioBtn.Checked)
                    {
                        overrideOldFileRadioBtn.BeginInvoke((MethodInvoker)delegate ()
                      {
                          asmDef.Write(mainFileTextField.Text);
                      });
                    }else if(chooseCustomFileRadioBtn.Checked)
                    {
                        statusLabel.BeginInvoke((MethodInvoker)delegate ()
                        {
                            saveFileDialog.InitialDirectory = Path.GetDirectoryName(mainFileTextField.Text);
                            saveFileDialog.FileName = Path.GetDirectoryName(mainFileTextField.Text) + Path.GetFileNameWithoutExtension(mainFileTextField.Text) +
                                ".Patched" + Path.GetExtension(mainFileTextField.Text);
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                asmDef.Write(saveFileDialog.FileName);
                            }
                        });
                    }
                }
            });
        }

        #region SaveStates
        private void MainForm_Load(object sender, EventArgs e)
        {
            mainFileLabel.ForeColor = Color.Red;
            patchFileLabel.ForeColor = Color.Red;

            devModeCheckBox.Checked = Settings.Default.devMode;
            trackFileCheckBox.Checked = Settings.Default.trackFile;

            switch(Settings.Default.fileOutputMode)
            {
                case 0:
                    acNewFileRadioBtn.Checked = true;
                    break;
                case 1:
                    overrideOldFileRadioBtn.Checked = true;
                    break;
                case 2:
                    chooseCustomFileRadioBtn.Checked = true;
                    break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.devMode = devModeCheckBox.Checked;
            Settings.Default.trackFile = trackFileCheckBox.Checked;
            Settings.Default.fileOutputMode = acNewFileRadioBtn.Checked ? 0 :
                                            overrideOldFileRadioBtn.Checked ? 1 :
                                            chooseCustomFileRadioBtn.Checked ? 2 : -1;
            Settings.Default.Save();
        }
        #endregion

        #region DragNDrop
        private void mainFileTextField_DragDrop(object sender, DragEventArgs e)
        {
            mainFileTextField.Text = e.Data.GetData(DataFormats.FileDrop).ToString();
        }

        private void patchFileTextField_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void textField_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }
#endregion

        #region FileSelectors
        private void selectPatchFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                patchFileTextField.Text = openFileDialog.FileName;
                mainFileWatcher.Path = Path.GetDirectoryName(patchFileTextField.Text);
                mainFileWatcher.Filter = Path.GetFileName(patchFileTextField.Text);

                patchFileLabel.ForeColor = Color.LimeGreen;
                if (mainFileLabel.ForeColor == Color.LimeGreen)
                    createPatchButton.Enabled = true;
            }
        }

        private void selectMainFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mainFileTextField.Text = openFileDialog.FileName;
                mainFileWatcher.Path = Path.GetDirectoryName(mainFileTextField.Text);
                mainFileWatcher.Filter = Path.GetFileName(mainFileTextField.Text);
                createLibButton.Enabled = true;

                mainFileLabel.ForeColor = Color.LimeGreen;
                if (patchFileLabel.ForeColor == Color.LimeGreen)
                    createPatchButton.Enabled = true;
            }
        }
#endregion

        #region File Watchers
        private void patchFileWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            patchFileLabel.ForeColor = Color.Red;
            createPatchButton.Enabled = false;
        }

        private void mainFileWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            mainFileLabel.ForeColor = Color.Red;
            createPatchButton.Enabled = false;
            createLibButton.Enabled = false;
        }

        private void patchFileWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            patchFileLabel.ForeColor = Color.LimeGreen;
            if (mainFileLabel.ForeColor == Color.LimeGreen)
                createPatchButton.Enabled = true;
        }

        private void mainFileWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            mainFileLabel.ForeColor = Color.LimeGreen;
            createLibButton.Enabled = true;
            if (patchFileLabel.ForeColor == Color.LimeGreen)
                createPatchButton.Enabled = true;
        }

        private void mainFileTextField_Leave(object sender, EventArgs e)
        {
            if (File.Exists(mainFileTextField.Text))
            {
                mainFileLabel.ForeColor = Color.LimeGreen;
                mainFileWatcher.Path = Path.GetDirectoryName(mainFileTextField.Text);
                mainFileWatcher.Filter = Path.GetFileName(mainFileTextField.Text);
                createLibButton.Enabled = true;
                if (patchFileLabel.ForeColor == Color.LimeGreen)
                    createPatchButton.Enabled = true;
            }
            else
            {
                mainFileLabel.ForeColor = Color.Red;
            }
        }

        private void patchFileTextField_Leave(object sender, EventArgs e)
        {
            if (File.Exists(patchFileTextField.Text))
            {
                patchFileLabel.ForeColor = Color.LimeGreen;
                patchFileWatcher.Path = Path.GetDirectoryName(patchFileTextField.Text);
                patchFileWatcher.Filter = Path.GetFileName(patchFileTextField.Text);
                createLibButton.Enabled = true;
                if (mainFileLabel.ForeColor == Color.LimeGreen)
                    createPatchButton.Enabled = true;
            }
            else
            {
                patchFileLabel.ForeColor = Color.Red;
            }
        }

        private void mainFileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if(trackFileCheckBox.Checked)
            {
                mainFileTextField.Text = e.FullPath;
            }
            else
            {
                mainFileLabel.ForeColor = Color.Red;
                createLibButton.Enabled = false;
                createPatchButton.Enabled = false;
            }
        }

        private void patchFileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (trackFileCheckBox.Checked)
            {
                patchFileTextField.Text = e.FullPath;
            }
            else
            {
                patchFileLabel.ForeColor = Color.Red;
                createPatchButton.Enabled = false;
            }
        }
        #endregion
    }
}
