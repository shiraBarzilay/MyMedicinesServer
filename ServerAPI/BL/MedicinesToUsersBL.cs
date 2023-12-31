﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using System.Data.Entity;

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
                    mtu.StartingDate = mtu.StartingDate ?? DateTime.Now;
                    mtu.LastUpdatedDate = mtu.LastUpdatedDate ?? DateTime.Now;
                    mtu.TakingHour = mtu.TakingHour?.AddHours(2);
                    db.MedicinesToUsersTbls.Add(Converters.MedicinesToUsersConverter.Map(mtu));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static List<GetMedicinesToUserModel> GetMedicinesToUser(int userId)
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                List<GetMedicinesToUser> mtus = db.GetMedicinesToUsers.Where(mtu => mtu.UserId == userId).ToList();
                return Converters.GetMedicinesToUser_Converter.Map(mtus);
            }
        }
        public static List<GetRelevantEmailsForReminder> GetEmailsForReminder()
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                DateTime currentDate = DateTime.Now;
                int hourAgo = currentDate.TimeOfDay.Hours + 1;
                // filter the medicines on current date and next hour
                List<GetMedicinesToUser> medicinesOnDate = db.GetMedicinesToUsers.Where(mtu =>
                        DbFunctions.TruncateTime(currentDate) <= DbFunctions.TruncateTime(mtu.LastUpdatedDate)
                        && DbFunctions.TruncateTime(currentDate) >= DbFunctions.TruncateTime(mtu.StartingDate)
                        && mtu.TakingHour.Value.Hours == hourAgo
                    ).ToList();
                // return list of relevant emails
                List<GetRelevantEmailsForReminder> usersToRemind = new List<GetRelevantEmailsForReminder>();
                medicinesOnDate.ForEach((medicine) =>
                {
                    string userEmail = UsersBL.GetUserById(medicine.UserId)?.UserEmail;
                    usersToRemind.Add(new GetRelevantEmailsForReminder(userEmail, medicine.TakingHour, medicine.MedicineName));
                });
                return usersToRemind;
            }
        }

        public static bool UpdateMedicineToUser(int mtuId, short? takingDay = null, TimeSpan? takingHour = null, bool? status = null)
        {
            using (MedicinesAppEntities db = new MedicinesAppEntities())
            {
                try
                {
                    MedicinesToUsersTbl mtu = db.MedicinesToUsersTbls.FirstOrDefault(_mtu => _mtu.Id == mtuId);
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
