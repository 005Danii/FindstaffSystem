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
    public partial class ucFlightBooking : UserControl
    {
        public ucFlightBooking()
        {
            InitializeComponent();
        }

        private void btnBookFlight_Click(object sender, EventArgs e)
        {
            fBookFlight fbf = new fBookFlight();
            fbf.Show();
        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            fReschedule fr = new fReschedule();
            fr.Show();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {

        }
    }
}
