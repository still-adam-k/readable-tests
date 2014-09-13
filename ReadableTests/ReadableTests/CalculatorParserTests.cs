using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using FluentAssertions;
using Xunit;

namespace ReadableTests
{
    public class CalculatorParserTests
    {
        [Fact]
        public void Build_Expression_Test_1()
        {
            var parameters = new[] { "2" };
            var builder = new ExpressionBuilder();

            var node = builder.BuildExpression(parameters);
            var calculatedValue = node.CalculateValue();

            calculatedValue.Should().Be(2);
        }

        [Fact]
        public void Build_Expression_Test_2()
        {
            var parameters = new[] { "3","+","9" };
            var builder = new ExpressionBuilder();

            var node = builder.BuildExpression(parameters);
            var calculatedValue = node.CalculateValue();

            calculatedValue.Should().Be(12);
        }

        [Fact]
        public void Build_Expression_Test_3()
        {
            var parameters = new[] { "2","+","5","/","2" };
            var builder = new ExpressionBuilder();

            var node = builder.BuildExpression(parameters);
            var calculatedValue = node.CalculateValue();

            calculatedValue.Should().Be(4.5);
        }

        [Fact]
        public void Build_Expression_Test_4()
        {
            var parameters = new[] { "2", "+", "3","*","89", "/", "6" };
            var builder = new ExpressionBuilder();

            var node = builder.BuildExpression(parameters);
            var calculatedValue = node.CalculateValue();

            calculatedValue.Should().Be(46.5);
        }

        [Fact]
        public void Build_Expression_Test_5()
        {
            var parameters = new[] { "2", "+", "3", "*", "8", "-", "6" };
            var builder = new ExpressionBuilder();

            var node = builder.BuildExpression(parameters);
            var calculatedValue = node.CalculateValue();

            calculatedValue.Should().Be(20);
        }
    }
}
