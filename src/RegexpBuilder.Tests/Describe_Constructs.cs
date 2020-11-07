using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_Constructs
    {
        [TestMethod]
        public void Test_Either_Constructs_Pattern()
        {
            const string EXPECTED = @"him|her";

            var pattern = new RegExpPattern()
                .Either(
                    i => i.Text("him"),
                    i => i.Text("her")
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Conditional_Constructs_Pattern()
        {
            const string EXPECTED = @"(?(\wi\w)him|her)";

            var pattern = new RegExpPattern()
                .ConditionalRule(
                    p => p
                        .Text("\\w", false)
                        .Text("i")
                        .Text("\\w", false),
                    p => p.Text("him"),
                    p => p.Text("her")
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Grouping_Constructs_Pattern()
        {
            const string EXPECTED = @"(\d)X(\d)F";

            var pattern = new RegExpPattern()
                .GroupOf(p => p.Text("\\d", false))
                .Text("X")
                .GroupOf(p => p.Text("\\d", false))
                .Text("F");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Grouping_Backreference_Constructs_Pattern()
        {
            const string EXPECTED = @"(\d)X\1F";

            var pattern = new RegExpPattern()
                .GroupOf(p => p.Text("\\d", false))
                .Text("X")
                .ValueFromGroup(1)
                .Text("F");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Grouping_Named_Backreference_Constructs_Pattern()
        {
            const string EXPECTED = @"(?<One>\d)x\k<One>F";

            var pattern = new RegExpPattern()
                .GroupOf(p => p.Text("\\d", false), "One")
                .Text("x")
                .ValueFromGroup("One")
                .Text("F");

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
