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
    public partial class ucBookFlight : UserControl
    {
        private string cmd = "", appNo = "", appID = "";
        private MySqlConnection connection;
        private MySqlCommand com;
        private MySqlDataReader dr;

        public ucBookFlight()
        {
            InitializeComponent();
        }

        public void init(string appno, string appid)
        {
            appNo = appno;
            appID = appid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ucBookFlight_Load(object sender, EventArgs e)
        {
            Connection con = new Findstaff.Connection();
            connection = con.dbConnection();
            dtp1.MinDate = DateTime.Now;
        }

        private void btnBookFlight_Click(object sender, EventArgs e)
        {
            connection.Open();
            if(cbAirport.Text != "")
            {
                DialogResult r = MessageBox.Show("Do you want to Record Flight details with the ff:\nApplicant: " + appname.Text
                + "\nFlight Schedule: " + dtp1.Value.ToString("yyyy-MM-dd") + "\nArriving to Airport: " + cbAirport.Text, "Record Flight Schedule Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    string airportID = "";
                    cmd = "select airport_id from countryairports_t where airportname = '" + cbAirport.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        airportID = dr[0].ToString();
                    }
                    dr.Close();
                    cmd = "insert into flights_t (app_id, app_no, flightdate, airport_id) values ('" + appID + "', '" + appNo + "', '" + dtp1.Value.ToString("yyyy-MM-dd") + "', '" + airportID + "')";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    cmd = "update app_t set appstatus = 'With Flight Schedule' where app_id = '" + appID + "'";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Flight schedule of " + appname.Text + " is recorded.", "Record Flight Schedule", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    dtp1.Value = DateTime.Now;
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please choose an airport.","Record Flight Details Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            connection.Close();
        }
    }
}
