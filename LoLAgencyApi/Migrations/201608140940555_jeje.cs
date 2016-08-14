namespace LoLAgencyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jeje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "doblekill", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "triplekill", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "quadrakill", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "asesino", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "monstruo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "heroe", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "conquistador", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "observer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "ward_dispenser", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "nofog", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "sauron", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "cantseeme", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "john_cena", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "piquete_ojos", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "cegador", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "bulletproof", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "die_hard", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "mc_hammer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "boolocable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "invencible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "indestructible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "trasto", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "rebel", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "macarra", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "maton", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "overlord", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "overlord");
            DropColumn("dbo.Usuarios", "maton");
            DropColumn("dbo.Usuarios", "macarra");
            DropColumn("dbo.Usuarios", "rebel");
            DropColumn("dbo.Usuarios", "trasto");
            DropColumn("dbo.Usuarios", "indestructible");
            DropColumn("dbo.Usuarios", "invencible");
            DropColumn("dbo.Usuarios", "boolocable");
            DropColumn("dbo.Usuarios", "mc_hammer");
            DropColumn("dbo.Usuarios", "die_hard");
            DropColumn("dbo.Usuarios", "bulletproof");
            DropColumn("dbo.Usuarios", "cegador");
            DropColumn("dbo.Usuarios", "piquete_ojos");
            DropColumn("dbo.Usuarios", "john_cena");
            DropColumn("dbo.Usuarios", "cantseeme");
            DropColumn("dbo.Usuarios", "sauron");
            DropColumn("dbo.Usuarios", "nofog");
            DropColumn("dbo.Usuarios", "ward_dispenser");
            DropColumn("dbo.Usuarios", "observer");
            DropColumn("dbo.Usuarios", "conquistador");
            DropColumn("dbo.Usuarios", "heroe");
            DropColumn("dbo.Usuarios", "monstruo");
            DropColumn("dbo.Usuarios", "asesino");
            DropColumn("dbo.Usuarios", "quadrakill");
            DropColumn("dbo.Usuarios", "triplekill");
            DropColumn("dbo.Usuarios", "doblekill");
        }
    }
}
