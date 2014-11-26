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
    public partial class AppointmentDate : DevExpress.XtraEditors.XtraForm
    {
        public bool IsAppointmentDateSet;
        
        public AppointmentDate()
        {
            InitializeComponent();
        }

        private void selectSimpleButton_Click(object sender, EventArgs e)
        {
            this.IsAppointmentDateSet = true;
            this.Close();
        }

        private void AppointmentDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }
    }
}