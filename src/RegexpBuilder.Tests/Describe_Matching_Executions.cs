using Acamti.RegexpBuilder.Rules;
using Acamti.RegexpBuilder.Types;
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
            var pattern = new RegExpPattern()
                .WithValue("dog");

            pattern.IsMatch("The quick brown fox jumps over the lazy dog")
                .Should()
                .BeTrue();
        }

        [TestMethod]
        public void Test_IsMatch_2()
        {
            var pattern = new RegExpPattern()
                .WithZeroOrMore(p => p.WithValue("a"))
                .WithValue("b");

            pattern.IsMatch("b").Should().BeTrue();
            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();
            pattern.IsMatch("abb").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_3()
        {
            var pattern = new RegExpPattern()
                .WithOneOrMore(p => p.WithValue("a"))
                .WithValue("b");

            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("b").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_4()
        {
            var pattern = new RegExpPattern()
                .WithZeroOrOne(p => p.WithValue("a"))
                .WithValue("b");

            pattern.IsMatch("b").Should().BeTrue();
            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();
            pattern.IsMatch("abb").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_5()
        {
            var pattern = new RegExpPattern()
                .WithZeroOrOne(p => p.WithValue("a"))
                .WithValue("b");

            pattern.IsMatch("b").Should().BeTrue();
            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("aab").Should().BeTrue();
            pattern.IsMatch("abb").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_6()
        {
            var pattern = new RegExpPattern()
                .WithAnyOneWordCharacter();

            pattern.IsMatch("a").Should().BeTrue();
            pattern.IsMatch("1").Should().BeTrue();

            pattern.IsMatch(".").Should().BeFalse();
            pattern.IsMatch(" ").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_7()
        {
            var pattern = new RegExpPattern()
                .WithAnyOneNonWordCharacter();

            pattern.IsMatch(".").Should().BeTrue();
            pattern.IsMatch(" ").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("1").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_8()
        {
            var pattern = new RegExpPattern()
                .WithAnyOneDigitCharacter();

            pattern.IsMatch("1").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch(".").Should().BeFalse();
            pattern.IsMatch(" ").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_9()
        {
            var pattern = new RegExpPattern()
                .WithEither(
                    s1 => s1.WithValue("him"),
                    s2 => s2.WithValue("her"));

            pattern.IsMatch("him").Should().BeTrue();
            pattern.IsMatch("her").Should().BeTrue();

            pattern.IsMatch("they").Should().BeFalse();
            pattern.IsMatch("them").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_10()
        {
            var pattern = new RegExpPattern()
                .WithConditionalRule(
                    c => c.WithAnyOneWordCharacter().WithValue("i").WithAnyOneWordCharacter(),
                    t => t.WithValue("him"),
                    f => f.WithValue("her"));

            pattern.IsMatch("him").Should().BeTrue();
            pattern.IsMatch("her").Should().BeTrue();

            pattern.IsMatch("they").Should().BeFalse();
            pattern.IsMatch("them").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_11()
        {
            var pattern = new RegExpPattern()
                .WithHardBegin()
                .WithValue("hi");

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
            var pattern = new RegExpPattern()
                .WithValue("hi")
                .WithHardStop();

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
            var pattern = new RegExpPattern()
                .WithWord(
                    p => p
                        .WithValue("are")
                        .WithZeroOrMore(p2 => p2.WithAnyOneWordCharacter())
                );

            pattern.IsMatch("area").Should().BeTrue();
            pattern.IsMatch("arena").Should().BeTrue();

            pattern.IsMatch("bare").Should().BeFalse();
            pattern.IsMatch("mare").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_16()
        {
            var pattern = new RegExpPattern()
                .WithNonWord(
                    p => p
                        .WithValue("qu")
                        .WithOneOrMore(p2 => p2.WithAnyOneWordCharacter()),
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
            var pattern = new RegExpPattern()
                .WithCharacterRange('A', 'Z');

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
            var pattern = new RegExpPattern()
                .WithCharacterRangeWithException('A', 'Z', 'N');

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
            var pattern = new RegExpPattern()
                .WithCharacterRangeWithException('A', 'Z', 'M', 'P');

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
            var pattern = new RegExpPattern()
                .OnlyIfAheadIs(p => p.WithValue("b"), p => p.WithValue("a"));

            pattern.IsMatch("ab").Should().BeTrue();
            pattern.IsMatch("cab").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("b").Should().BeFalse();
            pattern.IsMatch("ca").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_21()
        {
            var pattern = new RegExpPattern()
                .OnlyIfAheadIsNot(p => p.WithValue("b"), p => p.WithValue("a"));

            pattern.IsMatch("a").Should().BeTrue();
            pattern.IsMatch("ca").Should().BeTrue();

            pattern.IsMatch("b").Should().BeFalse();
            pattern.IsMatch("ab").Should().BeFalse();
            pattern.IsMatch("cab").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_22()
        {
            var pattern = new RegExpPattern()
                .OnlyIfBehindIs(p => p.WithValue("c"), p => p.WithValue("a"));

            pattern.IsMatch("ca").Should().BeTrue();
            pattern.IsMatch("cab").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("b").Should().BeFalse();
            pattern.IsMatch("ab").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_23()
        {
            var pattern = new RegExpPattern()
                .OnlyIfBehindIsNot(p => p.WithValue("c"), p => p.WithValue("a"));

            pattern.IsMatch("a").Should().BeTrue();
            pattern.IsMatch("ab").Should().BeTrue();

            pattern.IsMatch("b").Should().BeFalse();
            pattern.IsMatch("ca").Should().BeFalse();
            pattern.IsMatch("cab").Should().BeFalse();
        }

        [TestMethod]
        [DataRow("a", "A", WordCharacter.WordCharacterType.LowerCase)]
        public void Test_IsMatch_24(
            string match,
            string noMatch,
            WordCharacter.WordCharacterType wordType)
        {
            var pattern = new RegExpPattern()
                .WithAnyOneWordOfCharacterType(wordType);

            pattern.IsMatch(match).Should().BeTrue();

            pattern.IsMatch(noMatch).Should().BeFalse();
        }

        [TestMethod]
        [DataRow("A", "a", WordCharacter.WordCharacterType.LowerCase)]
        public void Test_IsMatch_25(
            string match,
            string noMatch,
            WordCharacter.WordCharacterType wordType)
        {
            var pattern = new RegExpPattern()
                .WithAnyOneWordNotOfCharacterType(wordType);

            pattern.IsMatch(match).Should().BeTrue();

            pattern.IsMatch(noMatch).Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_26()
        {
            var pattern = new RegExpPattern()
                .WithCharacter('❎');

            pattern.IsMatch("❎").Should().BeTrue();

            pattern.IsMatch("Q").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_27()
        {
            var pattern = new RegExpPattern()
                .WithAnyOneOfTheseCharacters("ae");

            pattern.IsMatch("gray").Should().BeTrue();

            pattern.IsMatch("guy").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_28()
        {
            var pattern = new RegExpPattern()
                .WithAnyOneOfNotTheseCharacters("aei");

            pattern.IsMatch("reign").Should().BeTrue();

            pattern.IsMatch("aei").Should().BeFalse();
        }
    }
}
