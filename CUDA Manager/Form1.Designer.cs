namespace CUDA_Manager
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
            this.TBstrat = new System.Windows.Forms.TextBox();
            this.lastrat = new System.Windows.Forms.Label();
            this.chkInter = new System.Windows.Forms.CheckBox();
            this.lawrkn = new System.Windows.Forms.Label();
            this.tbWorker = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBcores = new System.Windows.Forms.ComboBox();
            this.tbConfig = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buImport = new System.Windows.Forms.Button();
            this.buAddMine = new System.Windows.Forms.Button();
            this.gbFailover = new System.Windows.Forms.GroupBox();
            this.buMup = new System.Windows.Forms.Button();
            this.buMdwn = new System.Windows.Forms.Button();
            this.buRemove = new System.Windows.Forms.Button();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stratum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retry = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.conDG = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conSelMiner = new System.Windows.Forms.ToolStripMenuItem();
            this.buLoadSet = new System.Windows.Forms.Button();
            this.lalfails = new System.Windows.Forms.Label();
            this.opFilediag = new System.Windows.Forms.OpenFileDialog();
            this.buStart = new System.Windows.Forms.Button();
            this.bg_minemgr = new System.ComponentModel.BackgroundWorker();
            this.debugbox = new System.Windows.Forms.TextBox();
            this.gbaddm = new System.Windows.Forms.GroupBox();
            this.buShowPass = new System.Windows.Forms.Button();
            this.lanick = new System.Windows.Forms.Label();
            this.tbnickname = new System.Windows.Forms.TextBox();
            this.bg_monitor = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsYay = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsHR = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsConfig = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsSaveConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDivide = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsTemps = new System.Windows.Forms.ToolStripDropDownButton();
            this.OHprotect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFanstat = new System.Windows.Forms.ToolStripMenuItem();
            this.setGPUFansToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSetFan = new System.Windows.Forms.ToolStripComboBox();
            this.tsTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.laActive = new System.Windows.Forms.Label();
            this.bg_sensors = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.viewMinerLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMaxCon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGhost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMinTray = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAdvance = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conShow = new System.Windows.Forms.ToolStripMenuItem();
            this.conSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.conShowWarnings = new System.Windows.Forms.ToolStripMenuItem();
            this.conExit = new System.Windows.Forms.ToolStripMenuItem();
            this.bg_tray = new System.ComponentModel.BackgroundWorker();
            this.saFilediag = new System.Windows.Forms.SaveFileDialog();
            this.gbFailover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.conDG.SuspendLayout();
            this.gbaddm.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBstrat
            // 
            this.TBstrat.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.TBstrat.Location = new System.Drawing.Point(88, 74);
            this.TBstrat.Name = "TBstrat";
            this.TBstrat.Size = new System.Drawing.Size(241, 20);
            this.TBstrat.TabIndex = 4;
            this.TBstrat.Text = "stratum+tcp://pool.of.choice:0000";
            this.TBstrat.Click += new System.EventHandler(this.TBstrat_Click);
            this.TBstrat.TextChanged += new System.EventHandler(this.TBstrat_TextChanged);
            this.TBstrat.Enter += new System.EventHandler(this.TBstrat_Click);
            // 
            // lastrat
            // 
            this.lastrat.AutoSize = true;
            this.lastrat.Location = new System.Drawing.Point(6, 77);
            this.lastrat.Name = "lastrat";
            this.lastrat.Size = new System.Drawing.Size(46, 13);
            this.lastrat.TabIndex = 1;
            this.lastrat.Text = "Stratum:";
            // 
            // chkInter
            // 
            this.chkInter.AutoSize = true;
            this.chkInter.Location = new System.Drawing.Point(245, 156);
            this.chkInter.Name = "chkInter";
            this.chkInter.Size = new System.Drawing.Size(76, 17);
            this.chkInter.TabIndex = 8;
            this.chkInter.Text = "Interactive";
            this.chkInter.UseVisualStyleBackColor = true;
            // 
            // lawrkn
            // 
            this.lawrkn.AutoSize = true;
            this.lawrkn.Location = new System.Drawing.Point(6, 103);
            this.lawrkn.Name = "lawrkn";
            this.lawrkn.Size = new System.Drawing.Size(76, 13);
            this.lawrkn.TabIndex = 4;
            this.lawrkn.Text = "Worker Name:";
            // 
            // tbWorker
            // 
            this.tbWorker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbWorker.Location = new System.Drawing.Point(88, 100);
            this.tbWorker.Name = "tbWorker";
            this.tbWorker.Size = new System.Drawing.Size(147, 20);
            this.tbWorker.TabIndex = 5;
            this.tbWorker.TextChanged += new System.EventHandler(this.tbWorker_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Password:";
            // 
            // TBpass
            // 
            this.TBpass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TBpass.Location = new System.Drawing.Point(88, 126);
            this.TBpass.Name = "TBpass";
            this.TBpass.Size = new System.Drawing.Size(147, 20);
            this.TBpass.TabIndex = 6;
            this.TBpass.UseSystemPasswordChar = true;
            this.TBpass.TextChanged += new System.EventHandler(this.TBpass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "CPU Assist: ";
            // 
            // CBcores
            // 
            this.CBcores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBcores.FormattingEnabled = true;
            this.CBcores.Items.AddRange(new object[] {
            "None (Default)",
            "Single-core",
            "All Cores"});
            this.CBcores.Location = new System.Drawing.Point(88, 154);
            this.CBcores.Name = "CBcores";
            this.CBcores.Size = new System.Drawing.Size(147, 21);
            this.CBcores.TabIndex = 7;
            // 
            // tbConfig
            // 
            this.tbConfig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbConfig.Location = new System.Drawing.Point(97, 221);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(232, 20);
            this.tbConfig.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Need more options, like setting your own config to skip autotune?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter them here:";
            // 
            // buImport
            // 
            this.buImport.Location = new System.Drawing.Point(6, 19);
            this.buImport.Name = "buImport";
            this.buImport.Size = new System.Drawing.Size(323, 23);
            this.buImport.TabIndex = 2;
            this.buImport.Text = "Import Miner";
            this.buImport.UseVisualStyleBackColor = true;
            this.buImport.Click += new System.EventHandler(this.buImport_Click);
            // 
            // buAddMine
            // 
            this.buAddMine.Enabled = false;
            this.buAddMine.Location = new System.Drawing.Point(6, 252);
            this.buAddMine.Name = "buAddMine";
            this.buAddMine.Size = new System.Drawing.Size(323, 23);
            this.buAddMine.TabIndex = 10;
            this.buAddMine.Text = "Add Miner to Manager";
            this.buAddMine.UseVisualStyleBackColor = true;
            this.buAddMine.Click += new System.EventHandler(this.buAddMine_Click);
            // 
            // gbFailover
            // 
            this.gbFailover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFailover.Controls.Add(this.buMup);
            this.gbFailover.Controls.Add(this.buMdwn);
            this.gbFailover.Controls.Add(this.buRemove);
            this.gbFailover.Controls.Add(this.dgView);
            this.gbFailover.Controls.Add(this.buLoadSet);
            this.gbFailover.Controls.Add(this.lalfails);
            this.gbFailover.Location = new System.Drawing.Point(12, 27);
            this.gbFailover.Name = "gbFailover";
            this.gbFailover.Size = new System.Drawing.Size(571, 252);
            this.gbFailover.TabIndex = 1;
            this.gbFailover.TabStop = false;
            this.gbFailover.Text = "Failover";
            // 
            // buMup
            // 
            this.buMup.Location = new System.Drawing.Point(6, 223);
            this.buMup.Name = "buMup";
            this.buMup.Size = new System.Drawing.Size(75, 23);
            this.buMup.TabIndex = 12;
            this.buMup.Text = "Move up";
            this.buMup.UseVisualStyleBackColor = true;
            this.buMup.Click += new System.EventHandler(this.buMup_Click);
            // 
            // buMdwn
            // 
            this.buMdwn.Location = new System.Drawing.Point(87, 223);
            this.buMdwn.Name = "buMdwn";
            this.buMdwn.Size = new System.Drawing.Size(75, 23);
            this.buMdwn.TabIndex = 13;
            this.buMdwn.Text = "Move down";
            this.buMdwn.UseVisualStyleBackColor = true;
            this.buMdwn.Click += new System.EventHandler(this.buMdwn_Click);
            // 
            // buRemove
            // 
            this.buRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buRemove.Location = new System.Drawing.Point(484, 223);
            this.buRemove.Name = "buRemove";
            this.buRemove.Size = new System.Drawing.Size(81, 23);
            this.buRemove.TabIndex = 15;
            this.buRemove.Text = "Remove Entry";
            this.buRemove.UseVisualStyleBackColor = true;
            this.buRemove.Click += new System.EventHandler(this.buRemove_Click);
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AllowUserToResizeRows = false;
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.Stratum,
            this.Worker,
            this.retry});
            this.dgView.ContextMenuStrip = this.conDG;
            this.dgView.Location = new System.Drawing.Point(6, 19);
            this.dgView.MultiSelect = false;
            this.dgView.Name = "dgView";
            this.dgView.RowHeadersVisible = false;
            this.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgView.Size = new System.Drawing.Size(559, 198);
            this.dgView.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.FillWeight = 50F;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // Stratum
            // 
            this.Stratum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Stratum.FillWeight = 95F;
            this.Stratum.HeaderText = "Stratum";
            this.Stratum.Name = "Stratum";
            this.Stratum.ReadOnly = true;
            // 
            // Worker
            // 
            this.Worker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Worker.FillWeight = 50F;
            this.Worker.HeaderText = "Worker";
            this.Worker.Name = "Worker";
            this.Worker.ReadOnly = true;
            this.Worker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Worker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // retry
            // 
            this.retry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.retry.FillWeight = 25F;
            this.retry.HeaderText = "Retry Limit";
            this.retry.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.retry.Name = "retry";
            this.retry.ToolTipText = "Set timeout limit before switching to next miner.";
            // 
            // conDG
            // 
            this.conDG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conSelMiner});
            this.conDG.Name = "conDG";
            this.conDG.Size = new System.Drawing.Size(180, 26);
            this.conDG.Opening += new System.ComponentModel.CancelEventHandler(this.conDG_Opening);
            // 
            // conSelMiner
            // 
            this.conSelMiner.Name = "conSelMiner";
            this.conSelMiner.Size = new System.Drawing.Size(179, 22);
            this.conSelMiner.Text = "Start Selected Miner";
            this.conSelMiner.Click += new System.EventHandler(this.conSelMiner_Click);
            // 
            // buLoadSet
            // 
            this.buLoadSet.Location = new System.Drawing.Point(168, 223);
            this.buLoadSet.Name = "buLoadSet";
            this.buLoadSet.Size = new System.Drawing.Size(81, 23);
            this.buLoadSet.TabIndex = 14;
            this.buLoadSet.Text = "Load Settings";
            this.buLoadSet.UseVisualStyleBackColor = true;
            this.buLoadSet.Click += new System.EventHandler(this.buLoadSet_Click);
            // 
            // lalfails
            // 
            this.lalfails.AutoSize = true;
            this.lalfails.Location = new System.Drawing.Point(255, 228);
            this.lalfails.Name = "lalfails";
            this.lalfails.Size = new System.Drawing.Size(61, 13);
            this.lalfails.TabIndex = 10;
            this.lalfails.Text = "Failovers: 0";
            this.lalfails.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // opFilediag
            // 
            this.opFilediag.Filter = "CUDA Miners|*.bat";
            // 
            // buStart
            // 
            this.buStart.Enabled = false;
            this.buStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buStart.ForeColor = System.Drawing.Color.DarkGreen;
            this.buStart.Location = new System.Drawing.Point(12, 285);
            this.buStart.Name = "buStart";
            this.buStart.Size = new System.Drawing.Size(82, 23);
            this.buStart.TabIndex = 0;
            this.buStart.Text = "Start Miner";
            this.buStart.UseVisualStyleBackColor = true;
            this.buStart.Click += new System.EventHandler(this.buStart_Click);
            // 
            // bg_minemgr
            // 
            this.bg_minemgr.WorkerReportsProgress = true;
            this.bg_minemgr.WorkerSupportsCancellation = true;
            this.bg_minemgr.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_minemgr_DoWork);
            this.bg_minemgr.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_minemgr_ProgressChanged);
            this.bg_minemgr.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_minemgr_RunWorkerCompleted);
            // 
            // debugbox
            // 
            this.debugbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.debugbox.BackColor = System.Drawing.SystemColors.ControlText;
            this.debugbox.ForeColor = System.Drawing.SystemColors.Window;
            this.debugbox.Location = new System.Drawing.Point(4, 314);
            this.debugbox.Multiline = true;
            this.debugbox.Name = "debugbox";
            this.debugbox.ReadOnly = true;
            this.debugbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugbox.Size = new System.Drawing.Size(928, 198);
            this.debugbox.TabIndex = 2;
            // 
            // gbaddm
            // 
            this.gbaddm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbaddm.Controls.Add(this.buShowPass);
            this.gbaddm.Controls.Add(this.lanick);
            this.gbaddm.Controls.Add(this.tbnickname);
            this.gbaddm.Controls.Add(this.buAddMine);
            this.gbaddm.Controls.Add(this.buImport);
            this.gbaddm.Controls.Add(this.label3);
            this.gbaddm.Controls.Add(this.tbConfig);
            this.gbaddm.Controls.Add(this.CBcores);
            this.gbaddm.Controls.Add(this.label2);
            this.gbaddm.Controls.Add(this.label1);
            this.gbaddm.Controls.Add(this.TBpass);
            this.gbaddm.Controls.Add(this.lawrkn);
            this.gbaddm.Controls.Add(this.tbWorker);
            this.gbaddm.Controls.Add(this.chkInter);
            this.gbaddm.Controls.Add(this.lastrat);
            this.gbaddm.Controls.Add(this.TBstrat);
            this.gbaddm.Controls.Add(this.label4);
            this.gbaddm.Location = new System.Drawing.Point(589, 27);
            this.gbaddm.Name = "gbaddm";
            this.gbaddm.Size = new System.Drawing.Size(335, 281);
            this.gbaddm.TabIndex = 0;
            this.gbaddm.TabStop = false;
            this.gbaddm.Text = "Add Miner";
            // 
            // buShowPass
            // 
            this.buShowPass.Image = ((System.Drawing.Image)(resources.GetObject("buShowPass.Image")));
            this.buShowPass.Location = new System.Drawing.Point(241, 126);
            this.buShowPass.Name = "buShowPass";
            this.buShowPass.Size = new System.Drawing.Size(22, 20);
            this.buShowPass.TabIndex = 17;
            this.buShowPass.TabStop = false;
            this.buShowPass.UseVisualStyleBackColor = true;
            this.buShowPass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buShowPass_MouseDown);
            this.buShowPass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buShowPass_MouseUp);
            // 
            // lanick
            // 
            this.lanick.AutoSize = true;
            this.lanick.Location = new System.Drawing.Point(6, 51);
            this.lanick.Name = "lanick";
            this.lanick.Size = new System.Drawing.Size(58, 13);
            this.lanick.TabIndex = 16;
            this.lanick.Text = "Nickname:";
            // 
            // tbnickname
            // 
            this.tbnickname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbnickname.Location = new System.Drawing.Point(88, 48);
            this.tbnickname.MaxLength = 40;
            this.tbnickname.Name = "tbnickname";
            this.tbnickname.Size = new System.Drawing.Size(147, 20);
            this.tbnickname.TabIndex = 3;
            this.tbnickname.TextChanged += new System.EventHandler(this.tbnickname_TextChanged);
            this.tbnickname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbnickname_KeyPress);
            // 
            // bg_monitor
            // 
            this.bg_monitor.WorkerReportsProgress = true;
            this.bg_monitor.WorkerSupportsCancellation = true;
            this.bg_monitor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_monitor_DoWork);
            this.bg_monitor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_monitor_ProgressChanged);
            this.bg_monitor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_all_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus,
            this.tsYay,
            this.tsHR,
            this.tsConfig,
            this.tsDivide,
            this.tsTemps,
            this.tsTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(936, 24);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(90, 19);
            this.tsStatus.Text = "Status: Ready...";
            // 
            // tsYay
            // 
            this.tsYay.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsYay.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsYay.Name = "tsYay";
            this.tsYay.Size = new System.Drawing.Size(73, 19);
            this.tsYay.Text = "Yays: 0/min";
            this.tsYay.ToolTipText = "Average amount of accepted work per minute.";
            // 
            // tsHR
            // 
            this.tsHR.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsHR.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsHR.Name = "tsHR";
            this.tsHR.Size = new System.Drawing.Size(120, 19);
            this.tsHR.Text = "Avg. Hashrate: 0kh/s";
            this.tsHR.ToolTipText = "Average hashrate for the mining session.";
            // 
            // tsConfig
            // 
            this.tsConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSaveConfig});
            this.tsConfig.Name = "tsConfig";
            this.tsConfig.Size = new System.Drawing.Size(84, 22);
            this.tsConfig.Text = "Config: N/A";
            this.tsConfig.ToolTipText = "GPU configuration for the active miner.";
            this.tsConfig.TextChanged += new System.EventHandler(this.tsConfig_TextChanged);
            // 
            // tsSaveConfig
            // 
            this.tsSaveConfig.Enabled = false;
            this.tsSaveConfig.Name = "tsSaveConfig";
            this.tsSaveConfig.Size = new System.Drawing.Size(137, 22);
            this.tsSaveConfig.Text = "Save Config";
            this.tsSaveConfig.Click += new System.EventHandler(this.tsSaveConfig_Click);
            // 
            // tsDivide
            // 
            this.tsDivide.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsDivide.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsDivide.Name = "tsDivide";
            this.tsDivide.Size = new System.Drawing.Size(4, 19);
            // 
            // tsTemps
            // 
            this.tsTemps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OHprotect,
            this.toolStripSeparator1,
            this.tsFanstat,
            this.setGPUFansToToolStripMenuItem});
            this.tsTemps.Name = "tsTemps";
            this.tsTemps.Size = new System.Drawing.Size(71, 22);
            this.tsTemps.Text = "GPU: N/A";
            this.tsTemps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OHprotect
            // 
            this.OHprotect.CheckOnClick = true;
            this.OHprotect.Name = "OHprotect";
            this.OHprotect.Size = new System.Drawing.Size(172, 22);
            this.OHprotect.Text = "Protective Cooling";
            this.OHprotect.ToolTipText = "When enabled, CUDA Manager will increase your fan speed if your GPU overheats.";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // tsFanstat
            // 
            this.tsFanstat.Name = "tsFanstat";
            this.tsFanstat.Size = new System.Drawing.Size(172, 22);
            this.tsFanstat.Text = "Fans: N/A";
            // 
            // setGPUFansToToolStripMenuItem
            // 
            this.setGPUFansToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSetFan});
            this.setGPUFansToToolStripMenuItem.Name = "setGPUFansToToolStripMenuItem";
            this.setGPUFansToToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.setGPUFansToToolStripMenuItem.Text = "Set Fan Speed:";
            // 
            // tsSetFan
            // 
            this.tsSetFan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsSetFan.DropDownWidth = 60;
            this.tsSetFan.Items.AddRange(new object[] {
            "[Default]",
            "Auto",
            "5%",
            "10%",
            "15%",
            "20%",
            "25%",
            "30%",
            "35%",
            "40%",
            "45%",
            "50%",
            "55%",
            "60%",
            "65%",
            "70%",
            "75%",
            "80%",
            "85%",
            "90%",
            "95%",
            "100%"});
            this.tsSetFan.MaxDropDownItems = 10;
            this.tsSetFan.Name = "tsSetFan";
            this.tsSetFan.Size = new System.Drawing.Size(75, 23);
            this.tsSetFan.SelectedIndex = 0;
            this.tsSetFan.SelectedIndexChanged += new System.EventHandler(this.tsSetFan_SelectedIndexChanged);
            // 
            // tsTime
            // 
            this.tsTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsTime.Name = "tsTime";
            this.tsTime.Size = new System.Drawing.Size(120, 19);
            this.tsTime.Text = "Time Elapsed: 0 min.";
            // 
            // laActive
            // 
            this.laActive.AutoSize = true;
            this.laActive.Location = new System.Drawing.Point(100, 290);
            this.laActive.Name = "laActive";
            this.laActive.Size = new System.Drawing.Size(92, 13);
            this.laActive.TabIndex = 8;
            this.laActive.Text = "Active Miner: N/A";
            // 
            // bg_sensors
            // 
            this.bg_sensors.WorkerReportsProgress = true;
            this.bg_sensors.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_sensors_DoWork);
            this.bg_sensors.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_sensors_ProgressChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStart,
            this.toolStripSeparator3,
            this.viewMinerLogToolStripMenuItem,
            this.tsSaveLog,
            this.toolStripSeparator2,
            this.tsExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsStart
            // 
            this.tsStart.Enabled = false;
            this.tsStart.Name = "tsStart";
            this.tsStart.Size = new System.Drawing.Size(156, 22);
            this.tsStart.Text = "Start Miner";
            this.tsStart.Click += new System.EventHandler(this.buStart_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(153, 6);
            // 
            // viewMinerLogToolStripMenuItem
            // 
            this.viewMinerLogToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsClearLog});
            this.viewMinerLogToolStripMenuItem.Name = "viewMinerLogToolStripMenuItem";
            this.viewMinerLogToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.viewMinerLogToolStripMenuItem.Text = "View Miner Log";
            this.viewMinerLogToolStripMenuItem.Click += new System.EventHandler(this.viewMinerLogToolStripMenuItem_Click);
            // 
            // tsClearLog
            // 
            this.tsClearLog.Name = "tsClearLog";
            this.tsClearLog.Size = new System.Drawing.Size(158, 22);
            this.tsClearLog.Text = "Clear Miner Log";
            this.tsClearLog.Click += new System.EventHandler(this.tsClearLog_Click);
            // 
            // tsSaveLog
            // 
            this.tsSaveLog.Name = "tsSaveLog";
            this.tsSaveLog.Size = new System.Drawing.Size(156, 22);
            this.tsSaveLog.Text = "Save Miner Log";
            this.tsSaveLog.Click += new System.EventHandler(this.tsSaveLog_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(156, 22);
            this.tsExit.Text = "Exit";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOnTop,
            this.tsMaxCon,
            this.toolMinTray,
            this.toolStripSeparator4,
            this.tsAdvance});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // toolOnTop
            // 
            this.toolOnTop.CheckOnClick = true;
            this.toolOnTop.Name = "toolOnTop";
            this.toolOnTop.Size = new System.Drawing.Size(181, 22);
            this.toolOnTop.Text = "Always on top";
            this.toolOnTop.CheckStateChanged += new System.EventHandler(this.toolOnTop_CheckStateChanged);
            // 
            // tsMaxCon
            // 
            this.tsMaxCon.CheckOnClick = true;
            this.tsMaxCon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGhost});
            this.tsMaxCon.Name = "tsMaxCon";
            this.tsMaxCon.Size = new System.Drawing.Size(181, 22);
            this.tsMaxCon.Text = "Maximize Console";
            this.tsMaxCon.Click += new System.EventHandler(this.maximizeConsoleToolStripMenuItem_Click);
            // 
            // tsGhost
            // 
            this.tsGhost.CheckOnClick = true;
            this.tsGhost.Enabled = false;
            this.tsGhost.Name = "tsGhost";
            this.tsGhost.Size = new System.Drawing.Size(122, 22);
            this.tsGhost.Text = "Ghosting";
            this.tsGhost.CheckStateChanged += new System.EventHandler(this.tsGhost_CheckStateChanged);
            // 
            // toolMinTray
            // 
            this.toolMinTray.CheckOnClick = true;
            this.toolMinTray.Name = "toolMinTray";
            this.toolMinTray.Size = new System.Drawing.Size(181, 22);
            this.toolMinTray.Text = "Minimize to Tray";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // tsAdvance
            // 
            this.tsAdvance.Name = "tsAdvance";
            this.tsAdvance.Size = new System.Drawing.Size(181, 22);
            this.tsAdvance.Text = "Advanced Options...";
            this.tsAdvance.Click += new System.EventHandler(this.tsAdvance_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAbout,
            this.tsGuide,
            this.donateToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tsAbout
            // 
            this.tsAbout.Name = "tsAbout";
            this.tsAbout.Size = new System.Drawing.Size(201, 22);
            this.tsAbout.Text = "About CUDA Manager...";
            this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
            // 
            // tsGuide
            // 
            this.tsGuide.Name = "tsGuide";
            this.tsGuide.Size = new System.Drawing.Size(201, 22);
            this.tsGuide.Text = "Getting Started...";
            this.tsGuide.Click += new System.EventHandler(this.tsGuide_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.donateToolStripMenuItem.Text = "Donate...";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "CUDA Manager";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conShow,
            this.conSep1,
            this.conShowWarnings,
            this.conExit});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(178, 76);
            this.trayMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // conShow
            // 
            this.conShow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conShow.Name = "conShow";
            this.conShow.Size = new System.Drawing.Size(177, 22);
            this.conShow.Text = "Show";
            // 
            // conSep1
            // 
            this.conSep1.Name = "conSep1";
            this.conSep1.Size = new System.Drawing.Size(174, 6);
            // 
            // conShowWarnings
            // 
            this.conShowWarnings.CheckOnClick = true;
            this.conShowWarnings.Name = "conShowWarnings";
            this.conShowWarnings.Size = new System.Drawing.Size(177, 22);
            this.conShowWarnings.Text = "Show Warnings";
            // 
            // conExit
            // 
            this.conExit.Name = "conExit";
            this.conExit.Size = new System.Drawing.Size(177, 22);
            this.conExit.Text = "Exit CUDA Manager";
            this.conExit.Click += new System.EventHandler(this.conExit_Click);
            // 
            // bg_tray
            // 
            this.bg_tray.WorkerReportsProgress = true;
            this.bg_tray.WorkerSupportsCancellation = true;
            this.bg_tray.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_tray_DoWork);
            this.bg_tray.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_tray_ProgressChanged);
            this.bg_tray.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_all_RunWorkerCompleted);
            // 
            // saFilediag
            // 
            this.saFilediag.Filter = "Comma Delimited|*.csv";
            this.saFilediag.FileOk += new System.ComponentModel.CancelEventHandler(this.saFilediag_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 540);
            this.Controls.Add(this.debugbox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buStart);
            this.Controls.Add(this.gbFailover);
            this.Controls.Add(this.gbaddm);
            this.Controls.Add(this.laActive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 85);
            this.Name = "Form1";
            this.Text = "CUDA Manager";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.gbFailover.ResumeLayout(false);
            this.gbFailover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.conDG.ResumeLayout(false);
            this.gbaddm.ResumeLayout(false);
            this.gbaddm.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lastrat;
        private System.Windows.Forms.TextBox TBstrat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBpass;
        private System.Windows.Forms.Label lawrkn;
        private System.Windows.Forms.TextBox tbWorker;
        private System.Windows.Forms.CheckBox chkInter;
        private System.Windows.Forms.ComboBox CBcores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbConfig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buAddMine;
        private System.Windows.Forms.Button buImport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbFailover;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.OpenFileDialog opFilediag;
        private System.Windows.Forms.Button buStart;
        private System.ComponentModel.BackgroundWorker bg_minemgr;
        private System.Windows.Forms.TextBox debugbox;
        private System.Windows.Forms.Button buMup;
        private System.Windows.Forms.Button buMdwn;
        private System.Windows.Forms.Button buRemove;
        private System.Windows.Forms.GroupBox gbaddm;
        private System.ComponentModel.BackgroundWorker bg_monitor;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsYay;
        private System.Windows.Forms.ToolStripStatusLabel tsHR;
        private System.Windows.Forms.ToolStripStatusLabel tsTime;
        private System.Windows.Forms.Label lanick;
        private System.Windows.Forms.TextBox tbnickname;
        private System.Windows.Forms.Label laActive;
        private System.Windows.Forms.ToolStripDropDownButton tsConfig;
        private System.Windows.Forms.ToolStripMenuItem tsSaveConfig;
        private System.ComponentModel.BackgroundWorker bg_sensors;
        private System.Windows.Forms.ToolStripStatusLabel tsDivide;
        private System.Windows.Forms.ToolStripDropDownButton tsTemps;
        private System.Windows.Forms.ToolStripMenuItem setGPUFansToToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tsSetFan;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsSaveLog;
        private System.Windows.Forms.ToolStripMenuItem OHprotect;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsAbout;
        private System.Windows.Forms.ToolStripMenuItem viewMinerLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ToolStripMenuItem tsFanstat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolMinTray;
        private System.Windows.Forms.ToolStripMenuItem tsGuide;
        private System.Windows.Forms.ToolStripMenuItem tsMaxCon;
        private System.Windows.Forms.ToolStripMenuItem toolOnTop;
        private System.Windows.Forms.Button buLoadSet;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem conShow;
        private System.Windows.Forms.ToolStripSeparator conSep1;
        private System.Windows.Forms.ToolStripMenuItem conShowWarnings;
        private System.Windows.Forms.ToolStripMenuItem conExit;
        private System.ComponentModel.BackgroundWorker bg_tray;
        private System.Windows.Forms.Label lalfails;
        private System.Windows.Forms.ToolStripMenuItem tsGhost;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem tsStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stratum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worker;
        private System.Windows.Forms.DataGridViewComboBoxColumn retry;
        private System.Windows.Forms.Button buShowPass;
        private System.Windows.Forms.ContextMenuStrip conDG;
        private System.Windows.Forms.ToolStripMenuItem conSelMiner;
        private System.Windows.Forms.SaveFileDialog saFilediag;
        private System.Windows.Forms.ToolStripMenuItem tsClearLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsAdvance;
    }
}

