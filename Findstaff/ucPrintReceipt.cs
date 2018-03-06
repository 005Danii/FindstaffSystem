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
    public partial class ucPrintReceipt : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private string cmd = "", payID = "";


        public ucPrintReceipt()
        {
            InitializeComponent();
        }

        public void init(string pay_id)
        {
            payID = pay_id;
        }

        #region Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            connection.Open();

            #region Query

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
        #endregion Print

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

            Chunk header7 = new Chunk("\n OFFICIAL RECEIPT", arial);
            PdfPCell rowHeader7 = new PdfPCell(new Phrase(header7));
            rowHeader7.Border = 0;
            rowHeader7.HorizontalAlignment = 1;
            rowHeader7.Colspan = 1;
            tblMain.AddCell(rowHeader7);

            PdfPCell TotDate = new PdfPCell(new Phrase(DateTime.Now.ToString(), arial));
            TotDate.Border = 0;
            TotDate.Colspan = 1;
            TotDate.HorizontalAlignment = 1;
            tblMain.AddCell(TotDate);

            Chunk header8 = new Chunk("\n \n Received from " + name.Text + " with TIN " + number.Text + "", arial);
            PdfPCell rowHeader8 = new PdfPCell(new Phrase(header8));
            rowHeader8.Border = 0;
            rowHeader8.HorizontalAlignment = 1;
            rowHeader8.Colspan = 1;
            tblMain.AddCell(rowHeader8);

            Chunk header9 = new Chunk("\n the sum of " + txtAmountWords.Text + " pesos", arial);
            PdfPCell rowHeader9 = new PdfPCell(new Phrase(header9));
            rowHeader9.Border = 0;
            rowHeader9.HorizontalAlignment = 1;
            rowHeader9.Colspan = 1;
            tblMain.AddCell(rowHeader9);

            Chunk header10 = new Chunk("\n (P " + amount.Text + " ) in full payment for " + feename + " ", arial);
            PdfPCell rowHeader10 = new PdfPCell(new Phrase(header9));
            rowHeader10.Border = 0;
            rowHeader10.HorizontalAlignment = 1;
            rowHeader10.Colspan = 1;
            tblMain.AddCell(rowHeader10);

            Chunk header11 = new Chunk("\n \n By: ", arial);
            PdfPCell rowHeader11 = new PdfPCell(new Phrase(header9));
            rowHeader11.Border = 0;
            rowHeader11.HorizontalAlignment = 1;
            rowHeader11.Colspan = 1;
            tblMain.AddCell(rowHeader11);

            doc.Add(tblMain);
            return doc;
        }
    }
}
