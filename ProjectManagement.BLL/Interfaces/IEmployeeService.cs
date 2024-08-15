using ProjectManagement.DAL.Models;

namespace ProjectManagement.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        //Task<Employee> GetEmployeeByIdAsync(int id);
        //Task<Employee> CreateEmployeeAsync(Employee employee);
        //Task<Employee> UpdateEmployeeAsync(Employee employee);
        //Task DeleteEmployeeAsync(int id);

    }
}
