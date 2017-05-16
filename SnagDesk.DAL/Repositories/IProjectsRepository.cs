using System.Linq;
using SnagDesk.Domain;

namespace SnagDesk.DAL.Repositories
{
    public interface IProjectsRepository : IRepository<Project, int>
    {
        IQueryable<Task> GetTasks(int projectId);
        IQueryable<Task> GetTasks(int projectId, TaskStatus status);
        bool DoesProjectHaveStatus(int projectId, TaskStatus status);
    }
}