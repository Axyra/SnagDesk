using System.Collections.Generic;

namespace SnagDesk.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TaskStatusInfo> AvailableStatuses { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
