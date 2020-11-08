using System;
using System.Linq;

namespace Acamti.RegexpBuilder.Rules
{
    public static class ConstructsExtensions
    {
        public static RegExpPattern Either(
            this RegExpPattern pattern,
            bool isGrouped,
            params Func<RegExpPattern, RegExpPattern>[] rules)
        {
            var ruleValues = rules
                .Select(rule => rule.Invoke(new RegExpPattern()).ToString());

            var beginningGroupRule = isGrouped
                ? "("
                : string.Empty;

            var endingGroupRule = isGrouped
                ? @")"
                : string.Empty;

            pattern.AddRule(
                new RegExpValue($"{beginningGroupRule}{string.Join('|', ruleValues)}{endingGroupRule}"));

            return pattern;
        }

        public static RegExpPattern ConditionalRule(
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

        public static RegExpPattern ValueFromGroup(
            this RegExpPattern pattern,
            int index)
        {
            pattern.AddRule(new RegExpValue($@"\{index}"));

            return pattern;
        }

        public static RegExpPattern ValueFromGroup(
            this RegExpPattern pattern,
            string name)
        {
            pattern.AddRule(new RegExpValue($@"\k<{name}>"));

            return pattern;
        }

        public static RegExpPattern GroupOf(
            this RegExpPattern pattern,
            bool isCaptured,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.AddRule(
                isCaptured
                    ? new RegExpValue($"({ruleToGroup})")
                    : new RegExpValue($"(?:{ruleToGroup})"));

            return pattern;
        }

        public static RegExpPattern GroupOf(
            this RegExpPattern pattern,
            string name,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"(?<{name}>{ruleToGroup})"));

            return pattern;
        }
    }
}
