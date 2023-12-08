using API.Data;
using API.Model;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
namespace API.Service;

public class ProductService : ProductRepo
{
    public readonly ApplicationDbContext _DbContext;
    

    public ProductService(ApplicationDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public List<Product> GetAllProduct()
    {
        return _DbContext.Products.ToList();
    }

    public Product GetProductById(int id)
    {
        return _DbContext.Products.Find(id);
    }
    

    public void UpdateProduct(Product product)
    {
        _DbContext.Products.Update(product);
        _DbContext.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = _DbContext.Products.Find(id);
        if (product != null)
        {
            _DbContext.Products.Remove(product);
            _DbContext.SaveChanges();
        }
    }

    public string Saveproduct(string product_name ,double price ,int Quantity, IFormFile imageFile)
    {
        try
        {
            string FileName = imageFile.FileName;
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FileName);
            imageFile.CopyTo(new FileStream(imagePath, FileMode.Create));
            var product = new Product();
            product.product_name = product_name;
            product.Price = price;
            product.Quantity = Quantity;
            product.ImageUrl = FileName;
            _DbContext.Products.Add(product);
            _DbContext.SaveChanges();
            return "luu thanh cong";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<byte[]> getimg(string FileName)
    {
        
        var product = _DbContext.Products.FirstOrDefaultAsync(u => u.ImageUrl == FileName);
        if (product != null)
        {
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FileName);
            byte[] imgbyte = await System.IO.File.ReadAllBytesAsync(imagePath);
            return imgbyte;
        }
        return null;
    }
}