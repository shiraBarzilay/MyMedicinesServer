//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class GetMedicinesToUser
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
