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
    public partial class ucFees : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        private string cmd = "";
        MySqlDataReader dr;

        public ucFees()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucFeesAddEdit.Dock = DockStyle.Fill;
            ucFeesAddEdit.Visible = true;
            ucFeesAddEdit.panel1.Visible = true;
            ucFeesAddEdit.panel2.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvFees.Rows.Count != 0)
            {
                ucFeesAddEdit.txtID.Text = dgvFees.SelectedRows[0].Cells[0].Value.ToString();
                ucFeesAddEdit.txtFee2.Text = dgvFees.SelectedRows[0].Cells[1].Value.ToString();
                ucFeesAddEdit.Dock = DockStyle.Fill;
                ucFeesAddEdit.Visible = true;
                ucFeesAddEdit.panel1.Visible = false;
                ucFeesAddEdit.panel2.Visible = true;
                connection.Open();
                cmd = "Select j.typename from genfees_t f join feetype_t t"
                + " on f.fee_id = t.fee_id join jobtype_t j on j.jobtype_id = t.jobtype_id"
                + " where f.feename = '" + ucFeesAddEdit.txtFee2.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ucFeesAddEdit.dgvFees1.Rows.Add(dr[0]);
                }
                dr.Close();
                
                for (int x = 0; x < ucFeesAddEdit.dgvFees1.Rows.Count; x++)
                {
                    if (ucFeesAddEdit.cbType2.Items.Contains(ucFeesAddEdit.dgvFees1.Rows[x].Cells[0].Value.ToString()))
                    {
                        ucFeesAddEdit.cbType2.Items.Remove(ucFeesAddEdit.dgvFees1.Rows[x].Cells[0].Value.ToString());
                    }
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("No record available for edit.","No Existing Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            DialogResult r = MessageBox.Show("Do you want to delete the fee " + dgvFees.SelectedRows[0].Cells[1].Value.ToString() + "?", "Delete Skill confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                string cmd = "delete from genfees_t where fee_id = '" + dgvFees.SelectedRows[0].Cells[0].Value.ToString() + "';";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                dgvFees.Rows.Remove(dgvFees.SelectedRows[0]);
                MessageBox.Show("Fee Deleted!", "Fee Record Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
        }

        public void searchData(string valueToFind)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            string cmd = "Select g.Fee_ID'Fee ID', g.Feename'Fee Name', count(f.fee_id)'No. of Types' from Genfees_t g join feetype_t f "
                + "on g.fee_id = f.fee_id "
                + "WHERE concat(g.Fee_ID , ' ', g.Feename) LIKE '%" + valueToFind + "%' group by g.fee_id ";
            com = new MySqlCommand(cmd, connection);
            com.ExecuteNonQuery();

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvFees.DataSource = table;
        }

        private void txtFeeName_TextChanged(object sender, EventArgs e)
        {
            searchData(txtFeeName.Text);
        }

        private void ucFees_Load(object sender, EventArgs e)
        {
            searchData(txtFeeName.Text);
        }

        private void ucFeesAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            string com = "Select g.Fee_ID'Fee ID', g.Feename'Fee Name', count(f.fee_id)'No. of Types' from Genfees_t g join feetype_t f "
                + "on g.fee_id = f.fee_id "
                + "group by g.fee_id";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(com, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvFees.DataSource = ds.Tables[0];
                }
            }
        }

        private void ucFeesAddEdit_VisibleChanged_1(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            string com = "Select g.Fee_ID'Fee ID', g.Feename'Fee Name', count(f.fee_id)'No. of Types' from Genfees_t g join feetype_t f "
                + "on g.fee_id = f.fee_id "
                + "group by g.fee_id";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(com, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvFees.DataSource = ds.Tables[0];
                }
            }
        }
    }
}
