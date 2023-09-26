using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GetRelevantEmailsForReminder_Model
    {
        public string UserEmail { get; set; }
        public Nullable<System.TimeSpan> TakingHour { get; set; }
        public string MedicineName { get; set; }
    }
}
