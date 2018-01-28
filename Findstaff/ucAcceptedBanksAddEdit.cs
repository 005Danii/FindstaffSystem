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
    public partial class ucAcceptedBanksAddEdit : UserControl
    {
        private MySqlCommand com;
        private MySqlConnection connection;
        private MySqlDataReader dr;
        private string cmd = "";

        public ucAcceptedBanksAddEdit()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ucAcceptedBanksAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            if(this.Visible == true)
            {
                connection.Open();
                cmd = "Select countryname from country_t where (select count(b.country_id) from banksallowed_t b join country_t c on b.country_id = c.country_id group by c.country_id) = 0";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbCountry.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cmd = "Select bankname from banks_t";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    clBanks.Items.Add(dr[0].ToString());
                }
                dr.Close();
                connection.Close();
            }
            else
            {
                cbCountry.Items.Clear();
                clBanks.Items.Clear();
            }
        }
    }
}
