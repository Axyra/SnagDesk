using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnagDesk.Domain;

namespace SnagDesk.DAL.EntityFramework.Configurations
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Name).IsRequired().IsUnicode().HasMaxLength(350);

            Property(c => c.Description).IsUnicode();

            HasMany(c => c.AvailableStatuses).WithMany().Map(c => c.MapLeftKey("ProjectId").MapRightKey("StatusId"));

            ToTable("Projects");
        }
    }
}