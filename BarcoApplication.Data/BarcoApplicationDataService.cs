using System;
using System.Collections.Generic;
using System.Linq;
using BarcoApplication.Data.BibModels;

namespace BarcoApplication.Data
{

    /// <summary>
    /// KOEN
    /// </summary>
    public class BarcoApplicationDataService
    {
        private static readonly BarcoApplicationDataService _instance = new BarcoApplicationDataService();

        private Barco2021Context _context;

        public static BarcoApplicationDataService Instance()
        {
            return _instance;
        }

        private BarcoApplicationDataService()
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

        public RqRequest getRequestWithId(int id)
        {
            return _context.RqRequest.FirstOrDefault(r => r.IdRequest == id);
        }

        public RqRequestDetail getRequestDetailWithId(int id)
        {
            return _context.RqRequestDetail.FirstOrDefault(r => r.IdRequest == id);
        }

        public RqOptionel GetOptionelWithId(int id)
        {
            return _context.RqOptionel.FirstOrDefault(r => r.IdRequest == id);
        }

        public Eut GetEUTWithId(int id)
        {
            return _context.Eut.FirstOrDefault(r => r.IdRqDetail == id);
        }

        public void removeJobRequest(int requestId, int detailsId)
        {
            _context.RqOptionel.Remove(GetOptionelWithId(requestId));
            _context.Eut.Remove(GetEUTWithId(detailsId));
            _context.RqRequestDetail.Remove(getRequestDetailWithId(requestId));
            _context.RqRequest.Remove(getRequestWithId(requestId));
            
            _context.SaveChanges();
        }

        public RqOptionel GetOptionals(int id)
        {
            return _context.RqOptionel.FirstOrDefault(r => r.IdRequest == id);
        }

        public Eut GetEuts(int id)
        {
            return _context.Eut.FirstOrDefault(e => e.IdRqDetail == id);
        }

        public RqRequestDetail GetRequestDetail(int id)
        {
            return _context.RqRequestDetail.FirstOrDefault(r => r.IdRequest == id);
        }

        public int getJrNumber()
        {
            int jrNumber = int.Parse(_context.RqRequest.Max(p => p.JrNumber));
            return jrNumber;
        }

        public RqRequest AddRequest(RqRequest request, string initials, string projectName, string HydraProjectNr,
            string partNumber, DateTime? date, string grossWeight, string netWeight,
            string division, string jobNature, bool battery)
        {
            request.JrNumber = (getJrNumber() + 1).ToString();
            request.HydraProjectNr = HydraProjectNr;
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

            return request;
        }

        public RqOptionel AddOptionel(RqOptionel optional, RqRequest request, string link, string remarks)
        {
            optional.IdRequest = request.IdRequest;
            optional.Link = link;
            optional.Remarks = remarks;
            request.RqOptionel.Add(optional);

            return optional;
        }

        public RqRequestDetail AddDetail(RqRequestDetail requestDetail, RqRequest request, string testdivision)
        {
            requestDetail.IdRequest = request.IdRequest;
            requestDetail.Testdivisie = testdivision;
            request.RqRequestDetail.Add(requestDetail);
            _context.RqRequest.Add(request);

            return requestDetail;
        }

        public Eut AddEut(Eut eut, RqRequestDetail requestDetail, string omschrijving, DateTime dateEUT)
        {
            eut.IdRqDetail = requestDetail.IdRqDetail;
            eut.OmschrijvingEut = omschrijving;
            eut.AvailableDate = dateEUT;
            requestDetail.Eut.Add(eut);

            return eut;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
