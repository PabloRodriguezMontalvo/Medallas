namespace LoLAgencyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechasnullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "pentakill", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "doble_doble", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "doblekill", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "triplekill", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "quadrakill", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "asesino", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "monstruo", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "heroe", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "conquistador", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "observer", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "ward_dispenser", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "nofog", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "sauron", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "cantseeme", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "john_cena", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "piquete_ojos", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "cegador", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "bulletproof", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "die_hard", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "mc_hammer", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "intocable", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "invencible", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "indestructible", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "trasto", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "rebel", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "macarra", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "maton", c => c.DateTime());
            AlterColumn("dbo.Usuarios", "overlord", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "overlord", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "maton", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "macarra", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "rebel", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "trasto", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "indestructible", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "invencible", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "intocable", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "mc_hammer", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "die_hard", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "bulletproof", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "cegador", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "piquete_ojos", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "john_cena", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "cantseeme", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "sauron", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "nofog", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "ward_dispenser", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "observer", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "conquistador", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "heroe", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "monstruo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "asesino", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "quadrakill", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "triplekill", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "doblekill", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "doble_doble", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "pentakill", c => c.DateTime(nullable: false));
        }
    }
}
