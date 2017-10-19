namespace AutomataLogicEngineering.Test.JsonClasses
{
    using System.Collections.Generic;

    /// <summary>
    /// A class, representing a JSON class in the simplificationVectors.JSON file.
    /// </summary>
    public class DataRow
    {
        /// <summary>
        /// Gets or sets the values of the data row in the expected simplified truth table.
        /// </summary>
        public List<string> Values { get; set; }

        /// <summary>
        /// Gets or sets the result of the data row in the expected simplified truth table.
        /// </summary>
        public bool Result { get; set; }
    }
}

