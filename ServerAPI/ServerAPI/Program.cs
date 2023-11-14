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
using Data;

namespace ServerAPI
{
    public class Program
    {
        static Timer aTimer = new System.Timers.Timer(60 * 60 * 1000);
        static int lastHour = DateTime.Now.Hour;

        public static void Main(string[] args)
        {
            // Execute the logic immediately when the server starts
            OnTimedEvent(null, null);

            // Start the timer to repeat every 1 hour
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 60 * 60 * 1000; // Set the interval to 1 hour
            aTimer.Start();

            CreateHostBuilder(args).Build().Run();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            List<GetRelevantEmailsForReminder> relevantEmails = MedicinesToUsersBL.GetEmailsForReminder();
            EmailManager em = new EmailManager();
            relevantEmails.ForEach(relevantEmail =>
            {
                em.SendEmail(relevantEmail.UserEmail, relevantEmail.MedicineName, relevantEmail.TakingHour);
            });
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
