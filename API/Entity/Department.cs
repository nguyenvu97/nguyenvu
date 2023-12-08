using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Department
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int roomId { set; get; }
    public string roomName { set; get; }
    public string roomAddrees { set; get; }
    public string roomNumber { set; get; }
    public String Role { set; get; }
}