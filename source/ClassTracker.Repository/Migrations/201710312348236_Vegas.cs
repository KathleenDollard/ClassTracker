namespace ClassTracker.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vegas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatalogNumber = c.String(),
                        Name = c.String(),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GivenName = c.String(),
                        SurName = c.String(),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.Section",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                        Instructor_Id = c.Int(),
                        Term_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .ForeignKey("dbo.Instructor", t => t.Instructor_Id)
                .ForeignKey("dbo.Term", t => t.Term_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Term_Id);
            
            CreateTable(
                "dbo.Term",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Section", "Term_Id", "dbo.Term");
            DropForeignKey("dbo.Term", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.Section", "Instructor_Id", "dbo.Instructor");
            DropForeignKey("dbo.Section", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.Instructor", "Organization_Id", "dbo.Organization");
            DropForeignKey("dbo.Course", "Organization_Id", "dbo.Organization");
            DropIndex("dbo.Term", new[] { "Organization_Id" });
            DropIndex("dbo.Section", new[] { "Term_Id" });
            DropIndex("dbo.Section", new[] { "Instructor_Id" });
            DropIndex("dbo.Section", new[] { "Course_Id" });
            DropIndex("dbo.Instructor", new[] { "Organization_Id" });
            DropIndex("dbo.Course", new[] { "Organization_Id" });
            DropTable("dbo.Term");
            DropTable("dbo.Section");
            DropTable("dbo.Instructor");
            DropTable("dbo.Organization");
            DropTable("dbo.Course");
        }
    }
}
