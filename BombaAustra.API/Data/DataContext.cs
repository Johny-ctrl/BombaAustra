using BombaAustra.Shared.Entities;
using Microsoft.EntityFrameworkCore;


namespace BombaAustra.API.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> USUARIOS { get; set; }

        public DbSet<TipoUsuario> TIPO_USUARIOS { get; set; }

        public DbSet<TipoEquipo> TIPO_EQUIPO {  get; set; }

        public DbSet<Reporte> REPORTES { get; set; }

        public DbSet<NombreCompañia> NOMBRE_COMPANIAS { get; set; }

        public DbSet<EstadoEquipo> ESTADO_EQUIPO { get; set; }

        public DbSet<Equipo> EQUIPOS { get; set; }

        public DbSet<Compañia> COMPANIAS { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasIndex(x => x.ID_RUT).IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoUsuario>().HasIndex(x => x.ID_TIPO_USUARIO).IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoEquipo>().HasIndex(x => x.ID_TIPO_EQUIPO).IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reporte>().HasIndex(x => x.ID_REPORTE).IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NombreCompañia>().HasIndex(x => x.ID_NOMBRE_COMPAÑIA).IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EstadoEquipo>().HasIndex(x => x.ID_ESTADO).IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Equipo>().HasIndex(x => x.ID_EQUIPO).IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Compañia>().HasIndex(x => x.ID_COMPAÑIA).IsUnique();


        }
    }
}
