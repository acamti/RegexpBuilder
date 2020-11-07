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
                .AtStartOfStringOrLine()
                .Text("start");

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_End_Anchors_Pattern()
        {
            const string EXPECTED = "end$";

            var pattern = new RegExpPattern()
                .Text("end")
                .AtEndOfStringOrLine();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_Word_Boundary_Pattern()
        {
            const string EXPECTED = @"\bare\b";

            var pattern = new RegExpPattern()
                .WithWordBoundary(
                    p => p
                        .Text("are")
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

        [TestMethod]
        public void Test_End_Of_String_Pattern()
        {
            const string EXPECTED = @"abc\z";

            var pattern = new RegExpPattern()
                .Text("abc")
                .AtEndOfStringOnly();

            pattern.ToString().Should().Be(EXPECTED);
        }

        [TestMethod]
        public void Test_End_Of_String_Or_Before_New_Line_Pattern()
        {
            const string EXPECTED = @"abc\Z";

            var pattern = new RegExpPattern()
                .Text("abc")
                .AtEndOfStringOrBeforeNewLine();

            pattern.ToString().Should().Be(EXPECTED);
        }
    }
}
