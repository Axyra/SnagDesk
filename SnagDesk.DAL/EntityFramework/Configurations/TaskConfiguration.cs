using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnagDesk.Domain;

namespace SnagDesk.DAL.EntityFramework.Configurations
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Title).IsRequired().IsUnicode().HasMaxLength(500);

            Property(c => c.Description).IsRequired().IsUnicode();

            Property(c => c.Status).IsRequired();

            HasRequired(c => c.Project).WithMany(c => c.Tasks).WillCascadeOnDelete(false);
            HasRequired(c => c.StatusInfo).WithMany().HasForeignKey(c => c.Status).WillCascadeOnDelete(false);

            ToTable("Tasks");
        }
    }
}