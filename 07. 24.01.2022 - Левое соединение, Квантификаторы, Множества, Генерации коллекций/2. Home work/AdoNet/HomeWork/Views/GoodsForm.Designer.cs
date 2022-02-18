namespace HomeWork.Views
{
    partial class GoodsForm
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
            this.BtbCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.LblGoods = new System.Windows.Forms.Label();
            this.TbxTitle = new System.Windows.Forms.TextBox();
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
            this.LblHeader.Size = new System.Drawing.Size(442, 40);
            this.LblHeader.TabIndex = 1;
            this.LblHeader.Text = "Добавление товара";
            this.LblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtbCancel
            // 
            this.BtbCancel.BackColor = System.Drawing.Color.IndianRed;
            this.BtbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtbCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtbCancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtbCancel.Location = new System.Drawing.Point(280, 144);
            this.BtbCancel.Name = "BtbCancel";
            this.BtbCancel.Size = new System.Drawing.Size(128, 40);
            this.BtbCancel.TabIndex = 8;
            this.BtbCancel.Text = "Отмена";
            this.BtbCancel.UseVisualStyleBackColor = false;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOk.Location = new System.Drawing.Point(136, 144);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(128, 40);
            this.BtnOk.TabIndex = 7;
            this.BtnOk.Text = "Добавить";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // LblGoods
            // 
            this.LblGoods.BackColor = System.Drawing.Color.Silver;
            this.LblGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblGoods.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblGoods.Location = new System.Drawing.Point(24, 64);
            this.LblGoods.Name = "LblGoods";
            this.LblGoods.Size = new System.Drawing.Size(384, 32);
            this.LblGoods.TabIndex = 10;
            this.LblGoods.Text = "Наименование товара";
            this.LblGoods.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbxTitle
            // 
            this.TbxTitle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxTitle.Location = new System.Drawing.Point(24, 96);
            this.TbxTitle.Name = "TbxTitle";
            this.TbxTitle.Size = new System.Drawing.Size(384, 27);
            this.TbxTitle.TabIndex = 11;
            this.TbxTitle.TextChanged += new System.EventHandler(this.TbxTitle_TextChanged);
            // 
            // GoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(442, 210);
            this.Controls.Add(this.TbxTitle);
            this.Controls.Add(this.LblGoods);
            this.Controls.Add(this.BtbCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LblHeader);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoodsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление товара";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHeader;
        private System.Windows.Forms.Button BtbCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label LblGoods;
        private System.Windows.Forms.TextBox TbxTitle;
    }
}