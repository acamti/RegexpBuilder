namespace Acamti.RegexpBuilder.Types.RegExpCharacter
{
    public class RegExpWordCharacter : IRegExpCharacter
    {
        private readonly WordCharacter.WordCharacterType _character;
        private readonly bool _isIncluded;

        private RegExpWordCharacter(WordCharacter.WordCharacterType character, bool isIncluded)
        {
            _character = character;
            _isIncluded = isIncluded;
        }

        public override string ToString() =>
            WordCharacter.GetValue(_character, _isIncluded);

        public static IRegExpCharacter Build(
            WordCharacter.WordCharacterType character,
            bool asUnicode = false) =>
            new RegExpWordCharacter(character, asUnicode);
    }
}
