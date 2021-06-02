using System;
using System.Collections.Generic;

namespace BarcoApplication.Data.BibModels
{
    public partial class RqRequest
    {
        public RqRequest()
        {
            PlPlanning = new HashSet<PlPlanning>();
            PlPlanningsKalender = new HashSet<PlPlanningsKalender>();
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

        public virtual ICollection<PlPlanning> PlPlanning { get; set; }
        public virtual ICollection<PlPlanningsKalender> PlPlanningsKalender { get; set; }
        public virtual ICollection<RqOptionel> RqOptionel { get; set; }
        public virtual ICollection<RqRequestDetail> RqRequestDetail { get; set; }

        //Robbe
        //Maak van alles een string, die je dan in de listbox kan toevoegen
        public override string ToString() {

            //zeg hoe lang het max kan zijn
            int maxDivisionLength = 11;
            int maxJobNatureLength = 19;
            int maxEutProjectnameLength = 20;

            //Kijk hoe lang het huidige is
            int divisionLength = BarcoDivision.Length;
            int JobNatureLengt = JobNature.Length;
            int EutProjectnameLength = EutProjectname.Length;

            //Bereken het aantal spaties door het max - het huidige aantal te doen, dan hou je het aantal spaties dat het woord korter is over
            //De laatste getallen zijn spaties om afstand te creeeren tussen de verschillende tabellen
            int spacesToAddDivision = maxDivisionLength - divisionLength + 22;
            int spacesToAddJobNature = maxJobNatureLength - JobNatureLengt + 21;
            int spacesToAddEutProjectname = maxEutProjectnameLength - EutProjectnameLength + 14;

            string resultDivision = BarcoDivision;
            string resultJobNature = JobNature;
            string resultEutProjectname = EutProjectname;

            //een for loop die met een counter zal zorgen dat het aantal spaties zal worden toegevoegd
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

            return resultDivision + resultJobNature  + resultEutProjectname + " " + ExpectedEnddate.ToString().Substring(0, 10); ;
                }
    }
}
