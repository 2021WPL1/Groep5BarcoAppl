using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;

namespace BarcoApplicatie
{
    class Email
    {
        public void SendEmail()
        {
            try
            {
                // set smtp-client with basicAuthentication
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 465))
                {
                    // add from,to mailaddresses
                    MailAddress from = new MailAddress("testvivesnikki@gmail.com");
                    MailAddress to = new MailAddress("r0850378@student.vives.be");

                    MailMessage mail = new MailMessage(from, to);
                    // set subject & body
                    mail.Subject = "Titel";
                    mail.Body = "random info";

                    //smtpClient
                    client.Port = 465;
                    client.EnableSsl = true; //ssl = 465, tls = 465
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("testvivesnikki@gmail.com", "Wachtwoord1&");

                    client.Send(mail);
                    MessageBox.Show("email was sended!");
                };
            }

            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        } 
    }
}
