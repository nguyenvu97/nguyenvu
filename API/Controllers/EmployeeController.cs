using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/staff")]
public class EmployeeController : ControllerBase
{
    
    public readonly EmployeeService EmployeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        EmployeeService = employeeService;
    }
    [HttpPost("/carate")]
    public IActionResult createStaff(Employee employee)
    {
        return Ok(EmployeeService.AddStadd(employee));
    }
}