using System;
using System.Linq;

namespace Acamti.RegexpBuilder.Rules
{
    public static class ValuesExtensions
    {
        public static RegExpPattern WithValue(this RegExpPattern pattern, string value)
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
                .Select(_ => rule.Invoke(new RegExpPattern()));

            pattern.WithValue($"{rules.Aggregate("", (seed, r) => $"{seed}{r}")}");

            return pattern;
        }

        public static RegExpPattern WithGroup(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.WithValue($"(?:{ruleToGroup})");

            return pattern;
        }

        public static RegExpPattern WithGroup(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            bool capture)
        {
            if ( !capture )
                return pattern.WithGroup(rule);

            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.WithValue($"({ruleToGroup})");

            return pattern;
        }

        public static RegExpPattern WithGroup(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> rule,
            string name)
        {
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.WithValue($"(?<{name}>{ruleToGroup})");

            return pattern;
        }

        public static RegExpPattern WithCharacterRange(
            this RegExpPattern pattern,
            char from,
            char to)
        {
            pattern.WithValue($"[{from}-{to}]");

            return pattern;
        }

        public static RegExpPattern WithCharacterRangeWithException(
            this RegExpPattern pattern,
            char from,
            char to,
            char exception)
        {
            pattern.WithValue($"[{from}-{to}-[{exception}]]");

            return pattern;
        }

        public static RegExpPattern WithCharacterRangeWithException(
            this RegExpPattern pattern,
            char from,
            char to,
            char exceptionFrom,
            char exceptionTo)
        {
            pattern.WithValue($"[{from}-{to}-[{exceptionFrom}-{exceptionTo}]]");

            return pattern;
        }

        public static RegExpPattern OnlyIfAheadIs(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> cond,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var condToGroup = cond.Invoke(new RegExpPattern());
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.WithValue($"{ruleToGroup}(?={condToGroup})");

            return pattern;
        }

        public static RegExpPattern OnlyIfAheadIsNot(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> cond,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var condToGroup = cond.Invoke(new RegExpPattern());
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.WithValue($"{ruleToGroup}(?!{condToGroup})");

            return pattern;
        }

        public static RegExpPattern OnlyIfBehindIs(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> cond,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var condToGroup = cond.Invoke(new RegExpPattern());
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.WithValue($"(?<={condToGroup}){ruleToGroup}");

            return pattern;
        }

        public static RegExpPattern OnlyIfBehindIsNot(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> cond,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var condToGroup = cond.Invoke(new RegExpPattern());
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.WithValue($"(?<!{condToGroup}){ruleToGroup}");

            return pattern;
        }
    }
}
