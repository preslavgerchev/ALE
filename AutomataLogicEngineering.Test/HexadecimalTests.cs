namespace AutomataLogicEngineering.Test
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
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
        [Ignore]
        public void TruthTable_HexadecimalValues_Test()
        {
            Dictionary<string, string> collection;
            using (var r = new StreamReader("../../../truthTableVectors.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                // TODO PREGER temporarily skip nandify until implemented.
                // TODO PREGER what to do with single digit inputs?.
                // TODO PREGER tests with > seem to be incorrect? 
                collection = collection
                    .Where(x => !x.Key.Contains("%") && !x.Key.Any(char.IsDigit) && x.Key.Length != 1)
                    .ToDictionary(x => x.Key, x => x.Value);
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
