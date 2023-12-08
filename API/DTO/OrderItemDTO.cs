namespace API.Model;

public class OrderItemDTO
{
    public List<Product> Item { get; set; } = new List<Product>();

    public void Addtocart(Product product)
    {
        Item.Add(product);
    }

    public void Remove(Product product)
    {
        Item.Remove(product);
    }

    public double GetTotalPrice ()
    {
        double total = 0;
        foreach (var item in Item)
        {
            total += item.Price;
        }
        return total;
    }
}