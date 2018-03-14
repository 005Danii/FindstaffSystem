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
    public partial class ucAppView : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();

        public ucAppView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ucAppView_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region PDF
            Document doc = new Document(PageSize.A4, 30, 30, 50, 10);
            //PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Philippe\\Desktop\\Application Form.pdf", FileMode.Create));
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\ralmojuela\\Desktop\\Application Form.pdf", FileMode.Create));
            doc.Open();

            doc = BindingData(doc);

            doc.Close();
            //System.Diagnostics.Process.Start("C:\\Users\\Philippe\\Desktop\\Application Form.pdf");
            System.Diagnostics.Process.Start("C:\\Users\\ralmojuela\\Desktop\\Application Form.pdf");
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

            Chunk header1 = new Chunk("APPLICATION FOR EMPLOYMENT", arial);
            PdfPCell rowHeader1 = new PdfPCell(new Phrase(header1));
            rowHeader1.Border = 0;
            rowHeader1.HorizontalAlignment = 1;
            rowHeader1.Colspan = 1;
            tblMain.AddCell(rowHeader1);

            Chunk header2 = new Chunk("\n Applicant Number: "+ appno.Text +"", arial);
            PdfPCell rowHeader2 = new PdfPCell(new Phrase(header2));
            rowHeader2.Border = 0;
            rowHeader2.HorizontalAlignment = 0;
            rowHeader2.Colspan = 2;
            tblMain.AddCell(rowHeader2);

            Chunk header3 = new Chunk("Position: "+ position.Text +"", arial);
            PdfPCell rowHeader3 = new PdfPCell(new Phrase(header3));
            rowHeader3.Border = 0;
            rowHeader3.HorizontalAlignment = 0;
            rowHeader3.Colspan = 2;
            tblMain.AddCell(rowHeader3);

            Chunk header5 = new Chunk("Name: " + name.Text + "", arial);
            PdfPCell rowHeader5 = new PdfPCell(new Phrase(header5));
            rowHeader5.Border = 0;
            rowHeader5.HorizontalAlignment = 0;
            rowHeader5.Colspan = 2;
            tblMain.AddCell(rowHeader5);

            Chunk header6 = new Chunk("Gender: " + sex.Text + "", arial);
            PdfPCell rowHeader6 = new PdfPCell(new Phrase(header6));
            rowHeader6.Border = 0;
            rowHeader6.HorizontalAlignment = 0;
            rowHeader6.Colspan = 2;
            tblMain.AddCell(rowHeader6);

            Chunk header7 = new Chunk("Civil Status: " + civilstat.Text + "", arial);
            PdfPCell rowHeader7 = new PdfPCell(new Phrase(header7));
            rowHeader7.Border = 0;
            rowHeader7.HorizontalAlignment = 0;
            rowHeader7.Colspan = 2;
            tblMain.AddCell(rowHeader7);

            Chunk header8 = new Chunk("Birthday: " + birthday.Text + "", arial);
            PdfPCell rowHeader8 = new PdfPCell(new Phrase(header8));
            rowHeader8.Border = 0;
            rowHeader8.HorizontalAlignment = 0;
            rowHeader8.Colspan = 2;
            tblMain.AddCell(rowHeader8);

            Chunk header9 = new Chunk("Height: " + height.Text + "", arial);
            PdfPCell rowHeader9 = new PdfPCell(new Phrase(header9));
            rowHeader9.Border = 0;
            rowHeader9.HorizontalAlignment = 0;
            rowHeader9.Colspan = 2;
            tblMain.AddCell(rowHeader9);

            Chunk header10 = new Chunk("Weight: " + weight.Text + "", arial);
            PdfPCell rowHeader10 = new PdfPCell(new Phrase(header10));
            rowHeader10.Border = 0;
            rowHeader10.HorizontalAlignment = 0;
            rowHeader10.Colspan = 2;
            tblMain.AddCell(rowHeader10);

            Chunk header11 = new Chunk("\n EDUCATIONAL BACKGROUND", arial);
            PdfPCell rowHeader11 = new PdfPCell(new Phrase(header11));
            rowHeader11.Border = 0;
            rowHeader11.HorizontalAlignment = 0;
            rowHeader11.Colspan = 2;
            tblMain.AddCell(rowHeader11);

            PdfPTable table1 = new PdfPTable(dgvEducBack.Columns.Count);
            for (int j = 0; j < dgvEducBack.Columns.Count; j++)
            {
                table1.AddCell(new Phrase(dgvEducBack.Columns[j].HeaderText));
                table1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            table1.HeaderRows = 1;

            for (int i = 0; i < dgvEducBack.Rows.Count; i++)
            {
                for (int k = 0; k < dgvEducBack.Columns.Count; k++)
                {
                    if (dgvEducBack[k, i].Value != null)
                    {
                        table1.AddCell(new Phrase(dgvEducBack[k, i].Value.ToString()));
                        table1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    }
                }
            }
            tblMain.AddCell(table1);

            Chunk header12 = new Chunk("\nSKILLS", arial);
            PdfPCell rowHeader12 = new PdfPCell(new Phrase(header12));
            rowHeader12.Border = 0;
            rowHeader12.HorizontalAlignment = 0;
            rowHeader12.Colspan = 2;
            tblMain.AddCell(rowHeader12);

            PdfPTable table2 = new PdfPTable(dgvSkills.Columns.Count);
            for (int j = 0; j < dgvSkills.Columns.Count; j++)
            {
                table2.AddCell(new Phrase(dgvSkills.Columns[j].HeaderText));
                table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            table2.HeaderRows = 1;

            for (int i = 0; i < dgvSkills.Rows.Count; i++)
            {
                for (int k = 0; k < dgvSkills.Columns.Count; k++)
                {
                    if (dgvSkills[k, i].Value != null)
                    {
                        table2.AddCell(new Phrase(dgvSkills[k, i].Value.ToString()));
                        table2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    }
                }
            }
            tblMain.AddCell(table2);

            Chunk header13 = new Chunk("\n EMPLOYMENT HISTORY", arial);
            PdfPCell rowHeader13 = new PdfPCell(new Phrase(header13));
            rowHeader13.Border = 0;
            rowHeader13.HorizontalAlignment = 0;
            rowHeader13.Colspan = 2;
            tblMain.AddCell(rowHeader13);

            PdfPTable table3 = new PdfPTable(dgvEmpHistory.Columns.Count);
            for (int j = 0; j < dgvSkills.Columns.Count; j++)
            {
                table3.AddCell(new Phrase(dgvEmpHistory.Columns[j].HeaderText));
                table3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            table3.HeaderRows = 1;

            for (int i = 0; i < dgvEmpHistory.Rows.Count; i++)
            {
                for (int k = 0; k < dgvEmpHistory.Columns.Count; k++)
                {
                    if (dgvEmpHistory[k, i].Value != null)
                    {
                        table3.AddCell(new Phrase(dgvEmpHistory[k, i].Value.ToString()));
                        table3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    }
                }
            }
            tblMain.AddCell(table3);

            Chunk header14 = new Chunk("\n PERSONAL DATA \n Contact Number: " + contactno.Text + "", arial);
            PdfPCell rowHeader14 = new PdfPCell(new Phrase(header14));
            rowHeader14.Border = 0;
            rowHeader14.HorizontalAlignment = 0;
            rowHeader14.Colspan = 2;
            tblMain.AddCell(rowHeader14);

            Chunk header15 = new Chunk("City Address: " + cityadd.Text + "", arial);
            PdfPCell rowHeader15 = new PdfPCell(new Phrase(header15));
            rowHeader15.Border = 0;
            rowHeader15.HorizontalAlignment = 0;
            rowHeader15.Colspan = 2;
            tblMain.AddCell(rowHeader15);

            Chunk header16 = new Chunk("Provincial Address: " + provadd.Text + "", arial);
            PdfPCell rowHeader16 = new PdfPCell(new Phrase(header16));
            rowHeader16.Border = 0;
            rowHeader16.HorizontalAlignment = 0;
            rowHeader16.Colspan = 2;
            tblMain.AddCell(rowHeader16);

            Chunk header17 = new Chunk("Father's Name: " + fathersname.Text + "", arial);
            PdfPCell rowHeader17 = new PdfPCell(new Phrase(header17));
            rowHeader17.Border = 0;
            rowHeader17.HorizontalAlignment = 0;
            rowHeader17.Colspan = 2;
            tblMain.AddCell(rowHeader17);

            Chunk header18 = new Chunk("Father's Age: " + fathersage.Text + "", arial);
            PdfPCell rowHeader18 = new PdfPCell(new Phrase(header18));
            rowHeader18.Border = 0;
            rowHeader18.HorizontalAlignment = 0;
            rowHeader18.Colspan = 2;
            tblMain.AddCell(rowHeader18);

            Chunk header19 = new Chunk("Father's Occupation: " + fathersoccupation.Text + "", arial);
            PdfPCell rowHeader19 = new PdfPCell(new Phrase(header19));
            rowHeader19.Border = 0;
            rowHeader19.HorizontalAlignment = 0;
            rowHeader19.Colspan = 2;
            tblMain.AddCell(rowHeader19);

            Chunk header20 = new Chunk("Mother's Name: " + mothersname.Text + "", arial);
            PdfPCell rowHeader20 = new PdfPCell(new Phrase(header20));
            rowHeader20.Border = 0;
            rowHeader20.HorizontalAlignment = 0;
            rowHeader20.Colspan = 2;
            tblMain.AddCell(rowHeader20);

            Chunk header21 = new Chunk("Mother's Age: " + mothersage.Text + "", arial);
            PdfPCell rowHeader21 = new PdfPCell(new Phrase(header21));
            rowHeader21.Border = 0;
            rowHeader21.HorizontalAlignment = 0;
            rowHeader21.Colspan = 2;
            tblMain.AddCell(rowHeader21);

            Chunk header22 = new Chunk("Mother's Occupation: " + mothersoccupation.Text + "", arial);
            PdfPCell rowHeader22 = new PdfPCell(new Phrase(header22));
            rowHeader22.Border = 0;
            rowHeader22.HorizontalAlignment = 0;
            rowHeader22.Colspan = 2;
            tblMain.AddCell(rowHeader22);

            Chunk header23 = new Chunk("Spouse Name: " + spousename.Text + "", arial);
            PdfPCell rowHeader23 = new PdfPCell(new Phrase(header23));
            rowHeader23.Border = 0;
            rowHeader23.HorizontalAlignment = 0;
            rowHeader23.Colspan = 2;
            tblMain.AddCell(rowHeader23);

            Chunk header24 = new Chunk("Spouse Age: " + spouseage.Text + "", arial);
            PdfPCell rowHeader24 = new PdfPCell(new Phrase(header24));
            rowHeader24.Border = 0;
            rowHeader24.HorizontalAlignment = 0;
            rowHeader24.Colspan = 2;
            tblMain.AddCell(rowHeader24);

            Chunk header25 = new Chunk("Spouse Occupation: " + spouseoccupation.Text + "", arial);
            PdfPCell rowHeader25 = new PdfPCell(new Phrase(header25));
            rowHeader25.Border = 0;
            rowHeader25.HorizontalAlignment = 0;
            rowHeader25.Colspan = 2;
            tblMain.AddCell(rowHeader25);

            Chunk header26 = new Chunk("\n CHILDREN \n", arial);
            PdfPCell rowHeader26 = new PdfPCell(new Phrase(header26));
            rowHeader26.Border = 0;
            rowHeader26.HorizontalAlignment = 0;
            rowHeader26.Colspan = 1;
            tblMain.AddCell(rowHeader26);

            PdfPTable table5 = new PdfPTable(dgvChildren.Columns.Count);
            for (int j = 0; j < dgvChildren.Columns.Count; j++)
            {
                table5.AddCell(new Phrase(dgvChildren.Columns[j].HeaderText));
                table5.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            table5.HeaderRows = 1;

            for (int i = 0; i < dgvChildren.Rows.Count; i++)
            {
                for (int k = 0; k < dgvChildren.Columns.Count; k++)
                {
                    if (dgvChildren[k, i].Value != null)
                    {
                        table5.AddCell(new Phrase(dgvChildren[k, i].Value.ToString()));
                        table5.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    }
                }
            }
            tblMain.AddCell(table5);

            Chunk header27 = new Chunk("\n PERSONS TO BE CONTACTED IN CASE OF EMERGENCY \n", arial);
            PdfPCell rowHeader27 = new PdfPCell(new Phrase(header27));
            rowHeader27.Border = 0;
            rowHeader27.HorizontalAlignment = 0;
            rowHeader27.Colspan = 1;
            tblMain.AddCell(rowHeader27);

            PdfPTable table4 = new PdfPTable(dgvContactPersons.Columns.Count);
            for (int j = 0; j < dgvContactPersons.Columns.Count; j++)
            {
                table4.AddCell(new Phrase(dgvContactPersons.Columns[j].HeaderText));
                table4.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            table4.HeaderRows = 1;

            for (int i = 0; i < dgvContactPersons.Rows.Count; i++)
            {
                for (int k = 0; k < dgvContactPersons.Columns.Count; k++)
                {
                    if (dgvContactPersons[k, i].Value != null)
                    {
                        table4.AddCell(new Phrase(dgvContactPersons[k, i].Value.ToString()));
                        table4.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    }
                }
            }
            tblMain.AddCell(table4);

            doc.Add(tblMain);
            return doc;
        }
    }
}
