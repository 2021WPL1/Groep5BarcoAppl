using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class RqRequest
    {
        public RqRequest()
        {
            RqOptionel = new HashSet<RqOptionel>();
            RqRequestDetail = new HashSet<RqRequestDetail>();
        }

        public int IdRequest { get; set; }
        public string JrNumber { get; set; }
        public DateTime? RequestDate { get; set; }
        public string JrStatus { get; set; }
        public string Requester { get; set; }
        public string BarcoDivision { get; set; }
        public string JobNature { get; set; }
        public string EutProjectname { get; set; }
        public string EutPartnumbers { get; set; }
        public string HydraProjectNr { get; set; }
        public DateTime? ExpectedEnddate { get; set; }
        public bool? InternRequest { get; set; }
        public string GrossWeight { get; set; }
        public string NetWeight { get; set; }
        public bool Battery { get; set; }

        public virtual ICollection<RqOptionel> RqOptionel { get; set; }
        public virtual ICollection<RqRequestDetail> RqRequestDetail { get; set; }

        //lettertype monospaced font

        public override string ToString() {

            int maxDivisionLength = 11;
            int maxJobNatureLength = 19;
            int maxEutProjectnameLength = 20;



            int divisionLength = BarcoDivision.Length;
            int JobNatureLengt = JobNature.Length;
            int EutProjectnameLength = EutProjectname.Length;



            int spacesToAddDivision = maxDivisionLength - divisionLength + 22;
            int spacesToAddJobNature = maxJobNatureLength - JobNatureLengt + 21;
            int spacesToAddEutProjectname = maxEutProjectnameLength - EutProjectnameLength + 5;


            string resultDivision = BarcoDivision;
            string resultJobNature = JobNature;
            string resultEutProjectname = EutProjectname;

            for (int i = 0; i < spacesToAddDivision; i++)
            {
                resultDivision += " ";
            }


            for (int i = 0; i < spacesToAddJobNature; i++)
            {
                resultJobNature += " ";
            }

            for (int i = 0; i < spacesToAddEutProjectname; i++)
            {
                resultEutProjectname += " ";
            }

            return


                resultDivision + resultJobNature  + resultEutProjectname + " " +ExpectedEnddate;
               
                }
    }
}
