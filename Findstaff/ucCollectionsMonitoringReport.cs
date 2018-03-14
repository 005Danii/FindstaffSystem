﻿using System;
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
    public partial class ucCollectionsMonitoringReport : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader dr;
        private string cmd = "";
        private string[,] results;

        public ucCollectionsMonitoringReport()
        {
            InitializeComponent();
        }

        #region Load
        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvReports.Rows.Clear();
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            dgvReports.ColumnCount = 10;
            dgvReports.Columns[0].HeaderText = "Applicant ID";
            dgvReports.Columns[1].HeaderText = "Applicant Name";
            dgvReports.Columns[2].HeaderText = "Job Title";
            dgvReports.Columns[3].HeaderText = "Applicant Status";
            dgvReports.Columns[4].HeaderText = "Application Status";
            dgvReports.Columns[5].HeaderText = "Total No. Of Fees to Be Payed";
            dgvReports.Columns[6].HeaderText = "No. of Fees Paid";
            dgvReports.Columns[7].HeaderText = "No. of Fees to be Paid";
            dgvReports.Columns[8].HeaderText = "Fees to be Payed";
            dgvReports.Columns[9].HeaderText = "Status";
            int ctr = 0;
            cmd = "select a.app_id'Applicant ID', Concat(a.fname, ' ', a.mname, ' ', a.lname)'Name', a.position'Position', a.appstatus'Status', ap.appstats'Application Status' from app_t a " +
                            "join applications_t ap on a.app_id = ap.app_id where (a.dateadded between '" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTo.Value.ToString("yyyy-MM-dd") + "') and appstatus in ('For Deployment','With Flight Schedule', 'On Flight', 'Arrived','Deployed') ;";
            com = new MySqlCommand(cmd, connection);
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                ctr++;
            }
            dr.Close();
            results = new string[ctr, 11];
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
                results[ctr, 10] = dr[5].ToString();
                ctr++;
            }
            dr.Close();
            for (int x = 0; x < ctr; x++)
            {
                cmd = "select count(app_no) from payables_t where app_no = '"+results[x,10]+"'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    results[x, 5] = dr[0].ToString();
                }
                dr.Close();
                cmd = "select count(app_no) from payables_t where app_no = '" + results[x, 10] + "' and feestatus = 'Paid'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    results[x, 6] = dr[0].ToString();
                }
                dr.Close();
                cmd = "select count(app_no) from payables_t where app_no = '" + results[x, 10] + "' and feestatus = 'Balance'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    results[x, 7] = dr[0].ToString();
                }
                dr.Close();
                cmd = "select g.feename from payables_t p join genfees_t g on p.fee_id = g.fee_id where app_no = '" + results[x, 10] + "' and feestatus = 'Balance'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    results[x, 8] += dr[0].ToString() + "; ";
                }
                dr.Close();
                results[x, 8] += " ";
                if (Convert.ToInt32(results[x,5]) > Convert.ToInt32(results[x, 6]))
                {
                    results[x, 9] = "Partially Paid";
                }
                else if (Convert.ToInt32(results[x, 5]) == Convert.ToInt32(results[x, 6]))
                {
                    results[x, 9] = "Fully Paid";
                }
            }
            for(int x = 0; x < ctr; x++)
            {
                dgvReports.Rows.Add(results[x, 0], results[x, 1], results[x, 2], results[x, 3], results[x, 4], results[x, 5], results[x, 6], results[x, 7], results[x, 8], results[x, 9]);
            }
            connection.Close();
            //cmd = "select a.app_id'Applicant ID', Concat(a.fname, ' ', a.mname, ' ', a.lname)'Name', a.position'Position', a.appstatus'Status', ap.appstats'Application Status' from app_t a " +
            //    "join applications_t ap on a.app_id = ap.app_id;";
            //using (connection)
            //{
            //    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
            //    {
            //        DataSet ds = new DataSet();
            //        adapter.Fill(ds);
            //        dgvReports.DataSource = ds.Tables[0];
            //    }
            //}
        }
        #endregion Load

        #region Create
        private void btnCreatePdf_Click(object sender, EventArgs e)
        {
            #region PDF
            if(dgvReports.Rows.Count != 0)
            {
                Document doc = new Document(PageSize.A4, 30, 30, 50, 10);
                //PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Philippe\\Desktop\\Collections Monitoring Report.pdf", FileMode.Create));
                PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\ralmojuela\\Desktop\\Collections Monitoring Report.pdf", FileMode.Create));
                doc.Open();

                doc = BindingData(doc);

                doc.Close();
                //System.Diagnostics.Process.Start("C:\\Users\\Philippe\\Desktop\\Collections Monitoring Report.pdf");
                System.Diagnostics.Process.Start("C:\\Users\\ralmojuela\\Desktop\\Collections Monitoring Report.pdf");
                MessageBox.Show("PDF Created Successfully!");
            }
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

            Chunk header7 = new Chunk("\n COLLECTIONS MONITORING REPORT", arial);
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

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.MinDate = dtpFrom.Value;
        }
    }
}
