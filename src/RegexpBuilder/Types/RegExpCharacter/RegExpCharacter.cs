using System.Collections.Generic;

namespace Acamti.RegexpBuilder.Types.RegExpCharacter
{
    public class RegExpCharacter
    {
        private readonly List<char> _mustEscape =
            new List<char>(new[] { '.', '$', '^', '{', '[', '(', '|', ')', '*', '+', '?', '\\' });

        private readonly object _value;

        public RegExpCharacter(char value, bool asUnicodeValue)
        {
            if ( asUnicodeValue )
                _value = $"\\u{char.ConvertToUtf32(value.ToString(), 0):X4}";
            else if ( _mustEscape.Contains(value) )
                _value = "\\" + value;
            else
                _value = value;
        }

        public RegExpCharacter(EscapeCharacter.EscapeCharacterType escapeCharacter) =>
            _value = EscapeCharacter.GetValue(escapeCharacter);

        public override string ToString() =>
            _value.ToString();
    }
}
