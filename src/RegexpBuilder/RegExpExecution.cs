using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Acamti.RegexpBuilder
{
    public static class RegExpExecution
    {
        public static bool IsMatch(this RegExpPattern pattern, string input)
        {
            var regExp = new Regex(pattern.ToString());

            return regExp.IsMatch(input);
        }

        public static IEnumerable<string> Split(this RegExpPattern pattern, string input)
        {
            var regExp = new Regex(pattern.ToString());

            return regExp.Split(input);
        }

        public static MatchCollection Matches(
            this RegExpPattern pattern,
            string input) =>
            new Regex(pattern.ToString()).Matches(input);
    }
}
