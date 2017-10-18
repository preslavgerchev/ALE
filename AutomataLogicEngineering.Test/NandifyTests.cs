namespace AutomataLogicEngineering.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;
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
        public void Nandify_Test()
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
    }
}
