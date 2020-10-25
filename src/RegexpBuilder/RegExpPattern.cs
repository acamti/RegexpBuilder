using System;
using System.Collections.Generic;
using System.Linq;
using Acamti.RegexpBuilder.Rules;

namespace Acamti.RegexpBuilder
{
    public class RegExpPattern
    {
        private readonly List<RegExpValue> _rules;
        private bool _isStopped;

        private RegExpPattern() =>
            _rules = new List<RegExpValue>();

        internal void AddRule(RegExpValue rule)
        {
            if ( _isStopped )
                throw new Exception("No more rules can be added");

            _rules.Add(rule);
        }

        public static RegExpPattern With(bool hardBegin = false) =>
            hardBegin
                ? new RegExpPattern().Value("^")
                : new RegExpPattern();

        public RegExpPattern Stop()
        {
            _rules.Add(new RegExpValue("$"));

            _isStopped = true;

            return this;
        }

        private string Build() =>
            _rules.Aggregate(
                "",
                (seed, rule) => $"{seed}{rule.Value()}");

        public override string ToString() =>
            Build();
    }
}
