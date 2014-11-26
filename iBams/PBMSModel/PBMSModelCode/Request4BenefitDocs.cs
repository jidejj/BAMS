using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace PBMSModel.PBMS
{

    public partial class Request4BenefitDocs
    {
        public Request4BenefitDocs(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
