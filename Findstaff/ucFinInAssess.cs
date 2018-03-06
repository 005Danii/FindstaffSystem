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
    public partial class ucFinInAssess : UserControl
    {
        private MySqlConnection connection;
        private MySqlCommand com;
        private string cmd = "";
        private MySqlDataReader dr;

        public ucFinInAssess()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            rtbRemarks1.Clear();
            rtbRemarks2.Clear();
            rtbRemarks3.Clear();
            this.Hide();
        }

        private void ucFinInAssess_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Findstaff.Connection();
            connection = con.dbConnection();
        }

        private void btnFailInt_Click(object sender, EventArgs e)
        {
            string confirm = "";
            if (rtbRemarks1.Text != "")
            {
                confirm += "1st Remark: " + rtbRemarks1.Text;
                if (rtbRemarks2.Text != "")
                {
                    confirm += "\n2nd Remark: " + rtbRemarks2.Text;
                    if (rtbRemarks3.Text != "")
                    {
                        confirm += "\n3rd Remark: " + rtbRemarks3.Text;
                    }
                }
                DialogResult dr = MessageBox.Show("Are you sure you want to fail " + appname.Text + " with the ff. remarks?\n" + confirm, "Initial Interview Assessment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    connection.Open();
                    cmd = "update applications_t set finalinterviewstatus = 'Failed', initinterviewrem1 = '" + rtbRemarks1.Text + "', initinterviewrem2 = '" + rtbRemarks2.Text + "', initinterviewrem3 = '" + rtbRemarks3.Text + "' where app_no = '" + application.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    cmd = "update app_t set appstatus = 'Archived' where Concat(lname, ', ', fname, ' ', mname) = '" + appname.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Applicant " + appname.Text + " failed the Initial Interview!", "Initial Interview Status", MessageBoxButtons.OK, MessageBoxIcon.None);
                    connection.Close();
                    rtbRemarks1.Clear();
                    rtbRemarks2.Clear();
                    rtbRemarks3.Clear();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Remarks are needed to qualify the assessmemt.", "Initial Interview Assessment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPassInt_Click(object sender, EventArgs e)
        {
            string confirm = "";
            if (rtbRemarks1.Text != "")
            {
                confirm += "1st Remark: " + rtbRemarks1.Text;
                if (rtbRemarks2.Text != "")
                {
                    confirm += "\n2nd Remark: " + rtbRemarks2.Text;
                    if (rtbRemarks3.Text != "")
                    {
                        confirm += "\n3rd Remark: " + rtbRemarks3.Text;
                    }
                }
                DialogResult r = MessageBox.Show("Are you sure you want to pass " + appname.Text + " with the ff. remarks?\n" + confirm, "Initial Interview Assessment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    connection.Open();
                    string country = "", jobID = "", categID = "", jorderID = "", employer = "";
                    cmd = "select employer_id, job_id, category_id, jorder_id from applications_t where app_no = '" + application.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        employer = dr[0].ToString();
                        jobID = dr[1].ToString();
                        categID = dr[2].ToString();
                        jorderID = dr[3].ToString();
                    }
                    dr.Close();
                    cmd = "select country_id from employer_t where employer_id = '" + employer + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        country = dr[0].ToString();
                    }
                    dr.Close();
                    int ctr = 0;
                    cmd = "select reqapp from joborder_t where jorder_id = '" + jorderID + "' and job_id = '" + jobID + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        ctr = Convert.ToInt32(dr[0].ToString());
                    }
                    dr.Close();
                    if (ctr != 0)
                    {
                        int ctrB = 0, ctrJ = 0, ctrC = 0, x = 0, y = 0, z = 0;
                        cmd = "update applications_t set finalinterviewstatus = 'Passed' where app_no = '" + application.Text + "'";
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                        cmd = "update app_t set appstatus = 'Selected' where app_id = '" + applicant.Text + "'";
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                        cmd = "select count(req_id) from genreqs_t where allocation = 'Basic'";
                        com = new MySqlCommand(cmd, connection);
                        ctrB = int.Parse(com.ExecuteScalar() + "");
                        string[] reqIDBasic = new string[ctrB];
                        cmd = "select req_id from genreqs_t where allocation = 'Basic'";
                        com = new MySqlCommand(cmd, connection);
                        dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            reqIDBasic[x] = dr[0].ToString();
                            x++;
                        }
                        dr.Close();
                        cmd = "select count(req_id) from jobdocs_t where jorder_id = '" + jorderID + "' and job_id = '" + jobID + "'";
                        com = new MySqlCommand(cmd, connection);
                        ctrJ = int.Parse(com.ExecuteScalar() + "");
                        string[] reqIDJob = new string[ctrJ];
                        cmd = "select req_id from jobdocs_t where jorder_id = '" + jorderID + "' and job_id = '" + jobID + "'";
                        com = new MySqlCommand(cmd, connection);
                        dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            reqIDJob[y] = dr[0].ToString();
                            y++;
                        }
                        dr.Close();
                        cmd = "select count(req_id) from countryreqs_t where country_id = '" + country + "'";
                        com = new MySqlCommand(cmd, connection);
                        ctrC = int.Parse(com.ExecuteScalar() + "");
                        string[] reqIDCountry = new string[ctrC];
                        cmd = "select req_id from countryreqs_t where country_id = '" + country + "'";
                        com = new MySqlCommand(cmd, connection);
                        dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            reqIDCountry[z] = dr[0].ToString();
                            z++;
                        }
                        dr.Close();
                        x = 0; y = 0; z = 0;
                        for (x = 0; x < ctrB; x++)
                        {
                            cmd = "insert into appdoc_t values ('" + application.Text + "','" + applicant.Text + "','" + Convert.ToInt32(reqIDBasic[x]) + "','Required');";
                            com = new MySqlCommand(cmd, connection);
                            com.ExecuteNonQuery();
                        }
                        for (y = 0; y < ctrJ; y++)
                        {
                            cmd = "insert into appdoc_t values ('" + application.Text + "','" + applicant.Text + "','" + Convert.ToInt32(reqIDJob[y]) + "','Required');";
                            com = new MySqlCommand(cmd, connection);
                            com.ExecuteNonQuery();
                        }
                        for (z = 0; z < ctrC; z++)
                        {
                            cmd = "insert into appdoc_t values ('" + application.Text + "','" + applicant.Text + "','" + Convert.ToInt32(reqIDCountry[z]) + "','Required');";
                            com = new MySqlCommand(cmd, connection);
                            com.ExecuteNonQuery();
                        }
                        MessageBox.Show(appname.Text + " Passed Final Interview!", "Final Interview Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmd = "update joborder_t set reqapp = reqapp - 1 where jorder_id = '" + jorderID + "' and job_id = '" + jobID + "'";
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Required applicants for the job specified is already satisfied.", "Final Interview Contraint");
                    }
                    connection.Close();
                    rtbRemarks1.Clear();
                    rtbRemarks2.Clear();
                    rtbRemarks3.Clear();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Remarks are needed to qualify the assessmemt.", "Initial Interview Assessment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void rtbRemarks1_TextChanged(object sender, EventArgs e)
        {
            if (rtbRemarks1.Text != "")
            {
                rtbRemarks2.Enabled = true;
            }
            else
            {
                rtbRemarks2.Enabled = false;
                rtbRemarks2.Clear();
            }
        }

        private void rtbRemarks2_TextChanged(object sender, EventArgs e)
        {
            if (rtbRemarks2.Text != "")
            {
                rtbRemarks3.Enabled = true;
            }
            else
            {
                rtbRemarks3.Enabled = false;
            }
        }
    }
}
