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
    public partial class ucJobList : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private string cmd = "";
        MySqlDataReader dr;

        public ucJobList()
        {
            InitializeComponent();
        }

        private void btnAdvSe_Click(object sender, EventArgs e)
        {
            fAdvSearch fas = new fAdvSearch();
            fas.Show();
        }

        private void btnEmpAdd_Click(object sender, EventArgs e)
        {
            ucJobListAddEdit.Dock = DockStyle.Fill;
            ucJobListAddEdit.Visible = true;
            ucJobListAddEdit.panel1.Visible = true;
            ucJobListAddEdit.panel2.Visible = false;
        }

        private void btnEmpEdit_Click(object sender, EventArgs e)
        {
            string joborder = dgvJobList.SelectedRows[0].Cells[0].Value.ToString(), jobName = dgvJobList.SelectedRows[0].Cells[1].Value.ToString(), employer = dgvJobList.SelectedRows[0].Cells[2].Value.ToString(), category = "";
            
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            string cmd = "select employername from employer_t where employername <> '"+ dgvJobList.SelectedRows[0].Cells[2].Value.ToString() +"' ";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobListAddEdit.cbEmployer2.Items.Add(dr[0].ToString());
            }
            dr.Close();

            cmd = "select reqapp, salary, heightreq, weightreq, gender, cntrctstart from joborder_t where jorder_id = '" + dgvJobList.SelectedRows[0].Cells[0].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobListAddEdit.nddEmployees2.Text = dr[0].ToString();
                ucJobListAddEdit.txtSalary2.Text = dr[1].ToString();
                ucJobListAddEdit.txtHeight2.Text = dr[2].ToString();
                ucJobListAddEdit.txtWeight2.Text = dr[3].ToString();
                if(ucJobListAddEdit.cbMale2.Text == dr[4].ToString())
                {
                    ucJobListAddEdit.cbMale2.Checked = true;
                }
                else if (ucJobListAddEdit.cbFemale2.Text == dr[4].ToString())
                {
                    ucJobListAddEdit.cbFemale2.Checked = true;
                }
                else
                {
                    ucJobListAddEdit.cbMale2.Checked = true;
                    ucJobListAddEdit.cbFemale2.Checked = true;
                }
                ucJobListAddEdit.dtp2.Value = Convert.ToDateTime(dr[5].ToString());
            }
            dr.Close();

            cmd = "select jc.categoryname from jobcategory_t jc join joborder_t jo on jc.category_id = jo.category_id where jo.jorder_id = '" + dgvJobList.SelectedRows[0].Cells[0].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                category = dr[0].ToString();
            }
            dr.Close();
            
            cmd = "select g.skillname'Skill Name', js.proflevel'Proficiency Level' from jobskills_t js join genskills_t g on js.skill_id = g.skill_id where js.jorder_id = '" + dgvJobList.SelectedRows[0].Cells[0].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobListAddEdit.dgvSkills2.Rows.Add(dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            
            cmd = "select g.reqname'Requirement Name' from jobdocs_t j join genreqs_t g on j.req_id = g.req_id where j.jorder_id = '" + dgvJobList.SelectedRows[0].Cells[0].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobListAddEdit.dgvReqDocs2.Rows.Add(dr[0].ToString());
            }
            dr.Close();
            connection.Close();


            ucJobListAddEdit.Dock = DockStyle.Fill;
            ucJobListAddEdit.Visible = true;
            ucJobListAddEdit.panel1.Visible = false;
            ucJobListAddEdit.panel2.Visible = true;
            
            ucJobListAddEdit.lblJOrder.Text = joborder;
            ucJobListAddEdit.cbEmployer2.Text = employer;
            ucJobListAddEdit.cbCategory2.Text = category;

            connection.Open();
            cmd = "select country_id from employer_t where employername = '" + ucJobListAddEdit.cbEmployer2.Text + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                cmd = "select symbol from country_t where country_id = '" + dr[0].ToString() + "'";
            }
            dr.Close();
            string symbol = "";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                symbol = dr[0].ToString();
            }
            dr.Close();
            ucJobListAddEdit.txtSalaryCur2.Text = symbol;
            cmd = "select j.jobname from job_t j join jobcategory_t c where c.categoryname = '" + ucJobListAddEdit.cbCategory2.Text + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobListAddEdit.cbJobName2.Items.Add(dr[0]);
            }
            dr.Close();
            ucJobListAddEdit.cbJobName2.Text = jobName;
            connection.Close();
        }

        private void btnEmpDel_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpView_Click(object sender, EventArgs e)
        {
            string symbol = "";
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            string cmd = "select employername from employer_t where employername = '" + dgvJobList.SelectedRows[0].Cells[2].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobListView.employer.Text = dr[0].ToString();
            }
            dr.Close();

            cmd = "select c.symbol from country_t c join employer_t e on c.country_id = e.country_id where e.employername = '" + ucJobListView.employer.Text + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                symbol = dr[0].ToString();
            }
            dr.Close();

            cmd = "select jorder_id, reqapp, salary, gender, heightreq, weightreq, concat(monthname(cntrctstart), ' ', day(cntrctstart), ', ', year(cntrctstart)) from joborder_t where jorder_id = '" + dgvJobList.SelectedRows[0].Cells[0].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobListView.jono.Text = dr[0].ToString();
                ucJobListView.noofempreq.Text = dr[1].ToString();
                ucJobListView.salary.Text = symbol + " "+ dr[2].ToString();
                ucJobListView.gender.Text = dr[3].ToString();
                ucJobListView.height.Text = dr[4].ToString();
                ucJobListView.weight.Text = dr[5].ToString();
                ucJobListView.contractStart.Text = dr[6].ToString();
            }
            dr.Close();

            cmd = "select j.jobname from job_t j join joborder_t jo on j.job_id = jo.job_id where jorder_id = '" + dgvJobList.SelectedRows[0].Cells[0].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobListView.jobname.Text = dr[0].ToString();
            }
            dr.Close();

            cmd = "select jc.categoryname from jobcategory_t jc join joborder_t jo on jc.category_id = jo.category_id where jorder_id = '" + dgvJobList.SelectedRows[0].Cells[0].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobListView.category.Text = dr[0].ToString();
            }
            dr.Close();

            cmd = "select g.skillname'Skill Name', js.proflevel'Proficiency Level' from jobskills_t js join genskills_t g on js.skill_id = g.skill_id join job_t j on js.job_id = j.job_id where js.jorder_id = '" + dgvJobList.SelectedRows[0].Cells[0].Value.ToString() + "' and j.jobname = '"+ dgvJobList.SelectedRows[0].Cells[1].Value.ToString() + "'";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    ucJobListView.dgvSkills.DataSource = ds.Tables[0];
                }
            }

            cmd = "select g.reqname'Requirement Name' from jobdocs_t j join genreqs_t g on j.req_id = g.req_id where jorder_id = '" + dgvJobList.SelectedRows[0].Cells[0].Value.ToString() + "'";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    ucJobListView.dgvRequiredDocs.DataSource = ds.Tables[0];
                }
            }

            ucJobListView.Dock = DockStyle.Fill;
            ucJobListView.Visible = true;
        }

        public void searchData(string valueToFind)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            string cmd = "select jo.jorder_id'Job Order ID', j.jobname'Job', e.employername'Employer', jo.reqapp'No. of Required Applicants', jo.cntrctend'Job Order Valid Until' " +
                "from joborder_t jo join employer_t e on jo.employer_id = e.employer_id " +
                "join job_t j on jo.job_id = j.job_id where jo.cntrctstat = 'Active' or jo.cntrctstat = 'Renewed' AND concat(jo.jorder_id, j.jobname, e.employername, jo.reqapp, jo.cntrctend) LIKE '%" + valueToFind + "%'";
            com = new MySqlCommand(cmd, connection);
            com.ExecuteNonQuery();

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvJobList.DataSource = table;
        }

        private void ucJobListAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            cmd = "select jo.jorder_id'Job Order ID', j.jobname'Job', e.employername'Employer', jo.reqapp'No. of Required Applicants', jo.cntrctend'Job Order Valid Until' " +
                "from joborder_t jo join employer_t e on jo.employer_id = e.employer_id " +
                "join job_t j on jo.job_id = j.job_id where jo.cntrctstat = 'Active' or jo.cntrctstat = 'Renewed';";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvJobList.DataSource = ds.Tables[0];
                }
            }
            connection.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            searchData(txtName.Text);
        }

        private void ucJobList_Load(object sender, EventArgs e)
        {
            searchData(txtName.Text);
        }

        private void ucJobListAddEdit_VisibleChanged_1(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            cmd = "select jo.jorder_id'Job Order ID', j.jobname'Job', e.employername'Employer', jo.reqapp'No. of Required Applicants', jo.cntrctend'Job Order Valid Until' " +
                "from joborder_t jo join employer_t e on jo.employer_id = e.employer_id " +
                "join job_t j on jo.job_id = j.job_id where jo.cntrctstat = 'Active' or jo.cntrctstat = 'Renewed';";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvJobList.DataSource = ds.Tables[0];
                }
            }
            connection.Close();
        }
    }
}
