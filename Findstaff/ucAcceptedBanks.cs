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
    public partial class ucAcceptedBanks : UserControl
    {
        public ucAcceptedBanks()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucAcceptedBanksAddEdit.Dock = DockStyle.Fill;
            ucAcceptedBanksAddEdit.Visible = true;
            ucAcceptedBanksAddEdit.panel1.Visible = true;
            ucAcceptedBanksAddEdit.panel2.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ucAcceptedBanksAddEdit.Dock = DockStyle.Fill;
            ucAcceptedBanksAddEdit.Visible = true;
            ucAcceptedBanksAddEdit.panel1.Visible = false;
            ucAcceptedBanksAddEdit.panel2.Visible = true;
        }
    }
}
