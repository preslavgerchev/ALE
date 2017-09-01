namespace ALEConsole.Symbols
{
    public class Predicate : Symbol
    {
        public bool HasValue { get; }

        public Predicate(char charSymbol)
            :base(charSymbol)
        {
            this.HasValue = charSymbol == '0' || charSymbol == '1';
        }
    }
}
