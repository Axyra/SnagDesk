using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnagDesk.Domain;

namespace SnagDesk.DAL.EntityFramework.Configurations
{
    public class TaskStatusInfoConfiguration : EntityTypeConfiguration<TaskStatusInfo>
    {
        public TaskStatusInfoConfiguration()
        {
            HasKey(c => c.StatusId);
            Property(c => c.StatusId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.Title).IsRequired().IsUnicode().HasMaxLength(100);

            Property(c => c.Description).IsUnicode().HasMaxLength(350);

            ToTable("TaskStatusesInformation");
        }
    }
}