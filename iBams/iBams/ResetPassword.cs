using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using PBMSModel;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.XtraData;
using DevExpress.Data.Filtering;
using PBMSModel.Ibs_Security;


namespace iBams
{

    public partial class ResetPassword : DevExpress.XtraEditors.XtraForm
    {
        public string UserName;
        public ResetPassword(string UserName)
        {
            InitializeComponent();
            labelControl1.Visible = false;
            txtScrtAns.Visible = false;
            labelControl2.Visible = false;
            subButton.Visible = false;
            this.UserName = UserName;
            UserNameTxtBox.Text = this.UserName;
            UserNameTxtBox.Enabled = false;

        }
        public ResetPassword()
        {
            InitializeComponent();
            labelControl1.Visible = false;
            txtScrtAns.Visible = false;
            UserNameTxtBox.Visible = true;
            labelControl2.Visible = false;
            subButton.Visible = false;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (UserNameTxtBox.Text != "")
            {
                try
                {
                    XPQuery<Users> users = this.session1.Query<Users>();
                    var User = users.FirstOrDefault(item => item.ID_Login == UserNameTxtBox.Text);
                    if (User.ID_Login == UserNameTxtBox.Text)
                    {
                        labelControl1.Text = User.Secret_Question + "?";
                        label1.Visible = false;
                        UserNameTxtBox.Visible = false;
                        btnReset.Visible = false;
                        labelControl1.Visible = true;
                        txtScrtAns.Visible = true;
                        labelControl2.Visible = true;
                        subButton.Visible = true;
                        this.setUserName(User.ID_Login + " \n" + User.FirstName + " " + User.LastName + "\n");
                        //ChangePassword newPage = new ChangePassword();
                        ////newPage.pasWrd = txtPswd.Text;
                        //newPage.ChangePassword_GetUserName(this.getUserName());
                        //newPage.Show();
                        //this.Hide();
                    }

                }
                catch
                {
                    MessageBox.Show("Invalid User!!" + " " + UserNameTxtBox.Text);
                    UserNameTxtBox.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Invalid User!!" + " " + UserNameTxtBox.Text);
            }
        }

        public void setUserName(String UserName1)
        {
            UserName = UserName1;
        }
        public string getUserName()
        {
            return UserName;
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            if (txtScrtAns.Text != "")
            {
                try
                {
                    XPQuery<Users> users = this.session1.Query<Users>();
                    var User = users.FirstOrDefault(item => item.ID_Login == UserNameTxtBox.Text.Trim());
                    if (User.Secret_Answer == txtScrtAns.Text)
                    {
                        this.setUserName(User.FirstName + " " + User.LastName + "\n");
                        ChangePassword newPage = new ChangePassword();
                        //newPage.pasWrd = txtPswd.Text;
                        newPage.ChangePassword_GetUserName(UserNameTxtBox.Text.Trim());
                        newPage.ChangePassword_GetFullName(this.getUserName());
                        newPage.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Answer Try-Again!!");
                        txtScrtAns.Text = "";
                    }

                }
                catch
                {
                    MessageBox.Show("Server Error");
                    txtScrtAns.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Please enter your secret answer");
                txtScrtAns.Text = "";
            }
        }

        private void LoginPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            var LoginPage = new Login();
            LoginPage.Show();
        }

    }
}
