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

        public DbSet<ModeloVehiculo> MODELO_VEHICULO { get; set; }

        public DbSet<Gastos> GASTOS { get; set; }

        public DbSet<TipoVehiculo> TIPO_VEHICULO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasIndex(x => x.ID_RUT).IsUnique();

            modelBuilder.Entity<TipoUsuario>().HasIndex(x => x.ID_TIPO_USUARIO).IsUnique();

            modelBuilder.Entity<TipoEquipo>().HasIndex(x => x.ID_TIPO_EQUIPO).IsUnique();

            modelBuilder.Entity<Reporte>().HasIndex(x => x.ID_REPORTE).IsUnique();

            modelBuilder.Entity<NombreCompañia>().HasIndex(x => x.ID_NOMBRE_COMPAÑIA).IsUnique();

            modelBuilder.Entity<EstadoEquipo>().HasIndex(x => x.ID_ESTADO).IsUnique();

            modelBuilder.Entity<Equipo>().HasIndex(x => x.ID_EQUIPO).IsUnique();

            modelBuilder.Entity<Compañia>().HasIndex(x => x.ID_COMPAÑIA).IsUnique();

            modelBuilder.Entity<ModeloVehiculo>().HasIndex(x => x.ID_MODELO).IsUnique();

            modelBuilder.Entity<Gastos>().HasIndex(x => x.ID_GASTO).IsUnique();

            modelBuilder.Entity<TipoVehiculo>().HasIndex(x => x.SIGLA).IsUnique();

        }


    }
}
