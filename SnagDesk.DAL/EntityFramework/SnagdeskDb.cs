using System.Data.Entity;
using System.Reflection;
using SnagDesk.Domain;

namespace SnagDesk.DAL.EntityFramework
{
    public class SnagdeskDb : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatusInfo> TaskStatusInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(SnagdeskDb)));
        }
    }
}