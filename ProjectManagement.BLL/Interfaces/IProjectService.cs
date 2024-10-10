using ProjectManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.BLL.Interfaces
{
    public interface IProjectService
    {
        public Task<IEnumerable<Project>> GetAllProjectsAsync();
    }
}
