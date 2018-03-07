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
        private string cmd = "", user = "";

        public void init(string name)
        {
            user = name;
        }

        public ucReports()
        {
            InitializeComponent();
            ucApplicationStatus.Dock = DockStyle.Fill;
            ucCollectionsMonitoringReport.Dock = DockStyle.Fill;
            ucDeploymentMonitoringReport.Dock = DockStyle.Fill;
            ucApplicationStatus.Visible = false;
            ucDeploymentMonitoringReport.Visible = false;
            ucCollectionsMonitoringReport.Visible = false;
        }

        private void rbCountry_CheckedChanged(object sender, EventArgs e)
        {
            ucApplicationStatus.name.Text = user;
            ucApplicationStatus.Visible = true;
            ucDeploymentMonitoringReport.Visible = false;
            ucCollectionsMonitoringReport.Visible = false;
        }

        private void rbAcceptedBanks_CheckedChanged(object sender, EventArgs e)
        {
            ucDeploymentMonitoringReport.name.Text = user;
            ucApplicationStatus.Visible = false;
            ucDeploymentMonitoringReport.Visible = true;
            ucCollectionsMonitoringReport.Visible = false;
        }

        private void rbGeneralRequirements_CheckedChanged(object sender, EventArgs e)
        {
            ucCollectionsMonitoringReport.name.Text = user;
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
