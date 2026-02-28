using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaInvetario.Modelos;
using System.Reflection;

namespace SistemaInventario.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bodega> Bodegas { get; set; }


        //sobrescribe el método OnModelCreating para aplicar las configuraciones de las entidades utilizando
        //la reflexión para cargar todas las configuraciones desde el ensamblado actual (Assembly.GetExecutingAssembly()).
        //Esto permite que Entity Framework Core configure automáticamente las entidades según las clases de configuración definidas en el proyecto.
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
