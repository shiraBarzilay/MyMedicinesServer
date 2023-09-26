using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Data;
using Microsoft.AspNetCore.Http;
using Models;

namespace BL
{
    public class MedicinesBL
    {
        public static List<MedicinesModel> GetMedicines()
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                List<MedicinesTbl> medicines = db.MedicinesTbls.ToList();
                return Converters.MedicinesConverter.Map(medicines);
            }
        }
        public static List<MedicinesModel> GetMedicinesByUser(int userId)
        {
            using (MedicinesAppEntities dbn = new MedicinesAppEntities())
            {
                List<int> medicinesIds = dbn.MedicinesToUsersTbls.Where(mtu => mtu.UserId == userId && mtu.Status == true)
                    .Select(mtu => mtu.MedicineId).ToList();
                List<MedicinesTbl> medicines = new List<MedicinesTbl>();
                medicinesIds.ForEach((medicineId) =>
                {
                    MedicinesTbl medicine = dbn.MedicinesTbls.Where(m => m.MedicineId == medicineId).FirstOrDefault();
                    if (medicine != null)
                    {
                        medicines.Add(medicine);
                    }
                });
                return Converters.MedicinesConverter.Map(medicines);
            }
        }
        public static List<MedicinesModel> GetSignedMedicines(int userId)
        {
            List<MedicinesModel> allMedicines = GetMedicines();
            List<MedicinesModel> medicinesOf_CurrentUser = GetMedicinesByUser(userId);
            medicinesOf_CurrentUser.ForEach((medicine) => {
                allMedicines.Where(m => m.MedicineId == medicine.MedicineId).FirstOrDefault().IsExist_ToCurrentUser = true;
            });
            return allMedicines;
        }
        public static int AddMedicine(MedicinesModel medicine)
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                try
                {
                    MedicinesTbl newMedicine = db.MedicinesTbls.Add(Converters.MedicinesConverter.Map(medicine));
                    db.SaveChanges();
                    return newMedicine.MedicineId;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public async static void SaveFile(IFormFile postedFile)
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0,
                    AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("Server") - 1) + 
                    "\\Data\\src\\images\\" + postedFile.FileName;
                if (postedFile.Length > 0)
                {
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await postedFile.CopyToAsync(fileStream);
                    }
                }
        }
    }
}
