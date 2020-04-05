
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
        public CustomerForm()
        {
            InitializeComponent();
            //Border,Size,Location Form
            StandardFormSettings standartForm = new StandardFormSettings(this);
            CategorySettings();
            MouseClickSettings();
            // FillProductsTopDB();
            ReadProductsTopDB("Motherboard",130);
            //FillProductsTopDB();


        }
        private void MouseClickSettings()
        {
            MouseClickUserSettings();

        }
        private void MouseClickUserSettings()
        {
            Exit.MouseClick += (s, e) =>
            {
                this.Hide();
                AccountLoginForm ac = new AccountLoginForm();
                ac.Show();
            };
            SearchButton.MouseClick += (s,e)=>SearchClick(Search.Text);
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
                    ReadProductByTitle(pL[0], cL);
                }  
            }
            Search.Text = "";
        }
        #region DB Download
        private void ReadProductByTitle(Product p, List<Characteristic> cL)
        {
            panelTop.Controls.Clear();
            var panel = new Panel();
            panel.Size = new Size(960, 530);
            panel.Location = new Point(45, 45);
            var title = new Label();
            title.Location = new System.Drawing.Point(489, 15);
            title.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = Color.FromArgb(45, 45, 45);
            title.Size = new System.Drawing.Size(460, 70);
            var picture = new PictureBox();
            picture.Location = new System.Drawing.Point(3, 3);
            picture.Size = new System.Drawing.Size(480, 520);
            picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            var price = new Label();
            price.Location = new Point(600, 470);
            price.AutoSize = true;
            price.Font = new Font("Microsoft YaHei", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            price.ForeColor = Color.FromArgb(45, 45, 45);
            //price.Size = new System.Drawing.Size(102, 34);
            var priceCHRN = new Label();
            priceCHRN.Location = new System.Drawing.Point(720, 475);
            priceCHRN.Text = "грн";
            priceCHRN.Font = new Font("Microsoft YaHei", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceCHRN.ForeColor = Color.FromArgb(45, 45, 45);
            priceCHRN.Size = new System.Drawing.Size(51, 27);
            var love = new Label();
            love.Image = Properties.Resources.Ресурс_17;
            love.Location = new System.Drawing.Point(800, 460);
            love.Size = new System.Drawing.Size(46, 42);
            var basket = new Label();
            basket.Location = new System.Drawing.Point(860, 460);
            basket.Image = global::InternetMarket.Properties.Resources.Ресурс_16;
            basket.Size = new System.Drawing.Size(46, 42);
            var listBox = new ListBox();
            listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listBox.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            listBox.FormattingEnabled = true;
            listBox.Location = new System.Drawing.Point(500, 90);
            listBox.Size = new System.Drawing.Size(440, 338);
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
        }
        private void ReadProductsTopDB(string Category,int height)
        {
            using (M1 db = new M1())
            {
                var query = from prod in db.Products.AsParallel()
                            where prod.ProductCategory == Category
                            select prod;
                List<Product> listProd = query.ToList();
                int width = 30;
                    for (int i = 0; i < 15; i++)
                    {
                        var panel = new Panel();
                        panel.Size = new Size(300, 400);
                        panel.Location = new Point(width, height);

                        width += 325;
                        width = ((i+1) % 3 == 0 ? 30 : width);
                        height += ((i+1) % 3 == 0 ? 430 : 0);

                        var title = new Label();
                        title.Font = new Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        title.ForeColor = Color.FromArgb(45,45,45);
                        title.Size = new System.Drawing.Size(300, 70);
                        var picture = new PictureBox();
                        picture.Location = new System.Drawing.Point(0, 70);
                        picture.Size = new System.Drawing.Size(300, 270);
                        picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                        var price = new Label();
                        price.Location = new Point(0, 350);
                        price.AutoSize = true;
                        price.Font = new Font("Microsoft YaHei", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        price.ForeColor = Color.FromArgb(45, 45, 45);
                        //price.Size = new System.Drawing.Size(102, 34);
                        var priceCHRN= new Label();
                        priceCHRN.Location = new System.Drawing.Point(130, 360);
                        priceCHRN.Text = "грн";
                        priceCHRN.Font = new Font("Microsoft YaHei", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        priceCHRN.ForeColor = Color.FromArgb(45, 45, 45);
                        priceCHRN.Size = new System.Drawing.Size(51, 27);
                        var love = new Label();
                        love.Image = Properties.Resources.Ресурс_17;
                        love.Location = new System.Drawing.Point(180, 350);
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
                        panel.Controls.Add(title); panel.Controls.Add(picture); panel.Controls.Add(price);
                        panel.Controls.Add(priceCHRN); panel.Controls.Add(love); panel.Controls.Add(basket);
                        panelTop.Controls.Add(panel);
                    }

            }
        }

        private async void FillProductsTopDB()
        {
            try
            {
                using (M1 db = new M1())
                {
                    Product p = new Product();
                    p.Title = "Видеокарта Gigabyte GeForce RTX 2060 SUPER Gaming OC 3X 8192MB (GV-N206SGAMING OC-8GD)";
                    p.Price = 13999;
                    List<string> charactList = new List<string>();
                    charactList.Add("Объём памяти: 8192 Мб");
                    charactList.Add("Тип памяти: GDDR6");
                    charactList.Add("Шина памяти: 256 бит");
                    charactList.Add("Частота графического ядра: 1710 МГц");
                    charactList.Add("Частота видеопамяти: 14000 МГц");
                    charactList.Add("Разъемы для монитора: DisplayPort x 3 (v1.4)");
                    charactList.Add("HDMI 2.0b x 1");
                    charactList.Add("Производительность: 13838");
                    //p.Characteristics = charactList;

                    Image image = ImageDowloader(new Uri(@"https://img.telemart.ua/186243-380056/gigabyte-geforce-rtx-2060-super-gaming-oc-3x-8192mb-gv-n206sgaming-oc-8gd.png"));
                    MemoryStream memoryStream = new MemoryStream();
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] Data = memoryStream.ToArray();

                    //p.ImageData = Data;
                    db.Products.Add(p);
                    await db.SaveChangesAsync();
                }
            }
            catch
            {
                MessageBox.Show("Error Server");
            }
        }
        #endregion
        public Image ImageDowloader(Uri uri)
        {
            WebClient client = new WebClient();
            Stream s = client.OpenRead(uri);
            Image image = Image.FromStream(s);
            return image;
        }
        #region Hover and Leave Settings
        public void CategorySettings()
        {
            //Main Settings
            this.BackColor = Color.FromArgb(255, 255, 255);
            mainPanel.Location = new Point(300, 40);
            mainPanel.Size = new Size(this.Width-600, this.Height-40);
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
                    (s as Label).BackColor = Color.FromArgb(224, 224, 224);
                    (s as Label).ForeColor = Color.FromArgb(45, 45, 45);
                    (s as Label).Image = Image.FromFile("Images/Ресурс 14.png");
                };
                p.Controls[i].MouseClick += (s, e) =>
                {
                    panelTop.Controls.Clear();
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
