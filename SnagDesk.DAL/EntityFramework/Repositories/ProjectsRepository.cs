using System.Data.Entity;
using System.Linq;
using SnagDesk.DAL.Repositories;
using SnagDesk.Domain;

namespace SnagDesk.DAL.EntityFramework.Repositories
{
    public class ProjectsRepository : Repository<Project, int>, IProjectsRepository
    {
        public ProjectsRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Task> GetTasks(int projectId)
        {
            return All.Where(c => c.Id == projectId).SelectMany(c => c.Tasks);
        }

        public IQueryable<Task> GetTasks(int projectId, TaskStatus status)
        {
            return GetTasks(projectId).Where(c => c.Status == status);
        }

        public bool DoesProjectHaveStatus(int projectId, TaskStatus status)
        {
            return All.Where(c => c.Id == projectId)
                .Select(c => c.AvailableStatuses.Select(s => s.StatusId).Contains(status))
                .Single();
        }
    }
}