using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_Matching_Executions
    {
        [TestMethod]
        public void Test_IsMatch_1()
        {
            var pattern = RegExpPattern.With()
                .Value("dog");

            pattern.IsMatch("The quick brown fox jumps over the lazy dog")
                .Should()
                .BeTrue();
        }

        [TestMethod]
        public void Test_IsMatch_2()
        {
            var pattern = RegExpPattern.With()
                .ZeroOrMore(p => p.Value("a"))
                .Value("b");

            pattern.IsMatch("b").Should().BeTrue();
            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();
            pattern.IsMatch("abb").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_3()
        {
            var pattern = RegExpPattern.With()
                .OneOrMore(p => p.Value("a"))
                .Value("b");

            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("b").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_4()
        {
            var pattern = RegExpPattern.With()
                .ZeroOrOne(p => p.Value("a"))
                .Value("b");

            pattern.IsMatch("b").Should().BeTrue();
            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();
            pattern.IsMatch("abb").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_5()
        {
            var pattern = RegExpPattern.With()
                .ZeroOrOne(p => p.Value("a"))
                .Value("b");

            pattern.IsMatch("b").Should().BeTrue();
            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();
            pattern.IsMatch("abb").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_6()
        {
            var pattern = RegExpPattern.With()
                .AnyOneWordCharacter();

            pattern.IsMatch("a").Should().BeTrue();
            pattern.IsMatch("1").Should().BeTrue();

            pattern.IsMatch(".").Should().BeFalse();
            pattern.IsMatch(" ").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_7()
        {
            var pattern = RegExpPattern.With()
                .AnyOneNonWordCharacter();

            pattern.IsMatch(".").Should().BeTrue();
            pattern.IsMatch(" ").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("1").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_8()
        {
            var pattern = RegExpPattern.With()
                .AnyOneDigitCharacter();

            pattern.IsMatch("1").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch(".").Should().BeFalse();
            pattern.IsMatch(" ").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_9()
        {
            var pattern = RegExpPattern.With()
                .Either(
                    s1 => s1.Value("him"),
                    s2 => s2.Value("her"));

            pattern.IsMatch("him").Should().BeTrue();
            pattern.IsMatch("her").Should().BeTrue();

            pattern.IsMatch("they").Should().BeFalse();
            pattern.IsMatch("them").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_10()
        {
            var pattern = RegExpPattern.With()
                .ConditionallyRule(
                    c => c.AnyOneWordCharacter().Value("i").AnyOneWordCharacter(),
                    t => t.Value("him"),
                    f => f.Value("her"));

            pattern.IsMatch("him").Should().BeTrue();
            pattern.IsMatch("her").Should().BeTrue();

            pattern.IsMatch("they").Should().BeFalse();
            pattern.IsMatch("them").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_11()
        {
            var pattern = RegExpPattern
                .With(true)
                .Value("hi");

            pattern.IsMatch("hi").Should().BeTrue();
            pattern.IsMatch("him").Should().BeTrue();
            pattern.IsMatch("hi ").Should().BeTrue();
            pattern.IsMatch("him ").Should().BeTrue();

            pattern.IsMatch(" hi").Should().BeFalse();
            pattern.IsMatch(" him").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_12()
        {
            var pattern = RegExpPattern.With()
                .Value("hi")
                .Stop();

            pattern.IsMatch("hi").Should().BeTrue();
            pattern.IsMatch(" hi").Should().BeTrue();

            pattern.IsMatch("hi ").Should().BeFalse();
            pattern.IsMatch("him").Should().BeFalse();
            pattern.IsMatch(" him").Should().BeFalse();
            pattern.IsMatch(" him ").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_13()
        {
            var pattern = RegExpPattern
                .With()
                .Word(
                    p => p
                        .Value("are")
                        .ZeroOrMore(p2 => p2.AnyOneWordCharacter())
                );

            pattern.IsMatch("area").Should().BeTrue();
            pattern.IsMatch("arena").Should().BeTrue();

            pattern.IsMatch("bare").Should().BeFalse();
            pattern.IsMatch("mare").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_16()
        {
            var pattern = RegExpPattern
                .With()
                .NonWord(
                    p => p
                        .Value("qu")
                        .OneOrMore(p2 => p2.AnyOneWordCharacter()),
                    true,
                    false
                );

            pattern.IsMatch("equity").Should().BeTrue();
            pattern.IsMatch("equip").Should().BeTrue();
            pattern.IsMatch("acquaint").Should().BeTrue();

            pattern.IsMatch("queen").Should().BeFalse();
            pattern.IsMatch("quiet").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_17()
        {
            var pattern = RegExpPattern
                .With()
                .CharacterRange('A', 'Z');

            pattern.IsMatch("A").Should().BeTrue();
            pattern.IsMatch("B").Should().BeTrue();
            pattern.IsMatch("Z").Should().BeTrue();
            pattern.IsMatch("AA").Should().BeTrue();

            pattern.IsMatch("").Should().BeFalse();
            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("z").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_18()
        {
            var pattern = RegExpPattern
                .With()
                .CharacterRangeWithException('A', 'Z', 'N');

            pattern.IsMatch("A").Should().BeTrue();
            pattern.IsMatch("B").Should().BeTrue();
            pattern.IsMatch("Z").Should().BeTrue();
            pattern.IsMatch("AA").Should().BeTrue();

            pattern.IsMatch("").Should().BeFalse();
            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("N").Should().BeFalse();
            pattern.IsMatch("z").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_19()
        {
            var pattern = RegExpPattern
                .With()
                .CharacterRangeWithException('A', 'Z', 'M', 'P');

            pattern.IsMatch("A").Should().BeTrue();
            pattern.IsMatch("B").Should().BeTrue();
            pattern.IsMatch("Z").Should().BeTrue();
            pattern.IsMatch("AA").Should().BeTrue();

            pattern.IsMatch("").Should().BeFalse();
            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("M").Should().BeFalse();
            pattern.IsMatch("N").Should().BeFalse();
            pattern.IsMatch("O").Should().BeFalse();
            pattern.IsMatch("P").Should().BeFalse();
            pattern.IsMatch("z").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_20()
        {
            var pattern = RegExpPattern
                .With()
                .OnlyIfAheadIs(p => p.Value("b"), p => p.Value("a"));

            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("cab").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("b").Should().BeFalse();
            pattern.IsMatch("ca").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_21()
        {
            var pattern = RegExpPattern
                .With()
                .OnlyIfAheadIsNot(p => p.Value("b"), p => p.Value("a"));

            pattern.IsMatch("a").Should().BeTrue();
            pattern.IsMatch("ca").Should().BeTrue();

            pattern.IsMatch("b").Should().BeFalse();
            pattern.IsMatch("ab").Should().BeFalse();
            pattern.IsMatch("cab").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_22()
        {
            var pattern = RegExpPattern
                .With()
                .OnlyIfBehindIs(p => p.Value("c"), p => p.Value("a"));

            pattern.IsMatch("ca").Should().BeTrue();
            pattern.IsMatch("cab").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("b").Should().BeFalse();
            pattern.IsMatch("ab").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_23()
        {
            var pattern = RegExpPattern
                .With()
                .OnlyIfBehindIsNot(p => p.Value("c"), p => p.Value("a"));

            pattern.IsMatch("a").Should().BeTrue();
            pattern.IsMatch("ab").Should().BeTrue();

            pattern.IsMatch("b").Should().BeFalse();
            pattern.IsMatch("ca").Should().BeFalse();
            pattern.IsMatch("cab").Should().BeFalse();
        }
    }
}
