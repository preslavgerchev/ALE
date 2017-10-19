namespace AutomataLogicEngineering.Test.JsonClasses
{
    using System.Collections.Generic;

    /// <summary>
    /// A class, representing a JSON class in the simplificationVectors.JSON file.
    /// </summary>
    public class ExpectedSimplify
    {
        /// <summary>
        /// Gets or sets the table headers of the expected simplified truth table.
        /// </summary>
        public List<string> TableHeaders { get; set; }

        /// <summary>
        /// Gets or sets the predicates of the expected simplified truth table.
        /// </summary>
        public List<string> Predicates { get; set; }

        /// <summary>
        /// Gets or sets the data rows of the expected simplified truth table.
        /// </summary>
        public List<DataRow> DataRows { get; set; }
        
        /// <summary>
        /// Gets or sets the amount of data rows in the expected simplified truth table.
        /// </summary>
        public int NrOfDataRows { get; set; }
    }
}
