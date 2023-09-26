using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace BL
{
    public class MedicinesToUsersBL
    {
        public static bool AddExistingMedicineToUser(MedicinesToUsersModel mtu)
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                try
                {
                    mtu.Status = true;
                    mtu.StartingDate = DateTime.Now;
                    mtu.LastUpdatedDate = DateTime.Now;
                    db.MedicinesToUsersTbls.Add(Converters.MedicinesToUsersConverter.Map(mtu));
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool UpdateMedicineToUser(int userId, int medicineId, short? takingDay = null, TimeSpan? takingHour = null, bool? status = null)
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                try
                {
                    MedicinesToUsersTbl mtu = db.MedicinesToUsersTbls.FirstOrDefault(_mtu => _mtu.UserId == userId && _mtu.MedicineId == medicineId);
                    if (mtu != null)
                    {
                        if (takingDay != null)
                        {
                            mtu.TakingDay = takingDay;
                        }
                        if (takingHour != null)
                        {
                            mtu.TakingHour = takingHour;
                        }
                        if (status != null)
                        {
                            mtu.Status = status;
                        }
                        mtu.LastUpdatedDate = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
