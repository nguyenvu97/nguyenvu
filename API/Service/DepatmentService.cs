using API.Data;
using API.Model;

namespace API.Service;

public class DepatmentService
{
    public readonly ApplicationDbContext _DbContext;

    public DepatmentService(ApplicationDbContext dbContext)
    {
        _DbContext = dbContext;
    }
    
    //
    
    public void deleteDepatment(int roomId)
    {
        var  depatment= _DbContext.Departments.FirstOrDefault(u => u.roomId == roomId);
        if (depatment != null)
        {
            _DbContext.Departments.Remove(depatment);
            _DbContext.SaveChanges();
        }
    }
    //
    
    public List<Department> GetAllProduct()
    {
        return _DbContext.Departments.ToList();
    }
    
    
    // 
    public Department AddDepartment(Department department)
    {
        var department1 = new Department();
        department1.roomAddrees = department.roomAddrees;
        department1.roomName = department.roomName;
        department1.roomNumber = department.roomNumber;
        department1.Role = department.Role;
        _DbContext.Departments.Add(department1);
        _DbContext.SaveChanges();
        return department1;
    }
    public Department UpdateDepartment(Department updatedDepartment)
    {
        var existingDepartment = _DbContext.Departments.FirstOrDefault(u => u.roomId == updatedDepartment.roomId);
        if (existingDepartment != null)
        {
            existingDepartment.roomName = updatedDepartment.roomName;
            existingDepartment.roomAddrees = updatedDepartment.roomAddrees;
            existingDepartment.roomNumber = updatedDepartment.roomNumber;
                
            _DbContext.SaveChanges();
        }

        return existingDepartment;
    }
    public Department GetDepartmentById(int roomId)
    {
        // Lấy thông tin của phòng ban theo ID
        return _DbContext.Departments.FirstOrDefault(u => u.roomId == roomId);
    }
}