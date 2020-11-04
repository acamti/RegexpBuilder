using System;

namespace Acamti.RegexpBuilder.Types
{
    public static class WordCharacter
    {
        public enum WordCharacterType
        {
            LowerCase,
            UpperCase,
            TitleCase,
            Other,
            Modifier,
            NonSpacing,
            DecimalDigit,
            Punctuation
        }

        public static string GetValue(WordCharacterType type, bool isIncluded)
        {
            return type switch
            {
                WordCharacterType.LowerCase    => $"{( isIncluded ? "\\p" : "\\P" )}{{Ll}}",
                WordCharacterType.UpperCase    => $"{( isIncluded ? "\\p" : "\\P" )}{{Lu}}",
                WordCharacterType.TitleCase    => $"{( isIncluded ? "\\p" : "\\P" )}{{Lt}}",
                WordCharacterType.Other        => $"{( isIncluded ? "\\p" : "\\P" )}{{Lo}}",
                WordCharacterType.Modifier     => $"{( isIncluded ? "\\p" : "\\P" )}{{Lm}}",
                WordCharacterType.NonSpacing   => $"{( isIncluded ? "\\p" : "\\P" )}{{Mn}}",
                WordCharacterType.DecimalDigit => $"{( isIncluded ? "\\p" : "\\P" )}{{Nd}}",
                WordCharacterType.Punctuation  => $"{( isIncluded ? "\\p" : "\\P" )}{{P}}",
                _                              => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
