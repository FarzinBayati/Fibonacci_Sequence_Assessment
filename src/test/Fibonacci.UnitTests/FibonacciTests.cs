using NUnit.Framework;
using System;

namespace Fibonacci.UnitTests
{
    public class FibonacciTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 8)]               
        public void GetNthFibonacci_WhenRequestNthNumberInSequence_ReturnExpectedResult(int input, int expectedResult)
        {
            var result = SyncVR.RestApi.Helpers.FibonacciCalculator.GetNthFibonacci(input);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(-1)]
        public void GetNthFibonacci_InputIsNegative_ThrowArgumentException(int input)
        {
            Assert.That(() => SyncVR.RestApi.Helpers.FibonacciCalculator.GetNthFibonacci(input),
                Throws.Exception.TypeOf<ArgumentException>());
        }        
    }
}