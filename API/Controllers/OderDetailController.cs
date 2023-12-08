using API.Model;
using API.Repositories;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("/api/OderDetail")]
public class OderDetailController : ControllerBase
{
    public readonly OderDetailService _oderDetailService;

    public OderDetailController(OderDetailService oderDetailService)
    {
        _oderDetailService = oderDetailService;
    }
    [HttpPost ("/ADDOderDetail")]
    public IActionResult ADDOderDetail([FromBody] OderDetailDto oderDetailDto)
    {
        if (ModelState.IsValid)
        {
            _oderDetailService.ADDOderDetail(oderDetailDto);
            return Ok();
        }

        return BadRequest(ModelState);
    }
    [HttpDelete("/DeleteOderDetail")]
    public IActionResult DeleteOderDetail(int id)
    {
        _oderDetailService.DeleteOderDetail(id);
        return Ok("200");
    }
    [HttpPost("{id}")]
    public IActionResult UpdateOderDetail(long PriceTotal, int Quantity,int id)
    {
        _oderDetailService.UpdateOderDetail(PriceTotal,Quantity,id);
        return Ok("200");
    }

    [HttpGet]
    public void getall()
    {
        _oderDetailService.GetlistOderDetail();
    }
    
}