namespace AutomataLogicEngineering.Test
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;

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
    }
}
