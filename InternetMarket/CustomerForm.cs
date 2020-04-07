
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
        public CustomerForm()
        {
            InitializeComponent();
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
        #region Click Settings
        private void MouseClickSettings()
        {
            MouseClickUserSettings();
            MouseClickCabinetSettings();

        }
        private void MouseClickCabinetSettings()
        {
            CabinetBasket.MouseClick += (s, e) => { panelOrder.Visible = true; BasketClickOrder(basketList); MessageBox.Show("BASKET"); }; ;
        }
        private void MouseClickUserSettings()
        {
            Exit.MouseClick += (s, e) =>
            {
                this.Hide();
                AccountLoginForm ac = new AccountLoginForm();
                ac.Show();
            };
            SearchButton.MouseClick += (s,e)=> SearchClick(Search.Text);
            CabinetButtom.MouseClick += (s, e) => { panelCabinet.Visible = true; MessageBox.Show("Cabinet"); };
            basketButtom.MouseClick += (s, e) => { panelOrder.Visible = true; BasketClickOrder(basketList);MessageBox.Show("BASKET"); }; ;
        }
        public void SearchClick(string Text)
        {
            
            using (M1 db = new M1())
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
        private void BasketClickOrder(List<Product> pL)
        {
            panelBasket.Controls.Clear();
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
                //numeric.
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
                //priceCHRN.Size = new System.Drawing.Size(51, 27);
                picture.BackgroundImage = ImageDowloader(new Uri(pL[i].ImageData));
                title.Text = pL[i].Title;
                price.Text = (pL[i].Price).ToString();
                panel.Controls.Add(del); panel.Controls.Add(numeric); panel.Controls.Add(price);
                panel.Controls.Add(priceCHRN); panel.Controls.Add(title); panel.Controls.Add(picture);
                panelCabinet.Visible = true;
                panelBasket.Controls.Add(panel);
            }
            Control[] panels = panelOrder.Controls.Find("panel", true);
            int j=0;
            foreach (var item in basketList)
            {
                panels[j].Controls[0].MouseClick += (s, e) => { basketList.Remove(item); BasketClickOrder(basketList); };
                //(panels[j].Controls[1] as NumericUpDown).ValueChanged += (s, e) => 
                //{
                //    panels[j].Controls[2].Text = (Convert.ToInt32(panels[j].Controls[2].Text)*(panels[j].Controls[1] as NumericUpDown).Value).ToString();
                //};
                j++;
            }

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
            using (M1 db = new M1())
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
                    panelTop.Controls.Clear();
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
