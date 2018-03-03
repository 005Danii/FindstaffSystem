using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Findstaff
{
    public partial class ucReports : UserControl
    {
        public ucReports()
        {
            InitializeComponent();
            ucApplicationStatus.Dock = DockStyle.Fill;
            ucCollectionsMonitoringReport.Dock = DockStyle.Fill;
            ucDeploymentMonitoringReport.Dock = DockStyle.Fill;
        }

        private void rbCountry_CheckedChanged(object sender, EventArgs e)
        {
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
    }
}
