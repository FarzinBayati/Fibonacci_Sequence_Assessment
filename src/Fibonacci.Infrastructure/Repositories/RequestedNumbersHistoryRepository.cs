using Fibonacci.Infrastructure.DbContexts;
using Fibonacci.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fibonacci.Infrastructure.Repositories
{
    public class RequestedNumbersHistoryRepository : IRequestedNumbersHistoryRepository, IDisposable
    {
        private readonly FibonacciDbContext _context;

        public RequestedNumbersHistoryRepository(FibonacciDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddHistory(RequestedNumbersHistory history)
        {
            if (history == null)
                throw new ArgumentNullException(nameof(history));

            _context.RequestedNumbersHistories.Add(history);
            this.Save();
        }

        public IEnumerable<RequestedNumbersHistory> GetAllHistories()
        {
            return _context.RequestedNumbersHistories.ToList<RequestedNumbersHistory>();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}