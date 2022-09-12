using System;

namespace Fibonacci.RestApi.Models
{
    public class FibonacciDto
    {
        public int RequestedNumber { get; set; }
        public int Result { get; set; }
        public DateTime RequestedDateTime { get; set; }
    }
}