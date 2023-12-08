using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;


public class Oder
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public double payment { set; get; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    [ForeignKey("OderDetail")]
    public int OderDetail_id { set; get; }
    public OderDetail OderDetail { set; get; }

    
}