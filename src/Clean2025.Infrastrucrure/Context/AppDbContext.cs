using Microsoft.EntityFrameworkCore;
using Clean2025.Domain.Employees;
using System.Reflection;

namespace Clean2025.Infrastrucrure.Context;

    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Employee> Employees { get; set; }
        
    }
