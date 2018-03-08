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
    public partial class ucJobTypeAddEdit : UserControl
    {
        MySqlConnection connection;
        MySqlCommand com;
        private string cmd = "";

        public ucJobTypeAddEdit()
        {
            InitializeComponent();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            txtType.Clear();
            this.Hide();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            if(txtType.Text != "")
            {
                connection.Open();
                cmd = "select count(typename) from jobtype_t where typename = '" + txtType.Text + "'";
                com = new MySqlCommand(cmd, connection);
                int ctr = int.Parse(com.ExecuteScalar() + "");
                if (ctr == 0)
                {
                    cmd = "insert into jobtype_t (typename) values ('" + txtType.Text + "')";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("New Job Type Added", "Add Job Type", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txtType.Clear();
                    this.Hide();
                }
                connection.Close();
                
            }
        }

        private void ucJobTypeAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            string cmd = "";
            if (txtType2.Text == "")
            {
                MessageBox.Show("Job Type field must not be empty.", "Empty Job Type Name Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmd = "select count(typename) from jobtype_t where typename = '" + txtType2.Text + "'";
                com = new MySqlCommand(cmd, connection);
                int ctr = int.Parse(com.ExecuteScalar() + "");
                if (ctr == 0)
                {
                    DialogResult rs = MessageBox.Show("Are you sure you want to update the record with the following details?"
                    + "\nJob Type ID: " + txtID.Text + "\nNew Type Name: " + txtType2.Text, "Confirmation", MessageBoxButtons.YesNo);
                    if (rs == DialogResult.Yes)
                    {
                        cmd = "Update jobtype_t set typename = '" + txtType2.Text + "' where jobtype_id = '" + txtID.Text + "';";
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Changes Saved!", "Updated Job Type Record!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtID.Clear();
                        txtType2.Clear();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Job Type already exists.", "Update Job Type Record Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            connection.Close();
        }
    }
}
