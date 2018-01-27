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
    public partial class ucQueries : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private string cmd = "";

        public ucQueries()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            if (cbQuery.SelectedIndex == 0)
            {
                cmd = "SELECT distinct(j.jobname)'Job Title', Count(jo.job_id)'Count' from joborder_t jo join job_t j on jo.job_id = j.job_id group By j.jobname limit 10;";
                using (connection)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dgvQueries.DataSource = ds.Tables[0];
                    }
                }
            }
            else if (cbQuery.SelectedIndex == 1)
            {
                cmd = "Select distinct(c.countryname) 'Country', Count(jo.jorder_id)'No. of Job Orders' from country_t c join employer_t e on c.country_id = e.Country_id" +
                    " join joborder_t jo on jo.employer_id = e.Employer_id group by c.Countryname limit 10;";
                using (connection)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dgvQueries.DataSource = ds.Tables[0];
                    }
                }
            }
        }
    }
}
