namespace LoLAgencyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificacionecontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notificacions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        texto = c.String(),
                        leido = c.Boolean(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.UsuarioViewModels", t => t.usuario_Id)
                .Index(t => t.usuario_Id);
            
            CreateTable(
                "dbo.UsuarioViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        num_invocador = c.Long(nullable: false),
                        nick = c.String(),
                        pentakill = c.Boolean(nullable: false),
                        lastindexgame = c.Int(nullable: false),
                        doble_doble = c.Boolean(nullable: false),
                        doblekill = c.Boolean(nullable: false),
                        triplekill = c.Boolean(nullable: false),
                        quadrakill = c.Boolean(nullable: false),
                        asesino = c.Boolean(nullable: false),
                        monstruo = c.Boolean(nullable: false),
                        heroe = c.Boolean(nullable: false),
                        conquistador = c.Boolean(nullable: false),
                        observer = c.Boolean(nullable: false),
                        ward_dispenser = c.Boolean(nullable: false),
                        nofog = c.Boolean(nullable: false),
                        sauron = c.Boolean(nullable: false),
                        cantseeme = c.Boolean(nullable: false),
                        john_cena = c.Boolean(nullable: false),
                        piquete_ojos = c.Boolean(nullable: false),
                        cegador = c.Boolean(nullable: false),
                        bulletproof = c.Boolean(nullable: false),
                        die_hard = c.Boolean(nullable: false),
                        mc_hammer = c.Boolean(nullable: false),
                        intocable = c.Boolean(nullable: false),
                        invencible = c.Boolean(nullable: false),
                        indestructible = c.Boolean(nullable: false),
                        trasto = c.Boolean(nullable: false),
                        rebel = c.Boolean(nullable: false),
                        macarra = c.Boolean(nullable: false),
                        maton = c.Boolean(nullable: false),
                        overlord = c.Boolean(nullable: false),
                        kda = c.Single(nullable: false),
                        division = c.String(),
                        server = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notificacions", "usuario_Id", "dbo.UsuarioViewModels");
            DropIndex("dbo.Notificacions", new[] { "usuario_Id" });
            DropTable("dbo.UsuarioViewModels");
            DropTable("dbo.Notificacions");
        }
    }
}
