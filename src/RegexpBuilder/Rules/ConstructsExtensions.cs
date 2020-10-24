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

            pattern.AddRule(
                new RegExpValue(
                    $"({string.Join('|', ruleValues)})"
                ));

            return pattern;
        }
    }
}
