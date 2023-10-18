using BombaAustra.Shared.Entities;
using Microsoft.EntityFrameworkCore;


namespace BombaAustra.API.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoUsuario> tipo_Usuarios { get; set; }

        public DbSet<TipoEquipo> tipo_Equipos {  get; set; }

        public DbSet<Reporte> reportes { get; set; }

        public DbSet<NombreCompañia> nombre_Compañia { get; set; }

        public DbSet<EstadoEquipo> estado_Equipos { get; set; }

        public DbSet<Equipo> equipos { get; set; }

        public DbSet<Compañia> compañias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasIndex(x => x.ID_RUT).IsUnique();
        }
    }
}
