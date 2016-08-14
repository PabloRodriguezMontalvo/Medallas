namespace LoLAgencyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificaciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "intocable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Usuarios", "boolocable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "boolocable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Usuarios", "intocable");
        }
    }
}
