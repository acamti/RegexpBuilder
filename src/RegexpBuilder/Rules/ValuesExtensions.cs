using System;
using System.Linq;

namespace Acamti.RegexpBuilder.Rules
{
    public static class ValuesExtensions
    {
        public static RegExpPattern Value(this RegExpPattern pattern, string value)
        {
            if ( string.IsNullOrEmpty(value) ) return pattern;

            pattern.AddRule(new RegExpValue(value));

            return pattern;
        }

        public static RegExpPattern Repeat(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            int time)
        {
            var rules = Enumerable
                .Range(0, time)
                .Select(_ => rule.Invoke(RegExpPattern.With()));

            pattern.Value($"{rules.Aggregate("", (seed, r) => $"{seed}{r}")}");

            return pattern;
        }

        public static RegExpPattern Group(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToGroup = rule.Invoke(RegExpPattern.With());

            pattern.Value($"(?:{ruleToGroup})");

            return pattern;
        }

        public static RegExpPattern Group(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            bool capture)
        {
            if ( !capture )
                return pattern.Group(rule);

            var ruleToGroup = rule.Invoke(RegExpPattern.With());

            pattern.Value($"({ruleToGroup})");

            return pattern;
        }

        public static RegExpPattern Group(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            string name)
        {
            var ruleToGroup = rule.Invoke(RegExpPattern.With());

            pattern.Value($"(?<{name}>{ruleToGroup})");

            return pattern;
        }
    }
}
