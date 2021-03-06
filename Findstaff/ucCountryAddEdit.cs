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

namespace Findstaff
{
    public partial class ucCountryAddEdit : UserControl
    {
        private MySqlConnection connection;
        MySqlCommand com = new MySqlCommand();
        MySqlDataReader dr;
        private string cmd = "";

        public ucCountryAddEdit()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            connection.Open();
            if(txtCountryName1.Text != "" && txtCurrency1.Text != "" && txtSymbol1.Text != "")
            {
                int ctr = 0;
                string cID = "", cmd2 = "";
                if (dgvCountry.Rows.Count != 0)
                {
                    if(dgvAirports1.Rows.Count != 0)
                    {
                        string check = "Select Count(Countryname) from Country_t where Countryname = '" + txtCountryName1.Text + "'";
                        com = new MySqlCommand(check, connection);
                        ctr = int.Parse(com.ExecuteScalar() + "");
                        if (ctr == 0)
                        {
                            cmd = "Insert into Country_t (countryname, currencyname, symbol) values ('" + txtCountryName1.Text + "', '" + txtCurrency1.Text + "', '" + txtSymbol1.Text + "')";
                            com = new MySqlCommand(cmd, connection);
                            com.ExecuteNonQuery();
                            cmd = "Select country_id from country_t where countryname = '" + txtCountryName1.Text + "'";
                            com = new MySqlCommand(cmd, connection);
                            dr = com.ExecuteReader();
                            while (dr.Read())
                            {
                                cID = dr[0].ToString();
                            }
                            dr.Close();
                            cmd = "Insert into countryreqs_t (country_id, req_id, specdetails) values ";
                            for (int x = 0; x < dgvCountry.Rows.Count; x++)
                            {
                                cmd2 = "select req_id from genreqs_t where reqname = '" + dgvCountry.Rows[x].Cells[0].Value.ToString() + "'";
                                com = new MySqlCommand(cmd2, connection);
                                dr = com.ExecuteReader();
                                while (dr.Read())
                                {
                                    cmd += "('" + cID + "','" + dr[0].ToString() + "', '"+ dgvCountry.Rows[x].Cells[1].Value.ToString() + "')";
                                }
                                dr.Close();
                                if (x < dgvCountry.Rows.Count - 1)
                                {
                                    cmd += ",";
                                }
                            }
                            com = new MySqlCommand(cmd, connection);
                            com.ExecuteNonQuery();
                            for (int x = 0; x < dgvAirports1.Rows.Count; x++)
                            {
                                cmd = "insert into countryairports_t (country_id, airportname) values ('" + cID + "','" + dgvAirports1.Rows[x].Cells[0].Value.ToString() + "')";
                                com = new MySqlCommand(cmd, connection);
                                com.ExecuteNonQuery();
                            }
                            MessageBox.Show("Country Added!", "Added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCountryName1.Clear();
                            txtCurrency1.Clear();
                            txtSymbol1.Clear();
                            dgvCountry.Rows.Clear();
                            dgvAirports1.Rows.Clear();
                            txtDocDetails1.Clear();
                            txtAirport1.Clear();
                            cbReq.Items.Clear();
                            this.Hide();
                        }
                        else if (ctr != 0)
                        {
                            MessageBox.Show("Record already exists.", "Error Message");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No airports specified for the country", "Add Country Error");
                    }
                    
                }
                else
                {
                    MessageBox.Show("No documents specified for the country", "Add Country Error");
                }
            }
            else
            {
                MessageBox.Show("Empty Field/s Empty", "Add Country Error");
            }
            connection.Close();

            txtCountryName1.Clear();
            txtCurrency1.Clear();
            txtSymbol1.Clear();
            cbReq.Items.Clear();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            txtCountryName1.Clear();
            txtCurrency1.Clear();
            txtSymbol1.Clear();
            cbReq.Items.Clear();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            DialogResult r = MessageBox.Show("Do you want to update the with the ff changes?\n New Country Name: "+txtCountryName2.Text+" \nNew Currency: " 
                + txtCurrency2.Text + "\nNew Currency Symbol: " + txtSymbol2.Text, "Update Country Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if(r == DialogResult.Yes)
            {
                cmd = "update country_t set countryname = '"+txtCountryName2.Text+"', currencyname = '"+txtCurrency2.Text+"', symbol = '"+txtSymbol2.Text+"' where country_id = '"+txtCountryID2.Text+"'";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                MessageBox.Show("Updated Country!", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
            this.Hide();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            txtCountryID2.Clear();
            txtCurrency2.Clear();
            txtSymbol2.Clear();
            cbReq2.Items.Clear();
            dgvReq2.Rows.Clear();
            this.Hide();
        }
        
        private void btnAddRequire_Click(object sender, EventArgs e)
        {
            if(cbReq.Text != "")
            {
                dgvCountry.ColumnCount = 2;
                dgvCountry.Rows.Add(cbReq.Text, txtDocDetails1.Text);
                cbReq.Items.Remove(cbReq.Text);
            }
        }

        private void btnRemoveRequire_Click(object sender, EventArgs e)
        {
            if(dgvCountry.Rows.Count != 0)
            {
                cbReq.Items.Add(dgvCountry.SelectedRows[0].Cells[0].Value.ToString());
                dgvCountry.Rows.Remove(dgvCountry.SelectedRows[0]);
            }
        }
        
        private void btnAddRequire2_Click(object sender, EventArgs e)
        {
            if (cbReq2.Text != "" || txtDocDetails2.Text != "")
            {
                string reqId = "";
                dgvReq2.Rows.Add(txtCountryID2.Text, cbReq2.Text);
                cmd = "Select req_id from genreqs_t where reqname = '" + cbReq2.Text + "'";
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    reqId = dr[0].ToString();
                }
                dr.Close();

                cmd = "insert into countryreqs_t values ('"+txtCountryID2.Text+"','"+reqId+"', '"+txtDocDetails2.Text+"')";
                com = new MySqlCommand(cmd, connection);
                com.ExecuteNonQuery();
                cbReq2.Items.Remove(cbReq2.Text);
                txtDocDetails2.Clear();
            }
        }

        private void btnRemoveRequire2_Click(object sender, EventArgs e)
        {
            connection.Open();
            if(dgvReq2.Rows.Count != 0)
            {
                DialogResult a = MessageBox.Show("Are you sure you want to remove the document " + dgvReq2.SelectedRows[0].Cells[1].Value.ToString()
                    + " from the list of documents", "Remove Documents from Country", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(a == DialogResult.Yes)
                {
                    string reqId = "";
                    cbReq2.Items.Add(dgvReq2.SelectedRows[0].Cells[1].Value.ToString());
                    cmd = "Select req_id from genreqs_t where reqname = '" + dgvReq2.SelectedRows[0].Cells[1].Value.ToString() + "'";
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        reqId = dr[0].ToString();
                    }
                    dr.Close();
                    dgvReq2.Rows.Remove(dgvReq2.SelectedRows[0]);
                    cmd = "delete from countryreqs_t where country_id = '"+txtCountryID2.Text+"' and req_id = '"+reqId+"'";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    cmd = "Select c.COUNTRY_ID'Country ID', g.Reqname'Requirement Name', cr.specdetails'Requirement Details' from country_t c join countryreqs_t cr"
                + " on c.country_id = cr.country_id join genreqs_t g on cr.req_id = g.req_id"
                + " where c.countryname = '" + txtCountryName2.Text + "'";
                    int y = 0;
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        y++;
                    }
                    dr.Close();

                    string[,] reqlist = new string[3, y];
                    cmd = "Select c.COUNTRY_ID'Country ID', g.Reqname'Requirement Name', cr.specdetails'Requirement Details' from country_t c join countryreqs_t cr"
                    + " on c.country_id = cr.country_id join genreqs_t g on cr.req_id = g.req_id"
                    + " where c.countryname = '" + txtCountryName2.Text + "'";
                    int z = 0;
                    com = new MySqlCommand(cmd, connection);
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        reqlist[0, z] = dr[0].ToString();
                        reqlist[1, z] = dr[1].ToString();
                        reqlist[2, z] = dr[2].ToString();
                        z++;
                    }
                    dr.Close();
                    dgvReq2.ColumnCount = 3;
                    for (int x = 0; x < y; x++)
                    {
                        dgvReq2.Rows.Add(reqlist[0, x], reqlist[1, x], reqlist[2, x]);
                    }
                }
            }
            connection.Close();
        }

        private void ucCountryAddEdit_VisibleChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            connection = con.dbConnection();
            if (this.Visible == true)
            {
                connection.Open();
                string cmd = "select reqname from genreqs_t where allocation = 'country';";
                com = new MySqlCommand(cmd, connection);
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cbReq.Items.Add(dr[0].ToString());
                }
                dr.Close();

                cmd = "Select c.COUNTRY_ID'Country ID', g.Reqname'Requirement Name', cr.specdetails'Requirement Details' from country_t c join countryreqs_t cr"
                + " on c.country_id = cr.country_id join genreqs_t g on cr.req_id = g.req_id"
                + " where c.countryname = '" + txtCountryName2.Text + "'";
                int y = 0;
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    y++;
                }
                dr.Close();

                string[,] reqlist = new string[3,y];
                cmd = "Select c.COUNTRY_ID'Country ID', g.Reqname'Requirement Name', cr.specdetails'Requirement Details' from country_t c join countryreqs_t cr"
                + " on c.country_id = cr.country_id join genreqs_t g on cr.req_id = g.req_id"
                + " where c.countryname = '" + txtCountryName2.Text + "'";
                int z = 0;
                com = new MySqlCommand(cmd, connection);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    reqlist[0,z] = dr[0].ToString();
                    reqlist[1,z] = dr[1].ToString();
                    reqlist[2, z] = dr[2].ToString();
                    z++;
                }
                dr.Close();
                dgvReq2.ColumnCount = 3;
                for(int x = 0; x < y; x++)
                {
                    dgvReq2.Rows.Add(reqlist[0,x], reqlist[1,x], reqlist[2, x]);
                }
                
                for (int x = 0; x < dgvReq2.Rows.Count; x++)
                {
                    if (cbReq2.Items.Contains(dgvReq2.Rows[x].Cells[1].Value.ToString()))
                    {
                        cbReq2.Items.Remove(dgvReq2.Rows[x].Cells[1].Value.ToString());
                    }
                }
                cmd = "select airportname'Airports' from countryairports_t where country_id = '"+txtCountryID2.Text+"'";
                using (connection)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dgvAirports2.DataSource = ds.Tables[0];
                    }
                }
            }
            else
            {
                cbReq.Items.Clear();
                cbReq2.Items.Clear();
                dgvReq2.Rows.Clear();
            }
            connection.Close();
        }

        private void btnAddAirport1_Click(object sender, EventArgs e)
        {
            if(txtAirport1.Text != "")
            {
                dgvAirports1.ColumnCount = 1;
                dgvAirports1.Rows.Add(txtAirport1.Text);
            }
        }

        private void btnRemoveAirport1_Click(object sender, EventArgs e)
        {
            if(dgvAirports1.Rows.Count != 0)
            {
                dgvAirports1.Rows.Remove(dgvAirports1.SelectedRows[0]);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddAirport2_Click(object sender, EventArgs e)
        {
            connection.Open();
            if(txtAirport2.Text != "")
            {
                cmd = "select count(airportname) from countryairports_t where airportname = '" + txtAirport2.Text + "'";
                com = new MySqlCommand(cmd, connection);
                int ctr = int.Parse(com.ExecuteScalar()+"");
                if(ctr == 0)
                {
                    cmd = "insert into countryairports_t (country_id, airportname) values ('" + txtCountryID2.Text + "','" + txtAirport2.Text + "')";
                    com = new MySqlCommand(cmd, connection);
                    com.ExecuteNonQuery();
                    txtAirport2.Clear();
                    connection.Close();
                    cmd = "select airportname'Airports' from countryairports_t where country_id = '" + txtCountryID2.Text + "'";
                    using (connection)
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            dgvAirports2.DataSource = ds.Tables[0];
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Airport already exists.", "Add Airport Error");
                }
            }
        }

        private void btnRemoveAirport2_Click(object sender, EventArgs e)
        {
            connection.Open();
            cmd = "delete from countryairports_t where airportname = '" + dgvAirports2.SelectedRows[0].Cells[0].Value.ToString() + "'";
            com = new MySqlCommand(cmd, connection);
            com.ExecuteNonQuery();
            dgvAirports2.Rows.Remove(dgvAirports2.SelectedRows[0]);
            connection.Close();
        }
    }
}
