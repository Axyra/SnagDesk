using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using SnagDesk.Domain;

namespace SnagDesk.DAL.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SnagdeskDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"EntityFramework\Migrations";
        }

        protected override void Seed(SnagdeskDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.TaskStatusInfos.AddOrUpdate(c => c.StatusId,
                new TaskStatusInfo {StatusId = TaskStatus.New, Title = "New", Description = "New task"},
                new TaskStatusInfo {StatusId = TaskStatus.Assigned, Title = "Assigned"},
                new TaskStatusInfo {StatusId = TaskStatus.InProgress, Title = "Work in progress"},
                new TaskStatusInfo {StatusId = TaskStatus.Testing, Title = "Testing"},
                new TaskStatusInfo {StatusId = TaskStatus.Completed, Title = "Task completed"},
                new TaskStatusInfo {StatusId = TaskStatus.Closed, Title = "Closed"});

            var statusesForFirstProject =
                new List<TaskStatus> { TaskStatus.New, TaskStatus.InProgress, TaskStatus.Closed };
            var statusesForSecondProject = new List<TaskStatus>
            {
                TaskStatus.New,
                TaskStatus.InProgress,
                TaskStatus.Testing,
                TaskStatus.Completed
            };

            context.Projects.AddOrUpdate(c => c.Id,
                new Project
                {
                    Id = 1,
                    Name = "АБВГДЕЙКА",
                    AvailableStatuses = context.TaskStatusInfos.Local
                        .Where(c => statusesForFirstProject.Contains(c.StatusId))
                        .ToList(),
                    Tasks = new List<Task>
                    {
                        new Task {Id = 1, Status = TaskStatus.New, Title = "Добавить", Description = "Все добавить"},
                        new Task {Id = 2, Status = TaskStatus.Completed, Title = "Удалить", Description = "Все удалить"}
                    }
                },
                new Project
                {
                    Id = 2,
                    Name = "Test Project",
                    AvailableStatuses = context.TaskStatusInfos.Local
                        .Where(c => statusesForSecondProject.Contains(c.StatusId))
                        .ToList()
                });

            context.SaveChanges();
        }
    }
}
