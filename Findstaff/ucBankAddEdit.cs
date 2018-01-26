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
    public partial class ucBankAddEdit : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        private string cmd = "";

        public ucBankAddEdit()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            txtBankName.Clear();
            this.Hide();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            string check = "";
            cmd = "Select bankname from banks_t where bankname = '" + txtBankName.Text + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                check = dr[0].ToString();
            }
            dr.Close();
            if (!check.Equals(txtBankName.Text))
            {
                cmd = "Insert into Banks_t(Bankname) values ('" + txtBankName.Text + "')";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Bank Added", "Add Bank", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                txtBankName.Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bank Exists", "Add Bank Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void ucBankAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
        }
    }
}
