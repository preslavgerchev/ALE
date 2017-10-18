using System.Diagnostics;

namespace AutomataLogicEngineering.Test
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;
    using TruthTable;

    /// <summary>
    /// A test class for <see cref="TruthTable.ToDnfForm"/>.
    /// </summary>
    [TestClass]
    public class DnfTests
    {
        /// <summary>
        /// A test method, verifying that converting a truth table to a DNF form works as expected.
        /// </summary>
        [TestMethod]
        public void TruthTable_ToDnfForm_Test()
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
                if (normalTruthTable.CanBeConvertedToDnf)
                {
                    var dnfTruthTable = TruthTableGenerator.GenerateTruthTable(
                        NodeTreeCreator.Initialize(normalTruthTable.ToDnfForm()));
                    Assert.AreEqual(hexPair.Value, dnfTruthTable.HexadecimalResult);
                }
            }
        }
    }
}
