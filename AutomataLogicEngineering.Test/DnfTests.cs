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

        /// <summary>
        /// A test method, verifying that if the input is a tautology it can only be converted to a DNF form.
        /// </summary>
        [TestMethod]
        public void TruthTable_Tautology_Test()
        {
            var input = "&(~(&(>(&(X,|(&(~(&(>(|(=(=(|(&(=(%(0,%(S,>(>(~(>(>(%(%(=(0,R),&(%(1,X),&(P," +
                        "|(R,&(~(&(P,>(=(~(%(|(P,S),&(P,S))),R),=(>(Q,~(~(>(S,R)))),Q)))),0))))),0),X)," +
                        "Q)),S),R))),1),P),Q),Q),R),0),R),X)),P),1)),1),0)),1)";
            var node = NodeTreeCreator.Initialize(input);
            var normalTruthTable = TruthTableGenerator.GenerateTruthTable(node);
            Assert.IsTrue(normalTruthTable.CanBeConvertedToDnf);
            Assert.IsFalse(normalTruthTable.CanBeConvertedToCnf);
            var dnf = normalTruthTable.ToDnfForm();
            var dnfNode = NodeTreeCreator.Initialize(dnf);
            var dnfTruthTable = TruthTableGenerator.GenerateTruthTable(dnfNode);
            Assert.AreEqual(dnfTruthTable.HexadecimalResult, normalTruthTable.HexadecimalResult);
        }
    }
}
