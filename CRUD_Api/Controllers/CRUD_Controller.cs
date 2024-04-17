using CRUD_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CRUD_Controller : ControllerBase
    {
        private readonly ILogger<CRUD_Controller> _logger;

        public CRUD_Controller(ILogger<CRUD_Controller> logger)
        {
            _logger = logger;
        }

        [Route("GetAllRecords")]
        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(JsonConvert.SerializeObject(UserModel.getAllRecords()));
        }

        [Route("InsertRecord")]
        [HttpPost]
        public IActionResult Insert(string name, string email)
        {
            int res = UserModel.InsertRecord(name,email);

            if(res == 0)
            {
                return Ok("Executed : Something Went Wrong . . .");
            }

            return Ok("Executed : Record Inserted Successfully.");
        }

        [Route("UpdateRecord")]
        [HttpPut]
        public IActionResult Update(int id, string name, string email)
        {
            int res = UserModel.UpdateRecord(name, email, id);

            if (res == 0)
            {
                return Ok("Executed : Something Went Wrong . . .");
            }

            return Ok("Executed : Record Updated Successfully.");
        }

        [Route("DeleteRecord")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int res = UserModel.DeleteRecord(id);

            if (res == 0)
            {
                return Ok("Executed : Something Went Wrong . . .");
            }

            return Ok("Executed : Record Deleted Successfully.");
        }
    }
}
