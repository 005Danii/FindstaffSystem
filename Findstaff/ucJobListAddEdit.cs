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
    public partial class ucJobListAddEdit : UserControl
    {
        private MySqlConnection connection;
        private MySqlDataReader dr;
        MySqlCommand com = new MySqlCommand();
        private string cmd = "";


        public ucJobListAddEdit()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            string empID = "", catID = "", jobID = "", gender = "";
            connection.Open();
            if (cbEmployer1.Text != "" || cbCategory1.Text != "" || cbJob1.Text != "" || nddEmployees1.Value != 0 || txtSalary1.Text != ""
                || dgvSkills1.Rows.Count != 0 || dgvReqdDocs1.Rows.Count != 0 || !(cbMale.Checked == false) || !(cbFemale.Checked == false))
            {
                DialogResult r = MessageBox.Show("Do you want to add the job order with the ff. description?\nEmployer: " + cbEmployer1.Text
                    + "\nCategory: " + cbCategory1.Text + "\nJob Title: " + cbJob1.Text, "Add Job Order Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    cmd = "select employer_id from employer_t where employername = '" + cbEmployer1.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        empID = dr[0].ToString();
                    }
                    dr.Close();
                    cmd = "select category_id from jobcategory_t where categoryname = '" + cbCategory1.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        catID = dr[0].ToString();
                    }
                    dr.Close();
                    cmd = "select job_id from job_t where jobname = '" + cbJob1.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        jobID = dr[0].ToString();
                    }
                    dr.Close();
                    if (cbMale.Checked == true)
                    {
                        gender = cbMale.Text;
                    }
                    else if (cbFemale.Checked == true)
                    {
                        gender = cbFemale.Text;
                    }
                    else if (cbMale.Checked == true && cbFemale.Checked == true)
                    {
                        gender = "All";
                    }
                    cmd = "Select count(*) from joborder_t where  employer_id = '" + empID + "' and category_id = '" + catID + "' and job_id = '" + jobID + "' and cntrctstart = '" + dtp1.Value.ToString("yyyy-MM-dd") + "'";
                    com = new MySqlCommand(cmd, connection);
                    int ctr = int.Parse(com.ExecuteScalar() + "");
                    if (ctr == 0)
                    {
                        cmd = "insert into joborder_t (Employer_id, category_id, job_id, reqapp, salary, gender, heightreq, weightreq, cntrctstart, cntrctend, cntrctstat) "
                        + "values ('" + empID + "','" + catID + "','" + jobID + "','" + nddEmployees1.Value + "','" + txtSalary1.Text + "','" + gender + "','" + txtHeight.Text + "','" + txtWeight.Text + "', '" + dtp1.Value.ToString("yyyy-MM-dd") + "','" + (Convert.ToInt32(dtp1.Value.ToString("yyyy")) + 5).ToString() + "-" + dtp1.Value.ToString("MM") + "-" + dtp1.Value.ToString("dd") + "', 'Active')";
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                        string cmd2 = "", joID = "", sID = "", reqID = "";
                        cmd = "Select max(jorder_id) from joborder_t";
                        com = new MySqlCommand(cmd, connection);
                        dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            joID = dr[0].ToString();
                        }
                        dr.Close();
                        cmd = "insert into jobskills_t values ";
                        for (int x = 0; x < dgvSkills1.Rows.Count; x++)
                        {
                            cmd2 = "select skill_id from genskills_t where skillname = '" + dgvSkills1.Rows[x].Cells[0].Value.ToString() + "'";
                            com = new MySqlCommand(cmd2, connection);
                            dr = com.ExecuteReader();
                            while (dr.Read())
                            {
                                sID = dr[0].ToString();
                            }
                            dr.Close();
                            cmd += "('" + joID + "','" + empID + "','" + catID + "','" + jobID + "','" + sID + "','" + dgvSkills1.Rows[x].Cells[1].Value.ToString().Substring(0, 1) + "')";
                            if (x < dgvSkills1.Rows.Count - 1)
                            {
                                cmd += ",";
                            }
                        }
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                        cmd = "insert into jobdocs_t values ";
                        for (int x = 0; x < dgvReqdDocs1.Rows.Count; x++)
                        {
                            cmd2 = "select req_id from genreqs_t where reqname = '" + dgvReqdDocs1.Rows[x].Cells[0].Value.ToString() + "'";
                            com = new MySqlCommand(cmd2, connection);
                            dr = com.ExecuteReader();
                            while (dr.Read())
                            {
                                reqID = dr[0].ToString();
                            }
                            dr.Close();
                            cmd += "('" + joID + "','" + empID + "','" + catID + "','" + jobID + "','" + reqID + "')";
                            if (x < dgvReqdDocs1.Rows.Count - 1)
                            {
                                cmd += ",";
                            }
                        }
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Job Order Added!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();

                        cbEmployer1.Items.Clear();
                        cbCategory1.Items.Clear();
                        cbJob1.Items.Clear();
                        cbMale.Checked = false;
                        cbFemale.Checked = false;
                        nddEmployees1.Value = 1;
                        txtSalary1.Clear();
                        txtHeight.Clear();
                        txtWeight.Clear();
                        for (int x = 0; x < dgvSkills1.Rows.Count; x++)
                        {
                            cbSkillName.Items.Add(dgvSkills1.Rows[x].Cells[0].Value.ToString());
                        }
                        dgvSkills1.Rows.Clear();
                        for (int x = 0; x < dgvReqdDocs1.Rows.Count; x++)
                        {
                            cbSkillName.Items.Add(dgvReqdDocs1.Rows[x].Cells[0].Value.ToString());
                        }
                        dgvReqdDocs1.Rows.Clear();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("A job record in the list exists.", "Add Job to Listings Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Values Present", "Add Job Order Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            txtJobOrder1.Text = "";
            cbEmployer1.Items.Clear();
            cbCategory1.Items.Clear();
            cbJob1.Items.Clear();
            cbMale.Checked = false;
            cbFemale.Checked = false;
            nddEmployees1.Value = 1;
            txtSalary1.Clear();
            txtHeight.Clear();
            txtWeight.Clear();
            cbSkillName.Items.Clear();
            cbReqName.Items.Clear();
            for (int x = 0; x < dgvSkills1.Rows.Count; x++)
            {
                cbSkillName.Items.Add(dgvSkills1.Rows[x].Cells[0].Value.ToString());
            }
            dgvSkills1.Rows.Clear();
            for (int x = 0; x < dgvReqdDocs1.Rows.Count; x++)
            {
                cbSkillName.Items.Add(dgvReqdDocs1.Rows[x].Cells[0].Value.ToString());
            }
            dgvReqdDocs1.Rows.Clear();
            this.Hide();
        }

        private void btnEditJob_Click(object sender, EventArgs e)
        {
            connection.Open();
            int err = 0;
            string empID = "", categID = "", jobID = "", gender = "";
            cmd = "Delete from jobdocs_t where jorder_id = '" + lblJOrder.Text + "'";
            com = new MySqlCommand(cmd, connection);
            com.ExecuteNonQuery();
            cmd = "Delete from jobskills_t where jorder_id = '" + lblJOrder.Text + "'";
            com = new MySqlCommand(cmd, connection);
            com.ExecuteNonQuery();

            if (cbMale2.Checked == true && cbFemale2.Checked == false)
            {
                gender = "Male";
            }
            else if (cbMale2.Checked == true && cbFemale2.Checked == false)
            {
                gender = "Female";
            }
            else if (cbMale2.Checked == true && cbFemale2.Checked == true)
            {
                gender = "All";
            }
            else
            {
                err++;
            }
            if (dgvSkills2.Rows.Count == 0 || dgvReqDocs2.Rows.Count == 0)
            {
                err++;
            }
            if (txtSalary2.Text == "")
            {
                err++;
            }
            if(err == 0)
            {
                cmd = "select employer_id from employer_t where employername = '" + cbEmployer2.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    empID = dr[0].ToString();
                }
                dr.Close();
                cmd = "select category_id from jobcategory_t where categoryname = '" + cbCategory2.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    categID = dr[0].ToString();
                }
                dr.Close();
                cmd = "select job_id from job_t where jobname = '" + cbJobName2.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    jobID = dr[0].ToString();
                }
                dr.Close();
                cmd = "update joborder_t set employer_id = '"+empID+"', category_id = '"+categID+"', job_id = '"+jobID+"', reqapp = '"+nddEmployees2.Value+"', salary = '"+txtSalary2.Text+"', gender = '"+gender+"', heightreq = '"+txtHeight2.Text+"', weightreq = '"+txtWeight2.Text+"'"
                    + "cntrctstart = '"+dtp2.Value.ToString("yyyy-MM-dd")+"', cntrctend = '"+ (Convert.ToInt32(dtp2.Value.ToString("yyyy")) + 5).ToString() + "-" + dtp2.Value.ToString("MM") + "-" + dtp2.Value.ToString("dd") + "' "
                    + "where jorder_id = '"+lblJOrder.Text+"'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                cmd = "update applications_t set employer_id = '" + empID + "', category_id = '" + categID + "', job_id = '" + jobID + "' where jorder_id = '" + lblJOrder.Text + "'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                string cmd2 = "", sID = "", reqID = "";
                cmd = "insert into jobskills_t values ";
                for (int x = 0; x < dgvSkills2.Rows.Count; x++)
                {
                    cmd2 = "select skill_id from genskills_t where skillname = '" + dgvSkills2.Rows[x].Cells[0].Value.ToString() + "'";
                    com = new MySqlCommand(cmd2, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        sID = dr[0].ToString();
                    }
                    dr.Close();
                    cmd += "('" + lblJOrder.Text + "','" + empID + "','" + categID + "','" + jobID + "','" + sID + "','" + dgvSkills2.Rows[x].Cells[1].Value.ToString().Substring(0, 1) + "')";
                    if (x < dgvSkills2.Rows.Count - 1)
                    {
                        cmd += ",";
                    }
                }
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                cmd = "insert into jobdocs_t values ";
                for (int x = 0; x < dgvReqDocs2.Rows.Count; x++)
                {
                    cmd2 = "select req_id from genreqs_t where reqname = '" + dgvReqDocs2.Rows[x].Cells[0].Value.ToString() + "'";
                    com = new MySqlCommand(cmd2, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        reqID = dr[0].ToString();
                    }
                    dr.Close();
                    cmd += "('" + lblJOrder.Text + "','" + empID + "','" + categID + "','" + jobID + "','" + reqID + "')";
                    if (x < dgvReqDocs2.Rows.Count - 1)
                    {
                        cmd += ",";
                    }
                }
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Job Order Edit Saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                dgvSkills2.Rows.Clear();
                dgvReqDocs2.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Empty Fields Present (with the exception of height and weight)!", "Edit Job Order Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            cbEmployer2.Items.Clear();
            cbCategory2.Items.Clear();
            cbJobName2.Items.Clear();
            cbMale2.Checked = false;
            cbFemale2.Checked = false;
            dgvReqDocs2.Rows.Clear();
            dgvSkills2.Rows.Clear();
            cbSkillName2.Items.Clear();
            cbReqName2.Items.Clear();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbEmployer1.Text != "")
            {
                cbEmployer1.Enabled = false;
                btnAddSkill.Enabled = true;
                btnReqAdd.Enabled = true;
                btnAddAll.Enabled = true;
            }
        }

        private void ucJobListAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            if(this.Visible == true)
            {
                connection.Open();
                cmd = "Select employername from employer_t";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbEmployer1.Items.Add(dr[0]);
                    cbEmployer2.Items.Add(dr[0]);
                }
                dr.Close();

                cmd = "Select categoryname from jobcategory_t";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbCategory1.Items.Add(dr[0]);
                    cbCategory2.Items.Add(dr[0]);
                }
                dr.Close();
                
                cmd = "Select skillname from genskills_t where skilltype = 'General'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbSkillName.Items.Add(dr[0]);
                    cbSkillName2.Items.Add(dr[0]);
                }

                for(int x = 0; x < dgvSkills2.Rows.Count; x++)
                {
                    if (cbSkillName2.Items.Contains(dgvSkills2.Rows[x].Cells[0].Value.ToString()))
                    {
                        cbSkillName2.Items.Remove(dgvSkills2.Rows[x].Cells[0].Value.ToString());
                    }
                }

                dr.Close();
                cmd = "Select Reqname from genreqs_t where allocation = 'job'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbReqName.Items.Add(dr[0]);
                    cbReqName2.Items.Add(dr[0]);
                }
                dr.Close();

                for(int x = 0; x < dgvReqDocs2.Rows.Count; x++)
                {
                    if (cbReqName2.Items.Contains(dgvReqDocs2.Rows[x].Cells[0].Value.ToString()))
                    {
                        cbReqName2.Items.Remove(dgvReqDocs2.Rows[x].Cells[0].Value.ToString());
                    }
                }

                cmd = "select count(*) from joborder_t";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    txtJobOrder1.Text = (Convert.ToUInt32(dr[0].ToString()) + 1).ToString();
                }
                dr.Close();
                connection.Close();
            }
            else
            {
                cbEmployer1.Items.Clear();
                cbEmployer2.Items.Clear();
                cbCategory1.Items.Clear();
                cbCategory2.Items.Clear();
                cbSkillName.Items.Clear();
                cbSkillName2.Items.Clear();
                cbReqName.Items.Clear();
                cbReqName2.Items.Clear();
            }
            dtp1.MinDate = DateTime.Now;
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            if(cbSkillName.Text != "" && cbProf.Text != "")
            {
                dgvSkills1.ColumnCount = 2;
                dgvSkills1.Rows.Add(cbSkillName.Text, cbProf.Text);
                cbSkillName.Items.Remove(cbSkillName.Text);
                cbProf.SelectedIndex = -1;
            }
        }

        private void btnRemoveSkill_Click(object sender, EventArgs e)
        {
            if(dgvSkills1.Rows.Count != 0)
            {
                cbSkillName.Items.Add(dgvSkills1.SelectedRows[0].Cells[0].Value.ToString());
                dgvSkills1.Rows.Remove(dgvSkills1.SelectedRows[0]);
            }
        }

        private void btnReqAdd_Click(object sender, EventArgs e)
        {
            if (cbReqName.Text != "")
            {
                dgvReqdDocs1.ColumnCount = 1;
                dgvReqdDocs1.Rows.Add(cbReqName.Text);
                cbReqName.Items.Remove(cbReqName.Text);
            }
        }

        private void btnReqRemove_Click(object sender, EventArgs e)
        {
            if (dgvReqdDocs1.Rows.Count != 0)
            {
                cbReqName.Items.Add(dgvReqdDocs1.SelectedRows[0].Cells[0].Value.ToString());
                dgvReqdDocs1.Rows.Remove(dgvReqdDocs1.SelectedRows[0]);
            }
        }

        private void cbCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            cbJob1.Items.Clear();
            cmd = "select j.jobname from job_t j join jobcategory_t c on j.category_id = c.category_id where c.categoryname = '"+cbCategory1.Text+"'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                cbJob1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            connection.Close();
        }

        private void txtReqApp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSalary1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbEmployer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            cmd = "select country_id from employer_t where employername = '"+cbEmployer1.Text+"'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                cmd = "select symbol from country_t where country_id = '" + dr[0].ToString() +"'";
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
            txtSalaryCur.Text = symbol;
            connection.Close();
        }

        private void cbJob1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            cbSkillName.Items.Clear();
            cmd = "select skillname from genskills_t where skilltype = 'General'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                cbSkillName.Items.Add(dr[0]);
            }
            dr.Close();
            string jobID = "";
            cmd = "select job_id from job_t where jobname = '"+cbJob1.Text+"'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                jobID = dr[0].ToString();
            }
            dr.Close();
            cmd = "select g.skillname from genskills_t g join specskills_t s on g.skill_id = s.skill_id where s.job_id = '"+jobID+"'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                cbSkillName.Items.Add(dr[0]);
            }
            dr.Close();
            connection.Close();
        }

        private void txtSalary2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHeight2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtWeight2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            cbJobName2.Items.Clear();
            cmd = "select j.jobname from job_t j join jobcategory_t c on j.category_id = c.category_id where c.categoryname = '" + cbCategory2.Text + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                cbJobName2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            connection.Close();
        }

        private void cbEmployer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            cmd = "select country_id from employer_t where employername = '" + cbEmployer2.Text + "'";
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
            txtSalaryCur2.Text = symbol;
            connection.Close();
        }

        private void btnAddSkills2_Click(object sender, EventArgs e)
        {
            if(cbSkillName2.Text != "" && cbProf2.Text != "")
            {
                dgvSkills2.Rows.Add(cbSkillName2.Text, cbProf2.Text);
                cbSkillName2.Items.Remove(cbSkillName2.Text);
                cbProf2.SelectedIndex = -1;
            }
        }

        private void btnRemoveSkill2_Click(object sender, EventArgs e)
        {
            if(dgvSkills2.Rows.Count != 0)
            {
                cbSkillName2.Items.Add(dgvSkills2.SelectedRows[0].Cells[0].Value.ToString());
                dgvSkills2.Rows.Remove(dgvSkills2.SelectedRows[0]);
            }
        }

        private void btnAddDoc2_Click(object sender, EventArgs e)
        {
            if(cbReqName2.Text != "")
            {
                dgvReqDocs2.Rows.Add(cbReqName2.Text);
                cbReqName2.Items.Remove(cbReqName2.Text);
            }
        }

        private void btnRemoveDoc2_Click(object sender, EventArgs e)
        {
            if (dgvReqDocs2.Rows.Count != 0)
            {
                cbReqName2.Items.Add(dgvReqDocs2.SelectedRows[0].Cells[0].Value.ToString());
                dgvReqDocs2.Rows.Remove(dgvReqDocs2.SelectedRows[0]);
            }
        }
    }
}
