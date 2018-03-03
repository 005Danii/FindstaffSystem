namespace Findstaff
{
    partial class ucFlightBooking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnReschedule = new System.Windows.Forms.Button();
            this.btnBookFlight = new System.Windows.Forms.Button();
            this.dgvFlightBooking = new System.Windows.Forms.DataGridView();
            this.lblFlightBooking = new System.Windows.Forms.Label();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.ucReschedFlight = new Findstaff.ucReschedFlight();
            this.ucBookFlight = new Findstaff.ucBookFlight();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightBooking)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.White;
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1118, 50);
            this.pnlTabs.TabIndex = 61;
            // 
            // btnReschedule
            // 
            this.btnReschedule.BackColor = System.Drawing.Color.White;
            this.btnReschedule.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReschedule.FlatAppearance.BorderSize = 0;
            this.btnReschedule.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnReschedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnReschedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReschedule.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReschedule.ForeColor = System.Drawing.Color.Black;
            this.btnReschedule.Location = new System.Drawing.Point(487, 472);
            this.btnReschedule.Name = "btnReschedule";
            this.btnReschedule.Size = new System.Drawing.Size(150, 50);
            this.btnReschedule.TabIndex = 65;
            this.btnReschedule.Text = "RESCHEDULE";
            this.btnReschedule.UseVisualStyleBackColor = false;
            this.btnReschedule.Click += new System.EventHandler(this.btnReschedule_Click);
            // 
            // btnBookFlight
            // 
            this.btnBookFlight.BackColor = System.Drawing.Color.White;
            this.btnBookFlight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBookFlight.FlatAppearance.BorderSize = 0;
            this.btnBookFlight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnBookFlight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnBookFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookFlight.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookFlight.ForeColor = System.Drawing.Color.Black;
            this.btnBookFlight.Location = new System.Drawing.Point(331, 472);
            this.btnBookFlight.Name = "btnBookFlight";
            this.btnBookFlight.Size = new System.Drawing.Size(150, 50);
            this.btnBookFlight.TabIndex = 64;
            this.btnBookFlight.Text = "SCHEDULE FLIGHT";
            this.btnBookFlight.UseVisualStyleBackColor = false;
            this.btnBookFlight.Click += new System.EventHandler(this.btnBookFlight_Click);
            // 
            // dgvFlightBooking
            // 
            this.dgvFlightBooking.AllowUserToAddRows = false;
            this.dgvFlightBooking.AllowUserToDeleteRows = false;
            this.dgvFlightBooking.AllowUserToResizeColumns = false;
            this.dgvFlightBooking.AllowUserToResizeRows = false;
            this.dgvFlightBooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFlightBooking.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvFlightBooking.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlightBooking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFlightBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlightBooking.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFlightBooking.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvFlightBooking.Location = new System.Drawing.Point(47, 120);
            this.dgvFlightBooking.MultiSelect = false;
            this.dgvFlightBooking.Name = "dgvFlightBooking";
            this.dgvFlightBooking.ReadOnly = true;
            this.dgvFlightBooking.RowHeadersVisible = false;
            this.dgvFlightBooking.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvFlightBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlightBooking.Size = new System.Drawing.Size(1028, 315);
            this.dgvFlightBooking.TabIndex = 63;
            // 
            // lblFlightBooking
            // 
            this.lblFlightBooking.AutoSize = true;
            this.lblFlightBooking.BackColor = System.Drawing.Color.Transparent;
            this.lblFlightBooking.Font = new System.Drawing.Font("Century", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightBooking.ForeColor = System.Drawing.Color.Black;
            this.lblFlightBooking.Location = new System.Drawing.Point(21, 69);
            this.lblFlightBooking.Name = "lblFlightBooking";
            this.lblFlightBooking.Size = new System.Drawing.Size(205, 28);
            this.lblFlightBooking.TabIndex = 62;
            this.lblFlightBooking.Text = "Flight Schedule";
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.White;
            this.btnViewDetails.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnViewDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.ForeColor = System.Drawing.Color.Black;
            this.btnViewDetails.Location = new System.Drawing.Point(643, 472);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(150, 50);
            this.btnViewDetails.TabIndex = 66;
            this.btnViewDetails.Text = "VIEW DETAILS";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // ucReschedFlight
            // 
            this.ucReschedFlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucReschedFlight.Location = new System.Drawing.Point(26, 56);
            this.ucReschedFlight.Name = "ucReschedFlight";
            this.ucReschedFlight.Size = new System.Drawing.Size(10, 10);
            this.ucReschedFlight.TabIndex = 68;
            this.ucReschedFlight.VisibleChanged += new System.EventHandler(this.ucReschedFlight_VisibleChanged);
            // 
            // ucBookFlight
            // 
            this.ucBookFlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucBookFlight.Location = new System.Drawing.Point(6, 56);
            this.ucBookFlight.Name = "ucBookFlight";
            this.ucBookFlight.Size = new System.Drawing.Size(10, 10);
            this.ucBookFlight.TabIndex = 67;
            this.ucBookFlight.VisibleChanged += new System.EventHandler(this.ucBookFlight_VisibleChanged);
            // 
            // ucFlightBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.ucReschedFlight);
            this.Controls.Add(this.ucBookFlight);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnReschedule);
            this.Controls.Add(this.btnBookFlight);
            this.Controls.Add(this.dgvFlightBooking);
            this.Controls.Add(this.lblFlightBooking);
            this.Controls.Add(this.pnlTabs);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucFlightBooking";
            this.Size = new System.Drawing.Size(1118, 546);
            this.Load += new System.EventHandler(this.ucFlightBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightBooking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnReschedule;
        private System.Windows.Forms.Button btnBookFlight;
        public System.Windows.Forms.DataGridView dgvFlightBooking;
        private System.Windows.Forms.Label lblFlightBooking;
        private System.Windows.Forms.Button btnViewDetails;
        private ucBookFlight ucBookFlight;
        private ucReschedFlight ucReschedFlight;
    }
}
