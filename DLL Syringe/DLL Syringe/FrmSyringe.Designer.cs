namespace DLL_Syringe
{
    partial class FrmSyringe
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tslTooltipMain = new System.Windows.Forms.ToolStripLabel();
            this.lstDLLlistMain = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstProcessListMain = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDLLinjectDLL = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbProcessAutoRefresh = new System.Windows.Forms.ComboBox();
            this.btnProcessRefreshList = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lstDLLlistSettings = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDLLsave = new System.Windows.Forms.Button();
            this.btnFindDLL = new System.Windows.Forms.Button();
            this.txtDLLpath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDLLdescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDLLname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStripSettings = new System.Windows.Forms.ToolStrip();
            this.tslTooltipSettings = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.btnProcessSave = new System.Windows.Forms.Button();
            this.txtProcessWinTitle = new System.Windows.Forms.TextBox();
            this.btnProcessFullList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstProcessListSettings = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timerProcessList = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStripSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 316);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(660, 290);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.toolStripMain, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lstDLLlistMain, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lstProcessListMain, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(654, 284);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // toolStripMain
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.toolStripMain, 2);
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslTooltipMain});
            this.toolStripMain.Location = new System.Drawing.Point(0, 259);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(654, 25);
            this.toolStripMain.TabIndex = 9;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // tslTooltipMain
            // 
            this.tslTooltipMain.Name = "tslTooltipMain";
            this.tslTooltipMain.Size = new System.Drawing.Size(45, 22);
            this.tslTooltipMain.Text = "Tooltip";
            // 
            // lstDLLlistMain
            // 
            this.lstDLLlistMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstDLLlistMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDLLlistMain.FullRowSelect = true;
            this.lstDLLlistMain.GridLines = true;
            this.lstDLLlistMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstDLLlistMain.HideSelection = false;
            this.lstDLLlistMain.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lstDLLlistMain.LabelEdit = true;
            this.lstDLLlistMain.Location = new System.Drawing.Point(3, 18);
            this.lstDLLlistMain.Name = "lstDLLlistMain";
            this.lstDLLlistMain.Size = new System.Drawing.Size(321, 204);
            this.lstDLLlistMain.TabIndex = 0;
            this.lstDLLlistMain.UseCompatibleStateImageBehavior = false;
            this.lstDLLlistMain.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 146;
            // 
            // lstProcessListMain
            // 
            this.lstProcessListMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.lstProcessListMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstProcessListMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProcessListMain.FullRowSelect = true;
            this.lstProcessListMain.GridLines = true;
            this.lstProcessListMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstProcessListMain.HideSelection = false;
            this.lstProcessListMain.LabelEdit = true;
            this.lstProcessListMain.Location = new System.Drawing.Point(330, 18);
            this.lstProcessListMain.Name = "lstProcessListMain";
            this.lstProcessListMain.Size = new System.Drawing.Size(321, 204);
            this.lstProcessListMain.TabIndex = 2;
            this.lstProcessListMain.UseCompatibleStateImageBehavior = false;
            this.lstProcessListMain.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Window Title";
            this.columnHeader7.Width = 111;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Process Name";
            this.columnHeader8.Width = 146;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "DLL List";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Process List";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDLLinjectDLL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 28);
            this.panel1.TabIndex = 6;
            // 
            // btnDLLinjectDLL
            // 
            this.btnDLLinjectDLL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDLLinjectDLL.Location = new System.Drawing.Point(243, 3);
            this.btnDLLinjectDLL.Name = "btnDLLinjectDLL";
            this.btnDLLinjectDLL.Size = new System.Drawing.Size(75, 23);
            this.btnDLLinjectDLL.TabIndex = 5;
            this.btnDLLinjectDLL.Text = "Inject DLL";
            this.btnDLLinjectDLL.UseVisualStyleBackColor = true;
            this.btnDLLinjectDLL.Click += new System.EventHandler(this.btnDLLinjectDLL_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cmbProcessAutoRefresh);
            this.panel2.Controls.Add(this.btnProcessRefreshList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(330, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 28);
            this.panel2.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(191, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Auto Refrsh";
            // 
            // cmbProcessAutoRefresh
            // 
            this.cmbProcessAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProcessAutoRefresh.FormattingEnabled = true;
            this.cmbProcessAutoRefresh.Items.AddRange(new object[] {
            "OFF",
            "1 sec",
            "2 sec",
            "3 sec",
            "4 sec",
            "5 sec",
            "6 sec",
            "7 sec",
            "8 sec",
            "9 sec",
            "10 sec"});
            this.cmbProcessAutoRefresh.Location = new System.Drawing.Point(260, 5);
            this.cmbProcessAutoRefresh.Name = "cmbProcessAutoRefresh";
            this.cmbProcessAutoRefresh.Size = new System.Drawing.Size(56, 21);
            this.cmbProcessAutoRefresh.TabIndex = 7;
            this.cmbProcessAutoRefresh.Text = "OFF";
            this.cmbProcessAutoRefresh.SelectedIndexChanged += new System.EventHandler(this.cmbProcessAutoRefresh_SelectedIndexChanged);
            // 
            // btnProcessRefreshList
            // 
            this.btnProcessRefreshList.Location = new System.Drawing.Point(3, 3);
            this.btnProcessRefreshList.Name = "btnProcessRefreshList";
            this.btnProcessRefreshList.Size = new System.Drawing.Size(75, 23);
            this.btnProcessRefreshList.TabIndex = 6;
            this.btnProcessRefreshList.Text = "Refresh List";
            this.btnProcessRefreshList.UseVisualStyleBackColor = true;
            this.btnProcessRefreshList.Click += new System.EventHandler(this.btnProcessRefreshList_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(660, 290);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.15596F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.84404F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstDLLlistSettings, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStripSettings, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnProcessFullList, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstProcessListSettings, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(600, 200);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 284);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "DLL list";
            // 
            // lstDLLlistSettings
            // 
            this.lstDLLlistSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lstDLLlistSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDLLlistSettings.FullRowSelect = true;
            this.lstDLLlistSettings.GridLines = true;
            this.lstDLLlistSettings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstDLLlistSettings.HideSelection = false;
            this.lstDLLlistSettings.Location = new System.Drawing.Point(276, 18);
            this.lstDLLlistSettings.MinimumSize = new System.Drawing.Size(270, 200);
            this.lstDLLlistSettings.Name = "lstDLLlistSettings";
            this.tableLayoutPanel1.SetRowSpan(this.lstDLLlistSettings, 2);
            this.lstDLLlistSettings.Size = new System.Drawing.Size(270, 234);
            this.lstDLLlistSettings.TabIndex = 4;
            this.lstDLLlistSettings.UseCompatibleStateImageBehavior = false;
            this.lstDLLlistSettings.View = System.Windows.Forms.View.Details;
            this.lstDLLlistSettings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstDLLlistSettings_KeyDown);
            this.lstDLLlistSettings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstDLLlistSettings_MouseDoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 111;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Description";
            this.columnHeader6.Width = 147;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(551, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Add DLL";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDLLsave);
            this.panel3.Controls.Add(this.btnFindDLL);
            this.panel3.Controls.Add(this.txtDLLpath);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtDLLdescription);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtDLLname);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(551, 18);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(100, 234);
            this.panel3.TabIndex = 13;
            // 
            // btnDLLsave
            // 
            this.btnDLLsave.Location = new System.Drawing.Point(6, 164);
            this.btnDLLsave.Name = "btnDLLsave";
            this.btnDLLsave.Size = new System.Drawing.Size(75, 23);
            this.btnDLLsave.TabIndex = 0;
            this.btnDLLsave.Text = "Save to list";
            this.btnDLLsave.UseVisualStyleBackColor = true;
            this.btnDLLsave.Click += new System.EventHandler(this.btnDLLsave_Click);
            // 
            // btnFindDLL
            // 
            this.btnFindDLL.Location = new System.Drawing.Point(6, 85);
            this.btnFindDLL.Name = "btnFindDLL";
            this.btnFindDLL.Size = new System.Drawing.Size(75, 23);
            this.btnFindDLL.TabIndex = 6;
            this.btnFindDLL.Text = "Find DLL";
            this.btnFindDLL.UseVisualStyleBackColor = true;
            this.btnFindDLL.Click += new System.EventHandler(this.btnFindDLL_Click);
            // 
            // txtDLLpath
            // 
            this.txtDLLpath.Location = new System.Drawing.Point(3, 127);
            this.txtDLLpath.Name = "txtDLLpath";
            this.txtDLLpath.Size = new System.Drawing.Size(92, 20);
            this.txtDLLpath.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "DLL path";
            // 
            // txtDLLdescription
            // 
            this.txtDLLdescription.Location = new System.Drawing.Point(3, 59);
            this.txtDLLdescription.Name = "txtDLLdescription";
            this.txtDLLdescription.Size = new System.Drawing.Size(92, 20);
            this.txtDLLdescription.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Description";
            // 
            // txtDLLname
            // 
            this.txtDLLname.Location = new System.Drawing.Point(3, 20);
            this.txtDLLname.Name = "txtDLLname";
            this.txtDLLname.Size = new System.Drawing.Size(92, 20);
            this.txtDLLname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // toolStripSettings
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStripSettings, 3);
            this.toolStripSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripSettings.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslTooltipSettings});
            this.toolStripSettings.Location = new System.Drawing.Point(110, 259);
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(544, 25);
            this.toolStripSettings.TabIndex = 16;
            this.toolStripSettings.Text = "toolStrip1";
            // 
            // tslTooltipSettings
            // 
            this.tslTooltipSettings.Name = "tslTooltipSettings";
            this.tslTooltipSettings.Size = new System.Drawing.Size(45, 22);
            this.tslTooltipSettings.Text = "Tooltip";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.Controls.Add(this.txtProcessName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnProcessSave, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtProcessWinTitle, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 224);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(267, 28);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProcessName.Location = new System.Drawing.Point(110, 3);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(101, 20);
            this.txtProcessName.TabIndex = 2;
            this.txtProcessName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcessName_KeyDown);
            // 
            // btnProcessSave
            // 
            this.btnProcessSave.Location = new System.Drawing.Point(217, 3);
            this.btnProcessSave.Name = "btnProcessSave";
            this.btnProcessSave.Size = new System.Drawing.Size(43, 22);
            this.btnProcessSave.TabIndex = 0;
            this.btnProcessSave.Text = "Save";
            this.btnProcessSave.UseVisualStyleBackColor = true;
            this.btnProcessSave.Click += new System.EventHandler(this.btnProcessSave_Click);
            // 
            // txtProcessWinTitle
            // 
            this.txtProcessWinTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProcessWinTitle.Location = new System.Drawing.Point(3, 3);
            this.txtProcessWinTitle.Name = "txtProcessWinTitle";
            this.txtProcessWinTitle.Size = new System.Drawing.Size(101, 20);
            this.txtProcessWinTitle.TabIndex = 1;
            this.txtProcessWinTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcessWinTitle_KeyDown);
            // 
            // btnProcessFullList
            // 
            this.btnProcessFullList.Location = new System.Drawing.Point(3, 258);
            this.btnProcessFullList.Name = "btnProcessFullList";
            this.btnProcessFullList.Size = new System.Drawing.Size(100, 23);
            this.btnProcessFullList.TabIndex = 17;
            this.btnProcessFullList.Text = "Full Process List";
            this.btnProcessFullList.UseVisualStyleBackColor = true;
            this.btnProcessFullList.Click += new System.EventHandler(this.btnProcessFullList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Things to look for";
            // 
            // lstProcessListSettings
            // 
            this.lstProcessListSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.tableLayoutPanel1.SetColumnSpan(this.lstProcessListSettings, 2);
            this.lstProcessListSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstProcessListSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProcessListSettings.FullRowSelect = true;
            this.lstProcessListSettings.GridLines = true;
            this.lstProcessListSettings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstProcessListSettings.HideSelection = false;
            this.lstProcessListSettings.LabelEdit = true;
            this.lstProcessListSettings.Location = new System.Drawing.Point(3, 18);
            this.lstProcessListSettings.MinimumSize = new System.Drawing.Size(270, 200);
            this.lstProcessListSettings.Name = "lstProcessListSettings";
            this.lstProcessListSettings.Size = new System.Drawing.Size(270, 200);
            this.lstProcessListSettings.TabIndex = 1;
            this.lstProcessListSettings.UseCompatibleStateImageBehavior = false;
            this.lstProcessListSettings.View = System.Windows.Forms.View.Details;
            this.lstProcessListSettings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstProcessListSettings_KeyDown);
            this.lstProcessListSettings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstProcessListSettings_MouseDoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Window Title";
            this.columnHeader3.Width = 111;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Process Name";
            this.columnHeader4.Width = 146;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "dll";
            this.openFileDialog.Filter = "DLL(*.dll)|*.dll";
            this.openFileDialog.Title = "Find DLL\'s";
            // 
            // timerProcessList
            // 
            this.timerProcessList.Interval = 1000;
            this.timerProcessList.Tick += new System.EventHandler(this.timerProcessList_Tick);
            // 
            // FrmSyringe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 316);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(684, 354);
            this.Name = "FrmSyringe";
            this.ShowIcon = false;
            this.Text = "DLL Syringe";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStripSettings.ResumeLayout(false);
            this.toolStripSettings.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lstDLLlistMain;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lstProcessListSettings;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstDLLlistSettings;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnFindDLL;
        private System.Windows.Forms.TextBox txtDLLpath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDLLdescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDLLname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDLLsave;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.TextBox txtProcessWinTitle;
        private System.Windows.Forms.Button btnProcessSave;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripLabel tslTooltipMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListView lstProcessListMain;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDLLinjectDLL;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbProcessAutoRefresh;
        private System.Windows.Forms.Button btnProcessRefreshList;
        private System.Windows.Forms.ToolStrip toolStripSettings;
        private System.Windows.Forms.ToolStripLabel tslTooltipSettings;
        private System.Windows.Forms.Timer timerProcessList;
        private System.Windows.Forms.Button btnProcessFullList;
    }
}

