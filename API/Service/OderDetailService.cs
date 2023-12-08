using API.Data;
using API.Model;
using API.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Service;

public class OderDetailService : OderDetailDTO

{
    public readonly ApplicationDbContext _DbContext;

    public OderDetailService(ApplicationDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public List<OderDetail> GetlistOderDetail()
    {
        return _DbContext.OderDetails.ToList();
    }

    public OderDetail GetOderDetailById(int id)
    {
        return _DbContext.OderDetails.Find(id);
    }

   

    public void ADDOderDetail(OderDetailDto oderDetailDto)
    {
        var orderDetail = new OderDetail
        {
            PriceTotal = oderDetailDto.PriceTotal,
            Quantity = oderDetailDto.Quantity,
            Products = new List<Product>()
        };

        foreach (var product1 in oderDetailDto.ProductIds)
        {
            var product = _DbContext.Products.FirstOrDefault(u => u.ProductId == product1);
            if (product != null)
            {
                orderDetail.Products.Add(product);
              
            }
        }

        _DbContext.OderDetails.Add(orderDetail);
        _DbContext.SaveChanges();
    }

    public void UpdateOderDetail(long PriceTotal, int Quantity ,int id)
    {
        var oderDetail = _DbContext.OderDetails.FirstOrDefault(u => u.id == id);
        if (oderDetail != null)
        {
            oderDetail.PriceTotal = PriceTotal;
            oderDetail.Quantity = Quantity;

            _DbContext.Update(oderDetail);
            _DbContext.SaveChanges();
        }

    }

    public void DeleteOderDetail(int id)
    {
        var order = _DbContext.OderDetails.FirstOrDefault(u => u.id == id);
        if (order != null)
        {
            _DbContext.OderDetails.Remove(order);
            _DbContext.SaveChanges();
        }
    }
}