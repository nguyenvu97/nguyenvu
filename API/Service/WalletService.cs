using API.Data;
using API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Service;

public class WalletService 
{
   
   private readonly ApplicationDbContext _context;

   public WalletService(ApplicationDbContext context)
   {
      _context = context;
   }

   public IActionResult recharge(string idcard, string username , double recharge )
   {
      var user = _context.Users.FirstOrDefault(u => u.username == username);
      if (user != null)
      {
         var wallet1 = _context.Wallets.FirstOrDefault(u => u.idCard == idcard);
         {
            if (wallet1 != null)
            {
               wallet1.Balance += recharge;
               _context.SaveChanges();
            }
         }
      }


      return null;
   }
}