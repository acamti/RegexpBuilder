using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_Values
    {
        [TestMethod]
        public void Test_Simple_Text_Pattern()
        {
            const string EXPECTED = "winter";

            var pattern = RegExpPattern
                .With()
                .Value("winter");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Simple_Character_Pattern()
        {
            const string EXPECTED = "1";

            var pattern = RegExpPattern
                .With()
                .Value("1");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Repeat_Pattern()
        {
            const string EXPECTED = "^(?:6?6?6?)";

            var pattern = RegExpPattern
                .StartWith()
                .Group(
                    p => p.Repeat(
                        r => r.ZeroOrOne(p2 => p2.Value("6")),
                        3
                    )
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }
    }
}
