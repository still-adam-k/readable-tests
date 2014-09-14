using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Extensions;

namespace ReadableTests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("2", 2)]
        [InlineData("2+7", 9)]
        [InlineData("3*5", 15)]
        [InlineData("2+9*7-5", 60)]
        [InlineData("2+9*7/2-5", 28.5)]
        public void CalculateTest(string expression, double value)
        {
            var calculator = new Calculator.Calculator();

            var calculatedValue = calculator.Calculate(expression);
            calculatedValue.Should().Be(value);
        }

        [Fact]
        public void CalculateTest_one_Digit()
        {
            var calculator = new Calculator.Calculator();

            var calculatedValue = calculator.Calculate("2");
            calculatedValue.Should().Be(2);
        }

        [Fact]
        public void CalculateTest_add()
        {
            var calculator = new Calculator.Calculator();

            var calculatedValue = calculator.Calculate("2+3");
            calculatedValue.Should().Be(5);
        }

        [Fact]
        public void CalculateTest_one_multiplication()
        {
            var calculator = new Calculator.Calculator();

            var calculatedValue = calculator.Calculate("2*3");
            calculatedValue.Should().Be(6);
        }

        [Fact]
        public void CalculateTest_division()
        {
            var calculator = new Calculator.Calculator();

            var calculatedValue = calculator.Calculate("9/3");
            calculatedValue.Should().Be(3);
        }

        [Fact]
        public void CalculateTest_chaining()
        {
            var calculator = new Calculator.Calculator();

            var calculatedValue = calculator.Calculate("2+9*7-5");
            calculatedValue.Should().Be(60);
        }
    }
}
