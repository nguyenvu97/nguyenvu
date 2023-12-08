using API.Model;

namespace API.Repositories;

public interface UserRepo
{
    List<User> GetAllUser();
    User GetUserById(int id);
    // object? AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int id);
}