using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

[Table("UserAccounts")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { set; get; }
    public string username { set; get; }
    public string password { set; get; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public virtual Wallet Wallet { get; set; }
        
    
}