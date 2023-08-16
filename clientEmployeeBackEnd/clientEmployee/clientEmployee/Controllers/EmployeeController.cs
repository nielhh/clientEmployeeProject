using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skeleton.Models;
using skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skeleton.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _env;

        private readonly IEmployeeRepository _employee;
        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee ??
                throw new ArgumentNullException(nameof(employee));
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employee.GetEmployees());
        }
        [HttpGet]
        [Route("GetEmployeeByID/{Id}")]
        public async Task<IActionResult> GetEmployeeByID(int Id)
        {
            return Ok(await _employee.GetEmployeeByID(Id));
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post(Employee employee)
        {
            if (employee.BirthDate.Year < DateTime.Now.Year - 100) {
                return StatusCode(StatusCodes.Status400BadRequest, "Person can not be older than 150 years old");

            }

            var result = await _employee.InsertEmployee(employee);
            if (result.EmployeeID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put(Employee employee)
        {
            await _employee.UpdateEmployee(employee);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        //[HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _employee.DeleteEmployee(id);
            return new JsonResult("Deleted Successfully");
        }

    }
}
