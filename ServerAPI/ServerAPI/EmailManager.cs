using MailKit.Net.Smtp;
using MimeKit;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServerAPI
{
    public class EmailManager
    {
        //private readonly IEmailService _emailService;
        //public EmailManager(IEmailService emailService)
        //{
        //    _emailService = emailService;
        //}
        public void SendEmail(string toEmail, string medicineName, TimeSpan? hour)
        {
            string to = toEmail; //To address    
            string from = "MyMedicines2023@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "שלום, השעה: " + hour + ". הגיע הזמן לקחת " + medicineName + "! יום טוב:)";
            message.Subject = "מזכירים לך 🖐";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
           

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            // System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("bsd.odaya@gmail.com", "PM+bsdO100%");
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("MyMedicines2023@gmail.com", "gire ojse zyfv wkmu" );
            client.UseDefaultCredentials = false;
            //client.Credentials = basicCredential1;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                //todo: איך לדווח על שגיאה ???
                return;
            }
        }
    }
}
