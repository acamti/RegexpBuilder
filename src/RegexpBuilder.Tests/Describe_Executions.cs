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
            const string TRUE_MATCH_INPUT = "012-345-6789";
            const string FALSE_MATCH_INPUT = "(555)-555-5555";

            var pattern = RegExpPattern
                .With()
                .Value("-")
                .Repeat(p => p.AnyOneDigitCharacter(), 3, false)
                .Value("-");

            pattern.Split(TRUE_MATCH_INPUT).Should().BeEquivalentTo(expected);
            pattern.Split(FALSE_MATCH_INPUT).Should().NotBeEquivalentTo(expected);
        }
    }
}
