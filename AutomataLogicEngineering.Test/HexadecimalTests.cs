
namespace AutomataLogicEngineering.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;
    using Symbols;
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
                Assert.AreEqual(hexPair.Value, truthTable.HexadecimalResult);
            }
        }

        /// <summary>
        /// A test method, verifying that trying to call <see cref="Node.Apply"/> on a symbol that is
        /// NOT a connective or a predicate will thrown an exception.
        /// </summary>
        [TestMethod]
        public void Apply_InvalidSymbols_Test()
        {
            var invalidNodes = new List<Node>()
            {
                new Node(new Separator(',', 1, 1)),
                new Node(new Parenthesis('(', 1, 1, ParenthesisSide.Opening)),
                new Node(new Parenthesis(')', 1, 1, ParenthesisSide.Closing)),
            };

            foreach (var invalidNode in invalidNodes)
            {
                TestExtensions.Throws<Exception>(
                    () => invalidNode.Apply(),
                    $"Internal error. Cannot call Apply(..) for symbol '{invalidNode.Symbol.CharSymbol}'.");
            }
        }
    }
}
