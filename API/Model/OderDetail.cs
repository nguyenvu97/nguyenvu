using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class OderDetail
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { set; get; }
    public int Quantity { set; get; }
    public double PriceTotal { set; get; }
    public List<Product> Products;

}