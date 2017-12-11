namespace ILPatcherReborn
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainFileTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.patchFileTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.mainFileLabel = new MaterialSkin.Controls.MaterialLabel();
            this.patchFileLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.PatchTab = new System.Windows.Forms.TabPage();
            this.selectPatchFileBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.selectMainFileBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.statusLabel = new MaterialSkin.Controls.MaterialLabel();
            this.progressBar = new MaterialSkin.Controls.MaterialProgressBar();
            this.createPatchButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.createLibButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.devModeCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.chooseCustomFileRadioBtn = new MaterialSkin.Controls.MaterialRadioButton();
            this.overrideOldFileRadioBtn = new MaterialSkin.Controls.MaterialRadioButton();
            this.trackFileCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.acNewFileRadioBtn = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainFileWatcher = new System.IO.FileSystemWatcher();
            this.patchFileWatcher = new System.IO.FileSystemWatcher();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.materialTabControl1.SuspendLayout();
            this.PatchTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFileWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchFileWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // mainFileTextField
            // 
            this.mainFileTextField.AllowDrop = true;
            this.mainFileTextField.Depth = 0;
            this.mainFileTextField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.mainFileTextField.Hint = "";
            this.mainFileTextField.Location = new System.Drawing.Point(12, 45);
            this.mainFileTextField.MaxLength = 32767;
            this.mainFileTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.mainFileTextField.Name = "mainFileTextField";
            this.mainFileTextField.PasswordChar = '\0';
            this.mainFileTextField.SelectedText = "";
            this.mainFileTextField.SelectionLength = 0;
            this.mainFileTextField.SelectionStart = 0;
            this.mainFileTextField.Size = new System.Drawing.Size(325, 23);
            this.mainFileTextField.TabIndex = 0;
            this.mainFileTextField.TabStop = false;
            this.mainFileTextField.UseSystemPasswordChar = false;
            this.mainFileTextField.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainFileTextField_DragDrop);
            this.mainFileTextField.DragEnter += new System.Windows.Forms.DragEventHandler(this.textField_DragEnter);
            this.mainFileTextField.Leave += new System.EventHandler(this.mainFileTextField_Leave);
            // 
            // patchFileTextField
            // 
            this.patchFileTextField.AllowDrop = true;
            this.patchFileTextField.Depth = 0;
            this.patchFileTextField.Hint = "";
            this.patchFileTextField.Location = new System.Drawing.Point(12, 102);
            this.patchFileTextField.MaxLength = 32767;
            this.patchFileTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.patchFileTextField.Name = "patchFileTextField";
            this.patchFileTextField.PasswordChar = '\0';
            this.patchFileTextField.SelectedText = "";
            this.patchFileTextField.SelectionLength = 0;
            this.patchFileTextField.SelectionStart = 0;
            this.patchFileTextField.Size = new System.Drawing.Size(325, 23);
            this.patchFileTextField.TabIndex = 1;
            this.patchFileTextField.TabStop = false;
            this.patchFileTextField.UseSystemPasswordChar = false;
            this.patchFileTextField.DragDrop += new System.Windows.Forms.DragEventHandler(this.patchFileTextField_DragDrop);
            this.patchFileTextField.DragEnter += new System.Windows.Forms.DragEventHandler(this.textField_DragEnter);
            this.patchFileTextField.Leave += new System.EventHandler(this.patchFileTextField_Leave);
            // 
            // mainFileLabel
            // 
            this.mainFileLabel.AutoSize = true;
            this.mainFileLabel.Depth = 0;
            this.mainFileLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.mainFileLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mainFileLabel.Location = new System.Drawing.Point(8, 23);
            this.mainFileLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.mainFileLabel.Name = "mainFileLabel";
            this.mainFileLabel.Size = new System.Drawing.Size(70, 19);
            this.mainFileLabel.TabIndex = 2;
            this.mainFileLabel.Text = "Main File";
            // 
            // patchFileLabel
            // 
            this.patchFileLabel.AutoSize = true;
            this.patchFileLabel.Depth = 0;
            this.patchFileLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.patchFileLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.patchFileLabel.Location = new System.Drawing.Point(8, 80);
            this.patchFileLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.patchFileLabel.Name = "patchFileLabel";
            this.patchFileLabel.Size = new System.Drawing.Size(75, 19);
            this.patchFileLabel.TabIndex = 3;
            this.patchFileLabel.Text = "Patch File";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.PatchTab);
            this.materialTabControl1.Controls.Add(this.SettingsTab);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 82);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(396, 359);
            this.materialTabControl1.TabIndex = 4;
            // 
            // PatchTab
            // 
            this.PatchTab.BackColor = System.Drawing.Color.White;
            this.PatchTab.Controls.Add(this.selectPatchFileBtn);
            this.PatchTab.Controls.Add(this.selectMainFileBtn);
            this.PatchTab.Controls.Add(this.statusLabel);
            this.PatchTab.Controls.Add(this.progressBar);
            this.PatchTab.Controls.Add(this.createPatchButton);
            this.PatchTab.Controls.Add(this.createLibButton);
            this.PatchTab.Controls.Add(this.patchFileLabel);
            this.PatchTab.Controls.Add(this.patchFileTextField);
            this.PatchTab.Controls.Add(this.mainFileLabel);
            this.PatchTab.Controls.Add(this.mainFileTextField);
            this.PatchTab.Location = new System.Drawing.Point(4, 22);
            this.PatchTab.Name = "PatchTab";
            this.PatchTab.Padding = new System.Windows.Forms.Padding(3);
            this.PatchTab.Size = new System.Drawing.Size(388, 333);
            this.PatchTab.TabIndex = 0;
            this.PatchTab.Text = "Patch";
            // 
            // selectPatchFileBtn
            // 
            this.selectPatchFileBtn.AutoSize = true;
            this.selectPatchFileBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectPatchFileBtn.Depth = 0;
            this.selectPatchFileBtn.Icon = null;
            this.selectPatchFileBtn.Location = new System.Drawing.Point(344, 89);
            this.selectPatchFileBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.selectPatchFileBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.selectPatchFileBtn.Name = "selectPatchFileBtn";
            this.selectPatchFileBtn.Primary = false;
            this.selectPatchFileBtn.Size = new System.Drawing.Size(32, 36);
            this.selectPatchFileBtn.TabIndex = 9;
            this.selectPatchFileBtn.Text = "...";
            this.selectPatchFileBtn.UseVisualStyleBackColor = true;
            this.selectPatchFileBtn.Click += new System.EventHandler(this.selectPatchFileBtn_Click);
            // 
            // selectMainFileBtn
            // 
            this.selectMainFileBtn.AutoSize = true;
            this.selectMainFileBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectMainFileBtn.BackColor = System.Drawing.Color.White;
            this.selectMainFileBtn.Depth = 0;
            this.selectMainFileBtn.Icon = null;
            this.selectMainFileBtn.Location = new System.Drawing.Point(344, 32);
            this.selectMainFileBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.selectMainFileBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.selectMainFileBtn.Name = "selectMainFileBtn";
            this.selectMainFileBtn.Primary = false;
            this.selectMainFileBtn.Size = new System.Drawing.Size(32, 36);
            this.selectMainFileBtn.TabIndex = 8;
            this.selectMainFileBtn.Text = "...";
            this.selectMainFileBtn.UseVisualStyleBackColor = false;
            this.selectMainFileBtn.Click += new System.EventHandler(this.selectMainFileBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Depth = 0;
            this.statusLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.statusLabel.Location = new System.Drawing.Point(8, 162);
            this.statusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(131, 19);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "Waiting for Input...";
            // 
            // progressBar
            // 
            this.progressBar.Depth = 0;
            this.progressBar.Location = new System.Drawing.Point(12, 154);
            this.progressBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(364, 5);
            this.progressBar.TabIndex = 6;
            // 
            // createPatchButton
            // 
            this.createPatchButton.AutoSize = true;
            this.createPatchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createPatchButton.Depth = 0;
            this.createPatchButton.Enabled = false;
            this.createPatchButton.Icon = null;
            this.createPatchButton.Location = new System.Drawing.Point(12, 270);
            this.createPatchButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.createPatchButton.Name = "createPatchButton";
            this.createPatchButton.Primary = true;
            this.createPatchButton.Size = new System.Drawing.Size(120, 36);
            this.createPatchButton.TabIndex = 5;
            this.createPatchButton.Text = "Create Patch";
            this.createPatchButton.UseVisualStyleBackColor = true;
            this.createPatchButton.Click += new System.EventHandler(this.createPatchButton_Click);
            // 
            // createLibButton
            // 
            this.createLibButton.AutoSize = true;
            this.createLibButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createLibButton.Depth = 0;
            this.createLibButton.Enabled = false;
            this.createLibButton.Icon = null;
            this.createLibButton.Location = new System.Drawing.Point(12, 211);
            this.createLibButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.createLibButton.Name = "createLibButton";
            this.createLibButton.Primary = true;
            this.createLibButton.Size = new System.Drawing.Size(130, 36);
            this.createLibButton.TabIndex = 4;
            this.createLibButton.Text = "Create Library";
            this.createLibButton.UseVisualStyleBackColor = true;
            this.createLibButton.Click += new System.EventHandler(this.createLibButton_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.BackColor = System.Drawing.Color.White;
            this.SettingsTab.Controls.Add(this.devModeCheckBox);
            this.SettingsTab.Controls.Add(this.chooseCustomFileRadioBtn);
            this.SettingsTab.Controls.Add(this.overrideOldFileRadioBtn);
            this.SettingsTab.Controls.Add(this.trackFileCheckBox);
            this.SettingsTab.Controls.Add(this.acNewFileRadioBtn);
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(388, 333);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            // 
            // devModeCheckBox
            // 
            this.devModeCheckBox.AutoSize = true;
            this.devModeCheckBox.Depth = 0;
            this.devModeCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.devModeCheckBox.Location = new System.Drawing.Point(5, 45);
            this.devModeCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.devModeCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.devModeCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.devModeCheckBox.Name = "devModeCheckBox";
            this.devModeCheckBox.Ripple = true;
            this.devModeCheckBox.Size = new System.Drawing.Size(130, 30);
            this.devModeCheckBox.TabIndex = 5;
            this.devModeCheckBox.Text = "Developer Mode";
            this.devModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // chooseCustomFileRadioBtn
            // 
            this.chooseCustomFileRadioBtn.AutoSize = true;
            this.chooseCustomFileRadioBtn.Depth = 0;
            this.chooseCustomFileRadioBtn.Font = new System.Drawing.Font("Roboto", 10F);
            this.chooseCustomFileRadioBtn.Location = new System.Drawing.Point(5, 139);
            this.chooseCustomFileRadioBtn.Margin = new System.Windows.Forms.Padding(0);
            this.chooseCustomFileRadioBtn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chooseCustomFileRadioBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.chooseCustomFileRadioBtn.Name = "chooseCustomFileRadioBtn";
            this.chooseCustomFileRadioBtn.Ripple = true;
            this.chooseCustomFileRadioBtn.Size = new System.Drawing.Size(152, 30);
            this.chooseCustomFileRadioBtn.TabIndex = 4;
            this.chooseCustomFileRadioBtn.TabStop = true;
            this.chooseCustomFileRadioBtn.Text = "Choose Custom File";
            this.chooseCustomFileRadioBtn.UseVisualStyleBackColor = true;
            // 
            // overrideOldFileRadioBtn
            // 
            this.overrideOldFileRadioBtn.AutoSize = true;
            this.overrideOldFileRadioBtn.Depth = 0;
            this.overrideOldFileRadioBtn.Font = new System.Drawing.Font("Roboto", 10F);
            this.overrideOldFileRadioBtn.Location = new System.Drawing.Point(5, 109);
            this.overrideOldFileRadioBtn.Margin = new System.Windows.Forms.Padding(0);
            this.overrideOldFileRadioBtn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.overrideOldFileRadioBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.overrideOldFileRadioBtn.Name = "overrideOldFileRadioBtn";
            this.overrideOldFileRadioBtn.Ripple = true;
            this.overrideOldFileRadioBtn.Size = new System.Drawing.Size(130, 30);
            this.overrideOldFileRadioBtn.TabIndex = 3;
            this.overrideOldFileRadioBtn.TabStop = true;
            this.overrideOldFileRadioBtn.Text = "Override Old File";
            this.overrideOldFileRadioBtn.UseVisualStyleBackColor = true;
            // 
            // trackFileCheckBox
            // 
            this.trackFileCheckBox.AutoSize = true;
            this.trackFileCheckBox.Depth = 0;
            this.trackFileCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.trackFileCheckBox.Location = new System.Drawing.Point(5, 15);
            this.trackFileCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.trackFileCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.trackFileCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.trackFileCheckBox.Name = "trackFileCheckBox";
            this.trackFileCheckBox.Ripple = true;
            this.trackFileCheckBox.Size = new System.Drawing.Size(97, 30);
            this.trackFileCheckBox.TabIndex = 1;
            this.trackFileCheckBox.Text = "Track Files";
            this.trackFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // acNewFileRadioBtn
            // 
            this.acNewFileRadioBtn.AutoSize = true;
            this.acNewFileRadioBtn.Checked = true;
            this.acNewFileRadioBtn.Depth = 0;
            this.acNewFileRadioBtn.Font = new System.Drawing.Font("Roboto", 10F);
            this.acNewFileRadioBtn.Location = new System.Drawing.Point(5, 79);
            this.acNewFileRadioBtn.Margin = new System.Windows.Forms.Padding(0);
            this.acNewFileRadioBtn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.acNewFileRadioBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.acNewFileRadioBtn.Name = "acNewFileRadioBtn";
            this.acNewFileRadioBtn.Ripple = true;
            this.acNewFileRadioBtn.Size = new System.Drawing.Size(156, 30);
            this.acNewFileRadioBtn.TabIndex = 2;
            this.acNewFileRadioBtn.TabStop = true;
            this.acNewFileRadioBtn.Text = "Auto Create new File";
            this.acNewFileRadioBtn.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 61);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(396, 28);
            this.materialTabSelector1.TabIndex = 0;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = ".NET DLL\'s|*.dll|.NET EXEC\'s|*.exe";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // mainFileWatcher
            // 
            this.mainFileWatcher.EnableRaisingEvents = true;
            this.mainFileWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
            this.mainFileWatcher.SynchronizingObject = this;
            this.mainFileWatcher.Created += new System.IO.FileSystemEventHandler(this.mainFileWatcher_Created);
            this.mainFileWatcher.Deleted += new System.IO.FileSystemEventHandler(this.mainFileWatcher_Deleted);
            this.mainFileWatcher.Renamed += new System.IO.RenamedEventHandler(this.mainFileWatcher_Renamed);
            // 
            // patchFileWatcher
            // 
            this.patchFileWatcher.EnableRaisingEvents = true;
            this.patchFileWatcher.SynchronizingObject = this;
            this.patchFileWatcher.Created += new System.IO.FileSystemEventHandler(this.patchFileWatcher_Created);
            this.patchFileWatcher.Deleted += new System.IO.FileSystemEventHandler(this.patchFileWatcher_Deleted);
            this.patchFileWatcher.Renamed += new System.IO.RenamedEventHandler(this.patchFileWatcher_Renamed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 440);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Sizable = false;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.PatchTab.ResumeLayout(false);
            this.PatchTab.PerformLayout();
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFileWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchFileWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField mainFileTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField patchFileTextField;
        private MaterialSkin.Controls.MaterialLabel mainFileLabel;
        private MaterialSkin.Controls.MaterialLabel patchFileLabel;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage PatchTab;
        private MaterialSkin.Controls.MaterialRadioButton chooseCustomFileRadioBtn;
        private MaterialSkin.Controls.MaterialRadioButton overrideOldFileRadioBtn;
        private MaterialSkin.Controls.MaterialRadioButton acNewFileRadioBtn;
        private MaterialSkin.Controls.MaterialCheckBox trackFileCheckBox;
        private System.Windows.Forms.TabPage SettingsTab;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialRaisedButton createPatchButton;
        private MaterialSkin.Controls.MaterialRaisedButton createLibButton;
        private MaterialSkin.Controls.MaterialLabel statusLabel;
        private MaterialSkin.Controls.MaterialProgressBar progressBar;
        private MaterialSkin.Controls.MaterialCheckBox devModeCheckBox;
        private MaterialSkin.Controls.MaterialFlatButton selectPatchFileBtn;
        private MaterialSkin.Controls.MaterialFlatButton selectMainFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.IO.FileSystemWatcher mainFileWatcher;
        private System.IO.FileSystemWatcher patchFileWatcher;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

