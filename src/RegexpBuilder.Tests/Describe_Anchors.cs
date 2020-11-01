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

            var pattern = new RegExpPattern()
                .WithHardBegin()
                .WithValue("start");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_End_Anchors_Pattern()
        {
            const string EXPECTED = "end$";

            var pattern = new RegExpPattern()
                .WithValue("end")
                .WithHardStop();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_End_Is_Last_Rule_Anchors_Pattern()
        {
            Assert.ThrowsException<Exception>(
                () => new RegExpPattern()
                    .WithValue("end")
                    .WithHardStop()
                    .WithValue("not allowed")
            );
        }

        [TestMethod]
        public void Test_Word_Boundary_Pattern()
        {
            const string EXPECTED = @"\bare\w*\b";

            var pattern = new RegExpPattern()
                .WithWord(
                    p => p
                        .WithValue("are")
                        .WithZeroOrMore(p2 => p2.WithAnyOneWordCharacter())
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Word_Boundary_At_Beginning_Pattern()
        {
            const string EXPECTED = @"\bword123";

            var pattern = new RegExpPattern()
                .WithWord(
                    p => p
                        .WithValue("word")
                        .WithValue("123"),
                    true,
                    false
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Word_Boundary_At_End_Pattern()
        {
            const string EXPECTED = @"word123\b";

            var pattern = new RegExpPattern()
                .WithWord(
                    p => p
                        .WithValue("word")
                        .WithValue("123"),
                    false
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Boundary_Pattern()
        {
            const string EXPECTED = @"\Bgame\B";

            var pattern = new RegExpPattern()
                .WithNonWord(
                    p => p
                        .WithValue("game")
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Boundary_At_Beginning_Pattern()
        {
            const string EXPECTED = @"\bed";

            var pattern = new RegExpPattern()
                .WithWord(
                    p => p
                        .WithValue("ed"),
                    true,
                    false
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Boundary_At_End_Pattern()
        {
            const string EXPECTED = @"Wo\b";

            var pattern = new RegExpPattern()
                .WithWord(
                    p => p
                        .WithValue("Wo"),
                    false
                );

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
