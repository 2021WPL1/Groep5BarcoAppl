using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarcoApplicatie.BibModels;

namespace BarcoApplication.Data
{
    public class BarcoApplicationDataService
    {
        private static readonly BarcoApplicationDataService _instance = new BarcoApplicationDataService();
        private Barco2021Context _context;

        public static BarcoApplicationDataService Instance()
        {
            return _instance;
        }

        public BarcoApplicationDataService()
        {
            this._context = new Barco2021Context();
        }

        public List<RqBarcoDivision> getAllDivisions()
        {
            return _context.RqBarcoDivision.ToList();
        }

        public List<RqJobNature> getAllJobNatures()
        {
            return _context.RqJobNature.ToList();
        }

        public List<RqRequest> getAllRequests()
        {
            return _context.RqRequest.ToList();
        }

        public void SendJobRequest(string initials, string projectName, 
            string partNumber, DateTime? date, string grossWeight, string netWeight,
            string division, string jobNature, bool battery, string testdivision, string omschrijving,
            DateTime? dateEUT)
        {
            RqRequest request = new RqRequest();
            request.JrNumber = "0001";
            request.HydraProjectNr = "0001";
            request.Requester = initials;
            request.EutProjectname = projectName;
            request.EutPartnumbers = partNumber;
            request.ExpectedEnddate = date;
            request.InternRequest = false;
            request.GrossWeight = grossWeight;
            request.NetWeight = netWeight;
            request.BarcoDivision = division;
            request.JobNature = jobNature;
            request.Battery = battery;

            _context.RqRequest.Add(request);
            _context.SaveChanges();

            RqRequestDetail requestDetail = new RqRequestDetail();

            requestDetail.IdRequest = request.IdRequest;
            requestDetail.Testdivisie = testdivision;
            _context.RqRequestDetail.Add(requestDetail);
            _context.SaveChanges();

            Eut eut = new Eut();
            eut.OmschrijvingEut = omschrijving;
            eut.AvailableDate = dateEUT;

            eut.IdRqDetail = requestDetail.IdRqDetail;
            _context.Eut.Add(eut);
            _context.SaveChanges();
        }
    }
}
