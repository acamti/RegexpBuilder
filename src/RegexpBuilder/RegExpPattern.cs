﻿using System.Collections.Generic;
using System.Linq;

namespace Acamti.RegexpBuilder
{
    public class RegExpPattern
    {
        private readonly List<RegExpValue> _rules;

        private RegExpPattern() =>
            _rules = new List<RegExpValue>();

        internal void AddRule(RegExpValue rule)
        {
            _rules.Add(rule);
        }

        public static RegExpPattern With() =>
            new RegExpPattern();

        private string Build() =>
            _rules.Aggregate(
                "",
                (seed, rule) => $"{seed}{rule.Value()}");

        public override string ToString() =>
            Build();

        internal void AppendToLastRule(string value)
        {
            var lastRule = _rules.LastOrDefault();

            if ( lastRule is null ) return;

            lastRule.Append(value);
        }
    }
}
