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

    public partial class ControlResources : XPLiteObject
    {
        int fID_ControlResources;
        [Key(true)]
        public int ID_ControlResources
        {
            get { return fID_ControlResources; }
            set { SetPropertyValue<int>("ID_ControlResources", ref fID_ControlResources, value); }
        }
        string fID_Application;
        [Size(50)]
        public string ID_Application
        {
            get { return fID_Application; }
            set { SetPropertyValue<string>("ID_Application", ref fID_Application, value); }
        }
        string fGroupName;
        public string GroupName
        {
            get { return fGroupName; }
            set { SetPropertyValue<string>("GroupName", ref fGroupName, value); }
        }
        string fViewName;
        public string ViewName
        {
            get { return fViewName; }
            set { SetPropertyValue<string>("ViewName", ref fViewName, value); }
        }
        string fControlName;
        public string ControlName
        {
            get { return fControlName; }
            set { SetPropertyValue<string>("ControlName", ref fControlName, value); }
        }
        string fControlComment;
        public string ControlComment
        {
            get { return fControlComment; }
            set { SetPropertyValue<string>("ControlComment", ref fControlComment, value); }
        }
        string fControlDescription;
        [Size(200)]
        public string ControlDescription
        {
            get { return fControlDescription; }
            set { SetPropertyValue<string>("ControlDescription", ref fControlDescription, value); }
        }
    }

}
