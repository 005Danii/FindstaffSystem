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
    public partial class ucJobFeesAddEdit : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        private string cmd = "", cmd2 = "";
        private MySqlDataReader dr;

        public ucJobFeesAddEdit()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (dgvFees1.Rows.Count != 0)
            {
                string empID = "", jorderID = "";
                cmd = "select employer_id from employer_t where employername = '"+cbEmployer1.Text+"'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    empID = dr[0].ToString();
                }
                dr.Close();
                cmd = "select jo.jorder_id from joborder_t jo join employer_t e on jo.employer_id = e.employer_id join job_t j on jo.job_id = j.job_id where e.employername = '" + cbEmployer1.Text + "' and j.jobname = '"+cbJobName1.Text+"' and cntrctstat = 'Active'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    jorderID = dr[0].ToString();
                }
                dr.Close();
                int rowcount = dgvFees1.Rows.Count;
                cmd = "insert into jobfees_t (jorder_id, employer_id, fee_id, amount, jftype) values ";
                for(int x = 0; x < rowcount; x++)
                {
                    cmd2 = "select fee_id from genfees_t where feename = '" + dgvFees1.Rows[x].Cells[0].Value.ToString() + "';";
                    com = new MySqlCommand(cmd2, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        cmd += "('"+jorderID+"','"+empID+"','" + dr[0].ToString() + "','"+dgvFees1.Rows[x].Cells[1].Value.ToString()+"', '"+ dgvFees1.Rows[x].Cells[2].Value.ToString() + "')";
                    }
                    dr.Close();
                    if(x < rowcount - 1)
                    {
                        cmd += ",";
                    }
                }
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                cbEmployer1.Items.Clear();

                MessageBox.Show("Fees Added!", "Adding of Fees", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            connection.Close();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ucJobFeesAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Findstaff.Connection();
            connection = con.dbConnection();
            if (this.Visible == true)
            {
                connection.Open();
                cmd = "Select jorder_id from joborder_t where cntrctstat = 'Active';";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbEmployer1.Items.Add(dr[0]);
                }
                dr.Close();
                connection.Close();
            }
            else
            {
                cbEmployer1.Items.Clear();
                cbFees1.Items.Clear();
                cbFees2.Items.Clear();
            }
        }

        private void txtAmount1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAddFee1_Click(object sender, EventArgs e)
        {
            if(cbFees1.Text != "" && txtAmount1.Text != "" && cbPaymentType.Text !="")
            {
                dgvFees1.ColumnCount = 3;
                dgvFees1.Rows.Add(cbFees1.Text, txtAmount1.Text, cbPaymentType.Text);
                cbFees1.Items.Remove(cbFees1.Text);
                cbFees1.SelectedIndex = -1;
                txtAmount1.Clear();
                cbPaymentType.SelectedIndex = -1;
            }
        }

        private void btnRemoveFee_Click(object sender, EventArgs e)
        {
            if(dgvFees1.Rows.Count != 0)
            {
                cbFees1.Items.Add(dgvFees1.SelectedRows[0].Cells[0].Value.ToString());
                dgvFees1.Rows.Remove(dgvFees1.SelectedRows[0]);
            }
        }

        private void cbJobOrder1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbEmployer1.SelectedIndex != -1)
            {
                connection.Open();
                cmd = "select jobname from job_t j join joborder_t jo on j.job_id = jo.job_id join employer_t e on jo.employer_id = e.employer_id where e.employername = '"+cbEmployer1.Text+"';";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbJobName1.Items.Add(dr[0].ToString());
                }
                dr.Close();
                connection.Close();
            }
        }

        private void btnStart1_Click(object sender, EventArgs e)
        {
            if(cbEmployer1.Text != "" && cbJobName1.Text != "")
            {
                cbFees1.Enabled = true;
                txtAmount1.Enabled = true;
                cbPaymentType.Enabled = true;
                btnAddFee1.Enabled = true;
                btnRemoveFee.Enabled = true;
                btnAddAll.Enabled = true;
                connection.Open();
                string jorderID = "", type = "";
                cmd = "select jo.jorder_id from joborder_t jo join employer_t e on jo.employer_id = e.employer_id join job_t j on jo.job_id = j.job_id where e.employername = '" + cbEmployer1.Text + "' and j.jobname = '" + cbJobName1.Text + "' and cntrctstat = 'Active'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    jorderID = dr[0].ToString();
                }
                dr.Close();
                cmd = "select jt.jobtype_id from jobtype_t jt join job_t j on jt.jobtype_id = j.jobtype_id "
                    + "join joborder_t jo on jo.job_id = j.job_id where jo.jorder_id = '"+jorderID+"'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    type = dr[0].ToString();
                }
                dr.Close();

                cmd = "Select g.feename from genfees_t g join feetype_t f on g.fee_id = f.fee_id where f.jobtype_id = '"+type+"';";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbFees1.Items.Add(dr[0]);
                }
                dr.Close();

                connection.Close();
            }
        }
    }
}
