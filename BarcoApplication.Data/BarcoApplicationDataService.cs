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
            DateTime? dateEUT1, DateTime? dateEUT2, DateTime? dateEUT3, DateTime? dateEUT4, DateTime? dateEUT5, DateTime? dateEUT6)
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


            //======EUT1======
            Eut eut1 = new Eut();
            eut1.OmschrijvingEut = omschrijving;
            eut1.AvailableDate = dateEUT1;

            eut1.IdRqDetail = requestDetail.IdRqDetail;
            _context.Eut.Add(eut1);
            _context.SaveChanges();

            //======EUT2======
            Eut eut2 = new Eut();
            eut2.OmschrijvingEut = omschrijving;
            eut2.AvailableDate = dateEUT2;

            eut2.IdRqDetail = requestDetail.IdRqDetail;
            _context.Eut.Add(eut2);
            _context.SaveChanges();

            //======EUT3======
            Eut eut3 = new Eut();
            eut3.OmschrijvingEut = omschrijving;
            eut3.AvailableDate = dateEUT3;

            eut3.IdRqDetail = requestDetail.IdRqDetail;
            _context.Eut.Add(eut3);
            _context.SaveChanges();

            //======EUT4======
            Eut eut4 = new Eut();
            eut4.OmschrijvingEut = omschrijving;
            eut4.AvailableDate = dateEUT4;

            eut4.IdRqDetail = requestDetail.IdRqDetail;
            _context.Eut.Add(eut4);
            _context.SaveChanges();

            //======EUT5======
            Eut eut5 = new Eut();
            eut5.OmschrijvingEut = omschrijving;
            eut5.AvailableDate = dateEUT5;

            eut5.IdRqDetail = requestDetail.IdRqDetail;
            _context.Eut.Add(eut5);
            _context.SaveChanges();

            //======EUT6======
            Eut eut6 = new Eut();
            eut6.OmschrijvingEut = omschrijving;
            eut6.AvailableDate = dateEUT6;

            eut6.IdRqDetail = requestDetail.IdRqDetail;
            _context.Eut.Add(eut6);
            _context.SaveChanges();
        }
    }
}
