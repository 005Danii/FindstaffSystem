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
    public partial class ucIntListFinal : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        private string cmd = "";

        public ucIntListFinal()
        {
            InitializeComponent();
        }

        private void ucIntListFinal_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            dtp.MinDate = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAssess_Click(object sender, EventArgs e)
        {
            if(dgvIntervieweeList.SelectedRows[0].Cells[3].Value.ToString() == "For Final Interview")
            {
                MessageBox.Show("Applicant " + dgvIntervieweeList.SelectedRows[0].Cells[2].Value.ToString() + " doesn't have a schedule for final interview yet.", "Final Interview Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                ucFinInAssess.application.Text = dgvIntervieweeList.SelectedRows[0].Cells[0].Value.ToString();
                ucFinInAssess.applicant.Text = dgvIntervieweeList.SelectedRows[0].Cells[1].Value.ToString();
                ucFinInAssess.appname.Text = dgvIntervieweeList.SelectedRows[0].Cells[2].Value.ToString();
                ucFinInAssess.Dock = DockStyle.Fill;
                ucFinInAssess.Visible = true;
            }
        }

        private void ucFinInAssess_VisibleChanged(object sender, EventArgs e)
        {
            connection.Open();
            string jobID = "", empID = "";
            cmd = "select job_id from job_t where jobname = '" + jobname.Text + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                jobID = dr[0].ToString();
            }
            dr.Close();
            cmd = "select employer_id from employer_t where employername = '" + employer.Text + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                empID = dr[0].ToString();
            }
            dr.Close();
            cmd = "select app.app_no'Application No.', a.app_id'Applicant ID', concat(a.lname, ', ', a.fname, ' ', a.mname)'Applicant Name', a.appstatus'Status', app.finalinterviewdate'Final Interview Date' from applications_t app "
                + "join app_t a on app.app_id = a.app_id where app.appstats = 'Active' and (a.appstatus = 'For Final Interview' or a.appstatus = 'Scheduled for Final Inteview') "
                + "and app.jorder_id = '" + joborder.Text + "' and app.job_id = '" + jobID + "' and app.employer_id = '" + empID + "' and app.finalinterviewstatus is null and app.initinterviewstatus = 'Passed'";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvIntervieweeList.DataSource = ds.Tables[0];
                }
            }
            connection.Close();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            if (dtp.Value.ToString("dddd") != "Saturday" || dtp.Value.ToString("dddd") != "Sunday")
            {
                connection.Open();
                cmd = "update app_t set appstatus = 'Scheduled for Final Interview' where app_id = '" + dgvIntervieweeList.SelectedRows[0].Cells[1].Value.ToString() + "'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                cmd = "update applications_t set finalinterviewdate = '" + dtp.Value.ToString("yyyy-MM-dd") + "' where app_no = '" + dgvIntervieweeList.SelectedRows[0].Cells[0].Value.ToString() + "'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Applicant " + dgvIntervieweeList.SelectedRows[0].Cells[2].Value.ToString() + " has been scheduled for final interview.", "Final Interview Schedule", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                panel1.Visible = false;
                string jobID = "", empID = "";
                cmd = "select job_id from job_t where jobname = '" + jobname.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    jobID = dr[0].ToString();
                }
                dr.Close();
                cmd = "select employer_id from employer_t where employername = '" + employer.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    empID = dr[0].ToString();
                }
                dr.Close();
                cmd = "select app.app_no'Application No.', a.app_id'Applicant ID', concat(a.lname, ', ', a.fname, ' ', a.mname)'Applicant Name', a.appstatus'Status', app.finalinterviewdate'Final Interview Date' from applications_t app "
                    + "join app_t a on app.app_id = a.app_id where app.appstats = 'Active' and (a.appstatus = 'For Final Interview' or a.appstatus = 'Scheduled for Final Interview') "
                    + "and app.jorder_id = '" + joborder.Text + "' and app.job_id = '" + jobID + "' and app.employer_id = '" + empID + "' and app.finalinterviewstatus is null and app.initinterviewstatus = 'Passed'";
                using (connection)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dgvIntervieweeList.DataSource = ds.Tables[0];
                    }
                }
            }
            else
            {
                MessageBox.Show("Cannot set final interview date on weekends", "Final Interview Date Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void btnFinalInterviewSched_Click(object sender, EventArgs e)
        {
            if(dgvIntervieweeList.Rows.Count != 0)
            {
                if (dgvIntervieweeList.SelectedRows[0].Cells[3].Value.ToString() != "Scheduled for Final Interview")
                {
                    panel1.Visible = true;
                    dgvIntervieweeList.Enabled = false;
                    btnAssess.Enabled = false;
                    btnClose.Enabled = false;
                    btnFinalInterviewSched.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Applicant " + dgvIntervieweeList.SelectedRows[0].Cells[2].Value.ToString() + " already has a schedule for final interview.", "Final Interview Schedule Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dgvIntervieweeList.Enabled = true;
            btnAssess.Enabled = true;
            btnClose.Enabled = true;
            btnFinalInterviewSched.Enabled = true;
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            if(panel1.Visible == true)
            {
                dgvIntervieweeList.Enabled = false;
                btnFinalInterviewSched.Enabled = false;
                btnAssess.Enabled = false;
                btnClose.Enabled = false;
            }
            else
            {
                dgvIntervieweeList.Enabled = true;
                btnFinalInterviewSched.Enabled = true;
                btnAssess.Enabled = true;
                btnClose.Enabled = true;
            }
        }
    }
}
