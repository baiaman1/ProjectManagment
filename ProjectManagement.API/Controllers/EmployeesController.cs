using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Requests;
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
    }
}
