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
    public partial class ucAccoView : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        MySqlDataAdapter adapter;
        private string cmd = "";
        private string appNo = "", appName = "", fee = "";
        private string jorder = "", jobID = "", empID = "", jobName = "", employerName = "", appID = "", jobtype = "";
        private string[] fees;
        private decimal total = 0;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            if(panel1.Visible == true)
            {
                dgvViewAcco.Enabled = false;
                btnClose.Enabled = false;
                btnPayBal.Enabled = false;
            }
            else
            {
                dgvViewAcco.Enabled = true;
                btnClose.Enabled = true;
                btnPayBal.Enabled = true;
            }
        }

        private void btnGenerateReceipt_Click(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (Convert.ToDecimal(txtAmount.Text) >= Convert.ToDecimal(lblBalance.Text))
            {
                int ctr = 0;
                cmd = "select count(*) from receipts_t";
                com = new MySqlCommand(cmd, connection);
                ctr = int.Parse(com.ExecuteScalar() + "");
                string payID = "";
                if (ctr.ToString().Length == 1)
                {
                    payID = "P0000" + ctr.ToString();
                }
                else if (ctr.ToString().Length == 2)
                {
                    payID = "P000" + ctr.ToString();
                }
                else if (ctr.ToString().Length == 3)
                {
                    payID = "P00" + ctr.ToString();
                }
                else if (ctr.ToString().Length == 4)
                {
                    payID = "P0" + ctr.ToString();
                }
                else if (ctr.ToString().Length == 5)
                {
                    payID = "P" + ctr.ToString();
                }
                if (payID != "")
                {
                    cmd = "insert into receipts_t values ('" + payID + "','" + appID + "','" + lblBalance.Text + "','" + txtAmount.Text + "','" + (Convert.ToInt32(txtAmount.Text) - Convert.ToInt32(lblBalance.Text)) + "',current_date())";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Total Amount Paid: P" + lblBalance.Text + "\nPayment: P" + txtAmount.Text + "\nChange: P" + (Convert.ToInt32(txtAmount.Text) - Convert.ToInt32(lblBalance.Text)), "Payment Info");
                    for (int x = 0; x < dgvViewAcco.SelectedRows.Count; x++)
                    {
                        cmd = "update payables_t set feestatus = 'Paid', datepaid = current_date(), pay_id = '" + payID + "' where app_no = '" + appNo + "' and app_id = '" + appID + "' and fee_id = '" + fees[x] + "'";
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                    }
                    cmd = "select count(fee_id) from payables_t where feestatus <> 'Paid' and app_no = '" + appNo + "'";
                    com = new MySqlCommand(cmd, connection);
                    int cnt = int.Parse(com.ExecuteScalar() + "");
                    if (cnt == 0)
                    {
                        cmd = "update app_t set appstatus = 'For Deployment' where app_id = '" + appID + "'";
                        com = new MySqlCommand(cmd, connection);
                        com.ExecuteNonQuery();
                        MessageBox.Show("All fees are paid. Applicant status is for deployment.", "Payment of Fees");
                    }
                    ucPrintReceipt.init(payID);
                    ucPrintReceipt.name.Text = applicant.Text;
                    ucPrintReceipt.amount.Text = lblBalance.Text;
                    string allfees = "";
                    for(int x = 0; x < dgvViewAcco.SelectedRows.Count; x++)
                    {
                        allfees += dgvViewAcco.SelectedRows[x].Cells[0].Value.ToString() + "; ";
                    }
                    ucPrintReceipt.feename.Text = allfees;
                    ucPrintReceipt.Dock = DockStyle.Fill;
                    ucPrintReceipt.Visible = true;
                    resetTable();
                }
            }
            else
            {
                MessageBox.Show("Cannot accept payment lower than the balance set for the applicant.", "Payment Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public ucAccoView()
        {
            InitializeComponent();
        }

        public void init(string appno, string appname)
        {
            appNo = appno;
            appID = appname;
        }

        private void ucAccoView_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
        }

        private void btnPayBal_Click(object sender, EventArgs e)
        {
            connection.Open();
            fees = new string[dgvViewAcco.SelectedRows.Count];
            cmd = "select jt.typename from job_t j join applications_t a join jobtype_t jt on j.jobtype_id = jt.jobtype_id where a.app_no = '" + appNo + "'";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                jobtype = dr[0].ToString();
            }
            dr.Close();
            for (int x = 0; x < dgvViewAcco.SelectedRows.Count; x++)
            {
                cmd = "select fee_id from genfees_t where feename = '" + dgvViewAcco.SelectedRows[x].Cells[0].Value.ToString() + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    fees[x] = dr[0].ToString();
                }
                dr.Close();
                fee += dgvViewAcco.SelectedRows[x].Cells[0].Value.ToString() + "\n";
                total += Convert.ToDecimal(dgvViewAcco.SelectedRows[x].Cells[1].Value.ToString());

            }
            DialogResult y = MessageBox.Show("Are you sure you want to pay the balance(s)? \n" + fee, "Pay Balance?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == y)
            {
                panel1.Visible = true;
                lblBalance.Text = total.ToString();
                //Payment p = new Payment();
                //p.init(appNo, appID, fees, total, dgvViewAcco.SelectedRows.Count);
                //p.Show();
            }
            //if (jobtype == "Skilled")
            //{
                
            //}
            //else
            //{
            //    MessageBox.Show("Applicant doesn't need to pay the any fees.\nApplicant status already set to deployed.");
            //    cmd = "update app_t set appstatus = 'Deployed' where app_no = '" + appNo + "'";
            //    com = new MySqlCommand(cmd, connection);
            //    com.ExecuteNonQuery();
            //    this.Hide();
            //}
            connection.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ucAccoView_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            if (this.Visible == true)
            {
                cmd = "select jorder_id, job_id, employer_id from applications_t where app_no = '" + appNo + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    jorder = dr[0].ToString();
                    jobID = dr[1].ToString();
                    empID = dr[2].ToString();
                }
                dr.Close();
                cmd = "select jobname from job_t where job_id = '" + jobID + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    jobName = dr[0].ToString();
                }
                dr.Close();
                cmd = "select employername from employer_t where employer_id = '" + empID + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    employerName = dr[0].ToString();
                }
                dr.Close();
                cmd = "select concat(lname, ', ', fname, ' ', mname) from app_t where app_id = '" + appID + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    appName = dr[0].ToString();
                }
                dr.Close();
                joborder.Text = jorder;
                jobname.Text = jobName;
                employer.Text = employerName;
                applicant.Text = appName;
                dr.Close();
                cmd = "select f.feename'Fee Name', j.amount'Amount', p.feestatus'Status' "
                    + "from payables_t p join genfees_t f on p.fee_id = f.fee_id "
                    + "join jobfees_t j on p.fee_id = j.fee_id "
                    + "join applications_t app on app.app_no = p.app_no "
                    + "where app.appstats = 'Active' and app.app_no = '" + appNo + "' "
                    + "group by f.feename";
                using (adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvViewAcco.DataSource = ds.Tables[0];
                }
            }
            connection.Close();
        }

        public void resetTable()
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();
            if (this.Visible == true)
            {
                cmd = "select jorder_id, job_id, employer_id from applications_t where app_no = '" + appNo + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    jorder = dr[0].ToString();
                    jobID = dr[1].ToString();
                    empID = dr[2].ToString();
                }
                dr.Close();
                cmd = "select jobname from job_t where job_id = '" + jobID + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    jobName = dr[0].ToString();
                }
                dr.Close();
                cmd = "select employername from employer_t where employer_id = '" + empID + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    employerName = dr[0].ToString();
                }
                dr.Close();
                cmd = "select concat(lname, ', ', fname, ' ', mname) from app_t where app_id = '" + appID + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    appName = dr[0].ToString();
                }
                dr.Close();
                joborder.Text = jorder;
                jobname.Text = jobName;
                employer.Text = employerName;
                applicant.Text = appName;
                dr.Close();
                cmd = "SELECT f.feename'Fee Name', j.amount'Amount', p.feestatus'Status' FROM genfees_t f "
                    + "join payables_t p on f.fee_id = p.fee_id "
                    + "join applications_t app on app.App_no = p.App_no "
                    + "join jobfees_t j on j.jorder_id = app.jorder_id "
                    + "where app.appstats = 'Active' and app.app_no = '" + appNo + "' and app.appstats = 'Active' "
                    + "group by f.feename";
                using (adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvViewAcco.DataSource = ds.Tables[0];
                }
            }
            connection.Close();
        }
    }
}
