using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Findstaff
{
    public partial class ucEmployerView : UserControl
    {
        public ucEmployerView()
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
            //PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Philippe\\Desktop\\Employer.pdf", FileMode.Create));
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\ralmojuela\\Desktop\\Employer.pdf", FileMode.Create));
            doc.Open();

            doc = BindingData(doc);

            doc.Close();
            //System.Diagnostics.Process.Start("C:\\Users\\Philippe\\Desktop\\Employer.pdf");
            System.Diagnostics.Process.Start("C:\\Users\\ralmojuela\\Desktop\\Employer.pdf");
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

            Chunk header2 = new Chunk("2082 F. Benitez St., Malate, Manila, Philippines 1004", arial);
            PdfPCell rowHeader2 = new PdfPCell(new Phrase(header2));
            rowHeader2.Border = 0;
            rowHeader2.HorizontalAlignment = 1;
            rowHeader2.Colspan = 1;
            tblMain.AddCell(rowHeader2);

            Chunk header3 = new Chunk("\n \nEMPLOYER", arial);
            PdfPCell rowHeader3 = new PdfPCell(new Phrase(header3));
            rowHeader3.Border = 0;
            rowHeader3.HorizontalAlignment = 1;
            rowHeader3.Colspan = 1;
            tblMain.AddCell(rowHeader3);

            Chunk header5 = new Chunk("\nEmployer ID: " + empID.Text + "", arial);
            PdfPCell rowHeader5 = new PdfPCell(new Phrase(header5));
            rowHeader5.Border = 0;
            rowHeader5.HorizontalAlignment = 0;
            rowHeader5.Colspan = 2;
            tblMain.AddCell(rowHeader5);

            Chunk header6 = new Chunk("Employer: " + employer.Text + "", arial);
            PdfPCell rowHeader6 = new PdfPCell(new Phrase(header6));
            rowHeader6.Border = 0;
            rowHeader6.HorizontalAlignment = 0;
            rowHeader6.Colspan = 2;
            tblMain.AddCell(rowHeader6);

            Chunk header7 = new Chunk("Country: " + country.Text + "", arial);
            PdfPCell rowHeader7 = new PdfPCell(new Phrase(header7));
            rowHeader7.Border = 0;
            rowHeader7.HorizontalAlignment = 0;
            rowHeader7.Colspan = 2;
            tblMain.AddCell(rowHeader7);

            Chunk header8 = new Chunk("Foreign Principal: " + forPrincipal.Text + "", arial);
            PdfPCell rowHeader8 = new PdfPCell(new Phrase(header8));
            rowHeader8.Border = 0;
            rowHeader8.HorizontalAlignment = 0;
            rowHeader8.Colspan = 2;
            tblMain.AddCell(rowHeader8);

            Chunk header9 = new Chunk("Company Address: " + compAdd.Text + "", arial);
            PdfPCell rowHeader9 = new PdfPCell(new Phrase(header9));
            rowHeader9.Border = 0;
            rowHeader9.HorizontalAlignment = 0;
            rowHeader9.Colspan = 2;
            tblMain.AddCell(rowHeader9);

            Chunk header10 = new Chunk("Contact Number: " + contact.Text + "", arial);
            PdfPCell rowHeader10 = new PdfPCell(new Phrase(header10));
            rowHeader10.Border = 0;
            rowHeader10.HorizontalAlignment = 0;
            rowHeader10.Colspan = 2;
            tblMain.AddCell(rowHeader10);

            Chunk header11 = new Chunk("Company Email Address: " + compEmail.Text + "", arial);
            PdfPCell rowHeader11 = new PdfPCell(new Phrase(header11));
            rowHeader11.Border = 0;
            rowHeader11.HorizontalAlignment = 0;
            rowHeader11.Colspan = 2;
            tblMain.AddCell(rowHeader11);

            doc.Add(tblMain);
            return doc;
        }
    }
}
