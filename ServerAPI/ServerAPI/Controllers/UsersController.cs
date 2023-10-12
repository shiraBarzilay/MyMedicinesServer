using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Models;
using BL;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public UsersModel SignUp([FromBody] UsersModel user)
        {
            return UsersBL.SignUp(user);
        }

        [HttpGet]
        public UsersModel Login(string userEmail, string userPassword)
        {
            return UsersBL.Login(userEmail, userPassword);
        }

        [HttpPost]
        public bool AddExistingMedicineToUser([FromBody] MedicinesToUsersModel mtu)
        {
            // add existing medicine to user
            return MedicinesToUsersBL.AddExistingMedicineToUser(mtu);
        }

        [HttpPut]
        public bool UpdatePasswordToUser(int userId, string password)
        {
            return UsersBL.UpdatePasswordToUser(userId, password);
        }

        [HttpPost]
        public bool AddNewMedicineToUser(MedicinesToUsersModel mtu, string medicineName)
        {
            // adding medicine
            MedicinesModel medicine = new MedicinesModel();
            medicine.MedicineName = medicineName;
            mtu.MedicineId = MedicinesBL.AddMedicine(medicine);

            // add new-medicine to user
            return MedicinesToUsersBL.AddExistingMedicineToUser(mtu);
        }

        [HttpPut]
        public bool UpdateMedicineToUser(int mtuId, short? takingDay = null, TimeSpan? takingHour = null, bool? status = null)
        {
            return MedicinesToUsersBL.UpdateMedicineToUser(mtuId, takingDay, takingHour, status);
        }

        [HttpGet]
        public List<GetMedicinesToUserModel> GetMedicinesToUser(int userId)
        {
            return MedicinesToUsersBL.GetMedicinesToUser(userId);
        }
    }
}
