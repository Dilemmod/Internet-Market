using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Xml;
using DatabaseLibrary;

namespace InternetMarket
{
    public partial class AccountLoginForm : Form
    {

        public AccountLoginForm()
        {
            InitializeComponent();
            //Border,Size,Location Form
            StandardFormSettings standartForm = new StandardFormSettings(this);
            standartForm.SetBackgroundImage("Images/LoginBackgroundImage.jpg", new Uri(@"https://pixabay.com/get/57e7d3444850b114f0db8474c22a3663143ad6e05b5371497027.jpg"));
            ToLoginToRegisterButtons();
            PanelSettings();
            loginButton.MouseClick += loginButton_MouseClick;
            registrationButton.MouseClick += registrationButton_MouseClick;
            buttonFiller_DB.Location =new Point(this.Width-300,this.Height-150);
            

        }

        private async void registrationButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckRegistration())
            {
               try
                {
                    using (DataBaseIM db = new DataBaseIM())
                    {
                        UsersLogin user = new UsersLogin();
                        user.Login = registrationName.Text;
                        user.Password = registrationPassword.Text;
                        user.Mail = registrationMail.Text;
                        db.UsersLogins.Add(user);
                        CustomerInformation userInformation = new CustomerInformation();
                        userInformation.UserLogin = user;
                        db.CustomersInformations.Add(userInformation);
                        await db.SaveChangesAsync();
                    }
                }
                catch(Exception w)
                {
                    MessageBox.Show("Error Server: "+w.ToString());
                }
                MessageBox.Show("Account Created!");
                loginPanel.Visible = true;
                registrationPanel.Visible = false;
            }
        }
        private bool CheckRegistration()
        {
            if (registrationName.Text == "")
            {
                MessageBox.Show("Enter your name");
                return false;
            }
            if (registrationPassword.Text == "")
            {
                MessageBox.Show("Enter your password");
                return false;
            }
            if (registrationConfirmPassword.Text == "")
            {
                MessageBox.Show("Enter password confirmation");
                return false;
            }
            if (registrationConfirmPassword.Text != registrationPassword.Text)
            {
                MessageBox.Show("Passwords do not match");
                return false;
            }
            if (registrationMail.Text == "")
            {
                MessageBox.Show("Enter your email");
                return false;
            }
            if (UserExist())
            {
                MessageBox.Show("Such user already exists");
                return false;
            }
            else if (Regex.IsMatch(registrationMail.Text,
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) == false)
            {
                MessageBox.Show("Enter email in correct format like:\n\t jonah921@gmail.com");
                return false;
            }
            return true;
        }

        private void loginButton_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                using (DataBaseIM db = new DataBaseIM())
                {
                    UsersLogin user = db.UsersLogins.FirstOrDefault(u =>( u.Login == loginName.Text || u.Mail == loginName.Text) && u.Password == loginPassword.Text);
                    if (user!=null)
                    {
                        CustomerInformation cInfo = db.CustomersInformations.FirstOrDefault(cI=>cI.UserLoginId == user.Id);
                        if (cInfo!=null)
                        {
                            if (checkBoxUserSave.Checked)
                            {
                                try
                                {
                                    SaveSettings();
                                }
                                catch (Exception exd)
                                {
                                    MessageBox.Show("Error Server: " + exd);
                                }
                            }
                            this.Hide();
                            CustomerForm cF = new CustomerForm(cInfo);
                            cF.Show();
                        }
                        else
                        {
                            MenedjerInformation mInfo = db.MenedjersInformations.FirstOrDefault(mI => mI.UserLoginId == user.Id);
                            if (mInfo!=null)
                            {
                                if (checkBoxUserSave.Checked)
                                {
                                    try
                                    {
                                        SaveSettings();
                                    }
                                    catch (Exception exd)
                                    {
                                        MessageBox.Show("Error Server: " + exd);
                                    }
                                }
                                this.Hide();
                                AdminForm aF = new AdminForm();
                                aF.Show();
                                
                            }
                            else MessageBox.Show("NOT found");
                        }
                    }
                    else
                        MessageBox.Show("No such user found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Server: "+ex);
            }
        }

        private bool UserExist()
        {
            try
            {
                using (DataBaseIM db = new DataBaseIM())
                {
                    var query = from user in db.UsersLogins.AsParallel()
                                where user.Login == registrationName.Text || user.Mail == registrationMail.Text
                                select user;
                    if (query.ToList().Count != 0)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                MessageBox.Show("Error Server");
                return false;
            }
        }
    #region FormSettings
        private void PanelSettings()
        {
            loginPanel.Visible = true;
            registrationPanel.Visible = false;
            loginPanel.Location = new Point(this.Width / 2- loginPanel.Width/2, this.Height / 2 - loginPanel.Height / 2);
            registrationPanel.Location = new Point(this.Width / 2- registrationPanel.Width/2, this.Height / 2-registrationPanel.Height/2);
        }
        private void ToLoginToRegisterButtons()
        {

            loginToRegistration.MouseClick += (s, e) =>
            {
                loginPanel.Visible = false;
                registrationPanel.Visible = true;
            };
            loginToRegistration.MouseHover += (s, e) => loginToRegistration.ForeColor = Color.FromArgb(128, 170, 42);
            loginToRegistration.MouseLeave += (s, e) => loginToRegistration.ForeColor = Color.FromArgb(107, 142, 35);

            //Registration
            registrationToLogin.MouseClick += (s, e) =>
            {
                loginPanel.Visible = true;
                registrationPanel.Visible = false;
            };
            registrationToLogin.MouseHover += (s, e) => registrationToLogin.ForeColor = Color.FromArgb(128, 170, 42);
            registrationToLogin.MouseLeave += (s, e) => registrationToLogin.ForeColor = Color.FromArgb(107, 142, 35);
        }
        #endregion

        private void buttonFiller_DB_Click(object sender, EventArgs e)
        {
            string appPath = Application.ExecutablePath;
            string nead =appPath.Replace(@"InternetMarket\InternetMarket\bin\Debug\InternetMarket.exe", @"InternetMarket\Redactor_DataBaseIM\bin\Debug\netcoreapp3.0\Redactor_DataBaseIM.exe");
            Process p = Process.Start(nead);
            p.WaitForExit();
        }
        private bool CheckSettings()
        {
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
            if (allAppSettings.Count > 1)
            {
                string userLogin = allAppSettings["UserLogin"];
                string userPass = allAppSettings["UserPass"];
                if (userLogin != null || userPass != null|| userLogin != "Test" || userPass != "123")
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        private void ReadSettings()
        {
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
            if (allAppSettings.Count > 1)
            {
                //1.
                string userLogin = allAppSettings["UserLogin"];
                string userPass = allAppSettings["UserPass"];
                loginName.Text = userLogin;
                loginPassword.Text = userPass;
            }
        }
        private void SaveSettings()
        {
            XmlDocument doc = loadConfigDocument();
            XmlNode node = doc.SelectSingleNode("//appSettings");
            string[] keys = new string[] {
                "UserLogin",
                "UserPass",
            };
            string[] values = new string[]
            {
                loginName.Text,
                loginPassword.Text,
            };
            for (int i = 0; i < keys.Length; i++)
            {
                XmlElement element = node.SelectSingleNode(string.Format("//add[@key='{0}']", keys[i])) as XmlElement;

                if (element != null) { element.SetAttribute("value", values[i]); }
                else
                {
                    element = doc.CreateElement("add");
                    element.SetAttribute("key", keys[i]);
                    element.SetAttribute("value", values[i]);
                    node.AppendChild(element);
                }
            }
            doc.Save(Assembly.GetExecutingAssembly().Location + ".config");
            MessageBox.Show("Username and password saved");
        }
        private static XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(Assembly.GetExecutingAssembly().Location + ".config");
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }
        private void AccountLoginForm_Load(object sender, EventArgs e)
        {
            if (CheckSettings())
            {
                ReadSettings();
            }
        }
    }
}
