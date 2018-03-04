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
                + "join app_t a on app.app_id = a.app_id where app.appstats = 'Active' and a.appstatus = 'For Final Interview' "
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
    }
}
