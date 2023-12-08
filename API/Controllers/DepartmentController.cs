using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/Department")]
public class DepartmentController : ControllerBase
{
    public readonly DepatmentService _DepatmentService;

    public DepartmentController(DepatmentService depatmentService)
    {
        _DepatmentService = depatmentService;
    }
    
    
    [HttpDelete ("/delete/{id}")]

    public void deleteRoonm([FromQuery] int id) {
        _DepatmentService.deleteDepatment(id);
    }
    
    [HttpGet("/listDepatment")]
    public List<Department> getallDepatment()
    {
      return  _DepatmentService.GetAllProduct();
    }

    [HttpPost("/Depatment")]
    public IActionResult createDepatment([FromBody] Department department)
    {
        return Ok(_DepatmentService.AddDepartment(department));
    }

    [HttpPost("/updateDepatment")]
    public IActionResult UpdateDepatment([FromBody] Department department)
    {
        return Ok(_DepatmentService.UpdateDepartment(department));
    }

    [HttpGet("/getbyId/{id}")]
    public IActionResult getbyId([FromQuery] int id)
    {
        return Ok(_DepatmentService.GetDepartmentById(id));
    }

    

}