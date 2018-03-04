namespace Findstaff
{
    partial class ucReports
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
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.rbDepMonRep = new System.Windows.Forms.RadioButton();
            this.rbCollMonRep = new System.Windows.Forms.RadioButton();
            this.rbApplicationStatus = new System.Windows.Forms.RadioButton();
            this.ucCollectionsMonitoringReport = new Findstaff.ucCollectionsMonitoringReport();
            this.ucDeploymentMonitoringReport = new Findstaff.ucDeploymentMonitoringReport();
            this.ucApplicationStatus = new Findstaff.ucApplicationStatus();
            this.pnlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.White;
            this.pnlTabs.Controls.Add(this.rbDepMonRep);
            this.pnlTabs.Controls.Add(this.rbCollMonRep);
            this.pnlTabs.Controls.Add(this.rbApplicationStatus);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1155, 50);
            this.pnlTabs.TabIndex = 32;
            // 
            // rbDepMonRep
            // 
            this.rbDepMonRep.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDepMonRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.rbDepMonRep.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbDepMonRep.FlatAppearance.BorderSize = 0;
            this.rbDepMonRep.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray;
            this.rbDepMonRep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rbDepMonRep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbDepMonRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbDepMonRep.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDepMonRep.ForeColor = System.Drawing.Color.White;
            this.rbDepMonRep.Location = new System.Drawing.Point(256, 10);
            this.rbDepMonRep.Name = "rbDepMonRep";
            this.rbDepMonRep.Size = new System.Drawing.Size(350, 40);
            this.rbDepMonRep.TabIndex = 46;
            this.rbDepMonRep.Text = "Deployment Monitoring Report";
            this.rbDepMonRep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDepMonRep.UseVisualStyleBackColor = false;
            this.rbDepMonRep.CheckedChanged += new System.EventHandler(this.rbAcceptedBanks_CheckedChanged);
            // 
            // rbCollMonRep
            // 
            this.rbCollMonRep.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCollMonRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.rbCollMonRep.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbCollMonRep.FlatAppearance.BorderSize = 0;
            this.rbCollMonRep.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray;
            this.rbCollMonRep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rbCollMonRep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbCollMonRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCollMonRep.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCollMonRep.ForeColor = System.Drawing.Color.White;
            this.rbCollMonRep.Location = new System.Drawing.Point(612, 10);
            this.rbCollMonRep.Name = "rbCollMonRep";
            this.rbCollMonRep.Size = new System.Drawing.Size(350, 40);
            this.rbCollMonRep.TabIndex = 8;
            this.rbCollMonRep.Text = "Collections Monitoring Report";
            this.rbCollMonRep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCollMonRep.UseVisualStyleBackColor = false;
            this.rbCollMonRep.CheckedChanged += new System.EventHandler(this.rbGeneralRequirements_CheckedChanged);
            // 
            // rbApplicationStatus
            // 
            this.rbApplicationStatus.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbApplicationStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.rbApplicationStatus.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbApplicationStatus.FlatAppearance.BorderSize = 0;
            this.rbApplicationStatus.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray;
            this.rbApplicationStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rbApplicationStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbApplicationStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbApplicationStatus.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbApplicationStatus.ForeColor = System.Drawing.Color.White;
            this.rbApplicationStatus.Location = new System.Drawing.Point(0, 10);
            this.rbApplicationStatus.Name = "rbApplicationStatus";
            this.rbApplicationStatus.Size = new System.Drawing.Size(250, 40);
            this.rbApplicationStatus.TabIndex = 3;
            this.rbApplicationStatus.Text = "Application Status";
            this.rbApplicationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbApplicationStatus.UseVisualStyleBackColor = false;
            this.rbApplicationStatus.CheckedChanged += new System.EventHandler(this.rbCountry_CheckedChanged);
            // 
            // ucCollectionsMonitoringReport
            // 
            this.ucCollectionsMonitoringReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucCollectionsMonitoringReport.ForeColor = System.Drawing.Color.Black;
            this.ucCollectionsMonitoringReport.Location = new System.Drawing.Point(612, 56);
            this.ucCollectionsMonitoringReport.Name = "ucCollectionsMonitoringReport";
            this.ucCollectionsMonitoringReport.Size = new System.Drawing.Size(350, 350);
            this.ucCollectionsMonitoringReport.TabIndex = 35;
            // 
            // ucDeploymentMonitoringReport
            // 
            this.ucDeploymentMonitoringReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucDeploymentMonitoringReport.ForeColor = System.Drawing.Color.Black;
            this.ucDeploymentMonitoringReport.Location = new System.Drawing.Point(256, 56);
            this.ucDeploymentMonitoringReport.Name = "ucDeploymentMonitoringReport";
            this.ucDeploymentMonitoringReport.Size = new System.Drawing.Size(350, 350);
            this.ucDeploymentMonitoringReport.TabIndex = 34;
            // 
            // ucApplicationStatus
            // 
            this.ucApplicationStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucApplicationStatus.ForeColor = System.Drawing.Color.Black;
            this.ucApplicationStatus.Location = new System.Drawing.Point(0, 56);
            this.ucApplicationStatus.Name = "ucApplicationStatus";
            this.ucApplicationStatus.Size = new System.Drawing.Size(250, 250);
            this.ucApplicationStatus.TabIndex = 33;
            // 
            // ucReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.ucCollectionsMonitoringReport);
            this.Controls.Add(this.ucDeploymentMonitoringReport);
            this.Controls.Add(this.ucApplicationStatus);
            this.Controls.Add(this.pnlTabs);
            this.Name = "ucReports";
            this.Size = new System.Drawing.Size(1155, 500);
            this.Load += new System.EventHandler(this.ucReports_Load);
            this.pnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.RadioButton rbDepMonRep;
        private System.Windows.Forms.RadioButton rbCollMonRep;
        private System.Windows.Forms.RadioButton rbApplicationStatus;
        private ucApplicationStatus ucApplicationStatus;
        private ucDeploymentMonitoringReport ucDeploymentMonitoringReport;
        private ucCollectionsMonitoringReport ucCollectionsMonitoringReport;
    }
}
