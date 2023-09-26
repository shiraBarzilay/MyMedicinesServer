using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data;

namespace BL.Converters
{
    public class GetRelevantEmailsForReminder_Converter
    {
        public static GetRelevantEmailsForReminder_Model Map(GetRelevantEmailsForReminder reminder)
        {
            return new GetRelevantEmailsForReminder_Model
            {
                UserEmail = reminder.UserEmail,
                MedicineName = reminder.MedicineName,
                TakingHour = reminder.TakingHour
            };
        }
        public static List<GetRelevantEmailsForReminder_Model> Map(List<GetRelevantEmailsForReminder> reminders)
        {
            return reminders.Select(r => Map(r)).ToList();
        }
    }
}
