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
    public partial class ucEmployerTermination : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        private string cmd = "";

        public ucEmployerTermination()
        {
            InitializeComponent();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            rtbReason.Clear();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Do you really want to delete the employer? All active applications will be set to inactive and all applicants", "Delete Employer Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
            {
                connection.Open();
                string employerID = "";
                int cnt = 0;
                cmd = "select employer_id from employer_t where employername = '" + txtEmp1.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    employerID = dr[0].ToString();
                }
                dr.Close();
                cmd = "select count(app_id) where employer_id = '"+employerID+"'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cnt = Convert.ToInt32(dr[0]);
                }
                dr.Close();
                string[] appID = new string[cnt];
                cnt = 0;
                cmd = "select app_id from applications_t where employer_id = '" + employerID + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    appID[cnt] = dr[0].ToString();
                    cnt++;
                }
                dr.Close();
                for(int x = 0; x < cnt; x++)
                {
                    cmd = "update app_t set appstatus = 'For Selection' where app_id = '" + appID[x] + "'";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                }
                cmd = "update applications_t set appstats = 'Inactive' where employer_id = '"+employerID+"'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                connection.Close();
                cmd = "update employer_t set empstatus = 'Terminated', Reasons = '"+rtbReason.Text+"', tdate = current_date() where employer_id = '" + employerID + "'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                cmd = "update joborder_t set cntrctstat = 'Discontinued' where employer_id = '" + employerID + "'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Employer Terminated. All active job orders are discontinued.\nAll applicants for the job orders are set to 'For Selection' status and all applications for the employer are set to inactive");
                this.Hide();
            }
        }

        private void ucEmployerTermination_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
        }
    }
}
