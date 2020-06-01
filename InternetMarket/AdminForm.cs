using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseLibrary;

namespace InternetMarket
{
    public partial class AdminForm : Form
    {
        public DataBaseIM db;
        public AdminForm()
        {
            InitializeComponent();
            db = new DataBaseIM();
            Exit.MouseClick += (s, e) => { this.Hide(); AccountLoginForm ac = new AccountLoginForm(); ac.Show(); };
            //Border,Size,Location Form
            StandardFormSettings standartForm = new StandardFormSettings(this);
            this.BackColor = Color.FromArgb(255, 255, 255);
            MainPanel.BackColor = Color.FromArgb(255, 255, 255);
            MainPanel.Location = new Point((this.Width-1320)/2, 40);
            MainPanel.Size = new Size(this.Width - (this.Width - 1320), this.Height - (this.Height - 994));

            panelProducts.Visible = true; panelOrders.Visible = false; panelDataCustumer.Visible = false; panelDataMenegers.Visible = false; panelUsers.Visible = false;
            panelProducts.Location = new Point(294, 150);
            panelProducts.Size = new Size(1026, 850);
            db.Products.Load();
            dataGridViewPdoructs.DataSource = db.Products.Local.ToBindingList();
            dataGridViewPdoructs.Columns[0].Width = 50;
            dataGridViewPdoructs.Columns[1].Width = 400;
            dataGridViewPdoructs.Columns[2].Width = 50;
            dataGridViewPdoructs.Columns[3].Width = 65;
            dataGridViewPdoructs.Columns[4].Width = 300;
            dataGridViewPdoructs.Columns[5].Width = 100;



        }
        #region Products
        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            ProductForm pFormAdd = new ProductForm();
            DialogResult result = pFormAdd.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Product prod = new Product();
            prod.Title = pFormAdd.textBoxTitle.Text;
            prod.Price = pFormAdd.textBoxPrice.Text;
            prod.ImageData = pFormAdd.textBoxLink.Text;
            prod.ProductCategory = pFormAdd.textBoxCategory.Text;

            db.Products.Add(prod);
            await db.SaveChangesAsync();

            MessageBox.Show("Новый продукт добавлен");
        }

        private async void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewPdoructs.SelectedRows.Count > 0)
            {
                int index = dataGridViewPdoructs.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewPdoructs[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Product prod = db.Products.Find(id);
                while (true)
                {
                    Characteristic ch = db.Characteristics.FirstOrDefault(с => с.ProductId == id);
                    if (ch != null)
                    {
                        db.Characteristics.Remove(ch);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        break;
                    }
                }
                db.Products.Remove(prod);
                await db.SaveChangesAsync();
                MessageBox.Show("Продукт удален");
            }
        }
        private async void buttonChange_Click(object sender, EventArgs e)
        {   
            if (dataGridViewPdoructs.SelectedRows.Count > 0)
            {
                int index = dataGridViewPdoructs.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewPdoructs[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Product prod = db.Products.Find(id);
                ProductForm pFormChange = new ProductForm();
                pFormChange.textBoxTitle.Text = prod.Title;
                pFormChange.textBoxPrice.Text = prod.Price;
                pFormChange.textBoxLink.Text = prod.ImageData;
                pFormChange.textBoxCategory.Text = prod.ProductCategory;

                DialogResult result = pFormChange.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                prod.Title = pFormChange.textBoxTitle.Text;
                prod.Price = pFormChange.textBoxPrice.Text;
                prod.ImageData = pFormChange.textBoxLink.Text;
                prod.ProductCategory = pFormChange.textBoxCategory.Text;

                await db.SaveChangesAsync();
                dataGridViewPdoructs.Refresh();
                MessageBox.Show("Продукт обновлен");
            }
        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            panelProducts.Visible = true; panelOrders.Visible = false; panelDataCustumer.Visible = false; panelDataMenegers.Visible = false; panelUsers.Visible = false;
            panelProducts.Location = new Point(294, 150);
            panelProducts.Size = new Size(1026, 850);
            db.Products.Load();
            dataGridViewPdoructs.DataSource = db.Products.Local.ToBindingList();
            dataGridViewPdoructs.Columns[0].Width = 50;
            dataGridViewPdoructs.Columns[1].Width = 400;
            dataGridViewPdoructs.Columns[2].Width = 50;
            dataGridViewPdoructs.Columns[3].Width = 65;
            dataGridViewPdoructs.Columns[4].Width = 300;
            dataGridViewPdoructs.Columns[5].Width = 100;
        }
        #endregion
        private void OrdersButton_Click(object sender, EventArgs e)
        {
            panelOrders.Visible = true; panelProducts.Visible = false; panelDataCustumer.Visible = false; panelDataMenegers.Visible = false; panelUsers.Visible = false;
            panelOrders.Location = new Point(294, 150);
            panelOrders.Size = new Size(1026, 850);
            db.Orders.Load();
            dataGridViewOrders.DataSource = db.Orders.Local.ToBindingList();
            dataGridViewOrders.Columns[0].Width = 100;
            dataGridViewOrders.Columns[1].Width = 100;
            dataGridViewOrders.Columns[2].Width = 200;
            dataGridViewOrders.Columns[3].Width = 200;
            dataGridViewOrders.Columns[4].Width = 200;
            dataGridViewOrders.Columns[5].Width = 100;
        }
        private async void OrdersAddButton_Click(object sender, EventArgs e)
        {
            OrderForm pFormAdd = new OrderForm();
            DialogResult result = pFormAdd.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Order prod = new Order();

            prod.Created = pFormAdd.dateTimeCreated.Value;
            prod.CustomerInformationId = Convert.ToInt32(pFormAdd.textBoxId.Text);
            prod.DeliveryMethod = (pFormAdd.orderDeliveryMetod.Text == "Courier" ? DeliveryMetod.Courier:(pFormAdd.orderDeliveryMetod.Text == "FromNewMail" ? DeliveryMetod.FromNewMail: DeliveryMetod.Pickup));
            prod.PaymentMthod = (pFormAdd.orderPaymentMthod.Text== "GooglePay"?PaymentMthod.GooglePay: pFormAdd.orderPaymentMthod.Text == "UponReceipt" ? PaymentMthod.UponReceipt : PaymentMthod.VisaMastercard);
            prod.StatusOrder = pFormAdd.comboBoxStatus.Text == "Accepted" ? StatusOrder.Accepted : pFormAdd.comboBoxStatus.Text == "Canceled" ? StatusOrder.Canceled : pFormAdd.comboBoxStatus.Text == "Completed" ? StatusOrder.Completed : pFormAdd.comboBoxStatus.Text == "Deliver" ? StatusOrder.Deliver : StatusOrder.Processed;
            prod.OrderPrice = Convert.ToInt32(pFormAdd.textBoxPrice.Text);

            db.Orders.Add(prod);
            await db.SaveChangesAsync();

            MessageBox.Show("Новый объект добавлен");
        }

        private async void OrdersChangeButton_Click(object sender, EventArgs e)
        {

            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                int index = dataGridViewOrders.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewOrders[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Order prod = db.Orders.Find(id);
                OrderForm pFormChange = new OrderForm();
                pFormChange.dateTimeCreated.Value = prod.Created;
                pFormChange.textBoxId.Text = prod.CustomerInformationId.ToString();
                pFormChange.orderDeliveryMetod.Text = (prod.DeliveryMethod == DeliveryMetod.Courier ?"Courier" : (prod.DeliveryMethod == DeliveryMetod.FromNewMail ? "FromNewMail" : "Pickup"));
                pFormChange.orderPaymentMthod.Text = (prod.PaymentMthod ==  PaymentMthod.GooglePay? "GooglePay": prod.PaymentMthod == PaymentMthod.UponReceipt? "UponReceipt" : "VisaMastercard");
                pFormChange.comboBoxStatus.Text = prod.StatusOrder ==  StatusOrder.Accepted? "Accepted" : prod.StatusOrder == StatusOrder.Canceled? "Canceled" : prod.StatusOrder ==  StatusOrder.Completed? "Completed" : prod.StatusOrder == StatusOrder.Deliver? "Deliver" : "Processed";
                pFormChange.textBoxPrice.Text = prod.OrderPrice.ToString();
                DialogResult result = pFormChange.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                prod.Created = pFormChange.dateTimeCreated.Value;
                prod.CustomerInformationId = Convert.ToInt32(pFormChange.textBoxId.Text);
                prod.DeliveryMethod = (pFormChange.orderDeliveryMetod.Text == "Courier" ? DeliveryMetod.Courier : (pFormChange.orderDeliveryMetod.Text == "FromNewMail" ? DeliveryMetod.FromNewMail : DeliveryMetod.Pickup));
                prod.PaymentMthod = (pFormChange.orderPaymentMthod.Text == "GooglePay" ? PaymentMthod.GooglePay : pFormChange.orderPaymentMthod.Text == "UponReceipt" ? PaymentMthod.UponReceipt : PaymentMthod.VisaMastercard);
                prod.StatusOrder = pFormChange.comboBoxStatus.Text == "Accepted" ? StatusOrder.Accepted : pFormChange.comboBoxStatus.Text == "Canceled" ? StatusOrder.Canceled : pFormChange.comboBoxStatus.Text == "Completed" ? StatusOrder.Completed : pFormChange.comboBoxStatus.Text == "Deliver" ? StatusOrder.Deliver : StatusOrder.Processed;
                prod.OrderPrice = Convert.ToInt32(pFormChange.textBoxPrice.Text);

                await db.SaveChangesAsync();
                dataGridViewOrders.Refresh();
                MessageBox.Show("объект обновлен");
            }
        }

        private async void OrdersDelButton_Click(object sender, EventArgs e)
        {

            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                int index = dataGridViewOrders.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewOrders[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Order prod = db.Orders.Find(id);
                db.Orders.Remove(prod);
                await db.SaveChangesAsync();

                MessageBox.Show("Объект удален");
            }

        }

        private void DataCustumersButton_Click(object sender, EventArgs e)
        {
            panelDataCustumer.Visible = true; panelProducts.Visible = false; panelOrders.Visible = false; panelDataMenegers.Visible = false; panelUsers.Visible = false;
            panelDataCustumer.Location = new Point(294, 150);
            panelDataCustumer.Size = new Size(1026, 850);
            db.CustomersInformations.Load();
            dataGridViewCustumers.DataSource = db.CustomersInformations.Local.ToBindingList();
            dataGridViewCustumers.Columns[0].Width = 50;
            dataGridViewCustumers.Columns[1].Width = 100;
            dataGridViewCustumers.Columns[2].Width = 300;
            dataGridViewCustumers.Columns[3].Width = 300;
            dataGridViewCustumers.Columns[4].Width = 150;
            dataGridViewCustumers.Columns[5].Width = 100;
        }
        private async void buttonCustumerAdd_Click(object sender, EventArgs e)
        {
            CustumerInfoForm pFormAdd = new CustumerInfoForm();
            DialogResult result;
            while (true)
            {
                result = pFormAdd.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if (CheckUser(pFormAdd.textBoxFullName.Text, pFormAdd.textBoxAddres.Text, pFormAdd.textBoxPhone.Text))
                {
                    CustomerInformation prod = new CustomerInformation();

                    prod.Address = pFormAdd.textBoxAddres.Text;
                    prod.ContactFio = pFormAdd.textBoxFullName.Text;
                    prod.Phone = pFormAdd.textBoxPhone.Text;
                    prod.UserLoginId = Convert.ToInt32(pFormAdd.numericUpDownUserID.Value);
                    prod.DataOfBirth = pFormAdd.dataTimeBirth.Value.Day + "," + pFormAdd.dataTimeBirth.Value.Month + "," + pFormAdd.dataTimeBirth.Value.Year;

                    UsersLogin uL = db.UsersLogins.FirstOrDefault(u => u.Id == prod.UserLoginId);
                    if (uL == null)
                    {
                        MessageBox.Show("Для добавления информации о клиенте нужно создать акаунт");
                        UserForm uFAdd = new UserForm();
                        DialogResult ress;
                        while (true)
                        {
                            ress = uFAdd.ShowDialog(this);

                            if (ress == DialogResult.Cancel)
                                return;
                            if (CheckUser(uFAdd.EmailTextBox.Text))
                            {
                                UsersLogin user = new UsersLogin();

                                user.Login = uFAdd.LoginTextBox.Text;
                                user.Password = uFAdd.PasswordTextBox.Text;
                                user.Mail = uFAdd.EmailTextBox.Text;
                                user.Admin = true;

                                db.UsersLogins.Add(user);
                                prod.UserLogin = user;
                                db.CustomersInformations.Add(prod);
                                await db.SaveChangesAsync();
                                MessageBox.Show("Новый клиент и информация о нём добавлина");
                                return;
                            }
                        }
                    }
                    else
                    {
                        db.CustomersInformations.Add(prod);
                        await db.SaveChangesAsync();
                        MessageBox.Show("Информация о клиенте добавлина");
                        return;
                    }
                }
            }

        }

        private async void buttonCustumerAChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustumers.SelectedRows.Count > 0)
            {
                int index = dataGridViewCustumers.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewCustumers[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                CustomerInformation prod = db.CustomersInformations.Find(id);
                CustumerInfoForm pFormChange = new CustumerInfoForm();
                string[] spliter = prod.DataOfBirth.Split(',');
                pFormChange.dataTimeBirth.Value = new DateTime(Convert.ToInt32(spliter[2]), Convert.ToInt32(spliter[1]), Convert.ToInt32(spliter[0]));
                pFormChange.numericUpDownUserID.Value = Convert.ToDecimal(prod.UserLoginId);
                pFormChange.textBoxAddres.Text = prod.Address;
                pFormChange.textBoxPhone.Text = prod.Phone;
                pFormChange.textBoxFullName.Text = prod.ContactFio;
                DialogResult result = pFormChange.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                prod.Address = pFormChange.textBoxAddres.Text;
                prod.ContactFio = pFormChange.textBoxFullName.Text;
                prod.Phone = pFormChange.textBoxPhone.Text;
                prod.UserLoginId = Convert.ToInt32(pFormChange.numericUpDownUserID.Value);
                prod.DataOfBirth = pFormChange.dataTimeBirth.Value.Day + "," + pFormChange.dataTimeBirth.Value.Month + "," + pFormChange.dataTimeBirth.Value.Year;

                await db.SaveChangesAsync();
                dataGridViewCustumers.Refresh();
                MessageBox.Show("объект обновлен");
            }

        }

        private async void buttonCustumerDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustumers.SelectedRows.Count > 0)
            {
                int index = dataGridViewCustumers.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewCustumers[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                CustomerInformation prod = db.CustomersInformations.Find(id);
                db.CustomersInformations.Remove(prod);
                await db.SaveChangesAsync();

                MessageBox.Show("Объект удален");
            }
        }

        private async void DataManagersButton_Click(object sender, EventArgs e)
        {
            panelDataMenegers.Visible = true; panelDataCustumer.Visible = false; panelProducts.Visible = false; panelOrders.Visible = false; panelUsers.Visible = false;
            panelDataMenegers.Location = new Point(294, 150);
            panelDataMenegers.Size = new Size(1026, 850);
            db.MenedjersInformations.Load();
            dataGridViewMenegers.DataSource = db.MenedjersInformations.Local.ToBindingList();
            dataGridViewMenegers.Columns[0].Width = 50;
            dataGridViewMenegers.Columns[1].Width = 100;
            dataGridViewMenegers.Columns[2].Width = 200;
            dataGridViewMenegers.Columns[3].Width = 200;
            dataGridViewMenegers.Columns[4].Width = 200;
            dataGridViewMenegers.Columns[4].Width = 200;
            dataGridViewMenegers.Columns[6].Width = 100;
        }

        private async void buttonMenegerAdd_Click(object sender, EventArgs e)
        {
            MenegerInfoForm pFormAdd = new MenegerInfoForm();
            DialogResult result;
            while (true)
            {
                result = pFormAdd.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if (CheckUser(pFormAdd.textBoxFullName.Text, pFormAdd.textBoxAddres.Text, pFormAdd.textBoxPhone.Text))
                {
                    MenedjerInformation prod = new MenedjerInformation();
                    prod.Status = pFormAdd.textBoxStatus.Text;
                    prod.Address = pFormAdd.textBoxAddres.Text;
                    prod.FullName = pFormAdd.textBoxFullName.Text;
                    prod.PhoneNumber = pFormAdd.textBoxPhone.Text;
                    prod.UserLoginId = Convert.ToInt32(pFormAdd.numericUpDownUserID.Value);
                    prod.DataOfBirth = pFormAdd.dateTimeCreated.Value.Day + "," + pFormAdd.dateTimeCreated.Value.Month + "," + pFormAdd.dateTimeCreated.Value.Year;

                    UsersLogin uL = db.UsersLogins.FirstOrDefault(u => u.Id == prod.UserLoginId);
                    if (uL == null)
                    {
                        MessageBox.Show("Для добавления информации о менеджере нужно создать акаунт");
                        UserForm uFAdd = new UserForm();
                        DialogResult ress;
                        while (true)
                        {
                            ress = uFAdd.ShowDialog(this);
                            if (ress == DialogResult.Cancel)
                                return;
                            if (CheckUser(uFAdd.EmailTextBox.Text))
                            {
                                UsersLogin user = new UsersLogin();

                                user.Login = uFAdd.LoginTextBox.Text;
                                user.Password = uFAdd.PasswordTextBox.Text;
                                user.Mail = uFAdd.EmailTextBox.Text;
                                user.Admin = true;

                                db.UsersLogins.Add(user);
                                prod.UserLogin = user;
                                db.MenedjersInformations.Add(prod);
                                await db.SaveChangesAsync();
                                MessageBox.Show("Новый менеджер и информация о нём добавлина");
                                return;
                            }
                        }
                    }
                    else
                    {
                        db.MenedjersInformations.Add(prod);
                        await db.SaveChangesAsync();
                        MessageBox.Show("Информация о менеджер добавлина");
                        return;
                    }
                }
            }
        }
        public  bool CheckUser(string FullName, string Address , string PhoneNumber)
        {
            string pattern = @"^[А-я]{1}[a-я]+[,].[А-я]{1}[а-я]+[,].[А-я]{1}[а-я]+$";
            if (Regex.IsMatch(FullName, pattern,  RegexOptions.IgnorePatternWhitespace)|| Regex.IsMatch(FullName, "^[A-z]{1}[a-z]+[,].[A-z]{1}[a-z]+[,].[A-z]{1}[a-z]+$", RegexOptions.IgnorePatternWhitespace))
            {
                pattern = @"^[А-я]{1}[а-я]+[.,].[А-я]{1}[а-я]+\s?[д]?[д.]?[д]?[о]?[м]?\s?[0-9]{0,5}\s?[.,].\s?[к]?[к.]?[кв]?\s?[0-9]{0,5}$";
                if (Regex.IsMatch(Address, pattern, RegexOptions.IgnorePatternWhitespace)|| Regex.IsMatch(Address, "^[A-z]{1}[a-z]+[.,].[A-z]{1}[a-z]+ ?[h]?[o]?[u]?[s]?[e]?[.]? ?[0-9]{0,5} ?[.,]. ?[r]?[o]+[m]?[.]? ?[0-9]{0,5}$", RegexOptions.IgnorePatternWhitespace))
                {
                    pattern = @"^[+0-9]?[0-9]{5,12}$";
                    if (Regex.IsMatch(PhoneNumber, pattern, RegexOptions.IgnorePatternWhitespace))
                    {
                        return true;
                    }
                    else { MessageBox.Show("Номер теефона в не верном формате, верный формат: 380953162181"); return false; };
                }
                else { MessageBox.Show("Адрес в не верном формате, верный формат: Город, Улица НомерДома, НомерКвартиры"); return false; };
            }
            else { MessageBox.Show("Имя,Фамилия и Отчество в не правильном формате, верный формат: Фамилия,Имя,Отчество "); return false; };
        }
        public bool CheckUser(string Email)
        {   
             string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
             if (Regex.IsMatch(Email, pattern, RegexOptions.IgnoreCase))
             {
                     return true;
             }
             else { MessageBox.Show("Почта в не верном формате, верный формат: jonah921@gmail.com"); return false; };
        }


        private async void buttonMenegerChange_Click(object sender, EventArgs e)
        {

            if (dataGridViewMenegers.SelectedRows.Count > 0)
            {
                int index = dataGridViewMenegers.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewMenegers[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                MenedjerInformation prod = db.MenedjersInformations.Find(id);
                MenegerInfoForm pFormChange = new MenegerInfoForm();
                string[] spliter = prod.DataOfBirth.Split(',');
                pFormChange.dateTimeCreated.Value = new DateTime(Convert.ToInt32(spliter[2]), Convert.ToInt32(spliter[1]), Convert.ToInt32(spliter[0]));
                pFormChange.numericUpDownUserID.Value = Convert.ToDecimal(prod.UserLoginId);
                pFormChange.textBoxAddres.Text = prod.Address;
                pFormChange.textBoxPhone.Text = prod.PhoneNumber;
                pFormChange.textBoxFullName.Text = prod.FullName;
                pFormChange.textBoxStatus.Text = prod.Status;
                DialogResult result = pFormChange.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                prod.Status = pFormChange.textBoxStatus.Text;
                prod.Address = pFormChange.textBoxAddres.Text;
                prod.FullName = pFormChange.textBoxFullName.Text;
                prod.PhoneNumber = pFormChange.textBoxPhone.Text;
                prod.UserLoginId = Convert.ToInt32(pFormChange.numericUpDownUserID.Value);
                prod.DataOfBirth = pFormChange.dateTimeCreated.Value.Day + "," + pFormChange.dateTimeCreated.Value.Month + "," + pFormChange.dateTimeCreated.Value.Year;

                await db.SaveChangesAsync();
                dataGridViewMenegers.Refresh();
                MessageBox.Show("объект обновлен");
            }
        }

        private async void buttonMenegerDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewMenegers.SelectedRows.Count > 0)
            {
                int index = dataGridViewMenegers.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewMenegers[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                MenedjerInformation prod = db.MenedjersInformations.Find(id);
                db.MenedjersInformations.Remove(prod);
                await db.SaveChangesAsync();
                MessageBox.Show("Объект удален");
            }

        }

        private async void UsersButton_Click(object sender, EventArgs e)
        {
            panelUsers.Visible = true; panelDataCustumer.Visible = false; panelProducts.Visible = false; panelOrders.Visible = false; panelDataMenegers.Visible = false;
            panelUsers.Location = new Point(294, 150);
            panelUsers.Size = new Size(1026, 850);
            db.UsersLogins.Load();
            dataGridViewUsers.DataSource = db.UsersLogins.Local.ToBindingList();
            dataGridViewUsers.Columns[0].Width = 50;
            dataGridViewUsers.Columns[1].Width = 200;
            dataGridViewUsers.Columns[2].Width = 300;
            dataGridViewUsers.Columns[3].Width = 300;
            dataGridViewUsers.Columns[4].Width = 100;
        }

        private async void buttonUsersAdd_Click(object sender, EventArgs e)
        {
            UserForm uFAdd = new UserForm();
            DialogResult ress;
            while (true)
            {
                ress = uFAdd.ShowDialog(this);
                if (ress == DialogResult.Cancel)
                    return;
                if (CheckUser(uFAdd.EmailTextBox.Text))
                {
                    UsersLogin user = new UsersLogin();
                    user.Login = uFAdd.LoginTextBox.Text;
                    user.Password = uFAdd.PasswordTextBox.Text;
                    user.Mail = uFAdd.EmailTextBox.Text;
                    user.Admin = uFAdd.AdminCheck.Checked;
                    db.UsersLogins.Add(user);
                    await db.SaveChangesAsync();
                    MessageBox.Show("Новый объект добавлен");
                    if (user.Admin == true)
                    {
                        MenegerInfoForm pFormAdd = new MenegerInfoForm();
                        DialogResult result;
                        while (true)
                        {
                            result = pFormAdd.ShowDialog(this);

                            if (result == DialogResult.Cancel)
                                return;
                            if (CheckUser(pFormAdd.textBoxFullName.Text, pFormAdd.textBoxAddres.Text, pFormAdd.textBoxPhone.Text))
                            {
                                MenedjerInformation prod = new MenedjerInformation();
                                prod.Status = pFormAdd.textBoxStatus.Text;
                                prod.Address = pFormAdd.textBoxAddres.Text;
                                prod.FullName = pFormAdd.textBoxFullName.Text;
                                prod.PhoneNumber = pFormAdd.textBoxPhone.Text;
                                UsersLogin us = db.UsersLogins.FirstOrDefault(u => (u.Login == user.Login || u.Mail == user.Mail) && u.Password ==user.Password);
                                if (us != null)
                                { prod.UserLoginId = us.Id; }
                                prod.DataOfBirth = pFormAdd.dateTimeCreated.Value.Day + "," + pFormAdd.dateTimeCreated.Value.Month + "," + pFormAdd.dateTimeCreated.Value.Year;
                                db.MenedjersInformations.Add(prod);
                                await db.SaveChangesAsync();
                                MessageBox.Show("Информация о менеджер добавлина");
                                return;
                            }
                        }
                    }
                    else if(user.Admin == false)
                    {
                        CustumerInfoForm pFormAdd = new CustumerInfoForm();
                        DialogResult result;
                        while (true)
                        {
                            result = pFormAdd.ShowDialog(this);

                            if (result == DialogResult.Cancel)
                                return;
                            if (CheckUser(pFormAdd.textBoxFullName.Text, pFormAdd.textBoxAddres.Text, pFormAdd.textBoxPhone.Text))
                            {

                                CustomerInformation prod = new CustomerInformation();

                                prod.Address = pFormAdd.textBoxAddres.Text;
                                prod.ContactFio = pFormAdd.textBoxFullName.Text;
                                prod.Phone = pFormAdd.textBoxPhone.Text;
                                prod.UserLoginId = Convert.ToInt32(pFormAdd.numericUpDownUserID.Value);
                                prod.DataOfBirth = pFormAdd.dataTimeBirth.Value.Day + "," + pFormAdd.dataTimeBirth.Value.Month + "," + pFormAdd.dataTimeBirth.Value.Year;
                                UsersLogin us = db.UsersLogins.FirstOrDefault(u => (u.Login == user.Login || u.Mail == user.Mail) && u.Password ==user.Password);
                                if (us != null)
                                { prod.UserLoginId = us.Id; }
                                db.CustomersInformations.Add(prod);
                                await db.SaveChangesAsync();
                                MessageBox.Show("Информация о клиенте добавлина");
                                return;
                            }
                        }
                    }
                }
            }
        }

        private async void buttonUsersChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int index = dataGridViewUsers.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewUsers[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                UsersLogin prod = db.UsersLogins.Find(id);
                UserForm pFormChange = new UserForm();
                pFormChange.LoginTextBox.Text = prod.Login;
                pFormChange.PasswordTextBox.Text = prod.Password;
                pFormChange.EmailTextBox.Text = prod.Mail;
                pFormChange.AdminCheck.Checked = prod.Admin;
                DialogResult result = pFormChange.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                prod.Login = pFormChange.LoginTextBox.Text;
                prod.Password = pFormChange.PasswordTextBox.Text;
                prod.Mail = pFormChange.EmailTextBox.Text;
                prod.Admin = pFormChange.AdminCheck.Checked;

                await db.SaveChangesAsync();
                dataGridViewUsers.Refresh();
                MessageBox.Show("объект обновлен");
            }
        }

        private async void buttonUsersDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int index = dataGridViewUsers.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewUsers[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                UsersLogin user = db.UsersLogins.Find(id);
                if (user.Admin == true)
                {
                    MenedjerInformation mInfo = db.MenedjersInformations.FirstOrDefault(mI => mI.UserLoginId == user.Id);
                    if (mInfo != null)
                    {
                        db.MenedjersInformations.Remove(mInfo);
                    }
                }
                else
                {
                    CustomerInformation cInfo = db.CustomersInformations.FirstOrDefault(cI => cI.UserLoginId == user.Id);
                    if (cInfo != null)
                    {
                        db.CustomersInformations.Remove(cInfo);
                    }
                }

                db.UsersLogins.Remove(user);
                await db.SaveChangesAsync();

                MessageBox.Show("User удален");
            }
        }
    }
}
