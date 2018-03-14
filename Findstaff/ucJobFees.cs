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
    public partial class ucJobFees : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        private string cmd = "";
        MySqlDataReader dr;

        public ucJobFees()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucJobFeesAddEdit.Dock = DockStyle.Fill;
            ucJobFeesAddEdit.Visible = true;
            ucJobFeesAddEdit.panel1.Visible = true;
            ucJobFeesAddEdit.panel2.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ucJobFeesAddEdit.txtJobOrder2.Text = dgvJobFees.SelectedRows[0].Cells[0].Value.ToString();

            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            cmd = "select jf.jorder_id, e.employername from employer_t e join jobfees_t jf on e.employer_id = jf.employer_id where e.employername = '" + dgvJobFees.SelectedRows[0].Cells[1].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobFeesAddEdit.txtJobOrder2.Text = dr[0].ToString();
                ucJobFeesAddEdit.txtEmployer2.Text = dr[1].ToString();
            }
            dr.Close();

            cmd = "select g.feename'Fee Name', jf.amount'Amount' from jobfees_t jf join genfees_t g on jf.fee_id = g.fee_id where jorder_id = '" + ucJobFeesAddEdit.txtJobOrder2.Text + "'";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    ucJobFeesAddEdit.dgvFees2.DataSource = ds.Tables[0];
                }
            }
            connection.Close();
            ucJobFeesAddEdit.Dock = DockStyle.Fill;
            ucJobFeesAddEdit.Visible = true;
            ucJobFeesAddEdit.panel1.Visible = false;
            ucJobFeesAddEdit.panel2.Visible = true;
        }

        private void ucJobFeesAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Findstaff.Connection();
            connection = con.dbConnection();
            connection.Open();
            cmd = "select j.jobname'Job Order ID', e.employername'Employer', count(jf.fee_id)'No. of Fees to be Collected From Applicant' from joborder_t jo join job_t j on jo.job_id = j.job_id join jobfees_t jf on jo.jorder_id = jf.jorder_id join employer_t e on jo.employer_id = e.employer_id group by jo.jorder_id";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvJobFees.DataSource = ds.Tables[0];
                }
            }
            connection.Close();
        }

        public void searchData(string valueToFind)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            string cmd = cmd = "select j.jobname'Job Title', e.employername'Employer', count(jf.fee_id)'No. of Fees to be Collected From Applicant' from joborder_t jo join job_t j on jo.job_id = j.job_id join jobfees_t jf on jo.jorder_id = jf.jorder_id join employer_t e on jo.employer_id = e.employer_id WHERE concat (j.jobname, e.employername) LIKE '%" + valueToFind + "%' group by jf.jorder_id";
            com = new MySqlCommand(cmd, connection);
            com.ExecuteNonQuery();

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvJobFees.DataSource = table;
            connection.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchData(txtSearch.Text);
        }

        private void ucJobFees_Load(object sender, EventArgs e)
        {
            searchData(txtSearch.Text);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            cmd = "select jf.jorder_id, e.employername from employer_t e join jobfees_t jf on e.employer_id = jf.employer_id where e.employername = '" + dgvJobFees.SelectedRows[0].Cells[1].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucJobFeesView.jorderid.Text = dr[0].ToString();
                ucJobFeesView.employername.Text = dr[1].ToString();
            }
            dr.Close();

            cmd = "select g.feename'Fee Name', jf.amount'Amount' from jobfees_t jf join genfees_t g on jf.fee_id = g.fee_id where jorder_id = '" + ucJobFeesView.jorderid.Text + "'";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    ucJobFeesView.dgvFees.DataSource = ds.Tables[0];
                }
            }
            connection.Close();

            ucJobFeesView.Dock = DockStyle.Fill;
            ucJobFeesView.Visible = true;
        }

        private void ucJobFeesAddEdit_VisibleChanged_1(object sender, EventArgs e)
        {
            Connection con = new Findstaff.Connection();
            connection = con.dbConnection();
            connection.Open();
            cmd = "select j.jobname'Job Title', e.employername'Employer', count(jf.fee_id)'No. of Fees to be Collected From Applicant' from joborder_t jo join job_t j on jo.job_id = j.job_id join jobfees_t jf on jo.jorder_id = jf.jorder_id join employer_t e on jo.employer_id = e.employer_id group by jo.jorder_id";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvJobFees.DataSource = ds.Tables[0];
                }
            }
            connection.Close();
        }
    }
}
