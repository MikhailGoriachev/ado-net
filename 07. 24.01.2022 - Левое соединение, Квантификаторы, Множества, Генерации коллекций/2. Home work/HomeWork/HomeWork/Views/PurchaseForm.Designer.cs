namespace HomeWork.Views
{
    partial class PurchaseForm
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
            this.LblHeader = new System.Windows.Forms.Label();
            this.LblGoods = new System.Windows.Forms.Label();
            this.LblUnit = new System.Windows.Forms.Label();
            this.LblPrice = new System.Windows.Forms.Label();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.CmbGoods = new System.Windows.Forms.ComboBox();
            this.CmbUnits = new System.Windows.Forms.ComboBox();
            this.NudPrice = new System.Windows.Forms.NumericUpDown();
            this.NudAmount = new System.Windows.Forms.NumericUpDown();
            this.TbxDate = new System.Windows.Forms.MaskedTextBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtbCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // LblHeader
            // 
            this.LblHeader.BackColor = System.Drawing.Color.Silver;
            this.LblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblHeader.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblHeader.Location = new System.Drawing.Point(0, 0);
            this.LblHeader.Name = "LblHeader";
            this.LblHeader.Size = new System.Drawing.Size(657, 40);
            this.LblHeader.TabIndex = 0;
            this.LblHeader.Text = "Добавление закупки";
            this.LblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblGoods
            // 
            this.LblGoods.BackColor = System.Drawing.Color.Silver;
            this.LblGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblGoods.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblGoods.Location = new System.Drawing.Point(24, 64);
            this.LblGoods.Name = "LblGoods";
            this.LblGoods.Size = new System.Drawing.Size(272, 32);
            this.LblGoods.TabIndex = 1;
            this.LblGoods.Text = "Товар";
            this.LblGoods.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblUnit
            // 
            this.LblUnit.BackColor = System.Drawing.Color.Silver;
            this.LblUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblUnit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblUnit.Location = new System.Drawing.Point(24, 152);
            this.LblUnit.Name = "LblUnit";
            this.LblUnit.Size = new System.Drawing.Size(272, 32);
            this.LblUnit.TabIndex = 2;
            this.LblUnit.Text = "Единицы измерения";
            this.LblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPrice
            // 
            this.LblPrice.BackColor = System.Drawing.Color.Silver;
            this.LblPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblPrice.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblPrice.Location = new System.Drawing.Point(24, 240);
            this.LblPrice.Name = "LblPrice";
            this.LblPrice.Size = new System.Drawing.Size(272, 32);
            this.LblPrice.TabIndex = 3;
            this.LblPrice.Text = "Цена";
            this.LblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblAmount
            // 
            this.LblAmount.BackColor = System.Drawing.Color.Silver;
            this.LblAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblAmount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblAmount.Location = new System.Drawing.Point(360, 64);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(272, 32);
            this.LblAmount.TabIndex = 4;
            this.LblAmount.Text = "Количество";
            this.LblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblDate
            // 
            this.LblDate.BackColor = System.Drawing.Color.Silver;
            this.LblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblDate.Location = new System.Drawing.Point(360, 152);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(272, 32);
            this.LblDate.TabIndex = 5;
            this.LblDate.Text = "Дата закупки";
            this.LblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbGoods
            // 
            this.CmbGoods.BackColor = System.Drawing.Color.LightGray;
            this.CmbGoods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGoods.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CmbGoods.FormattingEnabled = true;
            this.CmbGoods.Location = new System.Drawing.Point(24, 96);
            this.CmbGoods.Name = "CmbGoods";
            this.CmbGoods.Size = new System.Drawing.Size(272, 26);
            this.CmbGoods.TabIndex = 0;
            // 
            // CmbUnits
            // 
            this.CmbUnits.BackColor = System.Drawing.Color.LightGray;
            this.CmbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUnits.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CmbUnits.FormattingEnabled = true;
            this.CmbUnits.Location = new System.Drawing.Point(24, 184);
            this.CmbUnits.Name = "CmbUnits";
            this.CmbUnits.Size = new System.Drawing.Size(272, 26);
            this.CmbUnits.TabIndex = 1;
            // 
            // NudPrice
            // 
            this.NudPrice.BackColor = System.Drawing.Color.LightGray;
            this.NudPrice.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudPrice.Location = new System.Drawing.Point(24, 272);
            this.NudPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NudPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudPrice.Name = "NudPrice";
            this.NudPrice.Size = new System.Drawing.Size(272, 27);
            this.NudPrice.TabIndex = 2;
            this.NudPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudAmount
            // 
            this.NudAmount.BackColor = System.Drawing.Color.LightGray;
            this.NudAmount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudAmount.Location = new System.Drawing.Point(360, 96);
            this.NudAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NudAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudAmount.Name = "NudAmount";
            this.NudAmount.Size = new System.Drawing.Size(272, 27);
            this.NudAmount.TabIndex = 3;
            this.NudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TbxDate
            // 
            this.TbxDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxDate.Location = new System.Drawing.Point(360, 184);
            this.TbxDate.Mask = "00/00/0000";
            this.TbxDate.Name = "TbxDate";
            this.TbxDate.Size = new System.Drawing.Size(272, 27);
            this.TbxDate.TabIndex = 4;
            this.TbxDate.ValidatingType = typeof(System.DateTime);
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOk.Location = new System.Drawing.Point(360, 256);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(128, 40);
            this.BtnOk.TabIndex = 5;
            this.BtnOk.Text = "Добавить";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtbCancel
            // 
            this.BtbCancel.BackColor = System.Drawing.Color.IndianRed;
            this.BtbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtbCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtbCancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtbCancel.Location = new System.Drawing.Point(504, 256);
            this.BtbCancel.Name = "BtbCancel";
            this.BtbCancel.Size = new System.Drawing.Size(128, 40);
            this.BtbCancel.TabIndex = 6;
            this.BtbCancel.Text = "Отмена";
            this.BtbCancel.UseVisualStyleBackColor = false;
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(657, 324);
            this.Controls.Add(this.BtbCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TbxDate);
            this.Controls.Add(this.NudAmount);
            this.Controls.Add(this.NudPrice);
            this.Controls.Add(this.CmbUnits);
            this.Controls.Add(this.CmbGoods);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.LblPrice);
            this.Controls.Add(this.LblUnit);
            this.Controls.Add(this.LblGoods);
            this.Controls.Add(this.LblHeader);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление закупки";
            ((System.ComponentModel.ISupportInitialize)(this.NudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHeader;
        private System.Windows.Forms.Label LblGoods;
        private System.Windows.Forms.Label LblUnit;
        private System.Windows.Forms.Label LblPrice;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.ComboBox CmbGoods;
        private System.Windows.Forms.ComboBox CmbUnits;
        private System.Windows.Forms.NumericUpDown NudPrice;
        private System.Windows.Forms.NumericUpDown NudAmount;
        private System.Windows.Forms.MaskedTextBox TbxDate;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtbCancel;
    }
}