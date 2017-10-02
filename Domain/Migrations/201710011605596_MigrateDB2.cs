namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Users_Id", "dbo.Users");
            DropIndex("dbo.Files", new[] { "Users_Id" });
            AddColumn("dbo.Files", "Users_Id1", c => c.Int());
            CreateIndex("dbo.Files", "Users_Id1");
            AddForeignKey("dbo.Files", "Users_Id1", "dbo.Users", "Id");
            DropColumn("dbo.Files", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "User_Id", c => c.Int());
            DropForeignKey("dbo.Files", "Users_Id1", "dbo.Users");
            DropIndex("dbo.Files", new[] { "Users_Id1" });
            DropColumn("dbo.Files", "Users_Id1");
            CreateIndex("dbo.Files", "Users_Id");
            AddForeignKey("dbo.Files", "Users_Id", "dbo.Users", "Id");
        }
    }
}
