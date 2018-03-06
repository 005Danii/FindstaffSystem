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
    public partial class ucFlightBooking : UserControl
    {
        private string cmd = "";
        private MySqlConnection connection;
        private MySqlCommand com;
        private MySqlDataReader dr;

        public ucFlightBooking()
        {
            InitializeComponent();
        }

        private void btnBookFlight_Click(object sender, EventArgs e)
        {
            if(dgvFlightBooking.Rows.Count != 0)
            {
                if(dgvFlightBooking.SelectedRows[0].Cells[3].Value.ToString() == "For Deployment")
                {
                    connection.Open();
                    string jobID = "", empID = "", jorderID = "", countryID = "";
                    cmd = "select job_id, employer_id, jorder_id from applications_t where app_no = '" + dgvFlightBooking.SelectedRows[0].Cells[1].Value.ToString() + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        jobID = dr[0].ToString();
                        empID = dr[1].ToString();
                        jorderID = dr[2].ToString();
                    }
                    dr.Close();
                    ucBookFlight.appname.Text = dgvFlightBooking.SelectedRows[0].Cells[2].Value.ToString();
                    ucBookFlight.joborder.Text = jorderID;
                    cmd = "select jobname from job_t where job_id = '" + jobID + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        ucBookFlight.jobname.Text = dr[0].ToString();
                    }
                    dr.Close();
                    cmd = "select country_id, employername from employer_t where employer_id = '" + empID + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        countryID = dr[0].ToString();
                        ucBookFlight.employer.Text = dr[1].ToString();
                    }
                    dr.Close();
                    cmd = "select countryname from country_t where country_id = '" + countryID + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        ucBookFlight.txtCountry.Text = dr[0].ToString();
                    }
                    dr.Close();
                    ucBookFlight.cbAirport.Items.Clear();
                    cmd = "select airportname from countryairports_t where country_id = '" + countryID + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        ucBookFlight.cbAirport.Items.Add(dr[0]);
                    }
                    dr.Close();
                    ucBookFlight.init(dgvFlightBooking.SelectedRows[0].Cells[0].Value.ToString(), dgvFlightBooking.SelectedRows[0].Cells[1].Value.ToString());
                    ucBookFlight.Dock = DockStyle.Fill;
                    ucBookFlight.Visible = true;
                    connection.Close();
                }
                else
                {
                    MessageBox.Show(dgvFlightBooking.SelectedRows[0].Cells[2].Value.ToString() + " has a flight schedule already.","Book Flight Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            if (dgvFlightBooking.Rows.Count != 0)
            {
                if (dgvFlightBooking.SelectedRows[0].Cells[3].Value.ToString() == "With Flight Schedule")
                {
                    connection.Open();
                    string jobID = "", empID = "", jorderID = "";
                    cmd = "select job_id, employer_id, jorder_id from applications_t where app_no = '" + dgvFlightBooking.SelectedRows[0].Cells[1].Value.ToString() + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        jobID = dr[0].ToString();
                        empID = dr[1].ToString();
                        jorderID = dr[2].ToString();
                    }
                    dr.Close();
                    ucReschedFlight.appname.Text = dgvFlightBooking.SelectedRows[0].Cells[2].Value.ToString();
                    ucReschedFlight.joborder.Text = jorderID;
                    cmd = "select jobname from job_t where job_id = '" + jobID + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        ucReschedFlight.jobname.Text = dr[0].ToString();
                    }
                    dr.Close();
                    cmd = "select employername from employer_t where employer_id = '" + empID + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        ucReschedFlight.employer.Text = dr[0].ToString();
                    }
                    dr.Close();
                    ucReschedFlight.Dock = DockStyle.Fill;
                    ucReschedFlight.Visible = true;
                    connection.Close();
                }
                else
                {
                    MessageBox.Show(dgvFlightBooking.SelectedRows[0].Cells[2].Value.ToString() + " doesn't have a flight schedule yet.", "Reschedule Flight Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {

        }

        private void ucFlightBooking_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            cmd = "select a.app_no'Application No.', app.app_id'App ID', concat(app.lname, ', ', app.fname, ' ', app.mname)'Applicant Name', app.appstatus'Status', f.flightdate'Date of Flight' "
                    + "from app_t app join applications_t a on a.app_id = app.app_id left join flights_t f on a.app_id = f.app_id and a.app_no = f.app_no "
                    + "where app.appstatus in ('For Deployment', 'With Flight Schedule', 'On Flight', 'Arrived') and a.appstats = 'Active' ";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvFlightBooking.DataSource = ds.Tables[0];
                }
            }
        }

        private void ucBookFlight_VisibleChanged(object sender, EventArgs e)
        {
            cmd = "select a.app_no'Application No.', app.app_id'App ID', concat(app.lname, ', ', app.fname, ' ', app.mname)'Applicant Name', app.appstatus'Status', f.flightdate'Date of Flight' "
                    + "from app_t app join applications_t a on a.app_id = app.app_id left join flights_t f on a.app_id = f.app_id and a.app_no = f.app_no "
                    + "where app.appstatus in ('For Deployment', 'With Flight Schedule', 'On Flight', 'Arrived') and a.appstats = 'Active' ";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvFlightBooking.DataSource = ds.Tables[0];
                }
            }
        }

        private void ucReschedFlight_VisibleChanged(object sender, EventArgs e)
        {
            cmd = "select a.app_no'Application No.', app.app_id'App ID', concat(app.lname, ', ', app.fname, ' ', app.mname)'Applicant Name', app.appstatus'Status', f.flightdate'Date of Flight' "
                    + "from app_t app join applications_t a on a.app_id = app.app_id left join flights_t f on a.app_id = f.app_id and a.app_no = f.app_no "
                    + "where app.appstatus in ('For Deployment', 'With Flight Schedule', 'On Flight', 'Arrived') and a.appstats = 'Active' ";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvFlightBooking.DataSource = ds.Tables[0];
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvFlightBooking.Rows.Count != 0)
            {
                if (dgvFlightBooking.SelectedRows[0].Cells[3].Value.ToString() == "With Flight Schedule")
                {
                    DialogResult dr1 = MessageBox.Show("Has " + dgvFlightBooking.SelectedRows[0].Cells[2].Value.ToString() + "arrived in the airport");
                }
                else
                {
                    MessageBox.Show(dgvFlightBooking.SelectedRows[0].Cells[2].Value.ToString() + " doesn't have a flight schedule yet.", "Reschedule Flight Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }
    }
}
