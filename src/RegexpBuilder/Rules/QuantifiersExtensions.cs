using System;

namespace Acamti.RegexpBuilder.Rules
{
    public static class QuantifiersExtensions
    {
        private static bool IsText(RegExpPattern ruleToExtract)
        {
            var text = ruleToExtract.ToString();

            switch (text.Length)
            {
                case 1:
                case 2 when text[0] == '\\':
                    return false;
                default: return true;
            }
        }

        public static RegExpPattern WithZeroOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            var ruleToAdd = IsText(ruleToExtract)
                ? new RegExpPattern().WithGroup(p => p.WithValue(ruleToExtract.ToString()))
                : new RegExpPattern().WithValue(ruleToExtract.ToString());

            pattern.WithValue($"{ruleToAdd}*");

            return pattern;
        }

        public static RegExpPattern WithOneOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            var ruleToAdd = IsText(ruleToExtract)
                ? new RegExpPattern().WithGroup(p => p.WithValue(ruleToExtract.ToString()))
                : new RegExpPattern().WithValue(ruleToExtract.ToString());

            pattern.WithValue($"{ruleToAdd}+");

            return pattern;
        }

        public static RegExpPattern WithZeroOrOne(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(new RegExpPattern());

            var ruleToAdd = IsText(ruleToExtract)
                ? new RegExpPattern().WithGroup(p => p.WithValue(ruleToExtract.ToString()))
                : new RegExpPattern().WithValue(ruleToExtract.ToString());

            pattern.WithValue($"{ruleToAdd}?");

            return pattern;
        }
    }
}
