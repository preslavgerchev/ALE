namespace AutomataLogicEngineering.Symbols
{
    public class Predicate : Symbol
    {
        public bool Value { get; set; }

        public int ValueRepresentation => this.Value ? 1 : 0;

        public Predicate(char charSymbol)
            :base(charSymbol)
        {
        }
    }
}
