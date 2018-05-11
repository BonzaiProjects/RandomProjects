namespace D2MoCa
{
    partial class FrmD2QS
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Show",
            "sub1",
            "sub2"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmD2QS));
            this.tot = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.chkDLL = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFindProgram = new System.Windows.Forms.Button();
            this.btnFindD2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tstInfoLabel = new System.Windows.Forms.ToolStripLabel();
            this.tsbSound = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowEachD2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.flowPrograms = new System.Windows.Forms.FlowLayoutPanel();
            this.tabD2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnD2addSave = new System.Windows.Forms.Button();
            this.btnD2edit = new System.Windows.Forms.Button();
            this.btnD2delete = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtD2customName = new System.Windows.Forms.TextBox();
            this.txtD2path = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lstDiablo2Paths = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProgramName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEnableProgram = new System.Windows.Forms.CheckBox();
            this.btnAddProgram = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProgramArguments = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProgramPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstPrograms = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEditProgram = new System.Windows.Forms.Button();
            this.chkCloseProgram = new System.Windows.Forms.CheckBox();
            this.btnDeleteProgram = new System.Windows.Forms.Button();
            this.chkStartProgram = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabD2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(104, 8);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(83, 13);
            this.linkLabel1.TabIndex = 93;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "More arguments";
            this.tot.SetToolTip(this.linkLabel1, "http://diablo2.diablowiki.net/Game_commands#Target_Line_Commands");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(273, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 116;
            this.label13.Text = "?";
            this.tot.SetToolTip(this.label13, "Check this if you picked a DLL instead of a program (will not use the Start/Close" +
        ")");
            // 
            // chkDLL
            // 
            this.chkDLL.AutoSize = true;
            this.chkDLL.Location = new System.Drawing.Point(236, 71);
            this.chkDLL.Name = "chkDLL";
            this.chkDLL.Size = new System.Drawing.Size(66, 17);
            this.chkDLL.TabIndex = 7;
            this.chkDLL.Text = "Is a DLL";
            this.tot.SetToolTip(this.chkDLL, "Start the program minimized");
            this.chkDLL.UseVisualStyleBackColor = true;
            this.chkDLL.CheckedChanged += new System.EventHandler(this.chkDLL_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(195, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 110;
            this.label11.Text = "?";
            this.tot.SetToolTip(this.label11, "Start/Close the selected program when D2QS is launched/closed. (Not used if it\'s " +
        "a DLL)");
            // 
            // btnFindProgram
            // 
            this.btnFindProgram.Image = global::D2MoCa.Properties.Resources.Find_5650;
            this.btnFindProgram.Location = new System.Drawing.Point(280, 30);
            this.btnFindProgram.Name = "btnFindProgram";
            this.btnFindProgram.Size = new System.Drawing.Size(22, 23);
            this.btnFindProgram.TabIndex = 2;
            this.tot.SetToolTip(this.btnFindProgram, "Find the program to launch");
            this.btnFindProgram.UseVisualStyleBackColor = true;
            this.btnFindProgram.Click += new System.EventHandler(this.btnFindProgram_Click);
            // 
            // btnFindD2
            // 
            this.btnFindD2.Image = global::D2MoCa.Properties.Resources.Find_5650;
            this.btnFindD2.Location = new System.Drawing.Point(363, 30);
            this.btnFindD2.Name = "btnFindD2";
            this.btnFindD2.Size = new System.Drawing.Size(22, 23);
            this.btnFindD2.TabIndex = 116;
            this.tot.SetToolTip(this.btnFindD2, "Find the program to launch");
            this.btnFindD2.UseVisualStyleBackColor = true;
            this.btnFindD2.Click += new System.EventHandler(this.btnFindD2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // openFileDialog
            // 
            this.openFileDialog.RestoreDirectory = true;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstInfoLabel,
            this.tsbSound});
            this.toolStrip.Location = new System.Drawing.Point(0, 508);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(961, 25);
            this.toolStrip.TabIndex = 94;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tstInfoLabel
            // 
            this.tstInfoLabel.Name = "tstInfoLabel";
            this.tstInfoLabel.Size = new System.Drawing.Size(50, 22);
            this.tstInfoLabel.Text = "Info text";
            // 
            // tsbSound
            // 
            this.tsbSound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSound.AutoToolTip = false;
            this.tsbSound.Image = global::D2MoCa.Properties.Resources.d2chk_false;
            this.tsbSound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSound.Name = "tsbSound";
            this.tsbSound.Size = new System.Drawing.Size(88, 22);
            this.tsbSound.Text = "Sound: OFF";
            this.tsbSound.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbSound.Click += new System.EventHandler(this.tsbSound_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.BackColor = global::D2MoCa.Properties.Settings.Default.wh;
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabD2);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::D2MoCa.Properties.Settings.Default, "wh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(961, 508);
            this.tabControl1.TabIndex = 75;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.SystemColors.Control;
            this.tabMain.Controls.Add(this.groupBox3);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(953, 479);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.flowEachD2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.flowPrograms);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(947, 473);
            this.groupBox3.TabIndex = 94;
            this.groupBox3.TabStop = false;
            // 
            // flowEachD2
            // 
            this.flowEachD2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowEachD2.AutoScroll = true;
            this.flowEachD2.BackColor = System.Drawing.SystemColors.Control;
            this.flowEachD2.Location = new System.Drawing.Point(0, 24);
            this.flowEachD2.Name = "flowEachD2";
            this.flowEachD2.Size = new System.Drawing.Size(223, 449);
            this.flowEachD2.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Start Diablo";
            // 
            // flowPrograms
            // 
            this.flowPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPrograms.AutoScroll = true;
            this.flowPrograms.BackColor = System.Drawing.SystemColors.Control;
            this.flowPrograms.Location = new System.Drawing.Point(229, 24);
            this.flowPrograms.Name = "flowPrograms";
            this.flowPrograms.Size = new System.Drawing.Size(715, 449);
            this.flowPrograms.TabIndex = 4;
            // 
            // tabD2
            // 
            this.tabD2.Controls.Add(this.groupBox4);
            this.tabD2.Location = new System.Drawing.Point(4, 25);
            this.tabD2.Name = "tabD2";
            this.tabD2.Padding = new System.Windows.Forms.Padding(3);
            this.tabD2.Size = new System.Drawing.Size(953, 479);
            this.tabD2.TabIndex = 2;
            this.tabD2.Text = "Diablo2 Settings";
            this.tabD2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.btnD2addSave);
            this.groupBox4.Controls.Add(this.btnD2edit);
            this.groupBox4.Controls.Add(this.btnD2delete);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtD2customName);
            this.groupBox4.Controls.Add(this.txtD2path);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.btnFindD2);
            this.groupBox4.Controls.Add(this.lstDiablo2Paths);
            this.groupBox4.Location = new System.Drawing.Point(2, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 467);
            this.groupBox4.TabIndex = 113;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Diablo 2 List";
            // 
            // btnD2addSave
            // 
            this.btnD2addSave.Location = new System.Drawing.Point(9, 58);
            this.btnD2addSave.Name = "btnD2addSave";
            this.btnD2addSave.Size = new System.Drawing.Size(65, 23);
            this.btnD2addSave.TabIndex = 121;
            this.btnD2addSave.Text = "Add/Save";
            this.btnD2addSave.UseVisualStyleBackColor = true;
            this.btnD2addSave.Click += new System.EventHandler(this.btnD2addSave_Click);
            // 
            // btnD2edit
            // 
            this.btnD2edit.Location = new System.Drawing.Point(297, 58);
            this.btnD2edit.Name = "btnD2edit";
            this.btnD2edit.Size = new System.Drawing.Size(36, 23);
            this.btnD2edit.TabIndex = 122;
            this.btnD2edit.Text = "Edit";
            this.btnD2edit.UseVisualStyleBackColor = true;
            this.btnD2edit.Click += new System.EventHandler(this.btnD2edit_Click);
            // 
            // btnD2delete
            // 
            this.btnD2delete.Location = new System.Drawing.Point(339, 58);
            this.btnD2delete.Name = "btnD2delete";
            this.btnD2delete.Size = new System.Drawing.Size(46, 23);
            this.btnD2delete.TabIndex = 123;
            this.btnD2delete.Text = "Delete";
            this.btnD2delete.UseVisualStyleBackColor = true;
            this.btnD2delete.Click += new System.EventHandler(this.btnD2delete_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 13);
            this.label15.TabIndex = 120;
            this.label15.Text = "Custom D2 Name";
            // 
            // txtD2customName
            // 
            this.txtD2customName.Location = new System.Drawing.Point(9, 32);
            this.txtD2customName.Name = "txtD2customName";
            this.txtD2customName.Size = new System.Drawing.Size(102, 20);
            this.txtD2customName.TabIndex = 114;
            // 
            // txtD2path
            // 
            this.txtD2path.Location = new System.Drawing.Point(117, 32);
            this.txtD2path.Name = "txtD2path";
            this.txtD2path.Size = new System.Drawing.Size(240, 20);
            this.txtD2path.TabIndex = 115;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(114, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 118;
            this.label17.Text = "D2 Path";
            // 
            // lstDiablo2Paths
            // 
            this.lstDiablo2Paths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstDiablo2Paths.CheckBoxes = true;
            this.lstDiablo2Paths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lstDiablo2Paths.FullRowSelect = true;
            this.lstDiablo2Paths.GridLines = true;
            this.lstDiablo2Paths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstDiablo2Paths.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.lstDiablo2Paths.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstDiablo2Paths.Location = new System.Drawing.Point(4, 87);
            this.lstDiablo2Paths.MultiSelect = false;
            this.lstDiablo2Paths.Name = "lstDiablo2Paths";
            this.lstDiablo2Paths.Size = new System.Drawing.Size(381, 375);
            this.lstDiablo2Paths.TabIndex = 10;
            this.lstDiablo2Paths.UseCompatibleStateImageBehavior = false;
            this.lstDiablo2Paths.View = System.Windows.Forms.View.Details;
            this.lstDiablo2Paths.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstDiablo2Paths_ItemChecked);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "On Main";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 108;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Path";
            this.columnHeader7.Width = 172;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.Transparent;
            this.tabSettings.Controls.Add(this.groupBox2);
            this.tabSettings.Location = new System.Drawing.Point(4, 25);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(953, 479);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Program Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.chkDLL);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtProgramName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chkEnableProgram);
            this.groupBox2.Controls.Add(this.btnAddProgram);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtProgramArguments);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtProgramPath);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lstPrograms);
            this.groupBox2.Controls.Add(this.btnFindProgram);
            this.groupBox2.Controls.Add(this.btnEditProgram);
            this.groupBox2.Controls.Add(this.chkCloseProgram);
            this.groupBox2.Controls.Add(this.btnDeleteProgram);
            this.groupBox2.Controls.Add(this.chkStartProgram);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 470);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other Programs";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(233, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 117;
            this.label14.Text = "If DLL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 113;
            this.label12.Text = "Button name";
            // 
            // txtProgramName
            // 
            this.txtProgramName.Location = new System.Drawing.Point(10, 32);
            this.txtProgramName.Name = "txtProgramName";
            this.txtProgramName.Size = new System.Drawing.Size(89, 20);
            this.txtProgramName.TabIndex = 0;
            this.txtProgramName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProgramName_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "Show on Main tab";
            // 
            // chkEnableProgram
            // 
            this.chkEnableProgram.AutoSize = true;
            this.chkEnableProgram.Location = new System.Drawing.Point(9, 71);
            this.chkEnableProgram.Name = "chkEnableProgram";
            this.chkEnableProgram.Size = new System.Drawing.Size(59, 17);
            this.chkEnableProgram.TabIndex = 4;
            this.chkEnableProgram.Text = "Enable";
            this.chkEnableProgram.UseVisualStyleBackColor = true;
            // 
            // btnAddProgram
            // 
            this.btnAddProgram.Location = new System.Drawing.Point(320, 68);
            this.btnAddProgram.Name = "btnAddProgram";
            this.btnAddProgram.Size = new System.Drawing.Size(65, 23);
            this.btnAddProgram.TabIndex = 8;
            this.btnAddProgram.Text = "Add/Save";
            this.btnAddProgram.UseVisualStyleBackColor = true;
            this.btnAddProgram.Click += new System.EventHandler(this.btnAddProgram_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 109;
            this.label8.Text = "Auto start/close";
            // 
            // txtProgramArguments
            // 
            this.txtProgramArguments.Location = new System.Drawing.Point(308, 32);
            this.txtProgramArguments.Name = "txtProgramArguments";
            this.txtProgramArguments.Size = new System.Drawing.Size(77, 20);
            this.txtProgramArguments.TabIndex = 3;
            this.txtProgramArguments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProgramArguments_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(305, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Arguments";
            // 
            // txtProgramPath
            // 
            this.txtProgramPath.Location = new System.Drawing.Point(100, 32);
            this.txtProgramPath.Name = "txtProgramPath";
            this.txtProgramPath.Size = new System.Drawing.Size(174, 20);
            this.txtProgramPath.TabIndex = 1;
            this.txtProgramPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProgramPath_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 107;
            this.label6.Text = ".exe path";
            // 
            // lstPrograms
            // 
            this.lstPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPrograms.CheckBoxes = true;
            this.lstPrograms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstPrograms.FullRowSelect = true;
            this.lstPrograms.GridLines = true;
            this.lstPrograms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstPrograms.HideSelection = false;
            this.lstPrograms.Location = new System.Drawing.Point(9, 96);
            this.lstPrograms.MultiSelect = false;
            this.lstPrograms.Name = "lstPrograms";
            this.lstPrograms.Size = new System.Drawing.Size(376, 340);
            this.lstPrograms.TabIndex = 9;
            this.lstPrograms.UseCompatibleStateImageBehavior = false;
            this.lstPrograms.View = System.Windows.Forms.View.Details;
            this.lstPrograms.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstPrograms_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Enable";
            this.columnHeader1.Width = 46;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = ".exe/.dll path";
            this.columnHeader2.Width = 121;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Arguments";
            this.columnHeader3.Width = 79;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Start+Close/DLL";
            this.columnHeader4.Width = 96;
            // 
            // btnEditProgram
            // 
            this.btnEditProgram.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEditProgram.Location = new System.Drawing.Point(292, 442);
            this.btnEditProgram.Name = "btnEditProgram";
            this.btnEditProgram.Size = new System.Drawing.Size(36, 23);
            this.btnEditProgram.TabIndex = 10;
            this.btnEditProgram.Text = "Edit";
            this.btnEditProgram.UseVisualStyleBackColor = true;
            this.btnEditProgram.Click += new System.EventHandler(this.btnEditProgram_Click);
            // 
            // chkCloseProgram
            // 
            this.chkCloseProgram.AutoSize = true;
            this.chkCloseProgram.Location = new System.Drawing.Point(164, 71);
            this.chkCloseProgram.Name = "chkCloseProgram";
            this.chkCloseProgram.Size = new System.Drawing.Size(52, 17);
            this.chkCloseProgram.TabIndex = 6;
            this.chkCloseProgram.Text = "Close";
            this.chkCloseProgram.UseVisualStyleBackColor = true;
            // 
            // btnDeleteProgram
            // 
            this.btnDeleteProgram.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDeleteProgram.Location = new System.Drawing.Point(334, 442);
            this.btnDeleteProgram.Name = "btnDeleteProgram";
            this.btnDeleteProgram.Size = new System.Drawing.Size(46, 23);
            this.btnDeleteProgram.TabIndex = 11;
            this.btnDeleteProgram.Text = "Delete";
            this.btnDeleteProgram.UseVisualStyleBackColor = true;
            this.btnDeleteProgram.Click += new System.EventHandler(this.btnDeleteProgram_Click);
            // 
            // chkStartProgram
            // 
            this.chkStartProgram.AutoSize = true;
            this.chkStartProgram.Location = new System.Drawing.Point(116, 71);
            this.chkStartProgram.Name = "chkStartProgram";
            this.chkStartProgram.Size = new System.Drawing.Size(48, 17);
            this.chkStartProgram.TabIndex = 5;
            this.chkStartProgram.Text = "Start";
            this.chkStartProgram.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(953, 479);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "DLL Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FrmD2QS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(961, 533);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmD2QS";
            this.Text = "Diablo II Quick Starter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.FrmD2QS_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabD2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolTip tot;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtProgramArguments;
        private System.Windows.Forms.Button btnFindProgram;
        private System.Windows.Forms.TextBox txtProgramPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEnableProgram;
        private System.Windows.Forms.ListView lstPrograms;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkCloseProgram;
        private System.Windows.Forms.CheckBox chkStartProgram;
        private System.Windows.Forms.Button btnDeleteProgram;
        private System.Windows.Forms.Button btnEditProgram;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnAddProgram;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowPrograms;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtProgramName;
        private System.Windows.Forms.CheckBox chkDLL;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel tstInfoLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripButton tsbSound;
        private System.Windows.Forms.FlowLayoutPanel flowEachD2;
        private System.Windows.Forms.TabPage tabD2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnD2addSave;
        private System.Windows.Forms.Button btnD2edit;
        private System.Windows.Forms.Button btnD2delete;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtD2customName;
        private System.Windows.Forms.TextBox txtD2path;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnFindD2;
        private System.Windows.Forms.ListView lstDiablo2Paths;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

