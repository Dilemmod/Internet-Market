namespace InternetMarket
{
    partial class UserForm
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
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.Lo = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AdminCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AdminCheck);
            this.groupBox1.Controls.Add(this.EmailTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PasswordTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.LoginTextBox);
            this.groupBox1.Controls.Add(this.Lo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 322);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Location = new System.Drawing.Point(131, 108);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(224, 29);
            this.PasswordTextBox.TabIndex = 68;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 22);
            this.label6.TabIndex = 67;
            this.label6.Text = "Password";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OliveDrab;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(255, 264);
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
            this.buttonAdd.Location = new System.Drawing.Point(131, 264);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 40);
            this.buttonAdd.TabIndex = 63;
            this.buttonAdd.Text = "OK";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginTextBox.Location = new System.Drawing.Point(131, 53);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(224, 29);
            this.LoginTextBox.TabIndex = 1;
            // 
            // Lo
            // 
            this.Lo.AutoSize = true;
            this.Lo.Location = new System.Drawing.Point(17, 60);
            this.Lo.Name = "Lo";
            this.Lo.Size = new System.Drawing.Size(56, 22);
            this.Lo.TabIndex = 0;
            this.Lo.Text = "Login";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmailTextBox.Location = new System.Drawing.Point(131, 163);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(224, 29);
            this.EmailTextBox.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.TabIndex = 69;
            this.label1.Text = "E-mail";
            // 
            // AdminCheck
            // 
            this.AdminCheck.AutoSize = true;
            this.AdminCheck.Location = new System.Drawing.Point(21, 219);
            this.AdminCheck.Name = "AdminCheck";
            this.AdminCheck.Size = new System.Drawing.Size(83, 26);
            this.AdminCheck.TabIndex = 72;
            this.AdminCheck.Text = "Admin";
            this.AdminCheck.UseVisualStyleBackColor = true;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(398, 345);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserForm";
            this.Text = "ProductForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonAdd;
        protected internal System.Windows.Forms.TextBox LoginTextBox;
        protected internal System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label6;
        protected internal System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.CheckBox AdminCheck;
    }
}