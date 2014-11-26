using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace PBMSModel.PBMS
{

    public partial class RSAMaster
    {
        public RSAMaster(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
