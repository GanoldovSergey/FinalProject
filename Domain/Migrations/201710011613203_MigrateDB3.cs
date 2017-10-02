namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Files", name: "Users_Id1", newName: "UserId");
            RenameIndex(table: "dbo.Files", name: "IX_Users_Id1", newName: "IX_UserId");
            DropColumn("dbo.Files", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "Users_Id", c => c.Int());
            RenameIndex(table: "dbo.Files", name: "IX_UserId", newName: "IX_Users_Id1");
            RenameColumn(table: "dbo.Files", name: "UserId", newName: "Users_Id1");
        }
    }
}
