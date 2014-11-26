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
    public partial class MDIparent : DevExpress.XtraEditors.XtraForm
    {
        public MDIparent()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
        }
        

        private void MDIparent_Load(object sender, EventArgs e)
        {
          statusBarName.Text= "My Page .";
          StatusBarToday.Text = DateTime.Today.ToShortDateString();
        }


        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();            

                MyPage child = new MyPage();
                child.MdiParent = this;
                child.Show();
                //ribbonControl1.StatusBar.ItemLinks.Add(barButtonItem2);
                //ribbonStatusBar1.CompanyName.ToString();
            
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();

            BrowseDocument child = new BrowseDocument();
            child.MdiParent = this;
            child.Show();
        }
    }
}