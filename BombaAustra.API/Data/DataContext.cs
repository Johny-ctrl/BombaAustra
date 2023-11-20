using BombaAustra.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BombaAustra.API.Data

{
    public class DataContext : IdentityDbContext<Usuario>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<Equipo> EQUIPOS { get; set; }

        public DbSet<Gastos> GASTO { get; set; }

        public DbSet<GastosResumen> GASTO_RESUMEN { get; set; }

        public DbSet<TipoVehiculo> TIPO_VEHICULO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipo>().HasIndex(x => x.ID_EQUIPO).IsUnique();

            modelBuilder.Entity<Gastos>().HasIndex(x => x.ID_GASTO).IsUnique();

            modelBuilder.Entity<TipoVehiculo>().HasIndex(x => x.SIGLA).IsUnique();

           modelBuilder.Entity<GastosResumen>().HasIndex(x => x.ID_RESUMEN).IsUnique();

        }


    }
}
                                
