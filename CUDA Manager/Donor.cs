using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUDA_Manager
{
    public partial class Donor : Form
    {
        private Form1 parent;
        public Donor(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(laAddress.Text);
            parent.inflateBalloon("Thank you!", "...whoever you are, it's appreciated! =)", ToolTipIcon.None);
        }
    }
}
