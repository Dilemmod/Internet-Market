namespace InternetMarket
{
    partial class AdminForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.buttonUsersDel = new System.Windows.Forms.Button();
            this.buttonUsersChange = new System.Windows.Forms.Button();
            this.buttonUsersAdd = new System.Windows.Forms.Button();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.panelDataMenegers = new System.Windows.Forms.Panel();
            this.buttonMenegerDel = new System.Windows.Forms.Button();
            this.buttonMenegerChange = new System.Windows.Forms.Button();
            this.buttonMenegerAdd = new System.Windows.Forms.Button();
            this.dataGridViewMenegers = new System.Windows.Forms.DataGridView();
            this.panelDataCustumer = new System.Windows.Forms.Panel();
            this.buttonCustumerDelete = new System.Windows.Forms.Button();
            this.buttonCustumerAChange = new System.Windows.Forms.Button();
            this.buttonCustumerAdd = new System.Windows.Forms.Button();
            this.dataGridViewCustumers = new System.Windows.Forms.DataGridView();
            this.panelOrders = new System.Windows.Forms.Panel();
            this.OrdersDelButton = new System.Windows.Forms.Button();
            this.OrdersChangeButton = new System.Windows.Forms.Button();
            this.OrdersAddButton = new System.Windows.Forms.Button();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridViewPdoructs = new System.Windows.Forms.DataGridView();
            this.CatalogPanel = new System.Windows.Forms.Panel();
            this.ProductsButton = new System.Windows.Forms.Label();
            this.OrdersButton = new System.Windows.Forms.Label();
            this.DataCustumersButton = new System.Windows.Forms.Label();
            this.DataManagersButton = new System.Windows.Forms.Label();
            this.UsersButton = new System.Windows.Forms.Label();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.LogoIT = new System.Windows.Forms.Label();
            this.logoM = new System.Windows.Forms.Label();
            this.panelExit = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Label();
            this.Catalog = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.panelUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.panelDataMenegers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenegers)).BeginInit();
            this.panelDataCustumer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustumers)).BeginInit();
            this.panelOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.panelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPdoructs)).BeginInit();
            this.CatalogPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.panelExit.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.panelUsers);
            this.MainPanel.Controls.Add(this.panelDataMenegers);
            this.MainPanel.Controls.Add(this.panelDataCustumer);
            this.MainPanel.Controls.Add(this.panelOrders);
            this.MainPanel.Controls.Add(this.panelProducts);
            this.MainPanel.Controls.Add(this.CatalogPanel);
            this.MainPanel.Controls.Add(this.logoPanel);
            this.MainPanel.Controls.Add(this.panelExit);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1320, 1034);
            this.MainPanel.TabIndex = 0;
            // 
            // panelUsers
            // 
            this.panelUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelUsers.Controls.Add(this.buttonUsersDel);
            this.panelUsers.Controls.Add(this.buttonUsersChange);
            this.panelUsers.Controls.Add(this.buttonUsersAdd);
            this.panelUsers.Controls.Add(this.dataGridViewUsers);
            this.panelUsers.Location = new System.Drawing.Point(58, 666);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(57, 56);
            this.panelUsers.TabIndex = 66;
            this.panelUsers.Visible = false;
            // 
            // buttonUsersDel
            // 
            this.buttonUsersDel.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonUsersDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUsersDel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUsersDel.ForeColor = System.Drawing.Color.White;
            this.buttonUsersDel.Location = new System.Drawing.Point(801, 39);
            this.buttonUsersDel.Name = "buttonUsersDel";
            this.buttonUsersDel.Size = new System.Drawing.Size(173, 41);
            this.buttonUsersDel.TabIndex = 64;
            this.buttonUsersDel.Text = "Delete";
            this.buttonUsersDel.UseVisualStyleBackColor = false;
            this.buttonUsersDel.Click += new System.EventHandler(this.buttonUsersDel_Click);
            // 
            // buttonUsersChange
            // 
            this.buttonUsersChange.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonUsersChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUsersChange.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUsersChange.ForeColor = System.Drawing.Color.White;
            this.buttonUsersChange.Location = new System.Drawing.Point(453, 39);
            this.buttonUsersChange.Name = "buttonUsersChange";
            this.buttonUsersChange.Size = new System.Drawing.Size(173, 41);
            this.buttonUsersChange.TabIndex = 63;
            this.buttonUsersChange.Text = "Change";
            this.buttonUsersChange.UseVisualStyleBackColor = false;
            this.buttonUsersChange.Click += new System.EventHandler(this.buttonUsersChange_Click);
            // 
            // buttonUsersAdd
            // 
            this.buttonUsersAdd.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonUsersAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUsersAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUsersAdd.ForeColor = System.Drawing.Color.White;
            this.buttonUsersAdd.Location = new System.Drawing.Point(111, 39);
            this.buttonUsersAdd.Name = "buttonUsersAdd";
            this.buttonUsersAdd.Size = new System.Drawing.Size(173, 41);
            this.buttonUsersAdd.TabIndex = 62;
            this.buttonUsersAdd.Text = "Add";
            this.buttonUsersAdd.UseVisualStyleBackColor = false;
            this.buttonUsersAdd.Click += new System.EventHandler(this.buttonUsersAdd_Click);
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewUsers.GridColor = System.Drawing.Color.OliveDrab;
            this.dataGridViewUsers.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(1026, 745);
            this.dataGridViewUsers.TabIndex = 61;
            // 
            // panelDataMenegers
            // 
            this.panelDataMenegers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelDataMenegers.Controls.Add(this.buttonMenegerDel);
            this.panelDataMenegers.Controls.Add(this.buttonMenegerChange);
            this.panelDataMenegers.Controls.Add(this.buttonMenegerAdd);
            this.panelDataMenegers.Controls.Add(this.dataGridViewMenegers);
            this.panelDataMenegers.Location = new System.Drawing.Point(0, 732);
            this.panelDataMenegers.Name = "panelDataMenegers";
            this.panelDataMenegers.Size = new System.Drawing.Size(48, 40);
            this.panelDataMenegers.TabIndex = 66;
            this.panelDataMenegers.Visible = false;
            // 
            // buttonMenegerDel
            // 
            this.buttonMenegerDel.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonMenegerDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMenegerDel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenegerDel.ForeColor = System.Drawing.Color.White;
            this.buttonMenegerDel.Location = new System.Drawing.Point(801, 39);
            this.buttonMenegerDel.Name = "buttonMenegerDel";
            this.buttonMenegerDel.Size = new System.Drawing.Size(173, 41);
            this.buttonMenegerDel.TabIndex = 64;
            this.buttonMenegerDel.Text = "Delete";
            this.buttonMenegerDel.UseVisualStyleBackColor = false;
            this.buttonMenegerDel.Click += new System.EventHandler(this.buttonMenegerDel_Click);
            // 
            // buttonMenegerChange
            // 
            this.buttonMenegerChange.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonMenegerChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMenegerChange.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMenegerChange.ForeColor = System.Drawing.Color.White;
            this.buttonMenegerChange.Location = new System.Drawing.Point(453, 39);
            this.buttonMenegerChange.Name = "buttonMenegerChange";
            this.buttonMenegerChange.Size = new System.Drawing.Size(173, 41);
            this.buttonMenegerChange.TabIndex = 63;
            this.buttonMenegerChange.Text = "Change";
            this.buttonMenegerChange.UseVisualStyleBackColor = false;
            this.buttonMenegerChange.Click += new System.EventHandler(this.buttonMenegerChange_Click);
            // 
            // buttonMenegerAdd
            // 
            this.buttonMenegerAdd.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonMenegerAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMenegerAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenegerAdd.ForeColor = System.Drawing.Color.White;
            this.buttonMenegerAdd.Location = new System.Drawing.Point(111, 39);
            this.buttonMenegerAdd.Name = "buttonMenegerAdd";
            this.buttonMenegerAdd.Size = new System.Drawing.Size(173, 41);
            this.buttonMenegerAdd.TabIndex = 62;
            this.buttonMenegerAdd.Text = "Add";
            this.buttonMenegerAdd.UseVisualStyleBackColor = false;
            this.buttonMenegerAdd.Click += new System.EventHandler(this.buttonMenegerAdd_Click);
            // 
            // dataGridViewMenegers
            // 
            this.dataGridViewMenegers.AllowUserToAddRows = false;
            this.dataGridViewMenegers.AllowUserToDeleteRows = false;
            this.dataGridViewMenegers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMenegers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMenegers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenegers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewMenegers.GridColor = System.Drawing.Color.OliveDrab;
            this.dataGridViewMenegers.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewMenegers.Name = "dataGridViewMenegers";
            this.dataGridViewMenegers.ReadOnly = true;
            this.dataGridViewMenegers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMenegers.Size = new System.Drawing.Size(1026, 745);
            this.dataGridViewMenegers.TabIndex = 61;
            // 
            // panelDataCustumer
            // 
            this.panelDataCustumer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelDataCustumer.Controls.Add(this.buttonCustumerDelete);
            this.panelDataCustumer.Controls.Add(this.buttonCustumerAChange);
            this.panelDataCustumer.Controls.Add(this.buttonCustumerAdd);
            this.panelDataCustumer.Controls.Add(this.dataGridViewCustumers);
            this.panelDataCustumer.Location = new System.Drawing.Point(58, 607);
            this.panelDataCustumer.Name = "panelDataCustumer";
            this.panelDataCustumer.Size = new System.Drawing.Size(47, 34);
            this.panelDataCustumer.TabIndex = 65;
            this.panelDataCustumer.Visible = false;
            // 
            // buttonCustumerDelete
            // 
            this.buttonCustumerDelete.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonCustumerDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCustumerDelete.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustumerDelete.ForeColor = System.Drawing.Color.White;
            this.buttonCustumerDelete.Location = new System.Drawing.Point(801, 39);
            this.buttonCustumerDelete.Name = "buttonCustumerDelete";
            this.buttonCustumerDelete.Size = new System.Drawing.Size(173, 41);
            this.buttonCustumerDelete.TabIndex = 64;
            this.buttonCustumerDelete.Text = "Delete";
            this.buttonCustumerDelete.UseVisualStyleBackColor = false;
            this.buttonCustumerDelete.Click += new System.EventHandler(this.buttonCustumerDelete_Click);
            // 
            // buttonCustumerAChange
            // 
            this.buttonCustumerAChange.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonCustumerAChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCustumerAChange.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCustumerAChange.ForeColor = System.Drawing.Color.White;
            this.buttonCustumerAChange.Location = new System.Drawing.Point(453, 39);
            this.buttonCustumerAChange.Name = "buttonCustumerAChange";
            this.buttonCustumerAChange.Size = new System.Drawing.Size(173, 41);
            this.buttonCustumerAChange.TabIndex = 63;
            this.buttonCustumerAChange.Text = "Change";
            this.buttonCustumerAChange.UseVisualStyleBackColor = false;
            this.buttonCustumerAChange.Click += new System.EventHandler(this.buttonCustumerAChange_Click);
            // 
            // buttonCustumerAdd
            // 
            this.buttonCustumerAdd.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonCustumerAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCustumerAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustumerAdd.ForeColor = System.Drawing.Color.White;
            this.buttonCustumerAdd.Location = new System.Drawing.Point(111, 39);
            this.buttonCustumerAdd.Name = "buttonCustumerAdd";
            this.buttonCustumerAdd.Size = new System.Drawing.Size(173, 41);
            this.buttonCustumerAdd.TabIndex = 62;
            this.buttonCustumerAdd.Text = "Add";
            this.buttonCustumerAdd.UseVisualStyleBackColor = false;
            this.buttonCustumerAdd.Click += new System.EventHandler(this.buttonCustumerAdd_Click);
            // 
            // dataGridViewCustumers
            // 
            this.dataGridViewCustumers.AllowUserToAddRows = false;
            this.dataGridViewCustumers.AllowUserToDeleteRows = false;
            this.dataGridViewCustumers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCustumers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCustumers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustumers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewCustumers.GridColor = System.Drawing.Color.OliveDrab;
            this.dataGridViewCustumers.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewCustumers.Name = "dataGridViewCustumers";
            this.dataGridViewCustumers.ReadOnly = true;
            this.dataGridViewCustumers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCustumers.Size = new System.Drawing.Size(1026, 745);
            this.dataGridViewCustumers.TabIndex = 61;
            // 
            // panelOrders
            // 
            this.panelOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelOrders.Controls.Add(this.OrdersDelButton);
            this.panelOrders.Controls.Add(this.OrdersChangeButton);
            this.panelOrders.Controls.Add(this.OrdersAddButton);
            this.panelOrders.Controls.Add(this.dataGridViewOrders);
            this.panelOrders.Location = new System.Drawing.Point(0, 668);
            this.panelOrders.Name = "panelOrders";
            this.panelOrders.Size = new System.Drawing.Size(50, 54);
            this.panelOrders.TabIndex = 65;
            this.panelOrders.Visible = false;
            // 
            // OrdersDelButton
            // 
            this.OrdersDelButton.BackColor = System.Drawing.Color.OliveDrab;
            this.OrdersDelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OrdersDelButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdersDelButton.ForeColor = System.Drawing.Color.White;
            this.OrdersDelButton.Location = new System.Drawing.Point(801, 39);
            this.OrdersDelButton.Name = "OrdersDelButton";
            this.OrdersDelButton.Size = new System.Drawing.Size(173, 41);
            this.OrdersDelButton.TabIndex = 64;
            this.OrdersDelButton.Text = "Delete";
            this.OrdersDelButton.UseVisualStyleBackColor = false;
            this.OrdersDelButton.Click += new System.EventHandler(this.OrdersDelButton_Click);
            // 
            // OrdersChangeButton
            // 
            this.OrdersChangeButton.BackColor = System.Drawing.Color.OliveDrab;
            this.OrdersChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OrdersChangeButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrdersChangeButton.ForeColor = System.Drawing.Color.White;
            this.OrdersChangeButton.Location = new System.Drawing.Point(453, 39);
            this.OrdersChangeButton.Name = "OrdersChangeButton";
            this.OrdersChangeButton.Size = new System.Drawing.Size(173, 41);
            this.OrdersChangeButton.TabIndex = 63;
            this.OrdersChangeButton.Text = "Change";
            this.OrdersChangeButton.UseVisualStyleBackColor = false;
            this.OrdersChangeButton.Click += new System.EventHandler(this.OrdersChangeButton_Click);
            // 
            // OrdersAddButton
            // 
            this.OrdersAddButton.BackColor = System.Drawing.Color.OliveDrab;
            this.OrdersAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OrdersAddButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdersAddButton.ForeColor = System.Drawing.Color.White;
            this.OrdersAddButton.Location = new System.Drawing.Point(111, 39);
            this.OrdersAddButton.Name = "OrdersAddButton";
            this.OrdersAddButton.Size = new System.Drawing.Size(173, 41);
            this.OrdersAddButton.TabIndex = 62;
            this.OrdersAddButton.Text = "Add";
            this.OrdersAddButton.UseVisualStyleBackColor = false;
            this.OrdersAddButton.Click += new System.EventHandler(this.OrdersAddButton_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            this.dataGridViewOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewOrders.GridColor = System.Drawing.Color.OliveDrab;
            this.dataGridViewOrders.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(1026, 745);
            this.dataGridViewOrders.TabIndex = 61;
            // 
            // panelProducts
            // 
            this.panelProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelProducts.Controls.Add(this.buttonDel);
            this.panelProducts.Controls.Add(this.buttonChange);
            this.panelProducts.Controls.Add(this.buttonAdd);
            this.panelProducts.Controls.Add(this.dataGridViewPdoructs);
            this.panelProducts.Location = new System.Drawing.Point(0, 607);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(50, 45);
            this.panelProducts.TabIndex = 62;
            this.panelProducts.Visible = false;
            // 
            // buttonDel
            // 
            this.buttonDel.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDel.ForeColor = System.Drawing.Color.White;
            this.buttonDel.Location = new System.Drawing.Point(801, 39);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(173, 41);
            this.buttonDel.TabIndex = 64;
            this.buttonDel.Text = "Delete";
            this.buttonDel.UseVisualStyleBackColor = false;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChange.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange.ForeColor = System.Drawing.Color.White;
            this.buttonChange.Location = new System.Drawing.Point(453, 39);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(173, 41);
            this.buttonChange.TabIndex = 63;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(111, 39);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(173, 41);
            this.buttonAdd.TabIndex = 62;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridViewPdoructs
            // 
            this.dataGridViewPdoructs.AllowUserToAddRows = false;
            this.dataGridViewPdoructs.AllowUserToDeleteRows = false;
            this.dataGridViewPdoructs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPdoructs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPdoructs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPdoructs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewPdoructs.GridColor = System.Drawing.Color.OliveDrab;
            this.dataGridViewPdoructs.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewPdoructs.Name = "dataGridViewPdoructs";
            this.dataGridViewPdoructs.ReadOnly = true;
            this.dataGridViewPdoructs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPdoructs.Size = new System.Drawing.Size(1026, 745);
            this.dataGridViewPdoructs.TabIndex = 61;
            // 
            // CatalogPanel
            // 
            this.CatalogPanel.Controls.Add(this.ProductsButton);
            this.CatalogPanel.Controls.Add(this.OrdersButton);
            this.CatalogPanel.Controls.Add(this.DataCustumersButton);
            this.CatalogPanel.Controls.Add(this.DataManagersButton);
            this.CatalogPanel.Controls.Add(this.UsersButton);
            this.CatalogPanel.Location = new System.Drawing.Point(0, 150);
            this.CatalogPanel.Name = "CatalogPanel";
            this.CatalogPanel.Size = new System.Drawing.Size(294, 400);
            this.CatalogPanel.TabIndex = 60;
            // 
            // ProductsButton
            // 
            this.ProductsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ProductsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductsButton.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductsButton.ForeColor = System.Drawing.Color.White;
            this.ProductsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProductsButton.Location = new System.Drawing.Point(0, 0);
            this.ProductsButton.Name = "ProductsButton";
            this.ProductsButton.Size = new System.Drawing.Size(294, 80);
            this.ProductsButton.TabIndex = 18;
            this.ProductsButton.Text = "Products";
            this.ProductsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProductsButton.Click += new System.EventHandler(this.ProductsButton_Click);
            // 
            // OrdersButton
            // 
            this.OrdersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.OrdersButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OrdersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrdersButton.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdersButton.ForeColor = System.Drawing.Color.White;
            this.OrdersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OrdersButton.Location = new System.Drawing.Point(0, 80);
            this.OrdersButton.Name = "OrdersButton";
            this.OrdersButton.Size = new System.Drawing.Size(294, 80);
            this.OrdersButton.TabIndex = 19;
            this.OrdersButton.Text = "Orfers";
            this.OrdersButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OrdersButton.Click += new System.EventHandler(this.OrdersButton_Click);
            // 
            // DataCustumersButton
            // 
            this.DataCustumersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.DataCustumersButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataCustumersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataCustumersButton.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataCustumersButton.ForeColor = System.Drawing.Color.White;
            this.DataCustumersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DataCustumersButton.Location = new System.Drawing.Point(0, 160);
            this.DataCustumersButton.Name = "DataCustumersButton";
            this.DataCustumersButton.Size = new System.Drawing.Size(294, 80);
            this.DataCustumersButton.TabIndex = 20;
            this.DataCustumersButton.Text = "Data Custumers";
            this.DataCustumersButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DataCustumersButton.Click += new System.EventHandler(this.DataCustumersButton_Click);
            // 
            // DataManagersButton
            // 
            this.DataManagersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.DataManagersButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataManagersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataManagersButton.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataManagersButton.ForeColor = System.Drawing.Color.White;
            this.DataManagersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DataManagersButton.Location = new System.Drawing.Point(0, 240);
            this.DataManagersButton.Name = "DataManagersButton";
            this.DataManagersButton.Size = new System.Drawing.Size(294, 80);
            this.DataManagersButton.TabIndex = 21;
            this.DataManagersButton.Text = "Data Menegers";
            this.DataManagersButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DataManagersButton.Click += new System.EventHandler(this.DataManagersButton_Click);
            // 
            // UsersButton
            // 
            this.UsersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.UsersButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsersButton.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersButton.ForeColor = System.Drawing.Color.White;
            this.UsersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UsersButton.Location = new System.Drawing.Point(0, 320);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(294, 80);
            this.UsersButton.TabIndex = 22;
            this.UsersButton.Text = "Users";
            this.UsersButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.LogoIT);
            this.logoPanel.Controls.Add(this.logoM);
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(1320, 70);
            this.logoPanel.TabIndex = 3;
            // 
            // LogoIT
            // 
            this.LogoIT.AutoSize = true;
            this.LogoIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoIT.Font = new System.Drawing.Font("Microsoft YaHei", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoIT.ForeColor = System.Drawing.Color.OliveDrab;
            this.LogoIT.Location = new System.Drawing.Point(12, 9);
            this.LogoIT.Name = "LogoIT";
            this.LogoIT.Size = new System.Drawing.Size(61, 52);
            this.LogoIT.TabIndex = 2;
            this.LogoIT.Text = "IT";
            // 
            // logoM
            // 
            this.logoM.AutoSize = true;
            this.logoM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoM.Font = new System.Drawing.Font("Microsoft YaHei", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.logoM.Location = new System.Drawing.Point(66, 9);
            this.logoM.Name = "logoM";
            this.logoM.Size = new System.Drawing.Size(198, 52);
            this.logoM.TabIndex = 3;
            this.logoM.Text = "MARKET";
            // 
            // panelExit
            // 
            this.panelExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelExit.Controls.Add(this.Exit);
            this.panelExit.Controls.Add(this.Catalog);
            this.panelExit.Location = new System.Drawing.Point(0, 70);
            this.panelExit.Name = "panelExit";
            this.panelExit.Size = new System.Drawing.Size(1320, 80);
            this.panelExit.TabIndex = 2;
            // 
            // Exit
            // 
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Image = global::InternetMarket.Properties.Resources.Ресурс_7;
            this.Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Exit.Location = new System.Drawing.Point(1202, 10);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(105, 62);
            this.Exit.TabIndex = 20;
            this.Exit.Text = "Exit";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Catalog
            // 
            this.Catalog.BackColor = System.Drawing.Color.OliveDrab;
            this.Catalog.Dock = System.Windows.Forms.DockStyle.Left;
            this.Catalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Catalog.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Catalog.ForeColor = System.Drawing.Color.White;
            this.Catalog.Image = global::InternetMarket.Properties.Resources.Ресурс_8;
            this.Catalog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Catalog.Location = new System.Drawing.Point(0, 0);
            this.Catalog.Name = "Catalog";
            this.Catalog.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Catalog.Size = new System.Drawing.Size(294, 80);
            this.Catalog.TabIndex = 0;
            this.Catalog.Text = "Table catalog";
            this.Catalog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 1034);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.MainPanel.ResumeLayout(false);
            this.panelUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.panelDataMenegers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenegers)).EndInit();
            this.panelDataCustumer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustumers)).EndInit();
            this.panelOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.panelProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPdoructs)).EndInit();
            this.CatalogPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.logoPanel.PerformLayout();
            this.panelExit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panelExit;
        private System.Windows.Forms.Label Exit;
        private System.Windows.Forms.Label Catalog;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label LogoIT;
        private System.Windows.Forms.Label logoM;
        private System.Windows.Forms.Panel CatalogPanel;
        private System.Windows.Forms.Label ProductsButton;
        private System.Windows.Forms.Label OrdersButton;
        private System.Windows.Forms.Label DataCustumersButton;
        private System.Windows.Forms.Label DataManagersButton;
        private System.Windows.Forms.Label UsersButton;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panelOrders;
        private System.Windows.Forms.Button OrdersDelButton;
        private System.Windows.Forms.Button OrdersChangeButton;
        private System.Windows.Forms.Button OrdersAddButton;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.DataGridView dataGridViewPdoructs;
        private System.Windows.Forms.Panel panelDataCustumer;
        private System.Windows.Forms.Button buttonCustumerDelete;
        private System.Windows.Forms.Button buttonCustumerAChange;
        private System.Windows.Forms.Button buttonCustumerAdd;
        private System.Windows.Forms.DataGridView dataGridViewCustumers;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Button buttonUsersDel;
        private System.Windows.Forms.Button buttonUsersChange;
        private System.Windows.Forms.Button buttonUsersAdd;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Panel panelDataMenegers;
        private System.Windows.Forms.Button buttonMenegerDel;
        private System.Windows.Forms.Button buttonMenegerChange;
        private System.Windows.Forms.Button buttonMenegerAdd;
        private System.Windows.Forms.DataGridView dataGridViewMenegers;
    }
}