using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using DevExpress.Xpo.DB;

namespace PBMSModel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PBMSModel.PBMS.ConnectionHelper.Connect(AutoCreateOption.DatabaseAndSchema);
            PBMSModel.Ibs_Security.ConnectionHelper.Connect(AutoCreateOption.DatabaseAndSchema);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
           // Application.Run(new Form1());
        }
    }
}
