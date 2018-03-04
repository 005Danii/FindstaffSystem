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
    public partial class ucReports : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private string cmd = "";

        public ucReports()
        {
            InitializeComponent();
            ucApplicationStatus.Dock = DockStyle.Fill;
            ucCollectionsMonitoringReport.Dock = DockStyle.Fill;
            ucDeploymentMonitoringReport.Dock = DockStyle.Fill;
        }

        private void rbCountry_CheckedChanged(object sender, EventArgs e)
        {
            connection.Open();
            cmd = "SELECT concat(E.fname, ' ', E.mname, ' ', E.lname) FROM EMP_T E JOIN LOGS_T L"
                + " ON E.EMP_ID = L.EMP_ID where LOG_ID = (SELECT MAX(LOG_ID) FROM LOGS_T);";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ucApplicationStatus.name.Text = dr[0].ToString();
            }
            dr.Close();

            connection.Close();
            ucApplicationStatus.Visible = true;
            ucDeploymentMonitoringReport.Visible = false;
            ucCollectionsMonitoringReport.Visible = false;
        }

        private void rbAcceptedBanks_CheckedChanged(object sender, EventArgs e)
        {
            ucApplicationStatus.Visible = false;
            ucDeploymentMonitoringReport.Visible = true;
            ucCollectionsMonitoringReport.Visible = false;
        }

        private void rbGeneralRequirements_CheckedChanged(object sender, EventArgs e)
        {
            ucApplicationStatus.Visible = false;
            ucDeploymentMonitoringReport.Visible = false;
            ucCollectionsMonitoringReport.Visible = true;
        }

        private void ucReports_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
        }
    }
}
