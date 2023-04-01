using Domain.Entities;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RhDbContext : DbContext
    {
        public RhDbContext(DbContextOptions<RhDbContext> options) : base(options) { }
        public DbSet<Employee> Employee { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(PermissionSeed.Seed);
            modelBuilder.Entity<Employee>().HasData(EmployeeSeed.Seed);
        }
    }
}
