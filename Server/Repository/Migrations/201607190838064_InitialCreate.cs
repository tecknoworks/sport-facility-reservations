namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Teste", c => c.String());
            DropColumn("dbo.Users", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Test", c => c.String());
            DropColumn("dbo.Users", "Teste");
        }
    }
}
