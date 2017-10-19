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

        /// <summary>
        /// A test method, verifying that if the input is a tautology it can only be converted to a CNF form.
        /// </summary>
        [TestMethod]
        public void TruthTable_Contradiction_Test()
        {
            var input = "~(%(~(%(R,X)),&(=(0,=(R,|(Q,&(R,0)))),Q)))";
            var node = NodeTreeCreator.Initialize(input);
            var normalTruthTable = TruthTableGenerator.GenerateTruthTable(node);
            Assert.IsTrue(normalTruthTable.CanBeConvertedToCnf);
            Assert.IsFalse(normalTruthTable.CanBeConvertedToDnf);
            var cnf = normalTruthTable.ToCnfForm();
            var cnfNode = NodeTreeCreator.Initialize(cnf);
            var cnfTruthTable = TruthTableGenerator.GenerateTruthTable(cnfNode);
            Assert.AreEqual(cnfTruthTable.HexadecimalResult, normalTruthTable.HexadecimalResult);
        }
    }
}
