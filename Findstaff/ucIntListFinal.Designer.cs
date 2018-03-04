namespace Findstaff
{
    partial class ucIntListFinal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvIntervieweeList = new System.Windows.Forms.DataGridView();
            this.lblJob = new System.Windows.Forms.Label();
            this.lblEmp = new System.Windows.Forms.Label();
            this.lblJobOrder = new System.Windows.Forms.Label();
            this.lblIntervieweeList = new System.Windows.Forms.Label();
            this.employer = new System.Windows.Forms.Label();
            this.joborder = new System.Windows.Forms.Label();
            this.jobname = new System.Windows.Forms.Label();
            this.btnAssess = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFinalInterviewSched = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.lblCountry = new System.Windows.Forms.Label();
            this.ucFinInAssess = new Findstaff.ucFinInAssess();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervieweeList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIntervieweeList
            // 
            this.dgvIntervieweeList.AllowUserToAddRows = false;
            this.dgvIntervieweeList.AllowUserToDeleteRows = false;
            this.dgvIntervieweeList.AllowUserToResizeColumns = false;
            this.dgvIntervieweeList.AllowUserToResizeRows = false;
            this.dgvIntervieweeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIntervieweeList.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvIntervieweeList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIntervieweeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIntervieweeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIntervieweeList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvIntervieweeList.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvIntervieweeList.Location = new System.Drawing.Point(53, 106);
            this.dgvIntervieweeList.MultiSelect = false;
            this.dgvIntervieweeList.Name = "dgvIntervieweeList";
            this.dgvIntervieweeList.ReadOnly = true;
            this.dgvIntervieweeList.RowHeadersVisible = false;
            this.dgvIntervieweeList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvIntervieweeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIntervieweeList.Size = new System.Drawing.Size(1056, 327);
            this.dgvIntervieweeList.TabIndex = 51;
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJob.ForeColor = System.Drawing.Color.Black;
            this.lblJob.Location = new System.Drawing.Point(448, 74);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(43, 20);
            this.lblJob.TabIndex = 50;
            this.lblJob.Text = "Job :";
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmp.ForeColor = System.Drawing.Color.Black;
            this.lblEmp.Location = new System.Drawing.Point(761, 74);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(89, 20);
            this.lblEmp.TabIndex = 49;
            this.lblEmp.Text = "Employer :";
            // 
            // lblJobOrder
            // 
            this.lblJobOrder.AutoSize = true;
            this.lblJobOrder.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobOrder.ForeColor = System.Drawing.Color.Black;
            this.lblJobOrder.Location = new System.Drawing.Point(100, 74);
            this.lblJobOrder.Name = "lblJobOrder";
            this.lblJobOrder.Size = new System.Drawing.Size(90, 20);
            this.lblJobOrder.TabIndex = 48;
            this.lblJobOrder.Text = "Job Order :";
            // 
            // lblIntervieweeList
            // 
            this.lblIntervieweeList.AutoSize = true;
            this.lblIntervieweeList.Font = new System.Drawing.Font("Century", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntervieweeList.ForeColor = System.Drawing.Color.Black;
            this.lblIntervieweeList.Location = new System.Drawing.Point(25, 25);
            this.lblIntervieweeList.Name = "lblIntervieweeList";
            this.lblIntervieweeList.Size = new System.Drawing.Size(212, 28);
            this.lblIntervieweeList.TabIndex = 47;
            this.lblIntervieweeList.Text = "Interviewee List";
            // 
            // employer
            // 
            this.employer.AutoSize = true;
            this.employer.BackColor = System.Drawing.Color.Transparent;
            this.employer.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employer.ForeColor = System.Drawing.Color.Black;
            this.employer.Location = new System.Drawing.Point(857, 74);
            this.employer.Name = "employer";
            this.employer.Size = new System.Drawing.Size(77, 20);
            this.employer.TabIndex = 487;
            this.employer.Text = "employer";
            // 
            // joborder
            // 
            this.joborder.AutoSize = true;
            this.joborder.BackColor = System.Drawing.Color.Transparent;
            this.joborder.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joborder.ForeColor = System.Drawing.Color.Black;
            this.joborder.Location = new System.Drawing.Point(198, 74);
            this.joborder.Name = "joborder";
            this.joborder.Size = new System.Drawing.Size(70, 20);
            this.joborder.TabIndex = 486;
            this.joborder.Text = "joborder";
            // 
            // jobname
            // 
            this.jobname.AutoSize = true;
            this.jobname.BackColor = System.Drawing.Color.Transparent;
            this.jobname.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobname.ForeColor = System.Drawing.Color.Black;
            this.jobname.Location = new System.Drawing.Point(496, 74);
            this.jobname.Name = "jobname";
            this.jobname.Size = new System.Drawing.Size(72, 20);
            this.jobname.TabIndex = 485;
            this.jobname.Text = "jobname";
            // 
            // btnAssess
            // 
            this.btnAssess.BackColor = System.Drawing.Color.White;
            this.btnAssess.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAssess.FlatAppearance.BorderSize = 0;
            this.btnAssess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssess.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssess.ForeColor = System.Drawing.Color.Black;
            this.btnAssess.Location = new System.Drawing.Point(600, 446);
            this.btnAssess.Name = "btnAssess";
            this.btnAssess.Size = new System.Drawing.Size(100, 38);
            this.btnAssess.TabIndex = 505;
            this.btnAssess.Text = "ASSESS";
            this.btnAssess.UseVisualStyleBackColor = false;
            this.btnAssess.Click += new System.EventHandler(this.btnAssess_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(706, 446);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 38);
            this.btnClose.TabIndex = 504;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFinalInterviewSched
            // 
            this.btnFinalInterviewSched.BackColor = System.Drawing.Color.White;
            this.btnFinalInterviewSched.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnFinalInterviewSched.FlatAppearance.BorderSize = 0;
            this.btnFinalInterviewSched.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalInterviewSched.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalInterviewSched.ForeColor = System.Drawing.Color.Black;
            this.btnFinalInterviewSched.Location = new System.Drawing.Point(343, 446);
            this.btnFinalInterviewSched.Name = "btnFinalInterviewSched";
            this.btnFinalInterviewSched.Size = new System.Drawing.Size(251, 38);
            this.btnFinalInterviewSched.TabIndex = 503;
            this.btnFinalInterviewSched.Text = "SCHEDULE INTERVIEWEE";
            this.btnFinalInterviewSched.UseVisualStyleBackColor = false;
            this.btnFinalInterviewSched.Click += new System.EventHandler(this.btnFinalInterviewSched_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.lblCountry);
            this.panel1.Controls.Add(this.dtp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSchedule);
            this.panel1.Location = new System.Drawing.Point(271, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 184);
            this.panel1.TabIndex = 506;
            this.panel1.Visible = false;
            this.panel1.VisibleChanged += new System.EventHandler(this.panel1_VisibleChanged);
            // 
            // dtp
            // 
            this.dtp.CalendarFont = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Location = new System.Drawing.Point(105, 80);
            this.dtp.MinDate = new System.DateTime(2018, 2, 18, 0, 0, 0, 0);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(399, 27);
            this.dtp.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(51, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 73;
            this.label1.Text = "Date:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(282, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 33);
            this.btnCancel.TabIndex = 71;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.White;
            this.btnSchedule.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.ForeColor = System.Drawing.Color.Black;
            this.btnSchedule.Location = new System.Drawing.Point(152, 133);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(124, 33);
            this.btnSchedule.TabIndex = 70;
            this.btnSchedule.Text = "SCHEDULE";
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Century", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ForeColor = System.Drawing.Color.Black;
            this.lblCountry.Location = new System.Drawing.Point(122, 22);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(310, 28);
            this.lblCountry.TabIndex = 75;
            this.lblCountry.Text = "Date for Final Interview";
            // 
            // ucFinInAssess
            // 
            this.ucFinInAssess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucFinInAssess.Location = new System.Drawing.Point(3, 3);
            this.ucFinInAssess.Name = "ucFinInAssess";
            this.ucFinInAssess.Size = new System.Drawing.Size(10, 10);
            this.ucFinInAssess.TabIndex = 502;
            this.ucFinInAssess.Visible = false;
            this.ucFinInAssess.VisibleChanged += new System.EventHandler(this.ucFinInAssess_VisibleChanged);
            // 
            // ucIntListFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAssess);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFinalInterviewSched);
            this.Controls.Add(this.ucFinInAssess);
            this.Controls.Add(this.employer);
            this.Controls.Add(this.joborder);
            this.Controls.Add(this.jobname);
            this.Controls.Add(this.dgvIntervieweeList);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblEmp);
            this.Controls.Add(this.lblJobOrder);
            this.Controls.Add(this.lblIntervieweeList);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucIntListFinal";
            this.Size = new System.Drawing.Size(1155, 500);
            this.Load += new System.EventHandler(this.ucIntListFinal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervieweeList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblEmp;
        private System.Windows.Forms.Label lblJobOrder;
        private System.Windows.Forms.Label lblIntervieweeList;
        public System.Windows.Forms.DataGridView dgvIntervieweeList;
        public System.Windows.Forms.Label employer;
        public System.Windows.Forms.Label joborder;
        public System.Windows.Forms.Label jobname;
        private ucFinInAssess ucFinInAssess;
        private System.Windows.Forms.Button btnAssess;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFinalInterviewSched;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnSchedule;
    }
}
