namespace AutomataLogicEngineering.Test
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;
    using TruthTable;

    /// <summary>
    /// A test class for <see cref="TruthTable.HexadecimalResult"/>.
    /// </summary>
    [TestClass]
    public class HexadecimalTests
    {
        /// <summary>
        /// A test method, verifying that the hexadecimal results in the provided JSON file
        /// are as expected.
        /// </summary>
        [TestMethod]
        public void TruthTable_HexadecimalValues_Test()
        {
            Dictionary<string, string> collection;
            using (var r = new StreamReader("../../../truthTableVectors.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            foreach (var hexPair in collection)
            {
                var node = NodeTreeCreator.Initialize(hexPair.Key);
                var truthTable = TruthTableGenerator.GenerateTruthTable(node);
                truthTable.Calculate(node);
                Assert.AreEqual(hexPair.Value, truthTable.HexadecimalResult);
            }
        }
    }
}
