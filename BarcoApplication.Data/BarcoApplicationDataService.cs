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

        public void removeJobRequest(int id)
        {
            _context.RqRequest.Remove(getRequestWithId(id));
            _context.SaveChanges();
        }

        public RqRequest AddRequest(RqRequest request, string initials, string projectName,
            string partNumber, DateTime? date, string grossWeight, string netWeight,
            string division, string jobNature, bool battery)
        {
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

            return request;
        }

        public RqOptionel AddOptionel(RqOptionel optional, RqRequest request, string link, string remarks)
        {
            optional.IdRequest = request.IdRequest;
            optional.Link = link;
            optional.Remarks = remarks;
            _context.RqOptionel.Add(optional);
            _context.SaveChanges();

            return optional;
        }

        public RqRequestDetail AddDetail(RqRequestDetail requestDetail, RqRequest request, string testdivision)
        {
            requestDetail.IdRequest = request.IdRequest;
            requestDetail.Testdivisie = testdivision;
            _context.RqRequestDetail.Add(requestDetail);

            _context.SaveChanges();

            return requestDetail;
        }

        public Eut AddEut(Eut eut, RqRequestDetail requestDetail, string omschrijving, DateTime dateEUT)
        {
            eut.IdRqDetail = requestDetail.IdRqDetail;
            eut.OmschrijvingEut = omschrijving;
            eut.AvailableDate = dateEUT;
            _context.Eut.Add(eut);
            _context.SaveChanges();
            return eut;
        }
    }
}
