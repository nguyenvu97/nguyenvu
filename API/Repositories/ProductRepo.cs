using API.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Repositories;

public interface ProductRepo
{
    List<Product> GetAllProduct();
    Product GetProductById(int id);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}