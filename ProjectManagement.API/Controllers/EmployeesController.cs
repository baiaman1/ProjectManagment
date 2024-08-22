using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.DTOs.Employees;
using ProjectManagement.BLL.Interfaces;
using ProjectManagement.BLL.Services;
using ProjectManagement.DAL.Models;

namespace ProjectManagement.API.Controllers
{
    /// <summary>
    /// Контроллер, для работы с сотрудниками.
    /// </summary>
    /// <response code="401">Неавторизованный доступ.</response>
    /// <response code="400">Некорректный запрос.</response>
    /// <response code="500">Внутренняя ошибка сервера.</response>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        /// <summary>
        /// Контроллер, для работы с сотрудниками.
        /// </summary>
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Получить список сотрудников.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <resopnse code="200">Успешное выполнение операции.</resopnse>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        /// <summary>
        /// Получить сотрудника по id.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <resopnse code="200">Успешное выполнение операции.</resopnse>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        /// <summary>
        /// Создать сотрудника.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <resopnse code="200">Успешное выполнение операции.</resopnse>
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] EmployeeDto request)
        {
            try
            {
                var employee = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    Email = request.Email
                };
                var createdEmployee = await _employeeService.CreateEmployeeAsync(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Обновить сотрудника.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <resopnse code="200">Успешное выполнение операции.</resopnse>
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] EmployeeDto request)
        {
            var existEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (existEmployee == null)
            {
                return NotFound(id);
            }

            existEmployee.FirstName = request.FirstName;
            existEmployee.LastName = request.LastName;
            existEmployee.MiddleName = request.MiddleName;
            existEmployee.Email = request.Email;

            await _employeeService.UpdateEmployeeAsync(existEmployee);
            return Ok(existEmployee);
        }

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <resopnse code="200">Успешное выполнение операции.</resopnse>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(id);
            if (deleted == null) return null;
            return Ok(deleted);
        }
    }
}
