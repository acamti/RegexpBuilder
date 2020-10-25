using System;
using System.Linq;

namespace Acamti.RegexpBuilder.Rules
{
    public static class ConstructsExtensions
    {
        public static RegExpPattern Either(
            this RegExpPattern pattern,
            params Func<RegExpPattern, RegExpPattern>[] rules)
        {
            var ruleValues = rules.Select(
                rule =>
                    rule.Invoke(RegExpPattern.With()).ToString());

            pattern.Value(
                $"{string.Join('|', ruleValues)}"
            );

            return pattern;
        }

        public static RegExpPattern ConditionallyRule(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            Func<RegExpPattern, RegExpPattern> yes,
            Func<RegExpPattern, RegExpPattern> no)
        {
            var condition = rule.Invoke(RegExpPattern.With());
            var yesMatch = yes.Invoke(RegExpPattern.With());
            var noMatch = no.Invoke(RegExpPattern.With());

            pattern.Value($"(?({condition}){yesMatch}|{noMatch})");

            return pattern;
        }

        public static RegExpPattern GroupValue(
            this RegExpPattern pattern,
            int index)
        {
            pattern.Value($@"\{index + 1}");

            return pattern;
        }

        public static RegExpPattern GroupValue(
            this RegExpPattern pattern,
            string name)
        {
            pattern.Value($@"\k<{name}>");

            return pattern;
        }
    }
}
