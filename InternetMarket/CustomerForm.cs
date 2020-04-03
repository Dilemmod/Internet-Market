using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            FillProductsTopDB();


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
        }
        private async void FillProductsTopDB()
        {
            //try
            {
                using (DBInternetMarket db = new DBInternetMarket())
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
                    p.Characteristics = charactList;
                    p.ImageFileName = "Images/ProductPictures/1.png";
                    byte[] Data = PictureConverterToByteArrey("Images/ProductPictures/1.png",new Uri(@"https://img.telemart.ua/186243-380056/gigabyte-geforce-rtx-2060-super-gaming-oc-3x-8192mb-gv-n206sgaming-oc-8gd.png"));
                    p.ImageData = Data;

                    db.Products.Add(p);
                    await db.SaveChangesAsync();
                }
            }
            //catch
            {
                //MessageBox.Show("Error Server");
            }
        }
        public byte[] PictureConverterToByteArrey(string fileName, Uri uri)
        {
            WebClient client = new WebClient();
                //f.BackgroundImage = Image.FromFile(fileName);
            client.DownloadFile(uri, fileName);


            /// путь к файлу для загрузки
            //string filename = @"C:\Users\Eugene\Pictures\cats.jpg";
            /// заголовок файла
            //string title = "Коты";
            /// получаем короткое имя файла для сохранения в бд
            //string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // cats.jpg
                                                                                       // массив для хранения бинарных данных файла
            byte[] imageData;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }
            return imageData;
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
            Search.Text = (ComponentPanel.Controls.Count).ToString();

            SubdirectorySettings(ComponentPanel);
            SubdirectorySettings(PereferPanel);
            SubdirectorySettings(PcPanel);
            SubdirectorySettings(MonitorPanel);
            SubdirectorySettings(NoutbookPanel);

        }
        private void SubdirectorySettings(Panel p)
        {
            for (int i = 0; i<p.Controls.Count; i++)
            {
                p.Controls[i].MouseHover+= (s, e) =>
                {
                    (s as Label).Cursor = Cursors.Hand;
                    (s as Label).BackColor = Color.FromArgb(107,143,35) ;
                    (s as Label).ForeColor = Color.FromArgb(255, 255, 255);
                    (s as Label).Image = Image.FromFile("Images/WhiteCursor.png");
                };
                p.Controls[i].MouseLeave += (s, e) =>
                {
                    (s as Label).BackColor = Color.FromArgb(224, 224, 224);
                    (s as Label).ForeColor = Color.FromArgb(45, 45, 45);
                    (s as Label).Image = Image.FromFile("Images/Ресурс 14.png");
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
