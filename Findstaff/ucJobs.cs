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
    public partial class ucJobs : UserControl
    {
        private MySqlConnection connection;
        MySqlDataReader dr;
        MySqlCommand com = new MySqlCommand();
        private string cmd = "";

        public ucJobs()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucJobsAddEdit.Dock = DockStyle.Fill;
            ucJobsAddEdit.Visible = true;
            ucJobsAddEdit.panel1.Visible = true;
            ucJobsAddEdit.panel2.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvJobs.Rows.Count != 0)
            {
                string categ = dgvJobs.SelectedRows[0].Cells[2].Value.ToString(), type = dgvJobs.SelectedRows[0].Cells[3].Value.ToString(), job = dgvJobs.SelectedRows[0].Cells[1].Value.ToString();
                ucJobsAddEdit.Dock = DockStyle.Fill;
                ucJobsAddEdit.txtID.Text = dgvJobs.SelectedRows[0].Cells[0].Value.ToString();
                ucJobsAddEdit.Visible = true;
                ucJobsAddEdit.panel1.Visible = false;
                ucJobsAddEdit.panel2.Visible = true;
                ucJobsAddEdit.cbCategory1.Text = categ;
                ucJobsAddEdit.cbJobType2.Text = type;
                ucJobsAddEdit.txtJobs2.Text = job;
                connection.Open();
                cmd = "select g.skillname'Skills' from genskills_t g join specskills_t s on g.skill_id = s.skill_id where s.job_id = '" + ucJobsAddEdit.txtID.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ucJobsAddEdit.dgvSkills2.Rows.Add(dr[0].ToString());
                }
                dr.Close();
                for(int x = 0; x < ucJobsAddEdit.dgvSkills2.Rows.Count; x++)
                {
                    if (ucJobsAddEdit.cbSkills2.Items.Contains(ucJobsAddEdit.dgvSkills2.Rows[x].Cells[0].Value.ToString()))
                    {
                        ucJobsAddEdit.cbSkills2.Items.Remove(ucJobsAddEdit.dgvSkills2.Rows[x].Cells[0].Value.ToString());
                    }
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("No record available for edit.", "No Existing Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            DialogResult r = MessageBox.Show("Do you want to delete the job " + dgvJobs.SelectedRows[0].Cells[1].Value.ToString() + "?", "Delete Skill confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                string cmd = "delete from job_t where job_id = '" + dgvJobs.SelectedRows[0].Cells[0].Value.ToString() + "';";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                dgvJobs.Rows.Remove(dgvJobs.SelectedRows[0]);
                MessageBox.Show("Job Deleted!", "Job Record Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
        }

        public void searchData(string valueToFind)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            string cmd = "select j.job_id'Job ID', j.Jobname'Job Name', c.categoryname'Category', jt.typename'Type of Job' from jobcategory_t c join job_t j on c.category_id = j.category_id join jobtype_t jt where j.jobtype_id = jt.jobtype_id AND concat(j.job_id, j.Jobname, c.categoryname, jt.typename) LIKE '%" + valueToFind + "%'";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvJobs.DataSource = ds.Tables[0];
                }
            }
        }

        private void ucJobsAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            string com = "select j.job_id'Job ID', j.Jobname'Job Name', c.categoryname'Category', jt.typename'Type of Job' from jobcategory_t c join job_t j on c.category_id = j.category_id join jobtype_t jt where j.jobtype_id = jt.jobtype_id";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(com, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvJobs.DataSource = ds.Tables[0];
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            searchData(txtName.Text);
        }

        private void ucJobs_Load(object sender, EventArgs e)
        {
            searchData(txtName.Text);
        }

        private void ucJobsAddEdit_VisibleChanged_1(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            string com = "select j.job_id'Job ID', j.Jobname'Job Name', c.categoryname'Category', jt.typename'Type of Job' from jobcategory_t c join job_t j on c.category_id = j.category_id join jobtype_t jt where j.jobtype_id = jt.jobtype_id";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(com, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvJobs.DataSource = ds.Tables[0];
                }
            }
        }
    }
}
