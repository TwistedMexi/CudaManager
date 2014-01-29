namespace CUDA_Manager
{
    partial class Guide
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
            this.lbTopics = new System.Windows.Forms.ListBox();
            this.rtInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbTopics
            // 
            this.lbTopics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTopics.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTopics.FormattingEnabled = true;
            this.lbTopics.ItemHeight = 16;
            this.lbTopics.Items.AddRange(new object[] {
            "Active Miner",
            "Adding Miners",
            "Always on Top",
            "Failover",
            "Fan Controller",
            "Ghosting",
            "GPU Temperature",
            "Hashrate",
            "Maximize Console",
            "Miner Log",
            "Minimize to Tray",
            "Output Console",
            "Protective Cooling",
            "Save Config",
            "Switching Miners",
            "Warnings",
            "Yays"});
            this.lbTopics.Location = new System.Drawing.Point(13, 13);
            this.lbTopics.Name = "lbTopics";
            this.lbTopics.Size = new System.Drawing.Size(180, 292);
            this.lbTopics.TabIndex = 0;
            this.lbTopics.SelectedIndexChanged += new System.EventHandler(this.lbTopics_SelectedIndexChanged);
            // 
            // rtInfo
            // 
            this.rtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rtInfo.Location = new System.Drawing.Point(199, 0);
            this.rtInfo.Name = "rtInfo";
            this.rtInfo.ReadOnly = true;
            this.rtInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtInfo.Size = new System.Drawing.Size(297, 319);
            this.rtInfo.TabIndex = 2;
            this.rtInfo.Text = "\nGetting Started:\nPlease select a topic from the list on the left to view a brief" +
                " summary.\n\nIf additional help is needed, please visit:\nhttp://reddit.com/r/CUDAM" +
                "anager";
            this.rtInfo.Resize += new System.EventHandler(this.rtInfo_Resize);
            // 
            // Guide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 318);
            this.Controls.Add(this.rtInfo);
            this.Controls.Add(this.lbTopics);
            this.MinimumSize = new System.Drawing.Size(512, 357);
            this.Name = "Guide";
            this.Text = "CUDA Manager - Quick-start Guide";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTopics;
        private System.Windows.Forms.RichTextBox rtInfo;
    }
}