namespace SnagDesk.DAL.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 350),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskStatusesInformation",
                c => new
                    {
                        StatusId = c.Byte(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false),
                        Status = c.Byte(nullable: false),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.TaskStatusesInformation", t => t.Status)
                .Index(t => t.Status)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.ProjectTaskStatusInfoes",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        StatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.StatusId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.TaskStatusesInformation", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Status", "dbo.TaskStatusesInformation");
            DropForeignKey("dbo.Tasks", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectTaskStatusInfoes", "StatusId", "dbo.TaskStatusesInformation");
            DropForeignKey("dbo.ProjectTaskStatusInfoes", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectTaskStatusInfoes", new[] { "StatusId" });
            DropIndex("dbo.ProjectTaskStatusInfoes", new[] { "ProjectId" });
            DropIndex("dbo.Tasks", new[] { "Project_Id" });
            DropIndex("dbo.Tasks", new[] { "Status" });
            DropTable("dbo.ProjectTaskStatusInfoes");
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskStatusesInformation");
            DropTable("dbo.Projects");
        }
    }
}
