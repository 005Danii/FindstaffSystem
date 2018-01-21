using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Findstaff
{
    public partial class ucBanks : UserControl
    {
        public ucBanks()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucBankAddEdit.Dock = DockStyle.Fill;
            ucBankAddEdit.Visible = true;
            ucBankAddEdit.panel1.Visible = true;
            ucBankAddEdit.panel2.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ucBankAddEdit.Dock = DockStyle.Fill;
            ucBankAddEdit.Visible = true;
            ucBankAddEdit.panel1.Visible = false;
            ucBankAddEdit.panel2.Visible = true;
        }
    }
}
