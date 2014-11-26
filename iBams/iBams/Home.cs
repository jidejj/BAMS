using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iBams
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        public Home()
        {
            InitializeComponent();
            lblUsername.Text = Program.ID_Login.ToUpper();
        }

        private void tileControl11_Click(object sender, EventArgs e)
        {

        }

        private void tileItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            Application.Exit();
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            MyPage myPage = new MyPage();
            myPage.Show();
            myPage = null;
        }

        private void tileItem9_ItemClick(object sender, TileItemEventArgs e)
        {
            BrowseDocument DHSH = new BrowseDocument();
            DHSH.Show();

        }
    }
}