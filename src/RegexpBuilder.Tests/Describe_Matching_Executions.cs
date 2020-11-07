using System;
using System.Text.RegularExpressions;
using Acamti.RegexpBuilder.Rules;
using Acamti.RegexpBuilder.Types;
using Acamti.RegexpBuilder.Types.RegExpCharacter;
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
                .Text("dog");

            pattern.IsMatch("The quick brown fox jumps over the lazy dog")
                .Should()
                .BeTrue();
        }

        [TestMethod]
        public void Test_IsMatch_2()
        {
            var pattern = new RegExpPattern()
                .ZeroOrMoreOf(p => p.Text("a"))
                .Text("b");

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
                .OneOrMoreOf(p => p.Text("a"))
                .Text("b");

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
                .ZeroOrOneOf(p => p.Text("a"))
                .Text("b");

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
                .ZeroOrOneOf(p => p.Text("a"))
                .Text("b");

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
                .AnyWordCharacter();

            pattern.IsMatch("a").Should().BeTrue();
            pattern.IsMatch("1").Should().BeTrue();

            pattern.IsMatch(".").Should().BeFalse();
            pattern.IsMatch(" ").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_7()
        {
            var pattern = new RegExpPattern()
                .AnyNonWordCharacter();

            pattern.IsMatch(".").Should().BeTrue();
            pattern.IsMatch(" ").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("1").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_8()
        {
            var pattern = new RegExpPattern()
                .AnyOneDigit();

            pattern.IsMatch("1").Should().BeTrue();

            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch(".").Should().BeFalse();
            pattern.IsMatch(" ").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_9()
        {
            var pattern = new RegExpPattern()
                .Either(
                    s1 => s1.Text("him"),
                    s2 => s2.Text("her"));

            pattern.IsMatch("him").Should().BeTrue();
            pattern.IsMatch("her").Should().BeTrue();

            pattern.IsMatch("they").Should().BeFalse();
            pattern.IsMatch("them").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_10()
        {
            var pattern = new RegExpPattern()
                .ConditionalRule(
                    c => c.AnyWordCharacter().Text("i").AnyWordCharacter(),
                    t => t.Text("him"),
                    f => f.Text("her"));

            pattern.IsMatch("him").Should().BeTrue();
            pattern.IsMatch("her").Should().BeTrue();

            pattern.IsMatch("they").Should().BeFalse();
            pattern.IsMatch("them").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_11()
        {
            var pattern = new RegExpPattern()
                .AtStartOfStringOrLine()
                .Text("hi");

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
                .Text("hi")
                .AtEndOfStringOnly();

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
                .WithWordBoundary(
                    p => p
                        .Text("are")
                        .ZeroOrMoreOf(p2 => p2.AnyWordCharacter())
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
                .WithNonWordBoundary(
                    p => p
                        .Text("qu")
                        .OneOrMoreOf(p2 => p2.AnyWordCharacter()),
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
            var pattern = new RegExpPattern()
                .CharacterRange('A', 'Z', "NJ");

            pattern.IsMatch("A").Should().BeTrue();
            pattern.IsMatch("B").Should().BeTrue();
            pattern.IsMatch("Z").Should().BeTrue();
            pattern.IsMatch("AA").Should().BeTrue();

            pattern.IsMatch("").Should().BeFalse();
            pattern.IsMatch("a").Should().BeFalse();
            pattern.IsMatch("N").Should().BeFalse();
            pattern.IsMatch("J").Should().BeFalse();
            pattern.IsMatch("z").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_19()
        {
            var pattern = new RegExpPattern()
                .CharacterRange('A', 'Z', 'M', 'P');

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
                .OnlyIfAheadIs(p => p.Text("b"), p => p.Text("a"));

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
                .OnlyIfAheadIsNot(p => p.Text("b"), p => p.Text("a"));

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
                .OnlyIfBehindIs(p => p.Text("c"), p => p.Text("a"));

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
                .OnlyIfBehindIsNot(p => p.Text("c"), p => p.Text("a"));

            pattern.IsMatch("a").Should().BeTrue();
            pattern.IsMatch("ab").Should().BeTrue();

            pattern.IsMatch("b").Should().BeFalse();
            pattern.IsMatch("ca").Should().BeFalse();
            pattern.IsMatch("cab").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_24()
        {
            const string EXPECTED = @"\b[A-Z]\w*\b";

            var pattern = new RegExpPattern()
                .WithWordBoundary(
                    p =>
                        p.CharacterRange('A', 'Z')
                            .ZeroOrMoreOf(
                                p2 => p2.AnyWordCharacter()));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_IsMatch_25()
        {
            const string EXPECTED = @"\bth[^o]\w+\b";

            var pattern = new RegExpPattern()
                .WithWordBoundary(
                    p => p
                        .Text("th")
                        .AnyCharacterOtherThan(RegExpCharacter.Build('o'))
                        .OneOrMoreOf(p3 => p3.AnyWordCharacter())
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_IsMatch_26()
        {
            var pattern = new RegExpPattern()
                .Character('❎');

            pattern.IsMatch("❎").Should().BeTrue();

            pattern.IsMatch("Q").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_27()
        {
            var pattern = new RegExpPattern()
                .AnyCharacter("ae");

            pattern.IsMatch("gray").Should().BeTrue();

            pattern.IsMatch("guy").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_28()
        {
            var pattern = new RegExpPattern()
                .AnyCharacterOtherThan("aei");

            pattern.IsMatch("reign").Should().BeTrue();

            pattern.IsMatch("aei").Should().BeFalse();
        }

        [TestMethod]
        public void Test_IsMatch_29()
        {
            const string EXPECTED_REGEX_PATTERN = @"\G(.+)[\t\u007C](.+)\r?\n";

            var pattern = new RegExpPattern()
                .ByOnlyMatchingWherePreviousMatchEnded()
                .GroupOf(
                    p1 => p1.OneOrMoreOf(p2 => p2.AnyCharacter()))
                .AnyCharacter(
                    RegExpEscapeCharacter.Build(EscapeCharacter.EscapeCharacterType.Tab),
                    RegExpCharacter.Build('|', true))
                .GroupOf(
                    p1 => p1.OneOrMoreOf(p2 => p2.AnyCharacter()))
                .ZeroOrOneOf(p => p.Character(EscapeCharacter.EscapeCharacterType.CarriageReturn))
                .Character(EscapeCharacter.EscapeCharacterType.NewLine);

            pattern.ToString().Should().Be(EXPECTED_REGEX_PATTERN);

            const string INPUT = "Mumbai, India|13,922,125\t\n" +
                "Shanghai, China\t13,831,900\n" +
                "Karachi, Pakistan|12,991,000\n" +
                "Delhi, India\t12,259,230\n" +
                "Istanbul, Turkey|11,372,613\n";

            Console.WriteLine("Population of the World's Largest Cities, 2009");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,10}", "City", "Population");
            Console.WriteLine();

            foreach (Match match in pattern.Matches(INPUT))
            {
                Console.WriteLine("{0,-20} {1,10}",
                                  match.Groups[1].Value,
                                  match.Groups[2].Value);
            }
        }

        [TestMethod]
        public void Test_IsMatch_30()
        {
            const string EXPECTED = @"gr[ae]y\s\S+?[\s\p{P}]";

            var pattern = new RegExpPattern()
                .Text("gr")
                .AnyCharacter("ae")
                .Text("y")
                .Character(EscapeCharacter.EscapeCharacterType.WhiteSpace)
                .OneOrMoreOf(
                    p => p.Character(EscapeCharacter.EscapeCharacterType.NonWhiteSpace),
                    true
                )
                .AnyCharacter(
                    RegExpEscapeCharacter.Build(EscapeCharacter.EscapeCharacterType.WhiteSpace),
                    RegExpWordCharacter.Build(WordCharacter.WordCharacterType.Punctuation, true));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_IsMatch_31()
        {
            const string EXPECTED = @"^.+";

            var pattern = new RegExpPattern()
                .AtStartOfStringOrLine()
                .OneOrMoreOf(p => p.AnyCharacter());

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_IsMatch_32()
        {
            const string EXPECTED = @"\b.*[.?!;:](\s|\z)";

            var pattern = new RegExpPattern()
                .WithWordBoundary(
                    p => p
                        .ZeroOrMoreOf(p2 => p2.AnyCharacter())
                        .AnyCharacter(".?!;:")
                        .GroupOf(
                            p2 => p2
                                .Either(
                                    p3 => p3.Character(EscapeCharacter.EscapeCharacterType.WhiteSpace),
                                    p3 => p3.AtEndOfStringOnly()
                                )),
                    true,
                    false);

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_IsMatch_33()
        {
            const string EXPECTED = @"(\w)\1";

            var pattern = new RegExpPattern()
                .GroupOf(p => p.AnyWordCharacter())
                .ValueFromGroup(1);

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_IsMatch_34()
        {
            const string EXPECTED = @"\b(\w+)(\W){1,2}";

            var pattern = new RegExpPattern()
                .WithWordBoundary(
                    p => p.GroupOf(
                            p1 => p1.OneOrMoreOf(
                                p2 => p2.AnyWordCharacter()))
                        .Time(
                            p1 => p1.GroupOf(
                                p2 => p2.AnyNonWordCharacter()),
                            1,
                            2),
                    true,
                    false
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_IsMatch_35()
        {
            const string EXPECTED = @"\b\w+(e)?s(\s|$)";

            var pattern = new RegExpPattern()
                .WithWordBoundary(
                    p => p.OneOrMoreOf(p1 => p1.AnyWordCharacter())
                        .ZeroOrOneOf(p1 => p1.GroupOf(p2 => p2.Text("e")))
                        .Text("s")
                        .GroupOf(
                            p1 => p1.Either(
                                p2 => p2.Character(EscapeCharacter.EscapeCharacterType.WhiteSpace),
                                p3 => p3.AtEndOfStringOrLine()
                            )),
                    true,
                    false);

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_IsMatch_36()
        {
            const string EXPECTED = @"^(\(?\d{3}\)?[\s-])?\d{3}-\d{4}$";

            var pattern = new RegExpPattern()
                .AtStartOfStringOrLine()
                .ZeroOrOneOf(
                    p => p.GroupOf(
                        p1 => p1
                            .ZeroOrOneOf(p2 => p2.Character('('))
                            .Time(p2 => p2.AnyOneDigit(), 3)
                            .ZeroOrOneOf(p2 => p2.Character(')'))
                            .AnyCharacter(
                                RegExpEscapeCharacter.Build(EscapeCharacter.EscapeCharacterType.WhiteSpace),
                                RegExpCharacter.Build('-'))))
                .Time(p => p.AnyOneDigit(), 3)
                .Text("-")
                .Time(p => p.AnyOneDigit(), 4)
                .AtEndOfStringOrLine();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_IsMatch_37()
        {
            const string EXPECTED = @"^[0-9-[2468]]+$";

            var pattern = new RegExpPattern()
                .OneOrMoreOf(
                    p => p
                        .AtStartOfStringOrLine()
                        .CharacterRange('0', '9', "2468")
                )
                .AtEndOfStringOrLine();

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
