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
    public partial class ucCurrencyAddEdit : UserControl
    {

        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        private string cmd = "";

        public ucCurrencyAddEdit()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            txtCurrency.Clear();
            txtSymbol.Clear();
            this.Hide();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            if(txtCurrency.Text != "" || txtSymbol.Text != "")
            {
                string check = "";
                cmd = "Select currencyname, symbol from currency_t where Currencyname = '" + txtCurrency.Text + "' or symbol = '" + txtSymbol.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    check = dr[0].ToString();
                }
                dr.Close();
                if (check.Equals(""))
                {
                    cmd = "Insert into Currency_t(Currencyname, symbol) values ('" + txtCurrency.Text + "','" + txtSymbol.Text + "')";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Currency Added", "Add Currency", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                    txtCurrency.Clear();
                    txtSymbol.Clear();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Record exist with the same symbol or currency Exists", "Add Currency Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty fields present.", "Add Curency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void ucCurrencyAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
        }
    }
}
