using System.Collections.Generic;

namespace SnagDesk.Domain
{
    public enum TaskStatus : byte
    {
        New = 1, Assigned, InProgress, Testing, Completed, Closed
    }

    public class TaskStatusInfo
    {
        public TaskStatus StatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}