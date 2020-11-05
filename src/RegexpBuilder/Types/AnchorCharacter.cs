using System;

namespace Acamti.RegexpBuilder.Types
{
    public static class AnchorCharacter
    {
        public enum AnchorCharacterType
        {
            EndOfStringOnly,
            EndOfStringOrBeforeNewLine
        }

        public static string GetValue(AnchorCharacterType type)
        {
            return type switch
            {
                AnchorCharacterType.EndOfStringOnly => "\\z",
                AnchorCharacterType.EndOfStringOrBeforeNewLine => "\\Z",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
