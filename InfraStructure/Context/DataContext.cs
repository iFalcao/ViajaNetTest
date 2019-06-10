using Microsoft.EntityFrameworkCore;
using ViajaNet.Domain.Models;
using InfraStructure.Mapping;

namespace InfraStructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new VisitConfig());
        }
    }
}
