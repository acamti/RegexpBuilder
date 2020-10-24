using System.Collections.Generic;
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
            const string EXPECTED = @"(him|her)";

            var trueMatchInputs = new List<string>(new[] { "him", "her" });
            var falseMatchInputs = new List<string>(new[] { "they", "them" });

            var pattern = RegExpPattern
                .With()
                .Either(
                    p => p.Value("him", false),
                    p => p.Value("her", false)
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
            trueMatchInputs.ForEach(t => pattern.Match(t).Should().BeTrue());
            falseMatchInputs.ForEach(t => pattern.Match(t).Should().BeFalse());
        }
    }
}
