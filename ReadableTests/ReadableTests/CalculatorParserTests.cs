using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using FluentAssertions;
using Xunit;
using Xunit.Extensions;

namespace ReadableTests
{
    public class CalculatorParserTests
    {
        [Theory]
        [InlineData(1, 2, "2", "", "", "", "", "", "")]
        [InlineData(3, 12, "3", "+", "9", "", "", "", "")]
        [InlineData(5, 4.5, "2", "+", "5", "/", "2", "", "")]
        [InlineData(7, 46.5, "2", "+", "3", "*", "89", "/", "6")]
        [InlineData(7, 20, "2", "+", "3", "*", "8", "-", "6")]
        public void BuildExpressionTest(int count, double value, string p1, string p2, string p3, string p4, string p5, string p6, string p7)
        {
            var parameters = new[] { p1, p2, p3, p4, p5, p6, p7 };
            var builder = new ExpressionBuilder();

            var node = builder.BuildExpression(parameters.Where((x, i) => i < count).ToList());
            var calculatedValue = node.CalculateValue();

            calculatedValue.Should().Be(value);
        }

        public static IEnumerable<object[]> SampleExpressionData
        {
            get
            {
                yield return new object[] { 2, new string[] { "2" } };
                yield return new object[] { 12, new string[] { "3", "+", "9" } };
                yield return new object[] {4.5, new string[] { "2", "+", "5", "/", "2" } };
                yield return new object[] { 46.5, new string[] { "2", "+", "3", "*", "89", "/", "6" } };
                yield return new object[] { 20, new string[] { "2", "+", "3", "*", "8", "-", "6" } };
            }
        }

        [Theory]
        [PropertyData("SampleExpressionData")]
        public void BuildExpressionTest_pretty(double value, string[] expressions)
        {
            var builder = new ExpressionBuilder();

            var node = builder.BuildExpression(expressions);
            var calculatedValue = node.CalculateValue();

            calculatedValue.Should().Be(value);
        }

    }
}
