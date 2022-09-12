using Fibonacci.Infrastructure.Entities;
using Fibonacci.Infrastructure.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Fibonacci.Infrastructure.DbContexts
{
    public class FibonacciDbContext : DbContext
    {
        public DbSet<RequestedNumbersHistory> RequestedNumbersHistories { get; set; }

        public FibonacciDbContext(DbContextOptions<FibonacciDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FibonacciHistoryEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}