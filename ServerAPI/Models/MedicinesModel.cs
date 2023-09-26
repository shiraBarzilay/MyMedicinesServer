using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MedicinesModel
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineDescription { get; set; }
        public string MedicineImage { get; set; }
        public string MedicineEnglishName { get; set; }
        public bool IsExist_ToCurrentUser { get; set; }
    }
}
