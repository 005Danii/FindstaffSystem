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
    public partial class ucJobType : UserControl
    {
        MySqlConnection connection;
        MySqlCommand com;
        private string cmd = "";

        public ucJobType()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucJobTypeAddEdit1.Dock = DockStyle.Fill;
            ucJobTypeAddEdit1.Visible = true;
            ucJobTypeAddEdit1.panel1.Visible = true;
            ucJobTypeAddEdit1.panel2.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvJobType.Rows.Count != 0)
            {
                ucJobTypeAddEdit1.Dock = DockStyle.Fill;
                ucJobTypeAddEdit1.txtID.Text = dgvJobType.SelectedRows[0].Cells[0].Value.ToString();
                ucJobTypeAddEdit1.txtType2.Text = dgvJobType.SelectedRows[0].Cells[1].Value.ToString();
                ucJobTypeAddEdit1.Visible = true;
                ucJobTypeAddEdit1.panel1.Visible = false;
                ucJobTypeAddEdit1.panel2.Visible = true;
            }
        }

        private void ucJobTypeAddEdit1_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            cmd = "Select JobType_ID'Jobtype ID', Typename'Job Types' from Jobtype_t";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvJobType.DataSource = ds.Tables[0];
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            DialogResult r = MessageBox.Show("Do you want to delete the job type " + dgvJobType.SelectedRows[0].Cells[1].Value.ToString() + "?", "Delete Skill confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                string cmd = "delete from jobtype_t where jobtype_id = '" + dgvJobType.SelectedRows[0].Cells[0].Value.ToString() + "';";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                dgvJobType.Rows.Remove(dgvJobType.SelectedRows[0]);
                MessageBox.Show("Job Type Deleted!", "Job Type Record Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
        }

        private void ucJobType_Load(object sender, EventArgs e)
        {
            Connection con = new Findstaff.Connection();
            connection = con.dbConnection();
        }
    }
}
