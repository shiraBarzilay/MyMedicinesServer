using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GetMedicinesToUserModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.TimeSpan> TakingHour { get; set; }
        public Nullable<short> TakingDay { get; set; }
        public Nullable<System.DateTime> StartingDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string MedicineName { get; set; }
        public string MedicineDescription { get; set; }
        public string MedicineImage { get; set; }
        public string MedicineEnglishName { get; set; }
    }
}
