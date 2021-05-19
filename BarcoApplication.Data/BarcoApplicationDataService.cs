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

        public RqRequest SendJobRequest(string initials, string projectName, 
            string partNumber, DateTime? date, string grossWeight, string netWeight)
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
            request.BarcoDivision = "testDiv";
            request.JobNature = "testNature";

            _context.RqRequest.Add(request);
            _context.SaveChanges();

            return request;
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }
    }
}
