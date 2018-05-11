namespace D2QS
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpMain = new System.Windows.Forms.TabPage();
            this.flpDiabloBoxes = new System.Windows.Forms.FlowLayoutPanel();
            this.tbpDiabloSettings = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditDiabloCancel = new System.Windows.Forms.Button();
            this.dgvDiabloSettings = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGlideSettings = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkUseGlide = new System.Windows.Forms.CheckBox();
            this.chkDesktopResolution = new System.Windows.Forms.CheckBox();
            this.chkWindowMode = new System.Windows.Forms.CheckBox();
            this.cmbStaticSize = new System.Windows.Forms.ComboBox();
            this.chkCaptureMouse = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPathSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtButtonText = new System.Windows.Forms.TextBox();
            this.chkShowOnMain = new System.Windows.Forms.CheckBox();
            this.chkRunAsAdmin = new System.Windows.Forms.CheckBox();
            this.lblArgumentHelp = new System.Windows.Forms.Label();
            this.txtArguments = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDiabloRealmList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.txtWindowTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditDiabloUpdate = new System.Windows.Forms.Button();
            this.btnAddDiabloToList = new System.Windows.Forms.Button();
            this.tbpProgramSettings = new System.Windows.Forms.TabPage();
            this.btnTotalShortcut = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnResetSize = new System.Windows.Forms.Button();
            this.ctmDiabloList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmDiabloDesktopShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.tmDiabloEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmDiabloDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbpMain.SuspendLayout();
            this.tbpDiabloSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiabloSettings)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbpProgramSettings.SuspendLayout();
            this.ctmDiabloList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpMain);
            this.tabControl1.Controls.Add(this.tbpDiabloSettings);
            this.tabControl1.Controls.Add(this.tbpProgramSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(410, 494);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tbpMain
            // 
            this.tbpMain.BackColor = System.Drawing.Color.Transparent;
            this.tbpMain.Controls.Add(this.flpDiabloBoxes);
            this.tbpMain.Location = new System.Drawing.Point(4, 22);
            this.tbpMain.Name = "tbpMain";
            this.tbpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMain.Size = new System.Drawing.Size(402, 468);
            this.tbpMain.TabIndex = 0;
            this.tbpMain.Text = "Main";
            // 
            // flpDiabloBoxes
            // 
            this.flpDiabloBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDiabloBoxes.Location = new System.Drawing.Point(3, 3);
            this.flpDiabloBoxes.Name = "flpDiabloBoxes";
            this.flpDiabloBoxes.Size = new System.Drawing.Size(396, 462);
            this.flpDiabloBoxes.TabIndex = 0;
            // 
            // tbpDiabloSettings
            // 
            this.tbpDiabloSettings.BackColor = System.Drawing.Color.Transparent;
            this.tbpDiabloSettings.Controls.Add(this.label8);
            this.tbpDiabloSettings.Controls.Add(this.btnEditDiabloCancel);
            this.tbpDiabloSettings.Controls.Add(this.dgvDiabloSettings);
            this.tbpDiabloSettings.Controls.Add(this.groupBox1);
            this.tbpDiabloSettings.Controls.Add(this.groupBox2);
            this.tbpDiabloSettings.Controls.Add(this.btnEditDiabloUpdate);
            this.tbpDiabloSettings.Controls.Add(this.btnAddDiabloToList);
            this.tbpDiabloSettings.Location = new System.Drawing.Point(4, 22);
            this.tbpDiabloSettings.Name = "tbpDiabloSettings";
            this.tbpDiabloSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDiabloSettings.Size = new System.Drawing.Size(402, 468);
            this.tbpDiabloSettings.TabIndex = 1;
            this.tbpDiabloSettings.Text = "Diablo Settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Diablo Settings List";
            // 
            // btnEditDiabloCancel
            // 
            this.btnEditDiabloCancel.Enabled = false;
            this.btnEditDiabloCancel.Location = new System.Drawing.Point(304, 213);
            this.btnEditDiabloCancel.Name = "btnEditDiabloCancel";
            this.btnEditDiabloCancel.Size = new System.Drawing.Size(75, 23);
            this.btnEditDiabloCancel.TabIndex = 13;
            this.btnEditDiabloCancel.Text = "Cancel";
            this.btnEditDiabloCancel.UseVisualStyleBackColor = true;
            this.btnEditDiabloCancel.Visible = false;
            this.btnEditDiabloCancel.Click += new System.EventHandler(this.btnEditDiabloCancel_Click);
            // 
            // dgvDiabloSettings
            // 
            this.dgvDiabloSettings.AllowUserToAddRows = false;
            this.dgvDiabloSettings.AllowUserToDeleteRows = false;
            this.dgvDiabloSettings.AllowUserToResizeRows = false;
            this.dgvDiabloSettings.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDiabloSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiabloSettings.Location = new System.Drawing.Point(6, 262);
            this.dgvDiabloSettings.MultiSelect = false;
            this.dgvDiabloSettings.Name = "dgvDiabloSettings";
            this.dgvDiabloSettings.RowHeadersVisible = false;
            this.dgvDiabloSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiabloSettings.Size = new System.Drawing.Size(382, 193);
            this.dgvDiabloSettings.TabIndex = 0;
            this.dgvDiabloSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvDiabloSettings_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGlideSettings);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chkUseGlide);
            this.groupBox1.Controls.Add(this.chkDesktopResolution);
            this.groupBox1.Controls.Add(this.chkWindowMode);
            this.groupBox1.Controls.Add(this.cmbStaticSize);
            this.groupBox1.Controls.Add(this.chkCaptureMouse);
            this.groupBox1.Location = new System.Drawing.Point(6, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 93);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Specific Glide Settings";
            // 
            // lblGlideSettings
            // 
            this.lblGlideSettings.AutoSize = true;
            this.lblGlideSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGlideSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlideSettings.Location = new System.Drawing.Point(158, 20);
            this.lblGlideSettings.Name = "lblGlideSettings";
            this.lblGlideSettings.Size = new System.Drawing.Size(13, 13);
            this.lblGlideSettings.TabIndex = 24;
            this.lblGlideSettings.Text = "?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Size";
            // 
            // chkUseGlide
            // 
            this.chkUseGlide.AutoSize = true;
            this.chkUseGlide.Location = new System.Drawing.Point(6, 19);
            this.chkUseGlide.Name = "chkUseGlide";
            this.chkUseGlide.Size = new System.Drawing.Size(146, 17);
            this.chkUseGlide.TabIndex = 0;
            this.chkUseGlide.Text = "Use These Glide Settings";
            this.chkUseGlide.UseVisualStyleBackColor = true;
            // 
            // chkDesktopResolution
            // 
            this.chkDesktopResolution.AutoSize = true;
            this.chkDesktopResolution.Checked = true;
            this.chkDesktopResolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDesktopResolution.Location = new System.Drawing.Point(6, 44);
            this.chkDesktopResolution.Name = "chkDesktopResolution";
            this.chkDesktopResolution.Size = new System.Drawing.Size(119, 17);
            this.chkDesktopResolution.TabIndex = 1;
            this.chkDesktopResolution.Text = "Desktop Resolution";
            this.chkDesktopResolution.UseVisualStyleBackColor = true;
            // 
            // chkWindowMode
            // 
            this.chkWindowMode.AutoSize = true;
            this.chkWindowMode.Checked = true;
            this.chkWindowMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWindowMode.Location = new System.Drawing.Point(158, 44);
            this.chkWindowMode.Name = "chkWindowMode";
            this.chkWindowMode.Size = new System.Drawing.Size(95, 17);
            this.chkWindowMode.TabIndex = 2;
            this.chkWindowMode.Text = "Window Mode";
            this.chkWindowMode.UseVisualStyleBackColor = true;
            // 
            // cmbStaticSize
            // 
            this.cmbStaticSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaticSize.FormattingEnabled = true;
            this.cmbStaticSize.Location = new System.Drawing.Point(39, 65);
            this.cmbStaticSize.Name = "cmbStaticSize";
            this.cmbStaticSize.Size = new System.Drawing.Size(113, 21);
            this.cmbStaticSize.TabIndex = 3;
            // 
            // chkCaptureMouse
            // 
            this.chkCaptureMouse.AutoSize = true;
            this.chkCaptureMouse.Location = new System.Drawing.Point(158, 67);
            this.chkCaptureMouse.Name = "chkCaptureMouse";
            this.chkCaptureMouse.Size = new System.Drawing.Size(98, 17);
            this.chkCaptureMouse.TabIndex = 4;
            this.chkCaptureMouse.Text = "Capture Mouse";
            this.chkCaptureMouse.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPathSearch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtButtonText);
            this.groupBox2.Controls.Add(this.chkShowOnMain);
            this.groupBox2.Controls.Add(this.chkRunAsAdmin);
            this.groupBox2.Controls.Add(this.lblArgumentHelp);
            this.groupBox2.Controls.Add(this.txtArguments);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbDiabloRealmList);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtGamePath);
            this.groupBox2.Controls.Add(this.txtWindowTitle);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 136);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Diablo Settings";
            // 
            // btnPathSearch
            // 
            this.btnPathSearch.Image = global::D2QS.Properties.Resources.Find;
            this.btnPathSearch.Location = new System.Drawing.Point(187, 30);
            this.btnPathSearch.Name = "btnPathSearch";
            this.btnPathSearch.Size = new System.Drawing.Size(23, 23);
            this.btnPathSearch.TabIndex = 1;
            this.btnPathSearch.UseVisualStyleBackColor = true;
            this.btnPathSearch.Click += new System.EventHandler(this.btnPathSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Custom button text";
            // 
            // txtButtonText
            // 
            this.txtButtonText.Location = new System.Drawing.Point(9, 109);
            this.txtButtonText.Name = "txtButtonText";
            this.txtButtonText.Size = new System.Drawing.Size(172, 20);
            this.txtButtonText.TabIndex = 5;
            // 
            // chkShowOnMain
            // 
            this.chkShowOnMain.AutoSize = true;
            this.chkShowOnMain.Location = new System.Drawing.Point(187, 111);
            this.chkShowOnMain.Name = "chkShowOnMain";
            this.chkShowOnMain.Size = new System.Drawing.Size(93, 17);
            this.chkShowOnMain.TabIndex = 6;
            this.chkShowOnMain.Text = "Show on main";
            this.chkShowOnMain.UseVisualStyleBackColor = true;
            // 
            // chkRunAsAdmin
            // 
            this.chkRunAsAdmin.AutoSize = true;
            this.chkRunAsAdmin.Location = new System.Drawing.Point(282, 112);
            this.chkRunAsAdmin.Name = "chkRunAsAdmin";
            this.chkRunAsAdmin.Size = new System.Drawing.Size(91, 17);
            this.chkRunAsAdmin.TabIndex = 7;
            this.chkRunAsAdmin.Text = "Run as admin";
            this.chkRunAsAdmin.UseVisualStyleBackColor = true;
            // 
            // lblArgumentHelp
            // 
            this.lblArgumentHelp.AutoSize = true;
            this.lblArgumentHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblArgumentHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArgumentHelp.Location = new System.Drawing.Point(276, 16);
            this.lblArgumentHelp.Name = "lblArgumentHelp";
            this.lblArgumentHelp.Size = new System.Drawing.Size(13, 13);
            this.lblArgumentHelp.TabIndex = 19;
            this.lblArgumentHelp.Text = "?";
            // 
            // txtArguments
            // 
            this.txtArguments.Location = new System.Drawing.Point(216, 32);
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.Size = new System.Drawing.Size(157, 20);
            this.txtArguments.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Realm";
            // 
            // cmbDiabloRealmList
            // 
            this.cmbDiabloRealmList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiabloRealmList.FormattingEnabled = true;
            this.cmbDiabloRealmList.Location = new System.Drawing.Point(216, 71);
            this.cmbDiabloRealmList.Name = "cmbDiabloRealmList";
            this.cmbDiabloRealmList.Size = new System.Drawing.Size(157, 21);
            this.cmbDiabloRealmList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Custom window title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Path to game.exe";
            // 
            // txtGamePath
            // 
            this.txtGamePath.Location = new System.Drawing.Point(9, 32);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(172, 20);
            this.txtGamePath.TabIndex = 0;
            // 
            // txtWindowTitle
            // 
            this.txtWindowTitle.Location = new System.Drawing.Point(9, 71);
            this.txtWindowTitle.Name = "txtWindowTitle";
            this.txtWindowTitle.Size = new System.Drawing.Size(172, 20);
            this.txtWindowTitle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Arguments";
            // 
            // btnEditDiabloUpdate
            // 
            this.btnEditDiabloUpdate.Enabled = false;
            this.btnEditDiabloUpdate.Location = new System.Drawing.Point(304, 165);
            this.btnEditDiabloUpdate.Name = "btnEditDiabloUpdate";
            this.btnEditDiabloUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnEditDiabloUpdate.TabIndex = 14;
            this.btnEditDiabloUpdate.Text = "Update";
            this.btnEditDiabloUpdate.UseVisualStyleBackColor = true;
            this.btnEditDiabloUpdate.Visible = false;
            this.btnEditDiabloUpdate.Click += new System.EventHandler(this.btnEditDiabloUpdate_Click);
            // 
            // btnAddDiabloToList
            // 
            this.btnAddDiabloToList.Location = new System.Drawing.Point(304, 165);
            this.btnAddDiabloToList.Name = "btnAddDiabloToList";
            this.btnAddDiabloToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddDiabloToList.TabIndex = 12;
            this.btnAddDiabloToList.Text = "Add Diablo";
            this.btnAddDiabloToList.UseVisualStyleBackColor = true;
            this.btnAddDiabloToList.Click += new System.EventHandler(this.btnAddDiabloToList_Click);
            // 
            // tbpProgramSettings
            // 
            this.tbpProgramSettings.BackColor = System.Drawing.Color.Transparent;
            this.tbpProgramSettings.Controls.Add(this.btnLoadFromFile);
            this.tbpProgramSettings.Controls.Add(this.btnSaveToFile);
            this.tbpProgramSettings.Controls.Add(this.btnTotalShortcut);
            this.tbpProgramSettings.Controls.Add(this.button2);
            this.tbpProgramSettings.Controls.Add(this.btnResetSize);
            this.tbpProgramSettings.Location = new System.Drawing.Point(4, 22);
            this.tbpProgramSettings.Name = "tbpProgramSettings";
            this.tbpProgramSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbpProgramSettings.Size = new System.Drawing.Size(402, 468);
            this.tbpProgramSettings.TabIndex = 2;
            this.tbpProgramSettings.Text = "Program Settings";
            // 
            // btnTotalShortcut
            // 
            this.btnTotalShortcut.Location = new System.Drawing.Point(6, 35);
            this.btnTotalShortcut.Name = "btnTotalShortcut";
            this.btnTotalShortcut.Size = new System.Drawing.Size(156, 23);
            this.btnTotalShortcut.TabIndex = 2;
            this.btnTotalShortcut.Text = "Create start ALL shortcut";
            this.btnTotalShortcut.UseVisualStyleBackColor = true;
            this.btnTotalShortcut.Click += new System.EventHandler(this.btnTotalShortcut_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset ALL";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnResetSize
            // 
            this.btnResetSize.Location = new System.Drawing.Point(6, 6);
            this.btnResetSize.Name = "btnResetSize";
            this.btnResetSize.Size = new System.Drawing.Size(75, 23);
            this.btnResetSize.TabIndex = 0;
            this.btnResetSize.Text = "Reset Size";
            this.btnResetSize.UseVisualStyleBackColor = true;
            // 
            // ctmDiabloList
            // 
            this.ctmDiabloList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmDiabloDesktopShortcut,
            this.tmDiabloEdit,
            this.tmDiabloDelete});
            this.ctmDiabloList.Name = "ctmDiabloList";
            this.ctmDiabloList.Size = new System.Drawing.Size(166, 70);
            // 
            // tmDiabloDesktopShortcut
            // 
            this.tmDiabloDesktopShortcut.Name = "tmDiabloDesktopShortcut";
            this.tmDiabloDesktopShortcut.Size = new System.Drawing.Size(165, 22);
            this.tmDiabloDesktopShortcut.Text = "Desktop Shortcut";
            this.tmDiabloDesktopShortcut.Click += new System.EventHandler(this.tmDiabloDesktopShortcut_Click);
            // 
            // tmDiabloEdit
            // 
            this.tmDiabloEdit.Name = "tmDiabloEdit";
            this.tmDiabloEdit.Size = new System.Drawing.Size(165, 22);
            this.tmDiabloEdit.Text = "Edit";
            this.tmDiabloEdit.Click += new System.EventHandler(this.tmDiabloEdit_Click);
            // 
            // tmDiabloDelete
            // 
            this.tmDiabloDelete.Name = "tmDiabloDelete";
            this.tmDiabloDelete.Size = new System.Drawing.Size(165, 22);
            this.tmDiabloDelete.Text = "Delete";
            this.tmDiabloDelete.Click += new System.EventHandler(this.tmDiabloDelete_Click);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(6, 64);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToFile.TabIndex = 3;
            this.btnSaveToFile.Text = "Save to file";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(87, 64);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFromFile.TabIndex = 4;
            this.btnLoadFromFile.Text = "Load file";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(410, 494);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 175);
            this.Name = "Form1";
            this.Text = "Diablo II Quick Starter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tbpMain.ResumeLayout(false);
            this.tbpDiabloSettings.ResumeLayout(false);
            this.tbpDiabloSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiabloSettings)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tbpProgramSettings.ResumeLayout(false);
            this.ctmDiabloList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpMain;
        private System.Windows.Forms.TabPage tbpDiabloSettings;
        private System.Windows.Forms.TextBox txtWindowTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGamePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkUseGlide;
        private System.Windows.Forms.CheckBox chkWindowMode;
        private System.Windows.Forms.CheckBox chkCaptureMouse;
        private System.Windows.Forms.ComboBox cmbStaticSize;
        private System.Windows.Forms.CheckBox chkDesktopResolution;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip ctmDiabloList;
        private System.Windows.Forms.ToolStripMenuItem tmDiabloEdit;
        private System.Windows.Forms.ToolStripMenuItem tmDiabloDelete;
        private System.Windows.Forms.Button btnAddDiabloToList;
        private System.Windows.Forms.DataGridView dgvDiabloSettings;
        private System.Windows.Forms.Button btnEditDiabloUpdate;
        private System.Windows.Forms.Button btnEditDiabloCancel;
        private System.Windows.Forms.TabPage tbpProgramSettings;
        private System.Windows.Forms.ToolStripMenuItem tmDiabloDesktopShortcut;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDiabloRealmList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flpDiabloBoxes;
        private System.Windows.Forms.TextBox txtArguments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblArgumentHelp;
        private System.Windows.Forms.CheckBox chkRunAsAdmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtButtonText;
        private System.Windows.Forms.CheckBox chkShowOnMain;
        private System.Windows.Forms.Button btnPathSearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnResetSize;
        private System.Windows.Forms.Label lblGlideSettings;
        private System.Windows.Forms.Button btnTotalShortcut;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.Button btnSaveToFile;
    }
}

