using BarcoApplicatie.BibModels;
using BarcoApplicatie.viewModels;
using BarcoApplication.Data;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BarcoApplicatie
{
    //Nikki
    class Email
    {
        private BarcoApplicationDataService _dataService;

        //initialise for SendMail
        private static string mailFrom = "Groep3testprog@gmail.com";
        private static string mailFromPassword = "Testtest123";


        public void ActivateEmail()
        {
            _dataService = BarcoApplicationDataService.Instance();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        //tijdelijk
        void timer_Tick(object sender, EventArgs e)
        {
            //Date kan aangepast worden naar keuze
            DateTime emailSendTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 28, 0); //18pm,0min,0sec
            DateTime dateNow = DateTime.Now;

            //List<RqRequest> listAllRequests = _dataService.getAllRequests();
            //if (listAllRequests != null)
            //{

            if (dateNow.DayOfWeek != DayOfWeek.Saturday || dateNow.DayOfWeek != DayOfWeek.Sunday)
            {
                if (emailSendTime.Hour == dateNow.Hour && emailSendTime.Minute == dateNow.Minute)
                {
                    SendMail();
                }
            }
            
            //}
        }

        public void SendMail()
        {
            List<RqRequest> listAllRequests = _dataService.getAllRequests();

            //setup smtp & mail 
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                try
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(mailFrom, mailFromPassword);

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(mailFrom);
                    mail.To.Add("nikki.noppe@student.vives.be");

                    //needs to be updated with info!
                    mail.Subject = "testtesttes";
                    mail.Body = "Dit is een automatische mail" + listAllRequests;

                    client.Send(mail);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
