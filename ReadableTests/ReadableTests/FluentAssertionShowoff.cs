using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TestsSwissArmyKnife;
using Xunit;

namespace ReadableTests
{
    public class FluentAssertionShowoff
    {
        [Fact]
        public void Collections()
        {
            var stringCollection = new[] {"abc", "jkl", "qwe", "zxc",};

            stringCollection.Should().NotContainNulls();
            stringCollection.Should().OnlyContain(s => s.Length == 3);

            stringCollection.Should().ContainSingle(x => x == "zxc");
            stringCollection.Should().BeInAscendingOrder();
        }


    }
}
