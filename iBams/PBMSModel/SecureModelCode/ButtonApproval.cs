using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace PBMSModel.Ibs_Security
{

    public partial class ButtonApproval
    {
        public ButtonApproval(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
