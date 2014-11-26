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
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;


namespace iBams
{
    public partial class ChangePassword : DevExpress.XtraEditors.XtraForm
    {
        string ID_Login = "";
        public ChangePassword()
        {
            //label3.Text = ResetPassword;
            InitializeComponent();
        }
        public void ChangePassword_GetUserName(string User)
        {
            this.ID_Login = User;
        }
        public void ChangePassword_GetFullName(string User)
        {
            label3.Text =  User;
        }


        private void submit_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Guid ID= Guid.Parse(txtGUID_request4BenMaster.Text);
                XPQuery<Users> users = this.session1.Query<Users>();
                var User = users.FirstOrDefault(item => item.ID_Login == ID_Login);
                if ((User.ID_Login != null) && (textBox1.Text == textBox2.Text) && (textBox1.Text != ""))
                {
                    User.Password = Program.EncryptString(textBox1.Text);
                    session1.Save(User);
                    MessageBox.Show(Owner, "Saved Successfully", "Request for Benefit Master");
                    this.Hide();
                    var LoginPage = new Login();
                    LoginPage.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Password ");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }

            }
            catch
            {
                MessageBox.Show(Owner, "Error Occured from database");
                textBox1.Text = "";
                textBox2.Text = "";
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