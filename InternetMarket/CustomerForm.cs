﻿
using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InternetMarket
{
    public partial class CustomerForm : Form
    {
        List<Product> basketList = new List<Product>();
        CustomerInformation custumerInfo = new CustomerInformation();
        public CustomerForm(CustomerInformation custumerInfo)
        {
            InitializeComponent();
            this.custumerInfo = custumerInfo;
            //Border,Size,Location Form
            StandardFormSettings standartForm = new StandardFormSettings(this);
            this.BackColor = Color.FromArgb(255, 255, 255);
            mainPanel.BackColor = Color.FromArgb(255, 255, 255);
            mainPanel.Location = new Point(300, 40);
            mainPanel.Size = new Size(this.Width - 600, this.Height - 40);
            CategorySettings();
            MouseClickSettings();
            ReadProductsTopDB("Videocard", 130);
        }
        #region UserData
        private void CustumerDataPanelView()
        {
            dateTimeBirth.MinDate = new DateTime(1800,1,1);
            dateTimeBirth.MaxDate = new DateTime(2015, 1, 1);
            dateTimeBirth.Value = new DateTime(2000, 1, 1);
            if (custumerInfo.ContactFio != null)
            {
                string[] fioArrey = custumerInfo.ContactFio.Split(',');
                textBoxFamily.Text = fioArrey[0];
                textBoxName.Text = fioArrey[1];
                textBoxDad.Text = fioArrey[2];
            }
            //if (userData.Phone != 0)
            {
                //textBoxPhoneNumber.Text = userData.Phone;
            }
            if (custumerInfo.Address != null)
            {
                textBoxAddres.Text = custumerInfo.Address;
            }
           // if (userData.DataOfBirth != null)
            {
                //dateTimeBirth.Value = userData.DataOfBirth;
            }
            SaveCustumerInformation.MouseClick += (s, e) => SaveCustumerInformationMouseClick(custumerInfo);
        }
        private async void SaveCustumerInformationMouseClick(CustomerInformation userData)
        { 
            using (M3 db = new M3())
            {
                CustomerInformation custumerI = db.CustomersInformations.FirstOrDefault(cInfo => cInfo.Id == userData.Id);
                
                string pattern = @"^[А-Яа-я]{1}[а-я]{3,20}$";
                if (Regex.IsMatch(textBoxFamily.Text, pattern) || Regex.IsMatch(textBoxName.Text, pattern) || Regex.IsMatch(textBoxDad.Text, pattern))
                    custumerI.ContactFio = textBoxFamily.Text+"," + textBoxName.Text+"," + textBoxDad.Text;
                else if (custumerI.ContactFio==null&&(textBoxFamily.Text.Length!=0 || textBoxName.Text.Length != 0 || textBoxDad.Text.Length != 0))
                     MessageBox.Show("Для изменения Имени,Фамилии или Отчества нужно чтобы все эти поля были заполнены и имели вид обычных слов ");
                pattern = @"^[А-Яа-я]{1}[а-я]{1}[,а-я]{1}([а-я]{0,1})?([,а-я]{0,1})?([а-я]{0,11})?([,]{0,1})? [А-Яа-я]{1}[а-я]{1,19} [0-9а-я]{1}.{1,2}([,0-9а-я]{0,1})?(.{0,1})?([0-9]{0,1})?([,0-9]{0,1})?([0-9]{0,1})?([,]{0,1})? [0-9а-я]{1,2}([.]{0,1})?( [0-9]{2})?$";
                if (Regex.IsMatch(textBoxAddres.Text, pattern))
                    custumerI.Address = textBoxAddres.Text;
                else if(custumerI.Address == null && (textBoxAddres.Text.Length != 0))
                    MessageBox.Show("Адрес в не верном формате, верный формат: Город, Улица число, квартира число");
                pattern = @"^(?!\+.*\(.*\).*\-\-.*$)(?!\+.*\(.*\).*\-$)(([0-9]{0,12})?(\([0-9]{2})?(\)[0-9]{6})?(\+[0-9]{3,10})?(\([0-9]{2})?(\)[0-9]{3,6})?)$";
                if (Regex.IsMatch(textBoxPhoneNumber.Text, pattern))
                    MessageBox.Show("phone ok");
                else if (custumerI.Phone == null && (textBoxPhoneNumber.Text.Length != 0))
                    MessageBox.Show("Номер теефона в не верном формате, верный формат: 380953162181");
                dateTimeBirth.ValueChanged += (s, e) => MessageBox.Show("Change dataTime");
                await db.SaveChangesAsync();
                if(userData.ContactFio!= custumerI.ContactFio|| userData.Address != custumerI.Address|| userData.Phone != custumerI.Phone|| userData.DataOfBirth != custumerI.DataOfBirth)
                    MessageBox.Show("Данные сохранены");
                custumerInfo = custumerI;
            }
        }
        #endregion
        #region Click Settings
        private void MouseClickSettings()
        {
            MouseClickPanelUser();
            MouseClickCabinetSettings();
        }
        private void VisibleCabinetPanels(Panel p)
        {
            panelCabinet.Visible = true;
            panelOrder.Visible = false;
            panelCustumerInformation.Visible = false;
            panelSettings.Visible = false;
            panelHistoryOrders.Visible = false;
            p.Visible = true;
            p.Size = new Size(1060, 884);
            p.Location = new Point(0, 0);
        }
        private void VisibleCabinetPanels()
        {
            panelCabinet.Visible = true;
            panelOrder.Visible = false;
            panelCustumerInformation.Visible = false;
            panelSettings.Visible = false;
            panelHistoryOrders.Visible = false;
        }
        private void MouseClickCabinetSettings()
        {
            CabinetBasket.MouseClick += (s, e) => { VisibleCabinetPanels(panelOrder); OrderPanelView(basketList); }; ;
            CabinetUserData.MouseClick += (s, e) => { VisibleCabinetPanels(panelCustumerInformation); CustumerDataPanelView(); };
            CabinetSettingsButton.MouseClick += (s, e) => { VisibleCabinetPanels(panelSettings);  };
            CabinetHistoryOrders.MouseClick += (s, e) => { VisibleCabinetPanels(panelHistoryOrders); };
        }
        private void MouseClickPanelUser()
        {
            Exit.MouseClick += (s, e) =>
            {
                this.Hide();
                AccountLoginForm ac = new AccountLoginForm();
                ac.Show();
            };
            SearchButton.MouseClick += (s,e)=> SearchClick(Search.Text);
            CabinetButtom.MouseClick += (s, e) => { VisibleCabinetPanels(); };
            basketButtom.MouseClick += (s, e) => { VisibleCabinetPanels(panelOrder); OrderPanelView(basketList); } ;
        }
        public void SearchClick(string Text)
        {
            
            using (M3 db = new M3())
            {   
                var query = from prod in db.Products.AsParallel()
                            where Regex.IsMatch(prod.Title, Text, RegexOptions.IgnoreCase) || prod.Title == Text||prod.ProductCategory == Text
                            select prod;
                List<Product> pL = query.ToList();
                if (pL.Count == 0)
                {
                    MessageBox.Show("Not found");
                }
                else
                {
                    var queryC = from c in db.Characteristics.AsParallel()
                                 where c.ProductId == pL[0].Id
                                 select c;
                    List<Characteristic> cL = queryC.ToList();
                    ReadOneProduct(pL[0], cL);
                }  
            }
            Search.Text = "";
        }
        #endregion
        #region Order
        private async void OrderAceptButtonClick()
        {
            if (OrderPanelСompletedCorrectly())
            {
                using (M3 db = new M3())
                {
                    Order orderExamp = new Order();
                    CustomerInformation cIOrder = new CustomerInformation();
                    //cIOrder.Phone = orderPhoneNumber.Text;
                    cIOrder.Address = orderAddres.Text;
                    cIOrder.ContactFio = orderFamily.Text + "," + orderName.Text + "," + orderDad.Text;
                    orderExamp.OrderPrice = Convert.ToInt32(OrderPriceLabel.Text);
                    orderExamp.Created = DateTime.Now;
                    orderExamp.CustomerInformation = custumerInfo;
                    orderExamp.PaymentMthod = (orderPaymentMthod.Text == "Наличный расчёт" ? PaymentMthod.UponReceipt : (orderPaymentMthod.Text == "MasterCard" ? PaymentMthod.VisaMastercard : (orderPaymentMthod.Text == "GooglePay" ? PaymentMthod.GooglePay : orderExamp.PaymentMthod)));
                    orderExamp.DeliveryMethod = (orderDeliveryMetod.Text == "Курьером" ? DeliveryMetod.Courier : (orderDeliveryMetod.Text == "Новой почтой" ? DeliveryMetod.FromNewMail : (orderPaymentMthod.Text == "Самовывоз" ? DeliveryMetod.Pickup : orderExamp.DeliveryMethod)));
                    orderExamp.StatusOrder = StatusOrder.Accepted;
                    orderExamp.Product = basketList;
                    db.Orders.Add(orderExamp);
                    await db.SaveChangesAsync();
                    MessageBox.Show("Заказ принят");
                }
            }
        }
        private bool OrderPanelСompletedCorrectly()
        {
            string pattern = @"^[А-Яа-я]{1}[а-я]{3,20}$";
            if (Regex.IsMatch(orderFamily.Text, pattern) || Regex.IsMatch(orderName.Text, pattern) || Regex.IsMatch(orderDad.Text, pattern))
            {
                pattern = @"^[А-Яа-я]{1}[а-я]{1}[,а-я]{1}([а-я]{0,1})?([,а-я]{0,1})?([а-я]{0,11})?([,]{0,1})? [А-Яа-я]{1}[а-я]{1,19} [0-9а-я]{1}.{1,2}([,0-9а-я]{0,1})?(.{0,1})?([0-9]{0,1})?([,0-9]{0,1})?([0-9]{0,1})?([,]{0,1})? [0-9а-я]{1,2}([.]{0,1})?( [0-9]{2})?$";
                if (Regex.IsMatch(orderAddres.Text, pattern))
                {
                    pattern = @"^(?!\+.*\(.*\).*\-\-.*$)(?!\+.*\(.*\).*\-$)(([0-9]{0,12})?(\([0-9]{2})?(\)[0-9]{6})?(\+[0-9]{3,10})?(\([0-9]{2})?(\)[0-9]{3,6})?)$";
                    if (Regex.IsMatch(orderPhoneNumber.Text, pattern))
                    {
                        pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                        if (Regex.IsMatch(orderEmail.Text, pattern, RegexOptions.IgnoreCase))
                        {
                            if (orderDeliveryMetod.Text.Length != 0&&(orderDeliveryMetod.Text== "Самовывоз"|| orderDeliveryMetod.Text == "Новой почтой"|| orderDeliveryMetod.Text == "Курьером"))
                            {
                                if (orderPaymentMthod.Text.Length != 0&&(orderPaymentMthod.Text== "Наличный расчёт"|| orderPaymentMthod.Text == "MasterCard"|| orderPaymentMthod.Text == "GooglePay"))
                                {
                                    if (Convert.ToInt32(OrderPriceLabel.Text) != 0)
                                    {
                                        return true;
                                    }
                                    else { MessageBox.Show("В корзине пусто"); return false; };
                                }
                                else { MessageBox.Show("Выберите способ оплаты"); return false; };
                            }
                            else { MessageBox.Show("Выберите способ доставки"); return false; };
                        }
                        else { MessageBox.Show("Почта в не верном формате, верный формат: jonah921@gmail.com"); return false; };
                    }
                    else { MessageBox.Show("Номер теефона в не верном формате, верный формат: 380953162181"); return false; };
                }
                else { MessageBox.Show("Адрес в не верном формате, верный формат: Город, Улица число, квартира число"); return false; };
            }
            else { MessageBox.Show("Имя,Фамилия или Отчество в не правильном формате ");return false; };
        }
        private void OrderPanelView(List<Product> pList)
        {
            int orderPriceInt = 0;
            foreach (var product in pList)
            {
                orderPriceInt += Convert.ToInt32(product.Price);
            }
            if (custumerInfo.ContactFio != null)
            {
                string[] fioArrey = custumerInfo.ContactFio.Split(',');
                orderFamily.Text = fioArrey[0];
                orderName.Text = fioArrey[1];
                orderDad.Text = fioArrey[2];
            }
            if (custumerInfo.Phone != null)
            {
                textBoxPhoneNumber.Text = custumerInfo.Phone;
            }
            if (custumerInfo.Address != null)
            {
                orderAddres.Text = custumerInfo.Address;
            }
            OrderPriceLabel.Text = orderPriceInt.ToString();
            panelBasket.Controls.Clear();
            orderAceptButton.MouseClick += (s, e) => { OrderAceptButtonClick(); };
            BasketClickOrder(pList);
        }
        private void BasketClickOrder(List<Product> pL)
        {
            int height = 0;
            for (int i = 0; i < pL.Count; i++)
            {
                Panel panel = new Panel();
                panel.Size = new Size(550, 260);
                panel.BackColor = Color.FromArgb(107, 142, 35);
                panel.Location = new Point(0, height);
                height += 290;
                panel.Name = "panel";
                NumericUpDown numeric = new NumericUpDown();
                numeric.Size = new System.Drawing.Size(40, 29);
                numeric.Location = new System.Drawing.Point(465, 190);
                numeric.Maximum = 99;
                numeric.Minimum = 1;
                numeric.ForeColor = System.Drawing.Color.White;
                numeric.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                numeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
                numeric.BackColor = Color.FromArgb(45, 45, 45);
                Label del = new Label();
                del.Size = new System.Drawing.Size(70, 40);
                del.Font = new Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                del.ForeColor = Color.White;
                del.Location = new Point(510, 190);
                del.Text = "X";
                var title = new Label();
                title.Location = new System.Drawing.Point(260, 60);
                title.Font = new Font("Microsoft YaHei", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
                title.ForeColor = Color.FromArgb(45, 45, 45);
                title.Size = new System.Drawing.Size(250, 120);
                //title.Size = new System.Drawing.Size(460, 70);
                var picture = new PictureBox();
                picture.Location = new System.Drawing.Point(10, 10);
                picture.Size = new System.Drawing.Size(240, 240);
                picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                var price = new Label();
                price.Location = new Point(270, 180);
                price.AutoSize = true;
                price.Font = new Font("Microsoft YaHei", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
                price.ForeColor = Color.FromArgb(45, 45, 45);
                //price.Size = new System.Drawing.Size(102, 34);
                var priceCHRN = new Label();
                priceCHRN.Location = new System.Drawing.Point(413, 195);
                priceCHRN.Size = new System.Drawing.Size(50, 40);
                priceCHRN.Text = "грн";
                priceCHRN.Font = new Font("Microsoft YaHei", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
                priceCHRN.ForeColor = Color.FromArgb(45, 45, 45);
                picture.BackgroundImage = ImageDowloader(new Uri(pL[i].ImageData));
                title.Text = pL[i].Title;
                price.Text = (pL[i].Price).ToString();
                panel.Controls.Add(del);panel.Controls.Add(price); panel.Controls.Add(numeric);
                panel.Controls.Add(priceCHRN); panel.Controls.Add(title); panel.Controls.Add(picture);
                panelCabinet.Visible = true;
                panelBasket.Controls.Add(panel);
            }
            Control[] panels = panelOrder.Controls.Find("panel", true);
            int j=0;
            foreach (var item in basketList)
            {
                panels[j].Controls[0].MouseClick += (s, e) => { basketList.Remove(item); OrderPanelView(basketList); };

                (panels[j].Controls[1] as NumericUpDown).ValueChanged += (s, e) =>
                {
                    OrderPriceLabel.Text = (Convert.ToInt32(OrderPriceLabel.Text)+(Convert.ToInt32(panels[j].Controls[1].Text) * (panels[j].Controls[1] as NumericUpDown).Value)).ToString();
                };
                j++;
            }
            panelBasket.AutoScrollPosition = new Point(0, 0);

        }
        #endregion
        #region DB Download
        private void ReadOneProduct(Product p, List<Characteristic> cL)
        {
            panelCabinet.Visible = false;
            panelTop.Controls.Clear();
            var panel = new Panel();
            panel.Size = new Size(960, 530);
            panel.Location = new Point(45, 45);
            panel.Name = "panel";
            var title = new Label();
            title.Location = new System.Drawing.Point(489, 15);
            title.Font = new Font("Microsoft YaHei", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = Color.FromArgb(45, 45, 45);
            title.Size = new System.Drawing.Size(460, 70);
            var picture = new PictureBox();
            picture.Location = new System.Drawing.Point(3, 3);
            picture.Size = new System.Drawing.Size(480, 520);
            picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            var price = new Label();
            price.Location = new Point(580, 460);
            price.AutoSize = true;
            price.Font = new Font("Microsoft YaHei", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            price.ForeColor = Color.FromArgb(45, 45, 45);
            //price.Size = new System.Drawing.Size(102, 34);
            var priceCHRN = new Label();
            priceCHRN.Location = new System.Drawing.Point(730, 475);
            priceCHRN.Text = "грн";
            priceCHRN.Font = new Font("Microsoft YaHei", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceCHRN.ForeColor = Color.FromArgb(45, 45, 45);
            priceCHRN.Size = new System.Drawing.Size(51, 27);
            var love = new Label();
            love.Image = Properties.Resources.Ресурс_17;
            //LOVe vis
            love.Visible = false;
            love.Location = new System.Drawing.Point(800, 460);
            love.Size = new System.Drawing.Size(46, 42);
            var basket = new Label();
            basket.Location = new System.Drawing.Point(860, 460);
            basket.Image = global::InternetMarket.Properties.Resources.Ресурс_16;
            basket.Size = new System.Drawing.Size(46, 42);
            basket.Cursor = Cursors.Hand;
            var listBox = new ListBox();
            listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listBox.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            listBox.FormattingEnabled = true;
            listBox.Location = new System.Drawing.Point(500, 90);
            listBox.Size = new System.Drawing.Size(460, 350);
            //DB Data
            picture.BackgroundImage = ImageDowloader(new Uri(p.ImageData));
            title.Text = p.Title;
            price.Text = (p.Price).ToString();

            foreach (var item in cL)
            {
                listBox.Items.Add(item.CharacteristicString);
            }
            panel.Controls.Add(title); panel.Controls.Add(picture); panel.Controls.Add(price);
            panel.Controls.Add(priceCHRN); panel.Controls.Add(love); panel.Controls.Add(basket);
            panel.Controls.Add(listBox);
            panelTop.Controls.Add(panel);
            basket.MouseClick += (s, e) => { basketList.Add(p); MessageBox.Show("Продукт добавлен в корзину"); };
        }
        private void ReadProductsTopDB(string Category,int height)
        {
            panelCabinet.Visible = false;
            using (M3 db = new M3())
            {
                var query = from prod in db.Products.AsParallel()
                            where prod.ProductCategory == Category
                            select prod;
                List<Product> listProd = query.ToList();
                if (listProd.Count == 0)
                {
                    MessageBox.Show("Not found");
                }
                else
                {
                    int width = 30;
                    for (int i = 0; i < 15; i++)
                    {
                        var panel = new Panel();
                        panel.Size = new Size(300, 410);
                        panel.Location = new Point(width, height);
                        width += 325;
                        width = ((i + 1) % 3 == 0 ? 30 : width);
                        height += ((i + 1) % 3 == 0 ? 430 : 0);
                        panel.Cursor = Cursors.Hand;;
                        panel.Name = "panel";
                        var title = new Label();
                        title.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        title.ForeColor = Color.FromArgb(45, 45, 45);
                        title.Size = new System.Drawing.Size(300, 70);
                        var picture = new PictureBox();
                        picture.Location = new System.Drawing.Point(0, 70);
                        picture.Size = new System.Drawing.Size(300, 270);
                        picture.Name = "picture";
                        picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        var price = new Label();
                        price.Location = new Point(0, 350);
                        price.AutoSize = true;
                        price.Font = new Font("Microsoft YaHei", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        price.ForeColor = Color.FromArgb(45, 45, 45);
                        var priceCHRN = new Label();
                        priceCHRN.Location = new System.Drawing.Point(135, 360);
                        priceCHRN.Text = "грн";
                        priceCHRN.Font = new Font("Microsoft YaHei", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        priceCHRN.ForeColor = Color.FromArgb(45, 45, 45);
                        priceCHRN.Size = new System.Drawing.Size(51, 27);
                        var love = new Label();
                        love.Image = Properties.Resources.Ресурс_17;
                        love.Visible = false;
                        love.Location = new System.Drawing.Point(190, 350);
                        love.Size = new System.Drawing.Size(46, 42);
                        var basket = new Label();
                        basket.Location = new System.Drawing.Point(240, 350);
                        basket.Image = global::InternetMarket.Properties.Resources.Ресурс_16;
                        basket.Size = new System.Drawing.Size(46, 42);
                        //DB Data
                        picture.BackgroundImage = ImageDowloader(new Uri(listProd[i].ImageData));
                        title.Text = listProd[i].Title;
                        price.Text = (listProd[i].Price).ToString();
                        
                        //Controls
                        panel.Controls.Add(picture); panel.Controls.Add(basket); panel.Controls.Add(price);
                        panel.Controls.Add(priceCHRN); panel.Controls.Add(love); panel.Controls.Add(title);
                        //Hover
                        panel.MouseHover += (s, e) => panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.MouseLeave += (s, e) => panel.BorderStyle = BorderStyle.None;
                        picture.MouseHover += (s, e) => panel.BorderStyle = BorderStyle.FixedSingle;
                        title.MouseHover += (s, e) => panel.BorderStyle = BorderStyle.FixedSingle;
                        price.MouseHover += (s, e) => panel.BorderStyle = BorderStyle.FixedSingle;
                        price.MouseLeave += (s, e) => panel.BorderStyle = BorderStyle.None;
                        title.MouseLeave += (s, e) => panel.BorderStyle = BorderStyle.None;
                        picture.MouseLeave += (s, e) => panel.BorderStyle = BorderStyle.None;
                        //Click Pannel
                        panelTop.Controls.Add(panel);
                    }
                    Control[] panels = panelTop.Controls.Find("panel",true);
                    int j= 0;
                    foreach (var prod in listProd)
                    {
                        var queryC = from c in db.Characteristics.AsParallel()
                                     where c.ProductId == prod.Id
                                     select c;
                        List<Characteristic> cL = queryC.ToList();
                        if (cL.Count != 0)
                        {
                            panels[j].MouseClick += (s, e) => ReadOneProduct(prod, cL);
                            panels[j].Controls[0].MouseClick += (s, e) => ReadOneProduct(prod, cL);
                            panels[j].Controls[1].MouseClick += (s, e) => { basketList.Add(prod); MessageBox.Show("Продукт добавлен в корзину"); };//BasketClickOrder(basketList); };
                           j++;
                        }
                        else
                            MessageBox.Show("Characteristics not found");
                    }
                    //MouseClickSettings();
                }
            }
        }
        public Image ImageDowloader(Uri uri)
        {
            try
            {
                WebClient client = new WebClient();
                Stream s = client.OpenRead(uri);
                Image image = Image.FromStream(s);
                return image;
            }
            catch
            {
                MessageBox.Show("Image not found");
                return null;
            }
        }
        #endregion
        #region Hover and Leave Settings
        public void CategorySettings()
        {
            ComponentPanel.Visible = false;
            PereferPanel.Visible = false;
            PcPanel.Visible = false;
            MonitorPanel.Visible = false;
            NoutbookPanel.Visible = false;
            //Hover
            СomponentPc.MouseHover += (s, e) => СomponentPc.Image = Image.FromFile("Images/Hover1.png");
            Perefer.MouseHover += (s, e) => Perefer.Image = Image.FromFile("Images/Hover2.png");
            Pc.MouseHover += (s, e) => Pc.Image = Image.FromFile("Images/Hover3.png");
            Monitor.MouseHover += (s, e) => Monitor.Image = Image.FromFile("Images/Hover4.png");
            Noutbook.MouseHover += (s, e) => Noutbook.Image = Image.FromFile("Images/Hover5.png");
            СomponentPc.MouseHover += CatalogHover;
            Perefer.MouseHover += CatalogHover;
            Pc.MouseHover += CatalogHover;
            Monitor.MouseHover += CatalogHover;
            Noutbook.MouseHover += CatalogHover;
            //Hover+Leave
            СomponentPc.MouseHover += (s, e) => {CatalogHoverPanel(ComponentPanel, 150); CatalogLeavePanel(PereferPanel); CatalogLeavePanel(PcPanel); CatalogLeavePanel(MonitorPanel); CatalogLeavePanel(NoutbookPanel); };
            Perefer.MouseHover += (s, e) => {CatalogHoverPanel(PereferPanel, 230);CatalogLeavePanel(ComponentPanel); CatalogLeavePanel(PcPanel); CatalogLeavePanel(MonitorPanel); CatalogLeavePanel(NoutbookPanel); };
            Pc.MouseHover += (s, e) => {CatalogHoverPanel(PcPanel, 310);CatalogLeavePanel(ComponentPanel); CatalogLeavePanel(PereferPanel); CatalogLeavePanel(MonitorPanel); CatalogLeavePanel(NoutbookPanel); };
            Monitor.MouseHover += (s, e) => {CatalogHoverPanel(MonitorPanel, 390);CatalogLeavePanel(ComponentPanel); CatalogLeavePanel(PereferPanel); CatalogLeavePanel(PcPanel); CatalogLeavePanel(NoutbookPanel); };
            Noutbook.MouseHover += (s, e) =>{ CatalogHoverPanel(NoutbookPanel, 470); CatalogLeavePanel(ComponentPanel); CatalogLeavePanel(PereferPanel); CatalogLeavePanel(PcPanel); CatalogLeavePanel(MonitorPanel); };
            //Leve
            СomponentPc.MouseLeave += (s, e) => СomponentPc.Image = Image.FromFile("Images/Ресурс 9.png");
            Perefer.MouseLeave += (s, e) => Perefer.Image = Image.FromFile("Images/Ресурс 10.png");
            Pc.MouseLeave += (s, e) => Pc.Image = Image.FromFile("Images/Ресурс 11.png");
            Monitor.MouseLeave += (s, e) => Monitor.Image = Image.FromFile("Images/Ресурс 13.png");
            Noutbook.MouseLeave += (s, e) => Noutbook.Image = Image.FromFile("Images/Ресурс 12.png");

            СomponentPc.MouseLeave += CatalogLeave;
            Perefer.MouseLeave += CatalogLeave;
            Pc.MouseLeave += CatalogLeave;
            Monitor.MouseLeave += CatalogLeave;
            Noutbook.MouseLeave += CatalogLeave;
            panelUser.MouseHover += (s, e) => {CatalogLeavePanel(ComponentPanel); CatalogLeavePanel(PereferPanel); CatalogLeavePanel(PcPanel); CatalogLeavePanel(MonitorPanel); CatalogLeavePanel(NoutbookPanel); };
            panelTop.MouseHover += (s, e) => { CatalogLeavePanel(ComponentPanel); CatalogLeavePanel(PereferPanel); CatalogLeavePanel(PcPanel); CatalogLeavePanel(MonitorPanel); CatalogLeavePanel(NoutbookPanel); };
            this.MouseHover += (s, e) => { CatalogLeavePanel(ComponentPanel); CatalogLeavePanel(PereferPanel); CatalogLeavePanel(PcPanel); CatalogLeavePanel(MonitorPanel); CatalogLeavePanel(NoutbookPanel); };
            ComponentPanel.MouseLeave += (s, e) => CatalogLeavePanel(ComponentPanel);
            PereferPanel.MouseLeave += (s, e) => CatalogLeavePanel(PereferPanel);
            PcPanel.MouseLeave += (s, e) => CatalogLeavePanel(PcPanel);
            MonitorPanel.MouseLeave += (s, e) => CatalogLeavePanel(MonitorPanel);
            NoutbookPanel.MouseLeave += (s, e) => CatalogLeavePanel(NoutbookPanel);

            SubdirectorySettings(ComponentPanel);
            SubdirectorySettings(PereferPanel);
            SubdirectorySettings(PcPanel);
            SubdirectorySettings(MonitorPanel);
            SubdirectorySettings(NoutbookPanel);

        }
        private void SubdirectorySettings(Panel p)
        {
            for (int i = 0; i < p.Controls.Count; i++)
            {
                p.Controls[i].MouseHover += (s, e) =>
                 {
                     (s as Label).Cursor = Cursors.Hand;
                     (s as Label).BackColor = Color.FromArgb(107, 143, 35);
                     (s as Label).ForeColor = Color.FromArgb(255, 255, 255);
                     (s as Label).Image = Image.FromFile("Images/WhiteCursor.png");
                 };
                p.Controls[i].MouseLeave += (s, e) =>
                {
                    (s as Label).BackColor = Color.FromArgb(152, 158, 161);
                    (s as Label).ForeColor = Color.FromArgb(45, 45, 45);
                    (s as Label).Image = Image.FromFile("Images/Ресурс 14.png");
                };
                p.Controls[i].MouseClick += (s, e) =>
                {
                    panelTop.AutoScrollPosition = new Point(0,0) ;
                    panelTop.Controls.Clear();
                    panelTop.Controls.Add(panelCabinet);
                    CatalogLeavePanel(p);
                    ReadProductsTopDB((s as Label).Name,30);
                };
            }
        }

        private void CatalogLeavePanel(Panel p)
        {
            p.Visible = false;
        }

        private void CatalogHoverPanel(Panel p,int h)
        {
            p.Visible = true;
            p.Location = new Point(294, h);
            p.AutoSize = true;
            p.BringToFront();
        }
        private void CatalogHover(object sender, EventArgs e)
        {
            (sender as Label).BackColor= Color.FromArgb(107, 143, 35);
        }
        private void CatalogLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(45, 45, 45);
        }
        #endregion
    }
}
