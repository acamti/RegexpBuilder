using System;

namespace Acamti.RegexpBuilder.Rules
{
    public static class QuantifiersExtensions
    {
        public static RegExpPattern ZeroOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(RegExpPattern.With());

            var ruleToAdd = ruleToExtract.ToString().Length == 1
                ? RegExpPattern.With().Value(ruleToExtract.ToString())
                : RegExpPattern.With().Grouped(p => p.Value(ruleToExtract.ToString()));

            pattern.Value($"{ruleToAdd}*");

            return pattern;
        }

        public static RegExpPattern OneOrMore(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(RegExpPattern.With());

            var ruleToAdd = ruleToExtract.ToString().Length == 1
                ? RegExpPattern.With().Value(ruleToExtract.ToString())
                : RegExpPattern.With().Grouped(p => p.Value(ruleToExtract.ToString()));

            pattern.Value($"{ruleToAdd}+");

            return pattern;
        }

        public static RegExpPattern ZeroOrOne(this RegExpPattern pattern, Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToExtract = rule.Invoke(RegExpPattern.With());

            var ruleToAdd = ruleToExtract.ToString().Length == 1
                ? RegExpPattern.With().Value(ruleToExtract.ToString())
                : RegExpPattern.With().Grouped(p => p.Value(ruleToExtract.ToString()));

            pattern.Value($"{ruleToAdd}?");

            return pattern;
        }
    }
}
