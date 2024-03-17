using BussinessLayer.Interface;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.Service;

namespace DapperCrud.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBl employeedl;

        public EmployeeController(IEmployeeBl employeedl)
        {
            this.employeedl = employeedl;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            try
            {
                var employee = await employeedl.GetEmployees();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeListById(int id)
        {
            try
            {
                var employee = await employeedl.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            try
            {
                var empdeleted =  employeedl.DeleteEmployeeById(id);

                employeedl.DeleteEmployeeById(id);
                    return Ok("Employee deleted successfully.");
                
                
            }
            catch (Exception ex)
            {
                // Log error
                return StatusCode(500, ex.Message);
            }
        }

        //update

        [HttpPut("{empIdUpdate}")]
        public async Task<IActionResult> UpdateEmployee(int empIdUpdate, [FromBody] Employee updateDto)
        {
            try
            {
                await employeedl.UpdateEmployeeBy(empIdUpdate, updateDto.Name, updateDto.Age, updateDto.Position);
                return Ok("Employee updated successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while updating the employee");
            }
        }




    }
}
