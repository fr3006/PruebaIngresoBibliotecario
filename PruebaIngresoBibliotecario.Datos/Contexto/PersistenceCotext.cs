using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaIngresoBibliotecario.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace PruebaIngresoBibliotecario.Datos.Contexto
{
    public class PersistenceCotext : DbContext
    {

        private readonly IConfiguration Config;
        public DbSet<solicitudPrestamo> Prestamos { get; set; }
                

        public PersistenceCotext(DbContextOptions<PersistenceCotext> options, IConfiguration config) : base(options)
        {
            Config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.HasDefaultSchema(Config.GetValue<string>("SchemaName"));

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<solicitudPrestamo>();
        }

        internal PersistenceCotext ConfigureAwait()
        {
            throw new NotImplementedException();
        }
    }
}
