using CaixaData.Mapping;
using CaixaDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace CaixaData.Context
{
    public class CaixaContext: DbContext
    {   
        public CaixaContext(DbContextOptions<CaixaContext> options) : base(options)
        {

        }
        public DbSet<Notas> Notas { get; set; }

        public DbSet<Saques> Saques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Notas>(new NotasMap().Configure);
           modelBuilder.Entity<Saques>(new SaquesMap().Configure);
        }
    }
}
