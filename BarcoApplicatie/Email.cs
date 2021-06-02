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

    class Email
    {
        private BarcoApplicationDataService _dataService;

        //Nikki
        public void ActivateEmail()
        {
            _dataService = BarcoApplicationDataService.Instance();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        //Nikki
        void timer_Tick(object sender, EventArgs e)
        {
            //Date kan aangepast worden naar keuze
            DateTime emailSendTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 28, 0); //18pm,0min,0sec
            DateTime dateNow = DateTime.Now;

            //geen mail op zaterdag & zondag
            if (dateNow.DayOfWeek != DayOfWeek.Saturday || dateNow.DayOfWeek != DayOfWeek.Sunday)
            {
                if (emailSendTime.Hour == dateNow.Hour && emailSendTime.Minute == dateNow.Minute)
                {
                    SendMail();
                }
            }    

        }

        //initialise for SendMail
        private static string mailFrom = "Groep3testprog@gmail.com";
        private static string mailFromPassword = "Testtest123";

        //Nikki
        public void SendMail()
        {
            //setup smtp & mail 
            using SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
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
                mail.Body = "Dit is een automatische mail";

                client.Send(mail);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
