﻿using System;
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
    public partial class ucIntListInit : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        private string cmd = "";
        private string jorder = "", job = "", employername = "", appname = "", appno = "";
        
        private void btnAssess_Click(object sender, EventArgs e)
        {
            int ctr = 0;
            connection.Open();
            cmd = "Select count(*) from applications_t where app_no = '"+ dgvIntervieweeList.SelectedRows[0].Cells[0].Value.ToString() + "' and (initinterviewdate < current_date() or initinterviewdate = current_date())";
            com = new MySqlCommand(cmd, connection);
            ctr = int.Parse(com.ExecuteScalar() + "");
            connection.Close();
            if (ctr == 1)
            {
                ucInIntAssess.application.Text = dgvIntervieweeList.SelectedRows[0].Cells[0].Value.ToString();
                ucInIntAssess.applicant.Text = dgvIntervieweeList.SelectedRows[0].Cells[1].Value.ToString();
                ucInIntAssess.appname.Text = dgvIntervieweeList.SelectedRows[0].Cells[2].Value.ToString();
                ucInIntAssess.Dock = DockStyle.Fill;
                ucInIntAssess.Visible = true;
            }
            else
            {
                MessageBox.Show("Applicant " + dgvIntervieweeList.SelectedRows[0].Cells[2].Value.ToString() + " is not yet for interview today.", "Initial Interview Error");
            }
        }

        private void ucInIntAssess_VisibleChanged(object sender, EventArgs e)
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
            cmd = "select app.app_no'Application No.', a.app_id'Applicant ID', concat(a.lname, ', ', a.fname, ' ', a.mname)'Applicant Name', app.initinterviewdate'Interview Date' from applications_t app "
                    + "join app_t a on app.app_id = a.app_id where app.appstats = 'Active'"
                    + "and app.jorder_id = '" + joborder.Text + "' and app.job_id = '" + jobID + "' and app.employer_id = '" + empID + "' and initinterviewstatus is null";
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

        public ucIntListInit()
        {
            InitializeComponent();
        }

        private void ucIntListInit_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
        }

        private void btnIntApp_Click(object sender, EventArgs e)
        {
            if(dgvIntervieweeList.Rows.Count != 0)
            {
                jorder = joborder.Text;
                job = jobname.Text;
                employername = employer.Text;
                appno = dgvIntervieweeList.SelectedRows[0].Cells[0].Value.ToString();
                appname = dgvIntervieweeList.SelectedRows[0].Cells[2].Value.ToString();
                ucInterviewCriteria.txtAppName.Text = appname;
                ucInterviewCriteria.txtAppNo.Text = appno;
                ucInterviewCriteria.txtJobOrderId.Text = jorder;
                ucInterviewCriteria.txtJobName.Text = job;
                ucInterviewCriteria.txtEmpName.Text = employername;
                ucInterviewCriteria.Dock = DockStyle.Fill;
                ucInterviewCriteria.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
