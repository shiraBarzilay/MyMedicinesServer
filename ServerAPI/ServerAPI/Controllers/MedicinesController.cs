using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Text.Json;
using System.IO;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class MedicinesController : ControllerBase
    {
        [HttpGet]
        public List<MedicinesModel> GetMedicines()
        {
            return MedicinesBL.GetMedicines();
        }

        [HttpGet]
        public List<MedicinesModel> GetMedicinesByUser(int userId)
        {
            return MedicinesBL.GetMedicinesByUser(userId);
        }
        [HttpGet]
        public List<MedicinesModel> GetSignedMedicines(int userId)
        {
            return MedicinesBL.GetSignedMedicines(userId);
        }

        [HttpPost]
        public int AddMedicine()
        {
            // saving image
            IFormFile postedFile = HttpContext.Request.Form.Files[0];
            MedicinesBL.SaveFile(postedFile);
            // adding medicine
            var data = HttpContext.Request.Form["medicine"];
            MedicinesModel medicine = JsonSerializer.Deserialize<MedicinesModel>(data);
            return MedicinesBL.AddMedicine(medicine);
        }
    }
}
