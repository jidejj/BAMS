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

    public partial class PasswordLogs : XPLiteObject
    {
        long fID_PasswordLogs;
        [Key(true)]
        public long ID_PasswordLogs
        {
            get { return fID_PasswordLogs; }
            set { SetPropertyValue<long>("ID_PasswordLogs", ref fID_PasswordLogs, value); }
        }
        string fID_Login;
        [Size(90)]
        public string ID_Login
        {
            get { return fID_Login; }
            set { SetPropertyValue<string>("ID_Login", ref fID_Login, value); }
        }
        string fPassword;
        [Size(700)]
        public string Password
        {
            get { return fPassword; }
            set { SetPropertyValue<string>("Password", ref fPassword, value); }
        }
        DateTime fTransDate;
        public DateTime TransDate
        {
            get { return fTransDate; }
            set { SetPropertyValue<DateTime>("TransDate", ref fTransDate, value); }
        }
        DateTime fExpiryDate;
        public DateTime ExpiryDate
        {
            get { return fExpiryDate; }
            set { SetPropertyValue<DateTime>("ExpiryDate", ref fExpiryDate, value); }
        }
        string fMachineName;
        [Size(7000)]
        public string MachineName
        {
            get { return fMachineName; }
            set { SetPropertyValue<string>("MachineName", ref fMachineName, value); }
        }
    }

}