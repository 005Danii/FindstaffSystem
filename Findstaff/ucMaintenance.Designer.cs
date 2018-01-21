namespace Findstaff
{
    partial class ucMaintenance
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
            this.rbAcceptedBanks = new System.Windows.Forms.RadioButton();
            this.rbCurrency = new System.Windows.Forms.RadioButton();
            this.rbGeneralRequirements = new System.Windows.Forms.RadioButton();
            this.rbCountry = new System.Windows.Forms.RadioButton();
            this.ucGenReqs = new Findstaff.ucGenReqs();
            this.ucCountry = new Findstaff.ucCountry();
            this.ucCurrency = new Findstaff.ucCurrency();
            this.ucAcceptedBanks = new Findstaff.ucAcceptedBanks();
            this.rbBank = new System.Windows.Forms.RadioButton();
            this.ucBanks = new Findstaff.ucBanks();
            this.pnlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.White;
            this.pnlTabs.Controls.Add(this.rbBank);
            this.pnlTabs.Controls.Add(this.rbAcceptedBanks);
            this.pnlTabs.Controls.Add(this.rbCurrency);
            this.pnlTabs.Controls.Add(this.rbGeneralRequirements);
            this.pnlTabs.Controls.Add(this.rbCountry);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1118, 50);
            this.pnlTabs.TabIndex = 31;
            // 
            // rbAcceptedBanks
            // 
            this.rbAcceptedBanks.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAcceptedBanks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.rbAcceptedBanks.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbAcceptedBanks.FlatAppearance.BorderSize = 0;
            this.rbAcceptedBanks.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray;
            this.rbAcceptedBanks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rbAcceptedBanks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbAcceptedBanks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAcceptedBanks.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAcceptedBanks.ForeColor = System.Drawing.Color.White;
            this.rbAcceptedBanks.Location = new System.Drawing.Point(342, 10);
            this.rbAcceptedBanks.Name = "rbAcceptedBanks";
            this.rbAcceptedBanks.Size = new System.Drawing.Size(162, 40);
            this.rbAcceptedBanks.TabIndex = 46;
            this.rbAcceptedBanks.Text = "Accepted Banks";
            this.rbAcceptedBanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAcceptedBanks.UseVisualStyleBackColor = false;
            this.rbAcceptedBanks.CheckedChanged += new System.EventHandler(this.rbAcceptedBanks_CheckedChanged);
            // 
            // rbCurrency
            // 
            this.rbCurrency.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.rbCurrency.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbCurrency.FlatAppearance.BorderSize = 0;
            this.rbCurrency.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray;
            this.rbCurrency.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rbCurrency.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCurrency.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCurrency.ForeColor = System.Drawing.Color.White;
            this.rbCurrency.Location = new System.Drawing.Point(106, 10);
            this.rbCurrency.Name = "rbCurrency";
            this.rbCurrency.Size = new System.Drawing.Size(122, 40);
            this.rbCurrency.TabIndex = 45;
            this.rbCurrency.Text = "Currency";
            this.rbCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCurrency.UseVisualStyleBackColor = false;
            this.rbCurrency.CheckedChanged += new System.EventHandler(this.rbCurrency_CheckedChanged);
            // 
            // rbGeneralRequirements
            // 
            this.rbGeneralRequirements.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbGeneralRequirements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.rbGeneralRequirements.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbGeneralRequirements.FlatAppearance.BorderSize = 0;
            this.rbGeneralRequirements.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray;
            this.rbGeneralRequirements.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rbGeneralRequirements.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbGeneralRequirements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbGeneralRequirements.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGeneralRequirements.ForeColor = System.Drawing.Color.White;
            this.rbGeneralRequirements.Location = new System.Drawing.Point(510, 10);
            this.rbGeneralRequirements.Name = "rbGeneralRequirements";
            this.rbGeneralRequirements.Size = new System.Drawing.Size(122, 40);
            this.rbGeneralRequirements.TabIndex = 8;
            this.rbGeneralRequirements.Text = "Job Details";
            this.rbGeneralRequirements.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbGeneralRequirements.UseVisualStyleBackColor = false;
            this.rbGeneralRequirements.CheckedChanged += new System.EventHandler(this.rbGeneralRequirements_CheckedChanged);
            // 
            // rbCountry
            // 
            this.rbCountry.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.rbCountry.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbCountry.FlatAppearance.BorderSize = 0;
            this.rbCountry.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray;
            this.rbCountry.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rbCountry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCountry.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCountry.ForeColor = System.Drawing.Color.White;
            this.rbCountry.Location = new System.Drawing.Point(0, 10);
            this.rbCountry.Name = "rbCountry";
            this.rbCountry.Size = new System.Drawing.Size(100, 40);
            this.rbCountry.TabIndex = 3;
            this.rbCountry.Text = "Country";
            this.rbCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCountry.UseVisualStyleBackColor = false;
            this.rbCountry.CheckedChanged += new System.EventHandler(this.rbCountry_CheckedChanged);
            // 
            // ucGenReqs
            // 
            this.ucGenReqs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucGenReqs.Location = new System.Drawing.Point(510, 56);
            this.ucGenReqs.Name = "ucGenReqs";
            this.ucGenReqs.Size = new System.Drawing.Size(100, 100);
            this.ucGenReqs.TabIndex = 44;
            this.ucGenReqs.Visible = false;
            // 
            // ucCountry
            // 
            this.ucCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucCountry.ForeColor = System.Drawing.Color.Black;
            this.ucCountry.Location = new System.Drawing.Point(0, 56);
            this.ucCountry.Name = "ucCountry";
            this.ucCountry.Size = new System.Drawing.Size(100, 100);
            this.ucCountry.TabIndex = 43;
            this.ucCountry.Visible = false;
            // 
            // ucCurrency
            // 
            this.ucCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucCurrency.ForeColor = System.Drawing.Color.Black;
            this.ucCurrency.Location = new System.Drawing.Point(106, 56);
            this.ucCurrency.Name = "ucCurrency";
            this.ucCurrency.Size = new System.Drawing.Size(100, 100);
            this.ucCurrency.TabIndex = 45;
            // 
            // ucAcceptedBanks
            // 
            this.ucAcceptedBanks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucAcceptedBanks.ForeColor = System.Drawing.Color.Black;
            this.ucAcceptedBanks.Location = new System.Drawing.Point(342, 56);
            this.ucAcceptedBanks.Name = "ucAcceptedBanks";
            this.ucAcceptedBanks.Size = new System.Drawing.Size(100, 100);
            this.ucAcceptedBanks.TabIndex = 46;
            // 
            // rbBank
            // 
            this.rbBank.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.rbBank.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbBank.FlatAppearance.BorderSize = 0;
            this.rbBank.FlatAppearance.CheckedBackColor = System.Drawing.Color.DimGray;
            this.rbBank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.rbBank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbBank.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBank.ForeColor = System.Drawing.Color.White;
            this.rbBank.Location = new System.Drawing.Point(234, 10);
            this.rbBank.Name = "rbBank";
            this.rbBank.Size = new System.Drawing.Size(102, 40);
            this.rbBank.TabIndex = 47;
            this.rbBank.Text = "Bank";
            this.rbBank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbBank.UseVisualStyleBackColor = false;
            this.rbBank.CheckedChanged += new System.EventHandler(this.rbBank_CheckedChanged);
            // 
            // ucBanks
            // 
            this.ucBanks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ucBanks.ForeColor = System.Drawing.Color.Black;
            this.ucBanks.Location = new System.Drawing.Point(236, 56);
            this.ucBanks.Name = "ucBanks";
            this.ucBanks.Size = new System.Drawing.Size(100, 100);
            this.ucBanks.TabIndex = 47;
            this.ucBanks.Visible = false;
            // 
            // ucMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.Controls.Add(this.ucBanks);
            this.Controls.Add(this.ucAcceptedBanks);
            this.Controls.Add(this.ucCurrency);
            this.Controls.Add(this.ucGenReqs);
            this.Controls.Add(this.ucCountry);
            this.Controls.Add(this.pnlTabs);
            this.Name = "ucMaintenance";
            this.Size = new System.Drawing.Size(1118, 500);
            this.VisibleChanged += new System.EventHandler(this.ucMaintenance_VisibleChanged);
            this.pnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.RadioButton rbCountry;
        private System.Windows.Forms.RadioButton rbGeneralRequirements;
        private ucCountry ucCountry;
        private ucGenReqs ucGenReqs;
        private System.Windows.Forms.RadioButton rbAcceptedBanks;
        private System.Windows.Forms.RadioButton rbCurrency;
        private ucCurrency ucCurrency;
        private ucAcceptedBanks ucAcceptedBanks;
        private System.Windows.Forms.RadioButton rbBank;
        private ucBanks ucBanks;
    }
}
