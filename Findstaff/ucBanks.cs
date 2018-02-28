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
    public partial class ucBanks : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        private string cmd = "";

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

        private void ucBankAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            cmd = "Select bank_id'Bank ID', Bankname'Name of Bank' from banks_t";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvBank.DataSource = ds.Tables[0];
                }
            }
            connection.Close();
        }
    }
}
