using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_Executions
    {
        [TestMethod]
        public void Test_Split_Execution()
        {
            var expected = new[] { "012", "6789" };

            var pattern = new RegExpPattern()
                .Text("-")
                .Repeat(p => p.AnyOneDigit(), 3)
                .Text("-");

            pattern.Split("012-345-6789").Should().BeEquivalentTo(expected);
            pattern.Split("(555)-555-5555").Should().NotBeEquivalentTo(expected);
        }
    }
}
