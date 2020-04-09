namespace InternetMarket
{
    partial class OrderForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.dateTimeCreated = new System.Windows.Forms.DateTimePicker();
            this.orderDeliveryMetod = new System.Windows.Forms.ComboBox();
            this.orderPaymentMthod = new System.Windows.Forms.ComboBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxStatus);
            this.groupBox1.Controls.Add(this.dateTimeCreated);
            this.groupBox1.Controls.Add(this.orderDeliveryMetod);
            this.groupBox1.Controls.Add(this.orderPaymentMthod);
            this.groupBox1.Controls.Add(this.textBoxId);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxPrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 415);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Accepted",
            "Canceled",
            "Processed",
            "Deliver",
            "Completed"});
            this.comboBoxStatus.Location = new System.Drawing.Point(204, 255);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(151, 33);
            this.comboBoxStatus.TabIndex = 100;
            // 
            // dateTimeCreated
            // 
            this.dateTimeCreated.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimeCreated.Location = new System.Drawing.Point(131, 101);
            this.dateTimeCreated.Name = "dateTimeCreated";
            this.dateTimeCreated.Size = new System.Drawing.Size(224, 33);
            this.dateTimeCreated.TabIndex = 99;
            // 
            // orderDeliveryMetod
            // 
            this.orderDeliveryMetod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.orderDeliveryMetod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderDeliveryMetod.FormattingEnabled = true;
            this.orderDeliveryMetod.Items.AddRange(new object[] {
            "Pickup",
            "FromNewMail",
            "Courier"});
            this.orderDeliveryMetod.Location = new System.Drawing.Point(204, 153);
            this.orderDeliveryMetod.Name = "orderDeliveryMetod";
            this.orderDeliveryMetod.Size = new System.Drawing.Size(151, 33);
            this.orderDeliveryMetod.TabIndex = 98;
            // 
            // orderPaymentMthod
            // 
            this.orderPaymentMthod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.orderPaymentMthod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderPaymentMthod.FormattingEnabled = true;
            this.orderPaymentMthod.Items.AddRange(new object[] {
            "UponReceipt",
            "VisaMastercard",
            "GooglePay"});
            this.orderPaymentMthod.Location = new System.Drawing.Point(204, 205);
            this.orderPaymentMthod.Name = "orderPaymentMthod";
            this.orderPaymentMthod.Size = new System.Drawing.Size(151, 33);
            this.orderPaymentMthod.TabIndex = 97;
            // 
            // textBoxId
            // 
            this.textBoxId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxId.Location = new System.Drawing.Point(131, 304);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(224, 29);
            this.textBoxId.TabIndex = 68;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 22);
            this.label6.TabIndex = 67;
            this.label6.Text = "CustumerID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 22);
            this.label5.TabIndex = 65;
            this.label5.Text = "StatusOrder";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OliveDrab;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(255, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 64;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(131, 357);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 40);
            this.buttonAdd.TabIndex = 63;
            this.buttonAdd.Text = "OK";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "PeymentMetod";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "DeliveryMetod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Created";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPrice.Location = new System.Drawing.Point(131, 53);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(224, 29);
            this.textBoxPrice.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "OrderPrice";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(398, 439);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrderForm";
            this.Text = "ProductForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonAdd;
        protected internal System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label5;
        protected internal System.Windows.Forms.ComboBox comboBoxStatus;
        protected internal System.Windows.Forms.DateTimePicker dateTimeCreated;
        protected internal System.Windows.Forms.ComboBox orderDeliveryMetod;
        protected internal System.Windows.Forms.ComboBox orderPaymentMthod;
        protected internal System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label6;
    }
}