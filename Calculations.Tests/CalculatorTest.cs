using System;
using System.Collections.Generic;
using System.IO;
using TestTraining;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Tests
{
    public class CalculatorFixture : IDisposable
    {
        public Calculator Calculator => new Calculator();

        public void Dispose()
        {
            // cleaning ://
        }
    }

    public class CalculatorTest : IClassFixture<CalculatorFixture>, IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly CalculatorFixture _calculatorFixture;
        private readonly MemoryStream _memoryStream;

        public CalculatorTest(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _calculatorFixture = calculatorFixture;
            _memoryStream = new MemoryStream();
            _testOutputHelper.WriteLine("constructor :)");
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckFiboNumbers()
        {
            _testOutputHelper.WriteLine("CheckFiboNumbers :)");
            var fiboNumbers = new List<int> { 1, 1, 2, 3, 5, 8, 13 };
            var calc = _calculatorFixture.Calculator; //new Calculator();
            Assert.Equal(fiboNumbers, calc.Fibo);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void Check8InFiboNumbers()
        {
            _testOutputHelper.WriteLine("Check8InFiboNumbers :)");
            var calc = _calculatorFixture.Calculator; // new Calculator();
            Assert.Contains(8, calc.Fibo);
        }

        [Fact]
        public void IsOdd_GivenOddValue_ReturnsTrue()
        {
            var calc = _calculatorFixture.Calculator;
            var res = calc.IsOdd(1);
            Assert.True(res);
        }

        [Fact]
        public void IsOdd_GivenEvenValue_ReturnsFalse()
        {
            var calc = _calculatorFixture.Calculator;
            var res = calc.IsOdd(2);
            Assert.False(res);
        }

        [Theory]
        //[InlineData(8,false)]
        //[InlineData(201,true)]
        //[MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))] // share
        //[MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType = typeof(TestDataShare))] // external import
        [IsOddOrEvenDataAttribute] // custom Attr
        public void IsOdd_TestOddAndEvent(int value, bool expected)
        {
            var calc = _calculatorFixture.Calculator;
            var res = calc.IsOdd(value);
            Assert.Equal(expected, res);
        }

        public void Dispose()
        {
            _memoryStream.Close();
            _calculatorFixture?.Dispose();
        }
    }
}
