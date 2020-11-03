using System;
using System.Linq;

namespace Acamti.RegexpBuilder.Rules
{
    public static class ConstructsExtensions
    {
        public static RegExpPattern WithEither(
            this RegExpPattern pattern,
            params Func<RegExpPattern, RegExpPattern>[] rules)
        {
            var ruleValues = rules.Select(
                rule =>
                    rule.Invoke(new RegExpPattern()).ToString());

            pattern.AddRule(new RegExpValue(
                                $"{string.Join('|', ruleValues)}"
                            ));

            return pattern;
        }

        public static RegExpPattern WithConditionalRule(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            Func<RegExpPattern, RegExpPattern> yes,
            Func<RegExpPattern, RegExpPattern> no)
        {
            var condition = rule.Invoke(new RegExpPattern());
            var yesMatch = yes.Invoke(new RegExpPattern());
            var noMatch = no.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"(?({condition}){yesMatch}|{noMatch})"));

            return pattern;
        }

        public static RegExpPattern WithGroupValue(
            this RegExpPattern pattern,
            int index)
        {
            pattern.AddRule(new RegExpValue($@"\{index + 1}"));

            return pattern;
        }

        public static RegExpPattern WithGroupValue(
            this RegExpPattern pattern,
            string name)
        {
            pattern.AddRule(new RegExpValue($@"\k<{name}>"));

            return pattern;
        }
    }
}
