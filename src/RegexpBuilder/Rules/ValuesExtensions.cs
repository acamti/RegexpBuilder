﻿using System;
using System.Linq;
using Acamti.RegexpBuilder.Types.RegExpCharacter;

namespace Acamti.RegexpBuilder.Rules
{
    public static class ValuesExtensions
    {
        public static RegExpPattern Text(this RegExpPattern pattern, string value, bool escapeCharacter = true)
        {
            if ( string.IsNullOrEmpty(value) ) return pattern;

            var concatChars = value
                .Aggregate(
                    string.Empty,
                    (seed, character) =>
                    {
                        var reC = (RegExpCharacter)RegExpCharacter.Build(character);
                        reC.EscapeChar = escapeCharacter;

                        return seed + reC;
                    }
                );

            pattern.AddRule(new RegExpValue(concatChars));

            return pattern;
        }

        public static RegExpPattern Repeat(
            this RegExpPattern pattern,
            int time,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var rules = Enumerable
                .Range(0, time)
                .Select(_ => rule.Invoke(new RegExpPattern()));

            pattern.AddRule(
                new RegExpValue($"{rules.Aggregate("", (seed, r) => $"{seed}{r}")}")
            );

            return pattern;
        }

        public static RegExpPattern OnlyIfAheadIs(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> cond,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var condToGroup = cond.Invoke(new RegExpPattern());
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToGroup}(?={condToGroup})"));

            return pattern;
        }

        public static RegExpPattern OnlyIfAheadIsNot(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> cond,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var condToGroup = cond.Invoke(new RegExpPattern());
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"{ruleToGroup}(?!{condToGroup})"));

            return pattern;
        }

        public static RegExpPattern OnlyIfBehindIs(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> cond,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var condToGroup = cond.Invoke(new RegExpPattern());
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"(?<={condToGroup}){ruleToGroup}"));

            return pattern;
        }

        public static RegExpPattern OnlyIfBehindIsNot(
            this RegExpPattern pattern,
            Func<RegExpPattern, RegExpPattern> cond,
            Func<RegExpPattern, RegExpPattern> rule)
        {
            var condToGroup = cond.Invoke(new RegExpPattern());
            var ruleToGroup = rule.Invoke(new RegExpPattern());

            pattern.AddRule(new RegExpValue($"(?<!{condToGroup}){ruleToGroup}"));

            return pattern;
        }
    }
}
