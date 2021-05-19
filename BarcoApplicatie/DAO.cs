using BarcoApplicatie.BibModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace BarcoApplicatie
{

    //===========  Koen =============
    class DAO
    {

        private static readonly DAO instance = new DAO();

        public static DAO Instance()
        {
            return instance;
        }

        private DAO()
        {
            this.context = new Barco2021Context();
        }

        private Barco2021Context context;

        public List<RqRequest> getAllRequests()
        {
            return context.RqRequest.ToList();
        }

        public void saveChanges()
        {
            context.SaveChanges();
        }

        public RqRequest getRequestWithId(int id)
        {
            return context.RqRequest.FirstOrDefault(r => r.IdRequest == id);
        }

        public void removeJobRequest(int id)
        {
            context.RqRequest.Remove(getRequestWithId(id));
            saveChanges();
        }


        public void addTestDivision(string testDivision)
        {
            RqRequestDetail requestDetail = new RqRequestDetail();
            requestDetail.Testdivisie = testDivision;

            context.RqRequestDetail.Add(requestDetail);
            context.SaveChanges();
        }
    }
}
