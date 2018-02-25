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
                cmd = "select employer_id from employer_t where employername = '" + txtEmp1.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    employerID = dr[0].ToString();
                }
                dr.Close();
                cmd = "update applications_t set appstats = 'Inactive' where employer_id = '"+employerID+"'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                connection.Close();
                cmd = "update employer_t set empstatus = 'Terminated', Reasons = '"+rtbReason.Text+"', tdate = current_date() where employer_id = '" + employerID + "'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
            }
        }
    }
}
