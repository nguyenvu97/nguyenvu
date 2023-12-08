using API.Data;
using API.Model;

namespace API.Service;

public class EmployeeService
{
    public readonly ApplicationDbContext _DbContext;

    public EmployeeService(ApplicationDbContext dbContext)
    {
        _DbContext = dbContext;
    }
    public Employee  AddStadd(Employee employee)
    {
        var staff1 = new Employee();
        staff1.staffName = employee.staffName;
        staff1.department = employee.department;
        staff1.rank = employee.rank;
        staff1.roomId = employee.roomId;
        _DbContext.staffs.Add(staff1);
        _DbContext.SaveChanges();
        return staff1;
    }
}