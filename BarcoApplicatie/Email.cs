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

        public void ActivateEmail()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DateTime emailSendTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 10, 0, 0); //18pm,0min,0sec,0
                                                                                                                          //tryout if it works
            if (emailSendTime > DateTime.Now)
            {
                MessageBox.Show("To early");
            }

            if (emailSendTime < DateTime.Now)
            {
                MessageBox.Show("To late");
            }

            if (emailSendTime == DateTime.Now)
            {
                List<RqRequest> listAllRequests = _dataService.getAllRequests ();
                if (listAllRequests == null)
                {
                    MessageBox.Show("email sended!");
                    //SendMail();
                }
                else
                {
                    MessageBox.Show("no email sended");
                }
            }

        }

        //initialise for SendMail
        private static string mailFrom = "Groep3testprog@gmail.com";
        private static string mailFromPassword = "Testtest123";

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
