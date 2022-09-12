using System;

namespace SyncVR.RestApi.Helpers
{
    public static class FibonacciCalculator
    {
        public static int GetNthFibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException();

            if (n == 0) return 0;
            else if (n == 1) return 1;
            else
            {
                return GetNthFibonacci(n - 1) + GetNthFibonacci(n - 2);
            }
        }
    }
}