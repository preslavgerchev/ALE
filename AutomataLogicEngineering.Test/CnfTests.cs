namespace AutomataLogicEngineering.Test
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;
    using TruthTable;

    /// <summary>
    /// A test class for <see cref="TruthTable.ToCnfForm"/>.
    /// </summary>
    [TestClass]
    public class CnfTests
    {
        /// <summary>
        /// A test method, verifying that converting a truth table to a CNF form works as expected.
        /// </summary>
        [TestMethod]
        public void TruthTable_ToCnfForm_Test()
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
                var normalTruthTable = TruthTableGenerator.GenerateTruthTable(node);
                if (normalTruthTable.CanBeConvertedToCnf)
                {
                    var cnfTruthTable = TruthTableGenerator.GenerateTruthTable(
                        NodeTreeCreator.Initialize(normalTruthTable.ToCnfForm()));
                    Assert.AreEqual(hexPair.Value, cnfTruthTable.HexadecimalResult);
                }
            }
        }
    }
}
