using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model;

public class Wallet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WalletId { get; set; }
    public string idCard { get; set; }
    public double Balance { set; get; }
    [ForeignKey("User")]
    public int Userid { set; get; }
    
    public virtual User user { get; set; }

    public Wallet()
    {
    }

    public Wallet(string idCard, double balance, User user)
    {
        this.idCard = idCard;
        Balance = balance;
            user= user;
    }

    public string GenerateIdCard()
    {
        Guid guid = Guid.NewGuid();
        return guid.ToString();
    }
    
}