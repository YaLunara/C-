namespace Homework7
{
    partial class FrmAddOdMsg
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
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.labCustomer = new System.Windows.Forms.Label();
            this.labGoods = new System.Windows.Forms.Label();
            this.txtGoods = new System.Windows.Forms.TextBox();
            this.labNums = new System.Windows.Forms.Label();
            this.txtNums = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(239, 55);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(157, 25);
            this.txtCustomer.TabIndex = 0;
            // 
            // labCustomer
            // 
            this.labCustomer.AutoSize = true;
            this.labCustomer.Location = new System.Drawing.Point(123, 58);
            this.labCustomer.Name = "labCustomer";
            this.labCustomer.Size = new System.Drawing.Size(67, 15);
            this.labCustomer.TabIndex = 1;
            this.labCustomer.Text = "用户姓名";
            this.labCustomer.Click += new System.EventHandler(this.labCustomer_Click);
            // 
            // labGoods
            // 
            this.labGoods.AutoSize = true;
            this.labGoods.Location = new System.Drawing.Point(123, 103);
            this.labGoods.Name = "labGoods";
            this.labGoods.Size = new System.Drawing.Size(69, 15);
            this.labGoods.TabIndex = 3;
            this.labGoods.Text = "物    品";
            // 
            // txtGoods
            // 
            this.txtGoods.Location = new System.Drawing.Point(239, 100);
            this.txtGoods.Name = "txtGoods";
            this.txtGoods.Size = new System.Drawing.Size(157, 25);
            this.txtGoods.TabIndex = 2;
            // 
            // labNums
            // 
            this.labNums.AutoSize = true;
            this.labNums.Location = new System.Drawing.Point(123, 147);
            this.labNums.Name = "labNums";
            this.labNums.Size = new System.Drawing.Size(69, 15);
            this.labNums.TabIndex = 5;
            this.labNums.Text = "数    量";
            // 
            // txtNums
            // 
            this.txtNums.Location = new System.Drawing.Point(239, 144);
            this.txtNums.Name = "txtNums";
            this.txtNums.Size = new System.Drawing.Size(157, 25);
            this.txtNums.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(126, 204);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(270, 34);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmAddOdMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 291);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labNums);
            this.Controls.Add(this.txtNums);
            this.Controls.Add(this.labGoods);
            this.Controls.Add(this.txtGoods);
            this.Controls.Add(this.labCustomer);
            this.Controls.Add(this.txtCustomer);
            this.Name = "FrmAddOdMsg";
            this.Text = "请输入订单信息";
            this.Load += new System.EventHandler(this.FrmAddOdMsg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label labCustomer;
        private System.Windows.Forms.Label labGoods;
        private System.Windows.Forms.TextBox txtGoods;
        private System.Windows.Forms.Label labNums;
        private System.Windows.Forms.TextBox txtNums;
        private System.Windows.Forms.Button btnOK;
    }
}