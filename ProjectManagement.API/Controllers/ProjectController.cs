using Microsoft.AspNetCore.Mvc;
using ProjectManagement.BLL.Interfaces;
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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        /// <summary>
        /// Контроллер, для работы с сотрудниками.
        /// </summary>
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        /// <summary>
        /// Получить список сотрудников.
        /// </summary>
        /// <returns>Результат выполнения операции.</returns>
        /// <resopnse code="200">Успешное выполнение операции.</resopnse>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            var employee = await _projectService.GetAllProjectsAsync();
            return Ok(employee);
        }

    }

}
