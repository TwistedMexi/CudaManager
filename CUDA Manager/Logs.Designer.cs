namespace CUDA_Manager
{
    partial class Logs
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
            this.dgLogs = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hashr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yaysmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totyays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timespent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gputemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fanspeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLogs
            // 
            this.dgLogs.AllowUserToAddRows = false;
            this.dgLogs.AllowUserToDeleteRows = false;
            this.dgLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Event,
            this.hashr,
            this.yaysmin,
            this.totyays,
            this.timespent,
            this.gputemp,
            this.fanspeed});
            this.dgLogs.Location = new System.Drawing.Point(12, 12);
            this.dgLogs.Name = "dgLogs";
            this.dgLogs.ReadOnly = true;
            this.dgLogs.RowHeadersVisible = false;
            this.dgLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLogs.Size = new System.Drawing.Size(837, 327);
            this.dgLogs.TabIndex = 0;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 100;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Event
            // 
            this.Event.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Event.HeaderText = "Event";
            this.Event.MinimumWidth = 200;
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            this.Event.Width = 200;
            // 
            // hashr
            // 
            this.hashr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.hashr.HeaderText = "Average Hashrate";
            this.hashr.Name = "hashr";
            this.hashr.ReadOnly = true;
            this.hashr.Width = 108;
            // 
            // yaysmin
            // 
            this.yaysmin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.yaysmin.HeaderText = "Average Yays";
            this.yaysmin.Name = "yaysmin";
            this.yaysmin.ReadOnly = true;
            this.yaysmin.Width = 90;
            // 
            // totyays
            // 
            this.totyays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totyays.HeaderText = "Total Yays";
            this.totyays.Name = "totyays";
            this.totyays.ReadOnly = true;
            this.totyays.Width = 76;
            // 
            // timespent
            // 
            this.timespent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.timespent.HeaderText = "Mining Time";
            this.timespent.Name = "timespent";
            this.timespent.ReadOnly = true;
            this.timespent.Width = 82;
            // 
            // gputemp
            // 
            this.gputemp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gputemp.HeaderText = "GPU Temp.";
            this.gputemp.Name = "gputemp";
            this.gputemp.ReadOnly = true;
            this.gputemp.Width = 81;
            // 
            // fanspeed
            // 
            this.fanspeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fanspeed.HeaderText = "Fan Speed";
            this.fanspeed.Name = "fanspeed";
            this.fanspeed.ReadOnly = true;
            this.fanspeed.Width = 78;
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 351);
            this.Controls.Add(this.dgLogs);
            this.MaximumSize = new System.Drawing.Size(877, 3000);
            this.Name = "Logs";
            this.Text = "Miner Log";
            this.Load += new System.EventHandler(this.Logs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn hashr;
        private System.Windows.Forms.DataGridViewTextBoxColumn yaysmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn totyays;
        private System.Windows.Forms.DataGridViewTextBoxColumn timespent;
        private System.Windows.Forms.DataGridViewTextBoxColumn gputemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn fanspeed;
    }
}