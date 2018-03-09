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
    public partial class ucJobListView : UserControl
    {
        //private MySqlConnection connection;
        //MySqlCommand com = new MySqlCommand();

        public ucJobListView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            #region PDF
            Document doc = new Document(PageSize.A4, 30, 30, 50, 10);
            //PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Philippe\\Desktop\\Receipt.pdf", FileMode.Create));
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\ralmojuela\\Desktop\\Job Order.pdf", FileMode.Create));
            doc.Open();

            doc = BindingData(doc);

            doc.Close();
            //System.Diagnostics.Process.Start("C:\\Users\\Philippe\\Desktop\\Receipt.pdf");
            System.Diagnostics.Process.Start("C:\\Users\\ralmojuela\\Desktop\\Job Order.pdf");
            MessageBox.Show("PDF Created Successfully!");
            
            this.Hide();
            #endregion PDF
            
        }

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

            Chunk header4 = new Chunk("2082 F. Benitez St., Malate, Manila, Philippines 1004", arial);
            PdfPCell rowHeader4 = new PdfPCell(new Phrase(header4));
            rowHeader4.Border = 0;
            rowHeader4.HorizontalAlignment = 1;
            rowHeader4.Colspan = 1;
            tblMain.AddCell(rowHeader4);

            Chunk header5 = new Chunk("\nJob Order No.: " + jono.Text + "\nGender Specification: "+ gender.Text +"", arial);
            PdfPCell rowHeader5 = new PdfPCell(new Phrase(header5));
            rowHeader5.Border = 0;
            rowHeader5.HorizontalAlignment = 0;
            rowHeader5.Colspan = 2;
            tblMain.AddCell(rowHeader5);

            Chunk header6 = new Chunk("Employer: " + employer.Text + "\nNo. of Employees Required: "+noofempreq.Text+"", arial);
            PdfPCell rowHeader6 = new PdfPCell(new Phrase(header6));
            rowHeader6.Border = 0;
            rowHeader6.HorizontalAlignment = 0;
            rowHeader6.Colspan = 2;
            tblMain.AddCell(rowHeader6);

            Chunk header7 = new Chunk("Category: " + category.Text + "\nSalary: "+salary.Text+"", arial);
            PdfPCell rowHeader7 = new PdfPCell(new Phrase(header7));
            rowHeader7.Border = 0;
            rowHeader7.HorizontalAlignment = 0;
            rowHeader7.Colspan = 2;
            tblMain.AddCell(rowHeader7);

            Chunk header8 = new Chunk("Job Name: " + jobname.Text + "\nHeight: "+height.Text+" ", arial);
            PdfPCell rowHeader8 = new PdfPCell(new Phrase(header8));
            rowHeader8.Border = 0;
            rowHeader8.HorizontalAlignment = 0;
            rowHeader8.Colspan = 2;
            tblMain.AddCell(rowHeader8);

            Chunk header9 = new Chunk("Contract Start: " + contractStart.Text + "\nWeight: "+weight.Text+"", arial);
            PdfPCell rowHeader9 = new PdfPCell(new Phrase(header9));
            rowHeader9.Border = 0;
            rowHeader9.HorizontalAlignment = 0;
            rowHeader9.Colspan = 2;
            tblMain.AddCell(rowHeader9);

            Chunk header10 = new Chunk("\n Skills \n", arial);
            PdfPCell rowHeader10 = new PdfPCell(new Phrase(header10));
            rowHeader10.Border = 0;
            rowHeader10.HorizontalAlignment = 0;
            rowHeader10.Colspan = 1;
            tblMain.AddCell(rowHeader10);

            PdfPTable table1 = new PdfPTable(dgvSkills.Columns.Count);
            for (int j = 0; j < dgvSkills.Columns.Count; j++)
            {
                table1.AddCell(new Phrase(dgvSkills.Columns[j].HeaderText));
                table1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            table1.HeaderRows = 1;

            for (int i = 0; i < dgvSkills.Rows.Count; i++)
            {
                for (int k = 0; k < dgvSkills.Columns.Count; k++)
                {
                    if (dgvSkills[k, i].Value != null)
                    {
                        table1.AddCell(new Phrase(dgvSkills[k, i].Value.ToString()));
                        table1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    }
                }
            }
            tblMain.AddCell(table1);

            Chunk header11 = new Chunk("\n Required Documents \n", arial);
            PdfPCell rowHeader11 = new PdfPCell(new Phrase(header11));
            rowHeader11.Border = 0;
            rowHeader11.HorizontalAlignment = 0;
            rowHeader11.Colspan = 1;
            tblMain.AddCell(rowHeader11);

            PdfPTable table2 = new PdfPTable(dgvRequiredDocs.Columns.Count);
            for (int j = 0; j < dgvRequiredDocs.Columns.Count; j++)
            {
                table2.AddCell(new Phrase(dgvRequiredDocs.Columns[j].HeaderText));
                table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            table2.HeaderRows = 1;

            for (int i = 0; i < dgvRequiredDocs.Rows.Count; i++)
            {
                for (int k = 0; k < dgvRequiredDocs.Columns.Count; k++)
                {
                    if (dgvRequiredDocs[k, i].Value != null)
                    {
                        table2.AddCell(new Phrase(dgvRequiredDocs[k, i].Value.ToString()));
                        table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    }
                }
            }
            tblMain.AddCell(table2);

            //Chunk header9 = new Chunk("\n \n Received from " + name.Text + " with TIN " + number.Text + " the sum of PHP " + amount.Text + " in full payment for " + feename.Text + " ", arial);
            //PdfPCell rowHeader9 = new PdfPCell(new Phrase(header9));
            //rowHeader9.Border = 0;
            //rowHeader9.HorizontalAlignment = 0;
            //rowHeader9.Colspan = 1;
            //tblMain.AddCell(rowHeader9);

            //Chunk header11 = new Chunk("\n \n By: " + user, arial);
            //PdfPCell rowHeader11 = new PdfPCell(new Phrase(header11));
            //rowHeader11.Border = 0;
            //rowHeader11.HorizontalAlignment = 2;
            //rowHeader11.Colspan = 1;
            //tblMain.AddCell(rowHeader11);

            doc.Add(tblMain);
            return doc;
            
        }
    }
}
