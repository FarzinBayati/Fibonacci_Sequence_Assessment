using System;

namespace Fibonacci.Infrastructure.Entities
{
    public class RequestedNumbersHistory
    {
        public int Id { get; set; }
        public int RequestedNumber { get; set; }
        public int Result { get; set; }
        public DateTime RequestedDateTime { get; set; } = DateTime.Now;
    }
}