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
    public partial class adv : Form
    {
        private Form1 parent;
        public adv(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void buOkay_Click(object sender, EventArgs e)
        {
            if (numAct.Value > 80)
            {
                DialogResult dialogResult = MessageBox.Show("Please be cautious when altering default temperature settings.\r\n\r\nIt's highly advised against raising Protective Cooling's limit above 80C.\r\nInstead, please check your fans for dust.\r\n\r\nDo you want to continue?", "Override Defaults?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    parent.unsafetmp = (int)numAct.Value;
                    parent.shutdowntmp = (int)numShut.Value;
                    this.Close();
                }
            }
            else
            {
                parent.unsafetmp = (int)numAct.Value;
                parent.shutdowntmp = (int)numShut.Value;
                this.Close();
            }
        }

        private void buReset_Click(object sender, EventArgs e)
        {
            numAct.Value = 80;
            numShut.Value = 100;
        }

        private void adv_Load(object sender, EventArgs e)
        {
            numAct.Value = parent.unsafetmp;
            numShut.Value = parent.shutdowntmp;
        }
    }
}
