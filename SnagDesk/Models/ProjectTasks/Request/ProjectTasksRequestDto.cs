using SnagDesk.Domain;

namespace SnagDesk.Models.ProjectTasks.Request
{
    public class ProjectTasksRequestDto : ListRequestDto
    {
        public int ProjectId { get; set; }
        public TaskStatus? Status { get; set; }
    }
}