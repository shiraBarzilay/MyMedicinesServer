using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace BL.Converters
{
    public class MedicinesConverter
    {
        public static MedicinesTbl Map(MedicinesModel medicine)
        {
            return new MedicinesTbl
            {
                MedicineId = medicine.MedicineId,
                MedicineName = medicine.MedicineName,
                MedicineDescription = medicine.MedicineDescription,
                MedicineImage = medicine.MedicineImage,
                MedicineEnglishName = medicine.MedicineEnglishName
            };
        }
        public static MedicinesModel Map(MedicinesTbl medicine)
        {
            return new MedicinesModel
            {
                MedicineId = medicine.MedicineId,
                MedicineName = medicine.MedicineName,
                MedicineDescription = medicine.MedicineDescription,
                MedicineImage = medicine.MedicineImage,
                MedicineEnglishName = medicine.MedicineEnglishName
            };
        }
        public static List<MedicinesModel> Map(List<MedicinesTbl> users)
        {
            return users.Select(u => Map(u)).ToList();
        }
    }
}
