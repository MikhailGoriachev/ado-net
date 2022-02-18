namespace HomeWork.Views
{
    partial class InfoForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.LblInfo = new System.Windows.Forms.Label();
            this.GrpInfo = new System.Windows.Forms.GroupBox();
            this.GbxGroup = new System.Windows.Forms.GroupBox();
            this.LblGroup = new System.Windows.Forms.Label();
            this.GbxName = new System.Windows.Forms.GroupBox();
            this.LblName = new System.Windows.Forms.Label();
            this.GbxSurname = new System.Windows.Forms.GroupBox();
            this.LblSurname = new System.Windows.Forms.Label();
            this.TbxInfoProgram = new System.Windows.Forms.TextBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.GbxInfoProgram = new System.Windows.Forms.GroupBox();
            this.GrpInfo.SuspendLayout();
            this.GbxGroup.SuspendLayout();
            this.GbxName.SuspendLayout();
            this.GbxSurname.SuspendLayout();
            this.GbxInfoProgram.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblInfo
            // 
            this.LblInfo.BackColor = System.Drawing.Color.DarkGray;
            this.LblInfo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblInfo.ForeColor = System.Drawing.Color.Transparent;
            this.LblInfo.Location = new System.Drawing.Point(48, 24);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(368, 56);
            this.LblInfo.TabIndex = 1;
            this.LblInfo.Text = "О программе";
            this.LblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GrpInfo
            // 
            this.GrpInfo.Controls.Add(this.GbxGroup);
            this.GrpInfo.Controls.Add(this.GbxName);
            this.GrpInfo.Controls.Add(this.GbxSurname);
            this.GrpInfo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GrpInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GrpInfo.Location = new System.Drawing.Point(48, 120);
            this.GrpInfo.Name = "GrpInfo";
            this.GrpInfo.Size = new System.Drawing.Size(368, 320);
            this.GrpInfo.TabIndex = 2;
            this.GrpInfo.TabStop = false;
            this.GrpInfo.Text = " Информация о разработчике ";
            // 
            // GbxGroup
            // 
            this.GbxGroup.Controls.Add(this.LblGroup);
            this.GbxGroup.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GbxGroup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GbxGroup.Location = new System.Drawing.Point(16, 216);
            this.GbxGroup.Name = "GbxGroup";
            this.GbxGroup.Size = new System.Drawing.Size(336, 72);
            this.GbxGroup.TabIndex = 5;
            this.GbxGroup.TabStop = false;
            this.GbxGroup.Text = "Группа";
            // 
            // LblGroup
            // 
            this.LblGroup.BackColor = System.Drawing.Color.Gray;
            this.LblGroup.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblGroup.ForeColor = System.Drawing.Color.Transparent;
            this.LblGroup.Location = new System.Drawing.Point(8, 24);
            this.LblGroup.Name = "LblGroup";
            this.LblGroup.Size = new System.Drawing.Size(320, 40);
            this.LblGroup.TabIndex = 5;
            this.LblGroup.Text = "ПУ011";
            this.LblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GbxName
            // 
            this.GbxName.Controls.Add(this.LblName);
            this.GbxName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GbxName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GbxName.Location = new System.Drawing.Point(16, 128);
            this.GbxName.Name = "GbxName";
            this.GbxName.Size = new System.Drawing.Size(336, 72);
            this.GbxName.TabIndex = 4;
            this.GbxName.TabStop = false;
            this.GbxName.Text = "Имя";
            // 
            // LblName
            // 
            this.LblName.BackColor = System.Drawing.Color.Gray;
            this.LblName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblName.ForeColor = System.Drawing.Color.Transparent;
            this.LblName.Location = new System.Drawing.Point(8, 24);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(320, 40);
            this.LblName.TabIndex = 4;
            this.LblName.Text = "Михаил";
            this.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GbxSurname
            // 
            this.GbxSurname.Controls.Add(this.LblSurname);
            this.GbxSurname.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GbxSurname.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GbxSurname.Location = new System.Drawing.Point(16, 40);
            this.GbxSurname.Name = "GbxSurname";
            this.GbxSurname.Size = new System.Drawing.Size(336, 72);
            this.GbxSurname.TabIndex = 3;
            this.GbxSurname.TabStop = false;
            this.GbxSurname.Text = "Фамилия";
            // 
            // LblSurname
            // 
            this.LblSurname.BackColor = System.Drawing.Color.Gray;
            this.LblSurname.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblSurname.ForeColor = System.Drawing.Color.Transparent;
            this.LblSurname.Location = new System.Drawing.Point(8, 24);
            this.LblSurname.Name = "LblSurname";
            this.LblSurname.Size = new System.Drawing.Size(320, 40);
            this.LblSurname.TabIndex = 3;
            this.LblSurname.Text = "Горячев";
            this.LblSurname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbxInfoProgram
            // 
            this.TbxInfoProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxInfoProgram.BackColor = System.Drawing.Color.DarkGray;
            this.TbxInfoProgram.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxInfoProgram.Location = new System.Drawing.Point(16, 32);
            this.TbxInfoProgram.Multiline = true;
            this.TbxInfoProgram.Name = "TbxInfoProgram";
            this.TbxInfoProgram.ReadOnly = true;
            this.TbxInfoProgram.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbxInfoProgram.Size = new System.Drawing.Size(622, 464);
            this.TbxInfoProgram.TabIndex = 4;
            this.TbxInfoProgram.TabStop = false;
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExit.BackColor = System.Drawing.Color.IndianRed;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnExit.ForeColor = System.Drawing.Color.Transparent;
            this.BtnExit.Location = new System.Drawing.Point(48, 464);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(368, 64);
            this.BtnExit.TabIndex = 0;
            this.BtnExit.Text = "Выход";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // GbxInfoProgram
            // 
            this.GbxInfoProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbxInfoProgram.Controls.Add(this.TbxInfoProgram);
            this.GbxInfoProgram.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GbxInfoProgram.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GbxInfoProgram.Location = new System.Drawing.Point(432, 16);
            this.GbxInfoProgram.Name = "GbxInfoProgram";
            this.GbxInfoProgram.Size = new System.Drawing.Size(646, 512);
            this.GbxInfoProgram.TabIndex = 6;
            this.GbxInfoProgram.TabStop = false;
            this.GbxInfoProgram.Text = " Информация о программе ";
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1118, 553);
            this.Controls.Add(this.GbxInfoProgram);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.GrpInfo);
            this.Controls.Add(this.LblInfo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 592);
            this.Name = "FormInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.FormInfo_Load);
            this.GrpInfo.ResumeLayout(false);
            this.GbxGroup.ResumeLayout(false);
            this.GbxName.ResumeLayout(false);
            this.GbxSurname.ResumeLayout(false);
            this.GbxInfoProgram.ResumeLayout(false);
            this.GbxInfoProgram.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.GroupBox GrpInfo;
        private System.Windows.Forms.GroupBox GbxGroup;
        private System.Windows.Forms.GroupBox GbxName;
        private System.Windows.Forms.GroupBox GbxSurname;
        private System.Windows.Forms.Label LblGroup;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblSurname;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.TextBox TbxInfoProgram;
        private System.Windows.Forms.GroupBox GbxInfoProgram;
    }
}