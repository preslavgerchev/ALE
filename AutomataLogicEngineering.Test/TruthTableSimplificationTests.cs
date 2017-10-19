namespace AutomataLogicEngineering.Test
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using JsonClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;
    using TruthTable;

    /// <summary>
    /// A test class for <see cref="TruthTable.Simplify"/>.
    /// </summary>
    [TestClass]
    public class TruthTableSimplificationTests
    {
        /// <summary>
        /// A test method, verifying that simplyfing a truth table works as expected.
        /// </summary>
        [TestMethod]
        public void TruthTable_Simplify_Test()
        {
            Dictionary<string, ExpectedSimplify> collection;
            using (var r = new StreamReader("../../../simplificationVectors.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<Dictionary<string, ExpectedSimplify>>(json);
            }
            foreach (var hexPair in collection)
            {
                var node = NodeTreeCreator.Initialize(hexPair.Key);
                var simplified = TruthTableGenerator.GenerateTruthTable(node).Simplify();
                var expectedSimplified = hexPair.Value;
                Assert.AreEqual(simplified.Rows.Count, expectedSimplified.NrOfDataRows);
                Assert.AreEqual(simplified.Header.Headers.Count, expectedSimplified.TableHeaders.Count);
                CollectionAssert.AreEqual(
                    simplified.Header.Headers.Take(simplified.Header.Headers.Count - 1).ToList(),
                    expectedSimplified.Predicates);
                for (var i = 0; i < expectedSimplified.DataRows.Count; i++)
                {
                    var expectedRow = expectedSimplified.DataRows[i];
                    var actualRow = simplified.Rows[i];
                    Assert.AreEqual(expectedRow.Result, actualRow.Result);
                    CollectionAssert.AreEqual(
                        expectedRow.Values,
                        actualRow.Cells.Select(x => x.SymbolInCell.ToString()).ToList());
                }
            }
        }
    }
}
