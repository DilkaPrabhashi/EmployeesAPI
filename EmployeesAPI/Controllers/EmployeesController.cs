using EmployeesAPI.Data;
using EmployeesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeesAPIDbContext dbContext;

        public EmployeesController(EmployeesAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await dbContext.EmployeesTb.ToListAsync());
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await dbContext.EmployeesTb.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            var employee = new Employees()
            {
                Id = Guid.NewGuid(),
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                Address = addEmployeeRequest.Address,
                Phone = addEmployeeRequest.Phone,

            };

            await dbContext.EmployeesTb.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployees([FromRoute] Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = await dbContext.EmployeesTb.FindAsync(id);

            if(employee != null)
            {
                employee.FirstName = updateEmployeeRequest.FirstName;
                employee.LastName = updateEmployeeRequest.LastName;
                employee.Address = updateEmployeeRequest.Address;
                employee.Phone = updateEmployeeRequest.Phone;

                await dbContext.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await dbContext.EmployeesTb.FindAsync(id);

            if(employee != null)
            {
                dbContext.Remove(employee);
                await dbContext.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound();
        }

    }
}
