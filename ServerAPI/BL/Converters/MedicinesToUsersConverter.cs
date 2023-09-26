using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace BL.Converters
{
    public class MedicinesToUsersConverter
    {
        public static MedicinesToUsersTbl Map(MedicinesToUsersModel mtu)
        {
            return new MedicinesToUsersTbl
            {
                Id = mtu.Id,
                UserId = mtu.UserId,
                MedicineId = mtu.MedicineId,
                Status = mtu.Status,
                TakingDay = mtu.TakingDay,
                TakingHour = mtu.TakingHour,
                StartingDate = mtu.StartingDate,
                LastUpdatedDate = mtu.LastUpdatedDate
            };
        }
    }
}
