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
                cmd = "Select c.countryname from country_t c where (select count(b.country_id) from banksallowed_t b join country_t c on b.country_id = c.country_id) = 0";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            string id = "";
            int num = 0;
            cmd = "select country_id from country_t where countryname = '"+cbCountry.Text+"'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                id = dr[0].ToString();
            }
            dr.Close();
            foreach (string s in clBanks.CheckedItems)
            {
                num++;
            }
            string[] banks = new string[num];
            num = 0;
            foreach (string s in clBanks.CheckedItems)
            {
                cmd = "select bank_id from banks_t where bankname = '" + s + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    banks[num] = dr[0].ToString();
                }
                dr.Close();
                num++;
            }
            cmd = "insert into banksallowed_t values ";
            for(int x = 0; x < num; x++)
            {
                cmd += "('"+id+"','"+banks[x]+"')";
                if(x < num - 1)
                {
                    cmd += ",";
                }
            }
            com = new MySqlCommand(cmd, connection);
            com.ExecuteNonQuery();
            MessageBox.Show("Accepted Banks in Country Added", "Add Accepted Banks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            connection.Close();
        }
    }
}
