namespace homework10
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
            this.components = new System.ComponentModel.Container();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.labCustomer = new System.Windows.Forms.Label();
            this.labGoods = new System.Windows.Forms.Label();
            this.txtGoods = new System.Windows.Forms.TextBox();
            this.labNums = new System.Windows.Forms.Label();
            this.txtNums = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(239, 33);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(157, 25);
            this.txtCustomer.TabIndex = 0;
            // 
            // labCustomer
            // 
            this.labCustomer.AutoSize = true;
            this.labCustomer.Location = new System.Drawing.Point(123, 36);
            this.labCustomer.Name = "labCustomer";
            this.labCustomer.Size = new System.Drawing.Size(67, 15);
            this.labCustomer.TabIndex = 1;
            this.labCustomer.Text = "用户姓名";
            this.labCustomer.Click += new System.EventHandler(this.labCustomer_Click);
            // 
            // labGoods
            // 
            this.labGoods.AutoSize = true;
            this.labGoods.Location = new System.Drawing.Point(123, 184);
            this.labGoods.Name = "labGoods";
            this.labGoods.Size = new System.Drawing.Size(69, 15);
            this.labGoods.TabIndex = 3;
            this.labGoods.Text = "物    品";
            // 
            // txtGoods
            // 
            this.txtGoods.Location = new System.Drawing.Point(239, 182);
            this.txtGoods.Name = "txtGoods";
            this.txtGoods.Size = new System.Drawing.Size(157, 25);
            this.txtGoods.TabIndex = 2;
            // 
            // labNums
            // 
            this.labNums.AutoSize = true;
            this.labNums.Location = new System.Drawing.Point(123, 132);
            this.labNums.Name = "labNums";
            this.labNums.Size = new System.Drawing.Size(69, 15);
            this.labNums.TabIndex = 5;
            this.labNums.Text = "数    量";
            // 
            // txtNums
            // 
            this.txtNums.Location = new System.Drawing.Point(239, 130);
            this.txtNums.Name = "txtNums";
            this.txtNums.Size = new System.Drawing.Size(157, 25);
            this.txtNums.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(125, 232);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(270, 34);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(239, 80);
            this.txtCustomerId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(157, 25);
            this.txtCustomerId.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "用户号码";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmAddOdMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 291);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labNums);
            this.Controls.Add(this.txtNums);
            this.Controls.Add(this.labGoods);
            this.Controls.Add(this.txtGoods);
            this.Controls.Add(this.labCustomer);
            this.Controls.Add(this.txtCustomer);
            this.Name = "FrmAddOdMsg";
            this.Text = "请输入订单信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAddOdMsg_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddOdMsg_FormClosed);
            this.Load += new System.EventHandler(this.FrmAddOdMsg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}