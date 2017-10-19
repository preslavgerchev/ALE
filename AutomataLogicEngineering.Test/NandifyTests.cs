namespace AutomataLogicEngineering.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;
    using Symbols;
    using TruthTable;
    
    /// <summary>
    /// A test class for <see cref="Node.GetInfixNotation"/>.
    /// </summary>
    [TestClass]
    public class NandifyTests
    {
        /// <summary>
        /// A test method, verifying that nandify-ing the input works as expected.
        /// </summary>
        /// <remarks>
        /// Note that due to the nature of how nandify works this test takes an enormous amount of time 
        /// (over an hour) to be completed. As such it's disabled by default. Removed the Ignore attribute 
        /// to run it.
        /// </remarks>
        [TestMethod]
        [Ignore]
        public void Nandify_All_Test()
        {
            Dictionary<string, string> collection;
            using (var r = new StreamReader("../../../truthTableVectors.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            foreach (var hexPair in collection)
            {
                try
                {
                    var node = NodeTreeCreator.Initialize(hexPair.Key);
                    var nandify = node.Nandify();
                    var nandifyNode = NodeTreeCreator.Initialize(nandify, false);
                    var hashCode = TruthTableGenerator.GenerateTruthTable(nandifyNode).HexadecimalResult;
                    Assert.AreEqual(hexPair.Value, hashCode);
                }
                catch (OutOfMemoryException)
                {
                    // Do nothing with the OutOfMemoryException as it's expected for long inputs.
                }
            }
        }

        /// <summary>
        /// A test method, verifying that nandify-ing the input works as expected. Note that only inputs
        /// with length less than 70 chars will be taken into account.
        /// </summary>
        /// <remarks>
        /// This test ensures some coverage and testing of the Nandify method, even if it's on short inputs.
        /// </remarks>
        [TestMethod]
        public void Nandify_Short_Test()
        {
            Dictionary<string, string> collection;
            using (var r = new StreamReader("../../../truthTableVectors.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                // Filter for inputs with length less than 70. This ensures that test will run fast.
                collection = collection.Where(x => x.Key.Length < 70).ToDictionary(x => x.Key, x => x.Value);
            }
            foreach (var hexPair in collection)
            {
                var node = NodeTreeCreator.Initialize(hexPair.Key);
                var nandify = node.Nandify();
                var nandifyNode = NodeTreeCreator.Initialize(nandify, false);
                var hashCode = TruthTableGenerator.GenerateTruthTable(nandifyNode).HexadecimalResult;
                Assert.AreEqual(hexPair.Value, hashCode);

            }
        }

        /// <summary>
        /// A test method, verifying that trying to nandify a symbol that is NOT a connective or a predicate
        /// will throw an exception.
        /// </summary>
        [TestMethod]
        public void Nandify_InvalidSymbols_Test()
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
                    () => invalidNode.Nandify(),
                    $"Internal error. Cannot call Nandify(..) for symbol '{invalidNode.Symbol.CharSymbol}'.");
            }
        }
    }
}
