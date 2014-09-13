using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace ReadableTests
{
    public class CalculatorTests
    {
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
