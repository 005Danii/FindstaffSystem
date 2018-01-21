using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Findstaff
{
    public partial class fBookFlight : Form
    {
        MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();

        public fBookFlight()
        {
            InitializeComponent();
        }

        private void fBookFlight_Load(object sender, EventArgs e)
        {
            string app = "", jorder = "", jname = "", emp = "";

            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            string query = "SELECT * FROM EMP_T;";
            com = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = com.ExecuteReader();
            while (dataReader.Read())
            {
                app = dataReader.GetString(3);
                jorder = dataReader.GetString(4);
                jname = dataReader.GetString(5);
                emp = dataReader.GetString(10);
            }
            connection.Close();

            appname.Text = app;
            joborder.Text = jorder;
            jobname.Text = jname;
            employer.Text = emp;
        }

        private void btnBookFlight_Click(object sender, EventArgs e)
        {
            DialogResult y = MessageBox.Show("Are you sure you want to book?", "Book Flight?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == y)
            {
                MessageBox.Show("Done!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
