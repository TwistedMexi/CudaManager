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
    public partial class Logs : Form
    {
        private Form1 parent;
        public Logs(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            foreach (string[] entry in parent.logs)
            {
                dgLogs.Rows.Add(entry);
            }
        }
    }
}
