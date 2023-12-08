using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Employee
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int staddId { set; get; }
    public int roomId { set; get; }
    public String staffName { set; get; }
    public String department { set; get; }
    public String rank { set; get; }
    
}