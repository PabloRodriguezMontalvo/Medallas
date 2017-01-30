using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LoLAgencyApi.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Notificacion> Notificaciones { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}