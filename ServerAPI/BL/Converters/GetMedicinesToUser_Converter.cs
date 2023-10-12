using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data;

namespace BL.Converters
{
    class GetMedicinesToUser_Converter
    {
        public static GetMedicinesToUserModel Map(GetMedicinesToUser mtu)
        {
            return new GetMedicinesToUserModel
            {
                Id = mtu.Id,
                UserId = mtu.UserId,
                MedicineId = mtu.MedicineId,
                Status = mtu.Status,
                TakingDay = mtu.TakingDay,
                TakingHour = mtu.TakingHour,
                StartingDate = mtu.StartingDate,
                LastUpdatedDate = mtu.LastUpdatedDate,
                MedicineName = mtu.MedicineName,
                MedicineDescription = mtu.MedicineDescription,
                MedicineImage = mtu.MedicineImage,
                MedicineEnglishName = mtu.MedicineEnglishName
            };
        }
        public static List<GetMedicinesToUserModel> Map(List<GetMedicinesToUser> mtus)
        {
            return mtus.Select(mtu => Map(mtu)).ToList();
        }
    }
}
