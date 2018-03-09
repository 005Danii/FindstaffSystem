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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnReschedule = new System.Windows.Forms.Button();
            this.btnBookFlight = new System.Windows.Forms.Button();
            this.dgvFlightBooking = new System.Windows.Forms.DataGridView();
            this.lblFlightBooking = new System.Windows.Forms.Label();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.ucReschedFlight = new Findstaff.ucReschedFlight();
            this.ucBookFlight = new Findstaff.ucBookFlight();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeployed = new System.Windows.Forms.Button();
            this.btnArrived = new System.Windows.Forms.Button();
            this.btnOnFlight = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightBooking)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.btnReschedule.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReschedule.ForeColor = System.Drawing.Color.Black;
            this.btnReschedule.Location = new System.Drawing.Point(407, 472);
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
            this.btnBookFlight.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookFlight.ForeColor = System.Drawing.Color.Black;
            this.btnBookFlight.Location = new System.Drawing.Point(251, 472);
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlightBooking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvFlightBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlightBooking.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvFlightBooking.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvFlightBooking.Location = new System.Drawing.Point(47, 155);
            this.dgvFlightBooking.MultiSelect = false;
            this.dgvFlightBooking.Name = "dgvFlightBooking";
            this.dgvFlightBooking.ReadOnly = true;
            this.dgvFlightBooking.RowHeadersVisible = false;
            this.dgvFlightBooking.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvFlightBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlightBooking.Size = new System.Drawing.Size(1028, 299);
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
            this.lblFlightBooking.Size = new System.Drawing.Size(252, 28);
            this.lblFlightBooking.TabIndex = 62;
            this.lblFlightBooking.Text = "Deployment Details";
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.White;
            this.btnViewDetails.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnViewDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.ForeColor = System.Drawing.Color.Black;
            this.btnViewDetails.Location = new System.Drawing.Point(563, 472);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(150, 50);
            this.btnViewDetails.TabIndex = 66;
            this.btnViewDetails.Text = "VIEW FLIGHT DETAILS";
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
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(719, 472);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 50);
            this.btnUpdate.TabIndex = 69;
            this.btnUpdate.Text = "UPDATE STATUS";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnDeployed);
            this.panel1.Controls.Add(this.btnArrived);
            this.panel1.Controls.Add(this.btnOnFlight);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(386, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 282);
            this.panel1.TabIndex = 72;
            this.panel1.Visible = false;
            // 
            // btnDeployed
            // 
            this.btnDeployed.BackColor = System.Drawing.Color.White;
            this.btnDeployed.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeployed.FlatAppearance.BorderSize = 0;
            this.btnDeployed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnDeployed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnDeployed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeployed.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeployed.ForeColor = System.Drawing.Color.Black;
            this.btnDeployed.Location = new System.Drawing.Point(98, 163);
            this.btnDeployed.Name = "btnDeployed";
            this.btnDeployed.Size = new System.Drawing.Size(150, 50);
            this.btnDeployed.TabIndex = 76;
            this.btnDeployed.Text = "DEPLOYED";
            this.btnDeployed.UseVisualStyleBackColor = false;
            this.btnDeployed.Click += new System.EventHandler(this.btnDeployed_Click);
            // 
            // btnArrived
            // 
            this.btnArrived.BackColor = System.Drawing.Color.White;
            this.btnArrived.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnArrived.FlatAppearance.BorderSize = 0;
            this.btnArrived.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnArrived.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnArrived.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrived.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrived.ForeColor = System.Drawing.Color.Black;
            this.btnArrived.Location = new System.Drawing.Point(98, 107);
            this.btnArrived.Name = "btnArrived";
            this.btnArrived.Size = new System.Drawing.Size(150, 50);
            this.btnArrived.TabIndex = 75;
            this.btnArrived.Text = "ARRIVED";
            this.btnArrived.UseVisualStyleBackColor = false;
            this.btnArrived.Click += new System.EventHandler(this.btnArrived_Click);
            // 
            // btnOnFlight
            // 
            this.btnOnFlight.BackColor = System.Drawing.Color.White;
            this.btnOnFlight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOnFlight.FlatAppearance.BorderSize = 0;
            this.btnOnFlight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnOnFlight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnOnFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnFlight.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnFlight.ForeColor = System.Drawing.Color.Black;
            this.btnOnFlight.Location = new System.Drawing.Point(98, 51);
            this.btnOnFlight.Name = "btnOnFlight";
            this.btnOnFlight.Size = new System.Drawing.Size(150, 50);
            this.btnOnFlight.TabIndex = 74;
            this.btnOnFlight.Text = "ON FLIGHT";
            this.btnOnFlight.UseVisualStyleBackColor = false;
            this.btnOnFlight.Click += new System.EventHandler(this.btnOnFlight_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(98, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 50);
            this.btnCancel.TabIndex = 77;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(80, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 28);
            this.label1.TabIndex = 64;
            this.label1.Text = "Update Status";
            // 
            // ucFlightBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucReschedFlight);
            this.Controls.Add(this.ucBookFlight);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnReschedule);
            this.Controls.Add(this.btnBookFlight);
            this.Controls.Add(this.dgvFlightBooking);
            this.Controls.Add(this.lblFlightBooking);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.btnUpdate);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucFlightBooking";
            this.Size = new System.Drawing.Size(1118, 546);
            this.Load += new System.EventHandler(this.ucFlightBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightBooking)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeployed;
        private System.Windows.Forms.Button btnArrived;
        private System.Windows.Forms.Button btnOnFlight;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
    }
}
