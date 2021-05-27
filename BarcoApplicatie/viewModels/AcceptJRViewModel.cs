using BarcoApplication.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarcoApplicatie.viewModels
{
    class AcceptJRViewModel : ViewModelBase
    {
        private BarcoApplicationDataService _dataservice;


        public void RqDate()
        {
            string dateTimeToday = DateTime.Now.ToString("yyyyMMdd");
            //Console.WriteLine(dateTimeString);
            //20210527
        }
        public void JrNumber()
        {
            //counter komt uit database
            int counter = 1;
            //als database leeg is komt counter op 1
            if (counter == 0)
            {
                counter = 1;
            }
            else
            {
                counter++;
            }
            //je counter met automatisch 4 cijfers
            string sCounter = String.Format("{0:D4}", counter);
            //0001
        }
    }
}
