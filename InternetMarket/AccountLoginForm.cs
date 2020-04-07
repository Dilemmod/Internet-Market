using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
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

        }

        private async void registrationButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckRegistration())
            {
               //try
                {
                    using (M3 db = new M3())
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
                //catch
                {
                    //MessageBox.Show("Error Server");
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

            //try
            {
                using (M3 db = new M3())
                {
                    var query = from user in db.UsersLogins.AsParallel()
                                where (user.Login == loginName.Text || user.Mail == loginName.Text) && user.Password == loginPassword.Text
                                select user;
                    List<UsersLogin> uLogin = query.ToList();
                    if (uLogin.Count != 0)
                    {
                        var queryCustumerInfo = from custInfo in db.CustomersInformations.AsParallel()
                                                where custInfo.UserLoginId == uLogin[0].Id
                                                select custInfo;
                        List<CustomerInformation> cInfoList = queryCustumerInfo.ToList();
                        if (cInfoList.Count != 0)
                        {
                            this.Hide();
                            CustomerForm cF = new CustomerForm(cInfoList[0]);
                            cF.Show();
                        }
                        else
                            MessageBox.Show("Such user was not found");
                    }
                    else
                        MessageBox.Show("Such user was not found");
                }
            }
           // catch
            {
                //MessageBox.Show("Error Server");
            }
        }
        private bool UserExist()
        {

            try
            {
                using (M3 db = new M3())
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
    }
}
