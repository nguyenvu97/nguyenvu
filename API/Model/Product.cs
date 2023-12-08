using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { set; get; }
    public string product_name { set; get; }
    public double Price { set; get; }
    public int Quantity { set; get; }
    public string ImageUrl { set; get; }
    public List<OderDetail> OderDetails;

}