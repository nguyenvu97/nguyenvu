using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using API.Data;
using API.Model;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Service;

public class UserService : UserRepo
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<User> GetAllUser()
    {
        return _context.Users.ToList();
    }

    public User GetUserById(int id)
    {
        return _context.Users.Find(id);
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserId == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public UserDto RegisterNewUser(UserDto userDto)
    {
        var user = new User();
        user.username = userDto.username;
        user.password = Sha256Password.Endingcode.ComputeSha256hash(userDto.password);
        user.CustomerName = userDto.CustomerName;
        user.Email = userDto.Email;
        var wallet1 = new Wallet();
        wallet1.Userid = user.UserId;
        string idcard = wallet1.GenerateIdCard();
        wallet1.idCard = idcard;
        user.Wallet = wallet1;
        // Thêm đối tượng User và Wallet vào cơ sở dữ liệu
        _context.Users.Add(user);
        _context.Wallets.Add(wallet1);
        _context.SaveChanges();
        return userDto;
    }
    public bool login(LoginDto loginDto)
    {
        var email1 = _context.Users.FirstOrDefault(u => u.Email == loginDto.email);
        if (email1 != null )
        {
            string passwordHash = Sha256Password.Endingcode.ComputeSha256hash(loginDto.password);
            if (email1.password == passwordHash)
            {
                return true;
            }
        }

        return false;

    }
}