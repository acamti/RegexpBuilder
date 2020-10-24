using System.Text.RegularExpressions;

namespace Acamti.RegexpBuilder
{
    public static class RegExpExecution
    {
        public static bool Match(this RegExpPattern pattern, string input)
        {
            var regExp = new Regex(pattern.ToString());

            return regExp.IsMatch(input);
        }
    }
}
