using MailKit.Net.Smtp;
using MimeKit;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var subject = "ברוכים הבאים לאפליקציה המגניבה 🖐";
            //var message = $@"<h3>הי, {toName}</h3> 
            //    <p>תודה שהצטרפת אלינו 🤗</p>
            //    <p>להתראות!</p>";
            //_emailService.Send(toEmail, subject, message, true);


            //var email = new MimeMessage();

            //email.From.Add(new MailboxAddress("Sender Name", "sender@email.com"));
            //email.To.Add(new MailboxAddress("Receiver Name", toEmail));

            //email.Subject = "ברוכים הבאים לאפליקציה המגניבה 🖐";
            //email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            //{
            //    Text = $@"<h3>הי, {toName}</h3> 
            //        <p>תודה שהצטרפת אלינו 🤗</p>
            //        <p>להתראות!</p>"
            //};
            //using (var smtp = new SmtpClient())
            //{
            //    smtp.Connect("smtp.server.address", 587, false);

            //    // Note: only needed if the SMTP server requires authentication
            //    smtp.Authenticate("smtp_username", "smtp_password");

            //    smtp.Send(email);
            //    smtp.Disconnect(true);
            //}

            string to = toEmail; //To address    
            string from = "bsd.odaya@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "שלום, השעה: " + hour + ". הגיע הזמן לקחת " + medicineName + "! יום טוב:)";
            message.Subject = "מזכירים לך 🖐";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("bsd.odaya@gmail.com", "PM+bsdO100%");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                return;
            }
        }
    }
}
