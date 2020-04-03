using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetMarket
{
    class StandardFormSettings
    {
        Form f;
        public StandardFormSettings(Form f)
        {
            this.f = f;
            f.StartPosition = FormStartPosition.Manual;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Width = Screen.PrimaryScreen.Bounds.Width;
            f.Height = Screen.PrimaryScreen.Bounds.Height - 46;
            CreateButton();
        }
        public void SetBackgroundImage(string fileName,Uri uri)
        {
            WebClient client = new WebClient();
            if (File.Exists(fileName))
            {
                f.BackgroundImage = Image.FromFile(fileName);
            }
            else
            {
                client.DownloadFile(uri, fileName);
                SetBackgroundImage(fileName,uri);
            }
        }
        private void CreateButton()
        {
            for (int i = 0; i < 3; i++)
            {
                Label button = new Label();
                button.BackColor = Color.FromArgb(45, 45, 45);
                button.Cursor = Cursors.Hand;
                button.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
                button.ForeColor = Color.FromArgb(167, 167, 167);
                button.Size = new Size(50, 40);
                button.TextAlign = ContentAlignment.MiddleCenter;
                f.Controls.Add(button);
                switch (i)
                {
                    case 0:
                        button.Name = "buttonExit";
                        button.Location = new Point(f.Width - 50, 0);
                        button.Text = "x";
                        button.MouseClick += (sender, e) => f.Close();
                        button.MouseLeave += (sender, e) => {
                            button.BackColor = Color.FromArgb(45, 45, 45);
                            button.ForeColor = Color.FromArgb(167, 167, 167);
                        };
                        button.MouseHover += (sender, e) => {
                            button.BackColor = Color.FromArgb(252, 68, 68);
                            button.ForeColor = Color.FromArgb(255, 255, 255);
                        };
                        break;
                    case 1:
                        button.Name = "buttonMin";
                        button.Location = new Point(f.Width - 100, 0);
                        button.Text = "-";
                        button.MouseClick += (sender, e) => f.WindowState = FormWindowState.Minimized;
                        button.MouseLeave += (sender, e) => {
                            button.BackColor = Color.FromArgb(45, 45, 45);
                            button.ForeColor = Color.FromArgb(167, 167, 167);
                        };
                        button.MouseHover += (sender, e) => {
                            button.BackColor = Color.FromArgb(69, 69, 69);
                            button.ForeColor = Color.FromArgb(255, 255, 255);
                        };
                        break;
                    default:
                        button.Cursor = Cursors.Default;
                        button.Location = new Point(0, 0);
                        button.Size = new Size(f.Width - 100, 40);
                        break;
                }
            }
        }
    }
}
