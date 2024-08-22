using Microsoft.EntityFrameworkCore;
using ProjectManagement.BLL.Interfaces;
using ProjectManagement.DAL.Data;
using ProjectManagement.DAL.Models;

namespace ProjectManagement.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) throw new Exception($"Employee with ID {id} not found.");
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;

        }
    }
}
