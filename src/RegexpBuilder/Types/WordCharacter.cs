using System;

namespace Acamti.RegexpBuilder.Types
{
    public static class WordCharacter
    {
        public enum WordCharacterType
        {
            LowerCase
        }

        public static string GetValue(WordCharacterType type)
        {
            return type switch
            {
                WordCharacterType.LowerCase => "Ll",
                _                           => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
