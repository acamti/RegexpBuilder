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

        public static RegExpPattern ZeroOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(RegExpPattern.With());

            var ruleToAdd = IsText(ruleToExtract)
                ? RegExpPattern.With().Group(p => p.Value(ruleToExtract.ToString()))
                : RegExpPattern.With().Value(ruleToExtract.ToString());

            pattern.Value($"{ruleToAdd}*");

            return pattern;
        }

        public static RegExpPattern OneOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(RegExpPattern.With());

            var ruleToAdd = IsText(ruleToExtract)
                ? RegExpPattern.With().Group(p => p.Value(ruleToExtract.ToString()))
                : RegExpPattern.With().Value(ruleToExtract.ToString());

            pattern.Value($"{ruleToAdd}+");

            return pattern;
        }

        public static RegExpPattern ZeroOrOne(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(RegExpPattern.With());

            var ruleToAdd = IsText(ruleToExtract)
                ? RegExpPattern.With().Group(p => p.Value(ruleToExtract.ToString()))
                : RegExpPattern.With().Value(ruleToExtract.ToString());

            pattern.Value($"{ruleToAdd}?");

            return pattern;
        }
    }
}
