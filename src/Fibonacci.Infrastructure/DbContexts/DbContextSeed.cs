using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Fibonacci.Infrastructure.DbContexts
{
    public class DbContextSeed
    {
        public static async Task MigrateAsync(FibonacciDbContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                context.Database.Migrate();                
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<FibonacciDbContext>();
                    log.LogError(exception.Message);
                    System.Threading.Thread.Sleep(2000);
                    await MigrateAsync(context, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}