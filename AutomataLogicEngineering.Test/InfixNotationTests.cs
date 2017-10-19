namespace AutomataLogicEngineering.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;
    using Symbols;

    /// <summary>
    /// A test class for <see cref="Node.GetInfixNotation"/>.
    /// </summary>
    [TestClass]
    public class InfixNotationTests
    {
        /// <summary>
        /// A test method, verifying that the infix notation for a given propositonal input is as expected.
        /// </summary>
        [TestMethod]
        public void InfixNotations_Test()
        {
            Dictionary<string, string> collection;
            using (var r = new StreamReader("../../../infixNotations.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            foreach (var hexPair in collection)
            {
                var node = NodeTreeCreator.Initialize(hexPair.Key);
                var infix = node.GetInfixNotation();
                Assert.AreEqual(hexPair.Value, infix);
            }
        }

        /// <summary>
        /// A test method, verifying that trying to call <see cref="Node.GetInfixNotation"/> on a symbol that is
        /// NOT a connective or a predicate will thrown an exception.
        /// </summary>
        [TestMethod]
        public void GetInfixNotation_InvalidSymbols_Test()
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
                    () => invalidNode.GetInfixNotation(),
                    $"Internal error. Cannot call GetInfixNotation(..) for symbol '{invalidNode.Symbol.CharSymbol}'.");
            }
        }
    }
}
