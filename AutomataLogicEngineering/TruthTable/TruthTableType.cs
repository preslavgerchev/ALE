namespace AutomataLogicEngineering.TruthTable
{
    /// <summary>
    /// Represents the type of truth table.
    /// </summary>
    public enum TruthTableType
    {
        /// <summary>
        /// Represents a normal truth table.
        /// </summary>
        Normal,

        /// <summary>
        /// Represents the simplification of a normal truth table.
        /// </summary>
        Simplified,

        /// <summary>
        /// Represents the DNF form of a normal truth table.
        /// </summary>
        Dnf,

        /// <summary>
        /// Represents the DNF form of a normal truth table.
        /// </summary>
        Cnf,

        /// <summary>
        /// Represents the DNF form of a simplified normal truth table.
        /// </summary>
        DnfSimplified,

        /// <summary>
        /// Represents the CNF form of a simplified normal truth table.
        /// </summary>
        CnfSimplified,
    }
}
