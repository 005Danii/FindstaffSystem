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
using System.Text.RegularExpressions;

namespace Findstaff
{
    public partial class ucFeesAddEdit : UserControl
    {
        private MySqlConnection connection;
        private MySqlCommand com = new MySqlCommand();
        private string cmd = "";
        private MySqlDataReader dr;

        public ucFeesAddEdit()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            int ctr = 0;
            string fID = "", cmd2 = "";
            if(dgvFees.Rows.Count != 0)
            {
                string check = "Select Count(Feename) from Genfees_t where Feename = '" + txtFees1.Text + "'";
                com = new MySqlCommand(check, connection);
                ctr = int.Parse(com.ExecuteScalar() + "");
                if (ctr == 0)
                {
                    string cmd = "Insert into Genfees_t (Feename) values ('" + txtFees1.Text + "')";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    cmd = "select fee_id from genfees_t where feename = '"+txtFees1.Text+"'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        fID = dr[0].ToString();
                    }
                    dr.Close();
                    cmd = "Insert into feetype_t (fee_id, jobtype_id) values ";
                    for (int x = 0; x < dgvFees.Rows.Count; x++)
                    {
                        cmd2 = "select jobtype_id from jobtype_t where typename = '" + dgvFees.Rows[x].Cells[0].Value.ToString() + "'";
                        com = new MySqlCommand(cmd2, connection);
                        dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            cmd += "('" + fID + "','" + dr[0].ToString() + "')";
                        }
                        dr.Close();
                        if (x < dgvFees.Rows.Count - 1)
                        {
                            cmd += ",";
                        }
                    }
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Added!", "Added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFees1.Clear();
                    cbType1.Items.Clear();
                    dgvFees.Rows.Clear();
                    this.Hide();

                }
                else if (ctr != 0)
                {
                    MessageBox.Show("Record already exists.", "Error Message");
                }
            }
            else
            {
                MessageBox.Show("Fee Text Field Empty","Add Fee Error");
            }
            connection.Close();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            txtFees1.Clear();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            string cmd = "";
            if(txtFee2.Text == "")
            {
                MessageBox.Show("Fee name must not be empty.", "Empty Fee Name Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult rs = MessageBox.Show("Are you sure You want to update the record with the following details?"
                    + "\nFee ID: " + txtID.Text + "\nNew Fee Name: " + txtFee2.Text, "Confirmation", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    cmd = "select count(feename) from genfees_t where feename = '" + txtFee2.Text + "'";
                    com = new MySqlCommand(cmd, connection);
                    int ctr = int.Parse(com.ExecuteScalar() + "");
                    if (ctr == 0)
                    {
                        cmd = "Update Genfees_t set feename = '" + txtFee2.Text + "' where fee_id = '" + txtID.Text + "';";
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Fee already exists. Proceeding with other updates", "Update Fee Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if(dgvFees1.Rows.Count != 0)
                    {
                        cmd = "delete from feetype_t where fee_id = '" + txtID.Text + "'";
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                        string cmd2 = "";
                        cmd = "Insert into feetype_t (fee_id, jobtype_id) values ";
                        for (int x = 0; x < dgvFees1.Rows.Count; x++)
                        {
                            cmd2 = "select jobtype_id from jobtype_t where typename = '" + dgvFees1.Rows[x].Cells[0].Value.ToString() + "'";
                            com = new MySqlCommand(cmd2, connection);
                            dr = com.ExecuteReader();
                            while (dr.Read())
                            {
                                cmd += "('" + txtID.Text + "','" + dr[0].ToString() + "')";
                            }
                            dr.Close();
                            if (x < dgvFees1.Rows.Count - 1)
                            {
                                cmd += ",";
                            }
                        }
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Changes Saved!", "Update Fee Record!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Fee should be available to at least one job type.", "Edit Fee Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtID.Clear();
                    txtFee2.Clear();
                    this.Hide();
                }
            }
            connection.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtFee2.Clear();
            this.Hide();
        }

        private void ucFeesAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            if(this.Visible == true)
            {
                connection.Open();
                cmd = "select typename from jobtype_t";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbType1.Items.Add(dr[0]);
                    cbType2.Items.Add(dr[0]);
                }
                dr.Close();

                cmd = "Select f.Fee_ID, j.typename'Requirement Name' from genfees_t f join feetype_t t"
                + " on f.fee_id = t.fee_id join jobtype_t j on j.jobtype_id = t.jobtype_id"
                + " where f.feename = '" + txtFee2.Text + "'";
                int y = 0;
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    y++;
                }
                dr.Close();
                connection.Close();
            }
            else
            {
                cbType1.Items.Clear();
                cbType2.Items.Clear();
                dgvFees1.Rows.Clear();
            }
        }

        private void txtFees1_TextChanged(object sender, EventArgs e)
        {
            if (!(new Regex(@"^[a-zA-Z ]*$").IsMatch(txtFees1.Text)))
            {
                txtFees1.Text = "";
            }
        }

        private void txtFee2_TextChanged(object sender, EventArgs e)
        {
            if (!(new Regex(@"^[a-zA-Z ]*$").IsMatch(txtFee2.Text)))
            {
                txtFee2.Text = "";
            }
        }

        private void btnAddFee1_Click(object sender, EventArgs e)
        {
            if(txtFees1.Text != "" && cbType1.Text != "")
            {
                dgvFees.ColumnCount = 1;
                dgvFees.Rows.Add(cbType1.Text);
                cbType1.Items.Remove(cbType1.Text);
                cbType1.SelectedIndex = -1;
            }
        }

        private void btnRemoveType_Click(object sender, EventArgs e)
        {
            if(dgvFees.Rows.Count != 0)
            {
                cbType1.Items.Add(dgvFees.SelectedRows[0].Cells[0].Value.ToString());
                dgvFees.Rows.Remove(dgvFees.SelectedRows[0]);
            }
        }

        private void btnAddFee2_Click(object sender, EventArgs e)
        {
            if(cbType2.Text != "")
            {
                dgvFees1.Rows.Add(cbType2.Text);
                cbType2.Items.Remove(cbType2.Text);
            }
        }

        private void btnRemoveFee1_Click(object sender, EventArgs e)
        {
            if(dgvFees1.Rows.Count != 0)
            {
                cbType2.Items.Add(dgvFees1.SelectedRows[0].Cells[0].Value.ToString());
                dgvFees1.Rows.Remove(dgvFees1.SelectedRows[0]);
            }
        }
    }
}
