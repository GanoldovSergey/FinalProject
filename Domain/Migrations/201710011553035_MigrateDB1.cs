namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "User_Id", c => c.Int());
            AlterColumn("dbo.Files", "Size", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Files", "Who_upload");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "Who_upload", c => c.Int());
            AlterColumn("dbo.Files", "Size", c => c.Int());
            DropColumn("dbo.Files", "User_Id");
        }
    }
}
