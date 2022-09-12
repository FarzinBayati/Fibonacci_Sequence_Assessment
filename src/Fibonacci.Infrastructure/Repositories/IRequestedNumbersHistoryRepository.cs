using Fibonacci.Infrastructure.Entities;
using System.Collections.Generic;

namespace Fibonacci.Infrastructure.Repositories
{
    public interface IRequestedNumbersHistoryRepository
    {
        void AddHistory(RequestedNumbersHistory history);
        bool Save();
        IEnumerable<RequestedNumbersHistory> GetAllHistories();
    }
}