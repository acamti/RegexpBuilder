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
                .MustBeginWith()
                .Text("start");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_End_Anchors_Pattern()
        {
            const string EXPECTED = "end$";

            var pattern = new RegExpPattern()
                .Text("end")
                .MustStopWith();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_End_Is_Last_Rule_Anchors_Pattern()
        {
            Assert.ThrowsException<Exception>(
                () => new RegExpPattern()
                    .Text("end")
                    .MustStopWith()
                    .Text("not allowed")
            );
        }

        [TestMethod]
        public void Test_Word_Boundary_Pattern()
        {
            const string EXPECTED = @"\bare\w*\b";

            var pattern = new RegExpPattern()
                .WithWordBoundary(
                    p => p
                        .Text("are")
                        .ZeroOrMoreOf(p2 => p2.AnyWordCharacter())
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Word_Boundary_At_Beginning_Pattern()
        {
            const string EXPECTED = @"\bword123";

            var pattern = new RegExpPattern()
                .WithWordBoundary(
                    p => p
                        .Text("word")
                        .Text("123"),
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
                .WithWordBoundary(
                    p => p
                        .Text("word")
                        .Text("123"),
                    false
                );

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Boundary_Pattern()
        {
            const string EXPECTED = @"\Bgame\B";

            var pattern = new RegExpPattern()
                .WithNonWordBoundary(p => p.Text("game"));

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Non_Word_Boundary_At_Beginning_Pattern()
        {
            const string EXPECTED = @"\bed";

            var pattern = new RegExpPattern()
                .WithWordBoundary(
                    p =>
                        p.Text("ed"),
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
                .WithWordBoundary(p => p.Text("Wo"), false);

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Matching_Where_Previous_Match_Ended_Pattern()
        {
            const string EXPECTED = @"\G";

            var pattern = new RegExpPattern()
                .ByOnlyMatchingWherePreviousMatchEnded();

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
