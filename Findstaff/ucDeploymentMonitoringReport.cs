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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Findstaff
{
    public partial class ucDeploymentMonitoringReport : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader dr;
        private string cmd = "";
        private string[,] results;
        private string countryID = "", employerID = "";

        public ucDeploymentMonitoringReport()
        {
            InitializeComponent();
        }

        #region Load
        private void btnLoad_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            int ctr = 0;
            cmd = "select a.app_id'Applicant ID', Concat(a.fname, ' ', a.mname, ' ', a.lname)'Name', a.position'Position', a.appstatus'Status', ap.appstats'Application Status' from app_t a " +
                            "join applications_t ap on a.app_id = ap.app_id where (a.dateadded between '"+dtpFrom.Value.ToString("yyyy-MM-dd")+"' and '" + dtpTo.Value.ToString("yyyy-MM-dd") + "') and appstatus in ('For Deployment','With Flight Schedule', 'On Flight', 'Arrived','Deployed') ;";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ctr++;
            }
            dr.Close();
            results = new string[ctr, 8];
            ctr = 0;
            cmd = "select a.app_id'Applicant ID', Concat(a.fname, ' ', a.mname, ' ', a.lname)'Name', a.position'Position', a.appstatus'Status', ap.appstats'Application Status', ap.app_no from app_t a " +
                            "join applications_t ap on a.app_id = ap.app_id where (a.dateadded between '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTo.Value.ToString("yyyy-MM-dd") + "') and a.appstatus in ('For Deployment','With Flight Schedule', 'On Flight', 'Arrived','Deployed') and ap.appstats = 'Active';";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                results[ctr, 0] = dr[0].ToString();
                results[ctr, 1] = dr[1].ToString();
                results[ctr, 2] = dr[2].ToString();
                results[ctr, 3] = dr[3].ToString();
                results[ctr, 4] = dr[4].ToString();
                results[ctr, 7] = dr[5].ToString();
                ctr++;
            }
            dr.Close();
            
            for (int x = 0; x < ctr; x++)
            {
                cmd = "select employer_id from applications_t where app_no = '" + results[x, 7] + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    employerID = dr[0].ToString();
                }
                dr.Close();
                cmd = "select e.employername, c.countryname from employer_t e join country_t c on e.country_id = c.country_id where e.employer_id = '" + employerID + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    results[x, 5] = dr[0].ToString();
                    results[x, 6] = dr[1].ToString();
                }
                dr.Close();
            }
            dgvReports.ColumnCount = 7;
            dgvReports.Columns[0].HeaderText = "Applicant ID";
            dgvReports.Columns[1].HeaderText = "Applicant Name";
            dgvReports.Columns[2].HeaderText = "Job Title";
            dgvReports.Columns[3].HeaderText = "Applicant Status";
            dgvReports.Columns[4].HeaderText = "Application Status";
            dgvReports.Columns[5].HeaderText = "Employer";
            dgvReports.Columns[6].HeaderText = "Country of Destination";
            for(int x = 0; x < ctr; x++)
            {
                dgvReports.Rows.Add(results[x, 0], results[x, 1], results[x, 2], results[x, 3], results[x, 4], results[x, 5], results[x, 6]);
            }
            //using (connection)
            //{
            //    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
            //    {
            //        DataSet ds = new DataSet();
            //        adapter.Fill(ds);
            //        dgvReports.DataSource = ds.Tables[0];
            //    }
            //}
            connection.Close();
        }
        #endregion Load

        #region Create
        private void btnCreatePdf_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            #region Query
            cmd = "select a.app_id'Applicant ID', Concat(a.fname, ' ', a.mname, ' ', a.lname)'Name', a.position'Position', a.appstatus'Applicant Status', ap.appstats'Application Status' from app_t a " +
                            "join applications_t ap on a.app_id = ap.app_id;";
            using (connection)
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dgvReports.DataSource = ds.Tables[0];
                }
            }
            #endregion Query

            #region PDF
            Document doc = new Document(PageSize.A4, 30, 30, 50, 10);
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Philippe\\Desktop\\Deployment Monitoring Report.pdf", FileMode.Create));
            doc.Open();

            doc = BindingData(doc);

            doc.Close();
            MessageBox.Show("PDF Created Successfully!");
            #endregion PDF
        }
        #endregion Create

        private Document BindingData(Document doc)
        {
            iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 13, 1);

            PdfPTable tblMain = new PdfPTable(1);
            tblMain.WidthPercentage = 100;
            tblMain.DefaultCell.Padding = 4.5f;
            tblMain.DefaultCell.Border = 0;

            Chunk header1 = new Chunk("FINDSTAFF PLACEMENT SERVICES, INC.", arial);
            PdfPCell rowHeader1 = new PdfPCell(new Phrase(header1));
            rowHeader1.Border = 0;
            rowHeader1.HorizontalAlignment = 1;
            rowHeader1.Colspan = 1;
            tblMain.AddCell(rowHeader1);

            Chunk header3 = new Chunk("''Pioneer in the Recruitment Industry''", arial);
            PdfPCell rowHeader3 = new PdfPCell(new Phrase(header3));
            rowHeader3.Border = 0;
            rowHeader3.HorizontalAlignment = 1;
            rowHeader3.Colspan = 1;
            tblMain.AddCell(rowHeader3);

            Chunk header4 = new Chunk("2082 F. Benitez St., Malate, Manila, Philippines 1004", arial);
            PdfPCell rowHeader4 = new PdfPCell(new Phrase(header4));
            rowHeader4.Border = 0;
            rowHeader4.HorizontalAlignment = 1;
            rowHeader4.Colspan = 1;
            tblMain.AddCell(rowHeader4);

            Chunk header5 = new Chunk("Tel. No. (+632) 5214116", arial);
            PdfPCell rowHeader5 = new PdfPCell(new Phrase(header5));
            rowHeader5.Border = 0;
            rowHeader5.HorizontalAlignment = 1;
            rowHeader5.Colspan = 1;
            tblMain.AddCell(rowHeader5);

            Chunk header6 = new Chunk("\n \n", arial);
            PdfPCell rowHeader6 = new PdfPCell(new Phrase(header6));
            rowHeader6.Border = 0;
            rowHeader6.HorizontalAlignment = 1;
            rowHeader6.Colspan = 1;
            tblMain.AddCell(rowHeader6);

            PdfPCell TotDate = new PdfPCell(new Phrase(DateTime.Now.ToString(), arial));
            TotDate.Border = 0;
            TotDate.Colspan = 1;
            TotDate.HorizontalAlignment = 2;
            tblMain.AddCell(TotDate);

            Chunk header7 = new Chunk("\n DEPLOYMENT MONITORING REPORT", arial);
            PdfPCell rowHeader7 = new PdfPCell(new Phrase(header7));
            rowHeader7.Border = 0;
            rowHeader7.HorizontalAlignment = 1;
            rowHeader7.Colspan = 1;
            tblMain.AddCell(rowHeader7);

            Chunk header8 = new Chunk("(From " + dtpFrom.Text + " to " + dtpTo.Text + ") \n \n", arial);
            PdfPCell rowHeader8 = new PdfPCell(new Phrase(header8));
            rowHeader8.Border = 0;
            rowHeader8.HorizontalAlignment = 1;
            rowHeader8.Colspan = 1;
            tblMain.AddCell(rowHeader8);

            PdfPTable table = new PdfPTable(dgvReports.Columns.Count);
            for (int j = 0; j < dgvReports.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dgvReports.Columns[j].HeaderText));
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            table.HeaderRows = 1;

            for (int i = 0; i < dgvReports.Rows.Count; i++)
            {
                for (int k = 0; k < dgvReports.Columns.Count; k++)
                {
                    if (dgvReports[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dgvReports[k, i].Value.ToString()));
                        table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    }
                }
            }

            tblMain.AddCell(table);

            Chunk header9 = new Chunk("\n \n Prepared by: " + name.Text + "", arial);
            PdfPCell rowHeader9 = new PdfPCell(new Phrase(header9));
            rowHeader9.Border = 0;
            rowHeader9.HorizontalAlignment = 2;
            rowHeader9.Colspan = 1;
            tblMain.AddCell(rowHeader9);

            doc.Add(tblMain);
            return doc;
        }
    }
}
