using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Findstaff
{
    public partial class ucAcceptedBanks : UserControl
    {
        private MySqlCommand com;
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private string cmd = "";

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

        private void ucAcceptedBanksAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            cmd = "Select c.countryname'Country', count(b.country_id)'No. of Accepted Banks' from country_t c join banksallowed_t b on c.country_id = b.country_id group by c.country_id";
            using (connection)
            {
                using (adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvAcceptedBanks.DataSource = ds.Tables[0];
                }
            }
        }
    }
}
