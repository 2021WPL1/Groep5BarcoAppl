using System;
using System.Collections.Generic;
using System.Linq;
using BarcoApplicatie.BibModelsNew;

namespace BarcoApplication.Data
{
    public class BarcoApplicationDataService
    {
        private static readonly BarcoApplicationDataService _instance = new BarcoApplicationDataService();

        private BarcoDBContext _context;

        public static BarcoApplicationDataService Instance()
        {
            return _instance;
        }

        private BarcoApplicationDataService()
        {
            this._context = new BarcoDBContext();
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

        public RqRequest getRequestWithId(int id)
        {
            return _context.RqRequest.FirstOrDefault(r => r.IdRequest == id);
        }

        public void removeJobRequest(int id)
        {
            _context.RqRequest.Remove(getRequestWithId(id));
            _context.SaveChanges();
        }

        public void SendJobRequest(string initials, string projectName,
            string partNumber, DateTime? date, string grossWeight, string netWeight,
            string division, string jobNature, bool battery, string testdivision, string omschrijving,
            DateTime? dateEUT, string link, string remarks)
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

            RqTestDevision testDevision = new RqTestDevision();
            testDevision.Afkorting = testdivision;
            _context.RqTestDevision.Add(testDevision);
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

            RqOptionel optional = new RqOptionel();
            optional.IdRequest = request.IdRequest;
            optional.Link = link;
            optional.Remarks = remarks;
            _context.RqOptionel.Add(optional);
            _context.SaveChanges();



        }

        //public void AddJobRequest(string initials, string projectName,
        //    string partNumber, DateTime? date, string grossWeight, string netWeight,
        //    string division, string jobNature, bool battery)
        //{
        //    RqRequest request = new RqRequest();
        //    request.JrNumber = "0001";
        //    request.HydraProjectNr = "0001";
        //    request.Requester = initials;
        //    request.EutProjectname = projectName;
        //    request.EutPartnumbers = partNumber;
        //    request.ExpectedEnddate = date;
        //    request.InternRequest = false;
        //    request.GrossWeight = grossWeight;
        //    request.NetWeight = netWeight;
        //    request.BarcoDivision = division;
        //    request.JobNature = jobNature;
        //    request.Battery = battery;

        //    _context.RqRequest.Add(request);
        //    _context.SaveChanges();

        //}

        //public void AddRequest(RqRequestDetail requestDetail, RqRequest request, string testdivision)
        //{
        //    requestDetail = new RqRequestDetail();

        //    requestDetail.IdRequest = request.IdRequest;
        //    requestDetail.Testdivisie = testdivision;
        //    _context.RqRequestDetail.Add(requestDetail);
        //    _context.SaveChanges();

        //}

        //public void AddEUT(RqRequestDetail requestDetail, string omschrijving, DateTime dateEUT)
        //{
        //    Eut eut = new Eut();
        //    eut.OmschrijvingEut = omschrijving;
        //    eut.AvailableDate = dateEUT;

        //    eut.IdRqDetail = requestDetail.IdRqDetail;
        //    _context.Eut.Add(eut);
        //    _context.SaveChanges();
        //}

        //public void AddOptional(RqRequest request, string link, string remarks)
        //{
        //    RqOptionel optional = new RqOptionel();
        //    optional.IdRequest = request.IdRequest;
        //    optional.Link = link;
        //    optional.Remarks = remarks;
        //    _context.RqOptionel.Add(optional);
        //    _context.SaveChanges();
        //}

    }
}
