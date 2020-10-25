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

        public static string[] Split(this RegExpPattern pattern, string input)
        {
            var regExp = new Regex(pattern.ToString());

            return regExp.Split(input);
        }
    }
}
