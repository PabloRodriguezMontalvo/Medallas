namespace LoLAgencyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosintporboolean : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "pentakill", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "doble_doble", c => c.Boolean(nullable: false));
            DropColumn("dbo.Usuarios", "doblekill");
            DropColumn("dbo.Usuarios", "triplekill");
            DropColumn("dbo.Usuarios", "quadrakill");
            DropColumn("dbo.Usuarios", "asesino");
            DropColumn("dbo.Usuarios", "monstruo");
            DropColumn("dbo.Usuarios", "heroe");
            DropColumn("dbo.Usuarios", "conquistador");
            DropColumn("dbo.Usuarios", "observer");
            DropColumn("dbo.Usuarios", "ward_dispenser");
            DropColumn("dbo.Usuarios", "nofog");
            DropColumn("dbo.Usuarios", "sauron");
            DropColumn("dbo.Usuarios", "cantseeme");
            DropColumn("dbo.Usuarios", "john_cena");
            DropColumn("dbo.Usuarios", "piquete_ojos");
            DropColumn("dbo.Usuarios", "cegador");
            DropColumn("dbo.Usuarios", "bulletproof");
            DropColumn("dbo.Usuarios", "die_hard");
            DropColumn("dbo.Usuarios", "mc_hammer");
            DropColumn("dbo.Usuarios", "intocable");
            DropColumn("dbo.Usuarios", "invencible");
            DropColumn("dbo.Usuarios", "indestructible");
            DropColumn("dbo.Usuarios", "trasto");
            DropColumn("dbo.Usuarios", "rebel");
            DropColumn("dbo.Usuarios", "macarra");
            DropColumn("dbo.Usuarios", "maton");
            DropColumn("dbo.Usuarios", "overlord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "overlord", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "maton", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "macarra", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "rebel", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "trasto", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "indestructible", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "invencible", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "intocable", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "mc_hammer", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "die_hard", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "bulletproof", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "cegador", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "piquete_ojos", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "john_cena", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "cantseeme", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "sauron", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "nofog", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "ward_dispenser", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "observer", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "conquistador", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "heroe", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "monstruo", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "asesino", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "quadrakill", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "triplekill", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "doblekill", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "doble_doble", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "pentakill", c => c.Int(nullable: false));
        }
    }
}
