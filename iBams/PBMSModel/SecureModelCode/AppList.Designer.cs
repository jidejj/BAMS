//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace PBMSModel.Ibs_Security
{

    public partial class AppList : XPLiteObject
    {
        string fID_App;
        [Key]
        [Size(50)]
        public string ID_App
        {
            get { return fID_App; }
            set { SetPropertyValue<string>("ID_App", ref fID_App, value); }
        }
        string fName;
        [Size(50)]
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>("Name", ref fName, value); }
        }
        string fPath;
        [Size(50)]
        public string Path
        {
            get { return fPath; }
            set { SetPropertyValue<string>("Path", ref fPath, value); }
        }
    }

}