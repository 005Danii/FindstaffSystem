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
    public partial class ucInIntAssess : UserControl
    {
        private MySqlConnection connection;
        private MySqlCommand com;
        private string cmd = "";

        public ucInIntAssess()
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

        private void btnPassInt_Click(object sender, EventArgs e)
        {
            string confirm = "";
            if(rtbRemarks1.Text != "")
            {
                confirm += "1st Remark: " + rtbRemarks1.Text;
                if(rtbRemarks2.Text != "")
                {
                    confirm += "\n2nd Remark: " + rtbRemarks2.Text;
                    if(rtbRemarks3.Text != "")
                    {
                        confirm += "\n3rd Remark: " + rtbRemarks3.Text;
                    }
                }
                DialogResult dr = MessageBox.Show("Are you sure you want to pass " + appname.Text + " with the ff. remarks?\n" + confirm, "Initial Interview Assessment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    connection.Open();
                    cmd = "update applications_t set initinterviewstatus = 'Passed', initinterviewrem1 = '" + rtbRemarks1.Text + "', initinterviewrem2 = '" + rtbRemarks2.Text + "', initinterviewrem3 = '" + rtbRemarks3.Text + "' where app_no = '" + application.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    cmd = "update app_t set appstatus = 'For Final Interview' where Concat(lname, ', ', fname, ' ', mname) = '" + appname.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Applicant " + appname.Text + " passed the Initial Interview!", "Initial Interview Status", MessageBoxButtons.OK, MessageBoxIcon.None);
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

        private void ucInIntAssess_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
        }

        private void rtbRemarks1_TextChanged(object sender, EventArgs e)
        {
            if(rtbRemarks1.Text != "")
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
                    cmd = "update applications_t set initinterviewstatus = 'Failed', initinterviewrem1 = '" + rtbRemarks1.Text + "', initinterviewrem2 = '" + rtbRemarks2.Text + "', initinterviewrem3 = '" + rtbRemarks3.Text + "' where app_no = '" + application.Text + "'";
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
    }
}
