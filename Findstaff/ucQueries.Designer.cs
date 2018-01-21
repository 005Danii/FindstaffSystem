namespace Findstaff
{
    partial class ucQueries
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbQuery = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvQueries = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueries)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.White;
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1555, 50);
            this.pnlTabs.TabIndex = 314;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.White;
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.Black;
            this.btnLoad.Location = new System.Drawing.Point(414, 78);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(114, 30);
            this.btnLoad.TabIndex = 313;
            this.btnLoad.Text = "GENERATE";
            this.btnLoad.UseVisualStyleBackColor = false;
            // 
            // cbQuery
            // 
            this.cbQuery.BackColor = System.Drawing.Color.White;
            this.cbQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuery.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQuery.ForeColor = System.Drawing.Color.Black;
            this.cbQuery.FormattingEnabled = true;
            this.cbQuery.Location = new System.Drawing.Point(111, 81);
            this.cbQuery.Name = "cbQuery";
            this.cbQuery.Size = new System.Drawing.Size(297, 28);
            this.cbQuery.TabIndex = 312;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(46, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 20);
            this.label8.TabIndex = 311;
            this.label8.Text = "Query:";
            // 
            // dgvQueries
            // 
            this.dgvQueries.AllowUserToAddRows = false;
            this.dgvQueries.AllowUserToDeleteRows = false;
            this.dgvQueries.AllowUserToResizeColumns = false;
            this.dgvQueries.AllowUserToResizeRows = false;
            this.dgvQueries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQueries.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvQueries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQueries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQueries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQueries.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQueries.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvQueries.Location = new System.Drawing.Point(50, 119);
            this.dgvQueries.MultiSelect = false;
            this.dgvQueries.Name = "dgvQueries";
            this.dgvQueries.ReadOnly = true;
            this.dgvQueries.RowHeadersVisible = false;
            this.dgvQueries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvQueries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueries.Size = new System.Drawing.Size(1059, 373);
            this.dgvQueries.TabIndex = 310;
            // 
            // ucQueries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cbQuery);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvQueries);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucQueries";
            this.Size = new System.Drawing.Size(1555, 547);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cbQuery;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataGridView dgvQueries;
    }
}
