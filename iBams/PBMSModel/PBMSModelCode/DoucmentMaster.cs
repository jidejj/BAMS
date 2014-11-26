using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace PBMSModel.PBMS
{

    public partial class DoucmentMaster
    {
        public DoucmentMaster(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
