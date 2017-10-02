namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Size = c.Int(),
                        Who_upload = c.Int(),
                        Rating = c.Decimal(precision: 18, scale: 2),
                        Number_Of_Raitings = c.Int(),
                        Files = c.Binary(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Raiting = c.Int(),
                        User = c.Int(),
                        File = c.Int(),
                        Files_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.Files_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Files_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Ratings", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Files", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Ratings", "Files_Id", "dbo.Files");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Ratings", new[] { "Users_Id" });
            DropIndex("dbo.Ratings", new[] { "Files_Id" });
            DropIndex("dbo.Files", new[] { "Users_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Ratings");
            DropTable("dbo.Files");
        }
    }
}
