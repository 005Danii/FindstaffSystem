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
    public partial class ucReschedFlight : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com;
        MySqlDataReader dr;
        private string appNo = "";
        private string cmd = "";

        public ucReschedFlight()
        {
            InitializeComponent();
        }

        public void init(string appno)
        {
            appNo = appno;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cbAirport.Items.Clear();
            dtpResched.Value = DateTime.Now;
            this.Hide();
        }

        private void ucReschedFlight_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            dtpResched.MinDate = DateTime.Now;
        }

        private void btnReschedFlight_Click(object sender, EventArgs e)
        {
            string airportID = "";
            connection.Open();
            if(cbAirport.Text != "")
            {
                DialogResult r = MessageBox.Show("Reschedule flight of "+appname.Text+" with the ff. details?\n Airport: " + cbAirport.Text 
                    + "\nFlight Date: " +dtpResched.Value.ToString("yyyy-MM-dd"), "Reschedule Flight Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(r == DialogResult.Yes)
                {
                    cmd = "select airport_id from countryairports_t where airportname = '" + cbAirport.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        airportID = dr[0].ToString();
                    }
                    dr.Close();
                    cmd = "update flights_t set airport_id = '" + airportID + "', flightdate = '" + dtpResched.Value.ToString("yyyy-MM-dd") + "' where app_no = '" + appNo + "'";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Reschedule of flight has been recorded.", "Reschedule Flight", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    dtpResched.Value = DateTime.Now;
                    cbAirport.Items.Clear();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please select airport of destination first.","Reschedule Flight Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            connection.Close();
        }
    }
}
