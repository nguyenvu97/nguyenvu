using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/user")] 
public class UserController : Controller
//  http://localhost:5281/api/user/Register
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    private IActionResult getalluser()
    {
        var user = _userService.GetAllUser();
        return Ok(user);
    }

    [HttpGet("{id}")]
    public IActionResult getUserbyid(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);

    }

    // [HttpPost]
    // public IActionResult saveuser(User user)
    // {
    //      _userService.(user);
    //     return Ok(user);
    // }

    [HttpPost("/Register")]
    public UserDto Register(UserDto userdto )
    {
        return  _userService.RegisterNewUser(userdto);
    }


    [HttpPut]
    public IActionResult Updateuser(int id, User user)
    {
        var user1 = _userService.GetUserById(id);
        if (user1 == null)
        {
            return NotFound();
        }
    
        user1.password = user.password;
        user1.username = user.username;
        _userService.UpdateUser(user1);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        _userService.DeleteUser(id);

        return NoContent();
    }

    [HttpPost("/login")]
    public IActionResult login(LoginDto loginDto)
    {
        return Ok(_userService.login(loginDto));
    }
 
}