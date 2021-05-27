using System;
using System.Collections.Generic;

namespace BarcoApplication.Data.BibModels
{
    public partial class RqTestDevision
    {
        public RqTestDevision()
        {
            PlResourcesDivision = new HashSet<PlResourcesDivision>();
            RqRequestDetail = new HashSet<RqRequestDetail>();
        }

        public string Afkorting { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<PlResourcesDivision> PlResourcesDivision { get; set; }
        public virtual ICollection<RqRequestDetail> RqRequestDetail { get; set; }
    }
}
