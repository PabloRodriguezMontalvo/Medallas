namespace LoLAgencyApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosdate : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Notificacions", "usuario_Id", "dbo.UsuarioViewModels");
            //DropIndex("dbo.Notificacions", new[] { "usuario_Id" });

            CreateTable(
                "dbo.Usuarios",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    num_invocador = c.Long(nullable: false),
                    nick = c.String(),
                    lastindexgame = c.Int(nullable: false),
                    doblekill = c.Int(nullable: false),
                    triplekill = c.Int(nullable: false),
                    quadrakill = c.Int(nullable: false),
                    pentakill = c.Int(nullable: false),
                    doble_doble = c.Int(nullable: false),
                    asesino = c.Int(nullable: false),
                    monstruo = c.Int(nullable: false),
                    heroe = c.Int(nullable: false),
                    conquistador = c.Int(nullable: false),
                    observer = c.Int(nullable: false),
                    ward_dispenser = c.Int(nullable: false),
                    nofog = c.Int(nullable: false),
                    sauron = c.Int(nullable: false),
                    cantseeme = c.Int(nullable: false),
                    john_cena = c.Int(nullable: false),
                    piquete_ojos = c.Int(nullable: false),
                    cegador = c.Int(nullable: false),
                    bulletproof = c.Int(nullable: false),
                    die_hard = c.Int(nullable: false),
                    mc_hammer = c.Int(nullable: false),
                    intocable = c.Int(nullable: false),
                    invencible = c.Int(nullable: false),
                    indestructible = c.Int(nullable: false),
                    trasto = c.Int(nullable: false),
                    rebel = c.Int(nullable: false),
                    macarra = c.Int(nullable: false),
                    maton = c.Int(nullable: false),
                    overlord = c.Int(nullable: false),
                    kda = c.Single(nullable: false),
                    division = c.String(),
                    server = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            AlterColumn("dbo.Usuarios", "doblekill", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "triplekill", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "quadrakill", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "pentakill", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "doble_doble", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "asesino", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "monstruo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "heroe", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "conquistador", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "observer", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "ward_dispenser", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "nofog", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "sauron", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "cantseeme", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "john_cena", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "piquete_ojos", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "cegador", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "bulletproof", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "die_hard", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "mc_hammer", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "intocable", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "invencible", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "indestructible", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "trasto", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "rebel", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "macarra", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "maton", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Usuarios", "overlord", c => c.DateTime(nullable: false));
            //DropTable("dbo.Notificacions");
            //DropTable("dbo.UsuarioViewModels");
            
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.id);
            
            AlterColumn("dbo.Usuarios", "overlord", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "maton", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "macarra", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "rebel", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "trasto", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "indestructible", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "invencible", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "intocable", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "mc_hammer", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "die_hard", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "bulletproof", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "cegador", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "piquete_ojos", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "john_cena", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "cantseeme", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "sauron", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "nofog", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "ward_dispenser", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "observer", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "conquistador", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "heroe", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "monstruo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "asesino", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "doble_doble", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "pentakill", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "quadrakill", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "triplekill", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuarios", "doblekill", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Notificacions", "usuario_Id");
            AddForeignKey("dbo.Notificacions", "usuario_Id", "dbo.UsuarioViewModels", "Id");
        }
    }
}
