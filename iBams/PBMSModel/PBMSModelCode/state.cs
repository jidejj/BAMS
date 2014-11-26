using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace PBMSModel.PBMS
{

    public partial class state
    {
        public state(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
