using System.Collections.Generic;

namespace Acamti.RegexpBuilder.Types.RegExpCharacter
{
    public class RegExpCharacter : IRegExpCharacter
    {
        private readonly bool _asUnicode;

        private readonly List<char> _mustEscape =
            new List<char>(new[] { '.', '$', '^', '{', '[', '(', '|', ')', '*', '+', '?', '\\' });

        private readonly char _value;

        private RegExpCharacter(char value, bool asUnicode)
        {
            _value = value;
            _asUnicode = asUnicode;
        }

        public bool EscapeChar { get; set; } = true;

        public override string ToString()
        {
            if ( _asUnicode )
                return $"\\u{char.ConvertToUtf32(_value.ToString(), 0):X4}";

            if ( EscapeChar && _mustEscape.Contains(_value) )
                return "\\" + _value;

            return _value.ToString();
        }

        public static IRegExpCharacter Build(
            char character,
            bool asUnicode = false)
            => new RegExpCharacter(character, asUnicode);
    }
}
