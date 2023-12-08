using API.Data;
using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    public readonly ProductService _ProductService;

    public ProductController(ProductService productService)
    {
        _ProductService = productService;
    }
   
    [HttpPost("/saveproduct")]
    public IActionResult SaveProduct(string product_name ,double Price ,int Quantity, IFormFile imageFile)
    {
        try
        {
            // Gọi phương thức Saveproduct để lưu sản phẩm và hình ảnh
            var result = _ProductService.Saveproduct(product_name,Price,Quantity, imageFile);

            // Nếu kết quả trả về là thành công, trả về mã thành công 200
            if (result == "luu thanh cong")
            {
                return Ok("Lưu sản phẩm thành công!");
            }
            else
            {
                // Nếu có lỗi, trả về mã lỗi 400 và thông báo lỗi
                return BadRequest(result);
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Lỗi khi lưu sản phẩm: {ex.Message}");
        }
    }

    [HttpGet("{FileName}")]
    public async Task<FileContentResult> GetImage (string FileName)
    {
        var product = await _ProductService.getimg(FileName);
        if (product != null)
        {
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FileName);
            byte[] imgbyte = await System.IO.File.ReadAllBytesAsync(imagePath);
            return File(imgbyte, "image/jpeg");
            
        }
        else
        {
            return null;
        }
    }
}