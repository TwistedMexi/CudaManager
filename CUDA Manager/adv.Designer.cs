namespace CUDA_Manager
{
    partial class adv
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numAct = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numShut = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.buOkay = new System.Windows.Forms.Button();
            this.buReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numIdle = new System.Windows.Forms.NumericUpDown();
            this.cbIdleMine = new System.Windows.Forms.ComboBox();
            this.chkIdle = new System.Windows.Forms.CheckBox();
            this.chkHaltRet = new System.Windows.Forms.CheckBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShut)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIdle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numAct);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numShut);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cooler Overrides";
            // 
            // numAct
            // 
            this.numAct.Location = new System.Drawing.Point(112, 24);
            this.numAct.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numAct.Name = "numAct";
            this.numAct.Size = new System.Drawing.Size(43, 20);
            this.numAct.TabIndex = 4;
            this.numAct.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "°C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Activate Protection:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Miner Shutdown:";
            // 
            // numShut
            // 
            this.numShut.Location = new System.Drawing.Point(112, 54);
            this.numShut.Name = "numShut";
            this.numShut.Size = new System.Drawing.Size(43, 20);
            this.numShut.TabIndex = 0;
            this.numShut.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "°C";
            // 
            // buOkay
            // 
            this.buOkay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buOkay.Location = new System.Drawing.Point(207, 231);
            this.buOkay.Name = "buOkay";
            this.buOkay.Size = new System.Drawing.Size(93, 23);
            this.buOkay.TabIndex = 2;
            this.buOkay.Text = "Apply";
            this.buOkay.UseVisualStyleBackColor = true;
            this.buOkay.Click += new System.EventHandler(this.buOkay_Click);
            // 
            // buReset
            // 
            this.buReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buReset.Location = new System.Drawing.Point(12, 231);
            this.buReset.Name = "buReset";
            this.buReset.Size = new System.Drawing.Size(105, 23);
            this.buReset.TabIndex = 3;
            this.buReset.Text = "Reset Settings";
            this.buReset.UseVisualStyleBackColor = true;
            this.buReset.Click += new System.EventHandler(this.buReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAutoStart);
            this.groupBox2.Controls.Add(this.chkHaltRet);
            this.groupBox2.Controls.Add(this.numIdle);
            this.groupBox2.Controls.Add(this.cbIdleMine);
            this.groupBox2.Controls.Add(this.chkIdle);
            this.groupBox2.Location = new System.Drawing.Point(12, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 114);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Miner Options";
            // 
            // numIdle
            // 
            this.numIdle.Location = new System.Drawing.Point(182, 57);
            this.numIdle.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numIdle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIdle.Name = "numIdle";
            this.numIdle.Size = new System.Drawing.Size(48, 20);
            this.numIdle.TabIndex = 2;
            this.numIdle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbIdleMine
            // 
            this.cbIdleMine.FormattingEnabled = true;
            this.cbIdleMine.Location = new System.Drawing.Point(115, 83);
            this.cbIdleMine.Name = "cbIdleMine";
            this.cbIdleMine.Size = new System.Drawing.Size(157, 21);
            this.cbIdleMine.TabIndex = 1;
            // 
            // chkIdle
            // 
            this.chkIdle.AutoSize = true;
            this.chkIdle.Location = new System.Drawing.Point(9, 58);
            this.chkIdle.Name = "chkIdle";
            this.chkIdle.Size = new System.Drawing.Size(273, 17);
            this.chkIdle.TabIndex = 0;
            this.chkIdle.Text = "Start miner when idle more than                    minutes.";
            this.chkIdle.UseVisualStyleBackColor = true;
            // 
            // chkHaltRet
            // 
            this.chkHaltRet.AutoSize = true;
            this.chkHaltRet.Location = new System.Drawing.Point(9, 85);
            this.chkHaltRet.Name = "chkHaltRet";
            this.chkHaltRet.Size = new System.Drawing.Size(95, 17);
            this.chkHaltRet.TabIndex = 3;
            this.chkHaltRet.Text = "Halt on Return";
            this.chkHaltRet.UseVisualStyleBackColor = true;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(9, 19);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(182, 17);
            this.chkAutoStart.TabIndex = 4;
            this.chkAutoStart.Text = "Start miner automatically on open";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // adv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 266);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buReset);
            this.Controls.Add(this.buOkay);
            this.Controls.Add(this.groupBox1);
            this.Name = "adv";
            this.Text = "Advanced Options";
            this.Load += new System.EventHandler(this.adv_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShut)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIdle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numShut;
        private System.Windows.Forms.NumericUpDown numAct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buOkay;
        private System.Windows.Forms.Button buReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbIdleMine;
        private System.Windows.Forms.CheckBox chkIdle;
        private System.Windows.Forms.NumericUpDown numIdle;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkHaltRet;
    }
}