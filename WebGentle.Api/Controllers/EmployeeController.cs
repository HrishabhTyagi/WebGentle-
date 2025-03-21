using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebGentle.Application.Commands;
using WebGentle.Application.Queries;
using WebGentle.Domain.Entities;

namespace WebGentle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var result = await sender.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddEmployee([FromBody]EmployeeEntity employee)
        {
            var result = await sender.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeEntity employee)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(id, employee));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }
    }
}
