using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Xpo;
using PBMSModel.Ibs_Security;

namespace iBams
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
            this.session1.ConnectionString = PBMSModel.Ibs_Security.ConnectionHelper.ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Initializes resource strings
        /// </summary>
        private void InitializeResourceString()
        {
            //lblUserName.Text = Resources.Login_Username_Label_Text;
            //lblPassword.Text = Resources.Login_Password_Label_Text;
            //btnLogin.Text = Resources.Login_Login_Button_Text;
        }

        private int loginAttemptCount = 0;

        //private void Login_Click(object sender, EventArgs e)
        //{

        //}

        /// <summary>
        /// Click event to handle the login process
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Login_Click(object sender, EventArgs e)
        {
            loginAttemptCount++;

            if (loginAttemptCount <= 3)
            {
                string signin = SignInUser(txtUsername.Text, txtPassword.Text);

                switch (signin)
                {
                    case ("done"):
                        loginAttemptCount = 0;
                        var frmHome = new Home();
                        frmHome.Show();
                        this.Hide();
                        break;
                    case ("NoGroup"):
                        loginAttemptCount = 0;
                        MessageBox.Show(
                        Properties.Resources.Login_Validation_Message_NoGroup,
                        Properties.Resources.Login_Validation_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        break;
                    case ("AccessDenied"):
                        MessageBox.Show(
                        Properties.Resources.Login_Validation_Message_AccessDenied,
                        Properties.Resources.Login_Validation_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        break;
                    case ("DefaultPassword"):
                        var frmchangepassword = new ChangePassword();
                        frmchangepassword.Show();
                        this.Hide();
                        break;
                    case ("InvalidCredentials"):
                        MessageBox.Show(
                        Properties.Resources.Login_Validation_Message_InvalidCredentials,
                        Properties.Resources.Login_Validation_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        break;
                }
            }
            else
            {
                try
                {
                    XPQuery<Users> users = this.session1.Query<Users>();
                    var User = users.FirstOrDefault(item => item.ID_Login == txtUsername.Text.Trim().ToLower());
                    if (User.ID_Login == txtUsername.Text.ToLower())
                    {
                        var frmChangePassword = new ResetPassword(txtUsername.Text.ToLower());
                        frmChangePassword.Show();
                        this.Hide();
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid User!!" + " " + txtUsername.Text);
                    txtUsername.Text = "";
                    Application.Exit();
                }
            }
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public String SignInUser(String ID_Login, String Password)
        {
            /// <summary>
            /// Check if Login Credential is Vendor's Credential
            /// </summary>
            /// 
            string IsVendor = "no";
            string EncryptedPassword = Program.EncryptString(Password);
            String DefaultPassword = "";

            //Check if Login Credential is Vendor's Credential
            XPQuery<Preferences> preferences = session1.Query<Preferences>();
            var pref = preferences.FirstOrDefault();

            if (pref.ID_Preferences != null)
            {
                String VendorEnabled = pref.VendorEnabled.ToString();

                if (pref.VendorLogin.ToString() == ID_Login && pref.VendorPassword.ToString() == EncryptedPassword)
                {
                    if (VendorEnabled.ToLower() == "false")
                        MessageBox.Show(
                            Properties.Resources.Login_Validation_Message_Vendor,
                            Properties.Resources.Login_Validation_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    Program.FullName = pref.VendorName.ToString();
                    Program.FirstName = pref.VendorName.ToString();
                    Program.ID_Login = pref.VendorLogin.ToString();
                    Program.IsVendor = "yes";
                    return "done";
                }
            }


            //if not a vendor
            XPQuery<Users> users = session1.Query<Users>();
            var user = users.FirstOrDefault(u => u.ID_Login == ID_Login && u.Password == EncryptedPassword);

            if (user != null)
            {
                XPQuery<UserGroup> UserGroup = session1.Query<UserGroup>();
                var usrgroup = UserGroup.FirstOrDefault(usrgrp => usrgrp.ID_Group == user.ID_Group);

                if (user.ID_Login != null)
                {
                    if (user.ID_Group.ToString() == "0")
                        return "NoGroup";

                    if (user.Enabled.ToString() == "False" || user.Enabled.ToString() == "False")
                        return "AccessDenied";

                    if (user.DefaultPassword.ToString().ToLower() == "true")
                    {
                        Program.ID_Login = user.ID_Login;
                        return "DefaultPassword";
                    }

                    Program.FullName = user.FirstName.ToString() + " " + user.LastName.ToString();
                    Program.FirstName = user.FirstName.ToString();
                    Program.ID_Login = user.ID_Login.ToString();
                    return "done";
                }
            }
            return "InvalidCredentials";

        }

        private void resetpassword_OpenLink(object sender, EventArgs e)
        {
            var frmChangePassword = new ResetPassword();
            frmChangePassword.Show();
            this.Hide();
        }
    }
}
