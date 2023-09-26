using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Models;
using BL;

namespace ServerAPI
{
    public class Program
    {
            static Timer aTimer = new System.Timers.Timer(20000);
            static int lastHour = DateTime.Now.Hour;

        public static void Main(string[] args)
        {
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Start();

            CreateHostBuilder(args).Build().Run();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (lastHour < DateTime.Now.Hour || (lastHour == 23 && DateTime.Now.Hour == 0))
            {
                lastHour = DateTime.Now.Hour;

                List<GetRelevantEmailsForReminder_Model> relevantEmails = UsersBL.GetRelevantEmailsRorReminder();
                EmailManager em = new EmailManager();
                relevantEmails.ForEach(relevantEmail =>
                {
                    em.SendEmail(relevantEmail.UserEmail, relevantEmail.MedicineName, relevantEmail.TakingHour);
                });
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
