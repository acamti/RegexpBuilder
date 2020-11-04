using System.Collections.Generic;
using System.Linq;
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

        public static IEnumerable<(int index, string name, string value)> Groups(
            this RegExpPattern pattern,
            string input)
        {
            var regExp = new Regex(pattern.ToString());

            return regExp
                .Match(input)
                .Groups
                .Values
                .Where((_, y) => y > 0)
                .Select(g => ( g.Index, g.Name, g.Value ));
        }
    }
}
