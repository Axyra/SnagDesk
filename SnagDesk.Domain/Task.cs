namespace SnagDesk.Domain
{
    public class Task
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }

        public virtual Project Project { get; set; }
        public virtual TaskStatusInfo StatusInfo { get; set; }
    }
}