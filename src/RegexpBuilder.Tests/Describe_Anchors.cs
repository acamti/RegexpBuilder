using System;
using Acamti.RegexpBuilder.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acamti.RegexpBuilder.Tests
{
    [TestClass]
    public class Describe_Anchors
    {
        [TestMethod]
        public void Test_Start_Anchors_Pattern()
        {
            const string EXPECTED = "^start";

            var pattern = RegExpPattern
                .With(true)
                .Value("start");

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_End_Anchors_Pattern()
        {
            const string EXPECTED = "end$";

            var pattern = RegExpPattern
                .With()
                .Value("end")
                .Stop();

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_End_Is_Last_Rule_Anchors_Pattern()
        {
            Assert.ThrowsException<Exception>(
                () => RegExpPattern
                    .With()
                    .Value("end")
                    .Stop()
                    .Value("not allowed")
            );
        }

        [TestMethod]
        public void Test_Word_Boundary_Pattern()
        {
            const string EXPECTED = @"\bare\w*\b";

            var pattern = RegExpPattern
                .With()
                .Word(
                    p => p
                        .Value("are")
                        .ZeroOrMore(p2 => p2.AnyOneWordCharacter())
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Word_Boundary_At_Beginning_Pattern()
        {
            const string EXPECTED = @"\bword123";

            var pattern = RegExpPattern
                .With()
                .Word(
                    p => p
                        .Value("word")
                        .Value("123"),
                    true,
                    false
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Word_Boundary_At_End_Pattern()
        {
            const string EXPECTED = @"word123\b";

            var pattern = RegExpPattern
                .With()
                .Word(
                    p => p
                        .Value("word")
                        .Value("123"),
                    false
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Boundary_Pattern()
        {
            const string EXPECTED = @"\Bgame\B";

            var pattern = RegExpPattern
                .With()
                .NonWord(
                    p => p
                        .Value("game")
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Boundary_At_Beginning_Pattern()
        {
            const string EXPECTED = @"\Bed";

            var pattern = RegExpPattern
                .With()
                .Word(
                    p => p
                        .Value("ed"),
                    true,
                    false
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Boundary_At_End_Pattern()
        {
            const string EXPECTED = @"Wo\b";

            var pattern = RegExpPattern
                .With()
                .Word(
                    p => p
                        .Value("Wo"),
                    false
                );

            pattern.ToString().Should().BeEquivalentTo(EXPECTED);
        }
    }
}
