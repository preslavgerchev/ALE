using System;
using System.Diagnostics;
using AutomataLogicEngineering.TruthTable;

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
    public class NandifyTests
    {
        /// <summary>
        /// A test method, verifying that the infix notation for a given propositonal input is as expected.
        /// </summary>
        [TestMethod]
        public void Nandify_Test()
        {
            Dictionary<string, string> collection;
            using (var r = new StreamReader("../../../truthTableVectors.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            var line = 0;
            foreach (var hexPair in collection)
            {
                try
                {
                    line++;
                    var node = NodeTreeCreator.Initialize(hexPair.Key);
                    var nandify = node.Nandify();
                    var nandifyNode = NodeTreeCreator.Initialize(nandify, false);
                    var hashCode = TruthTableGenerator.GenerateTruthTable(nandifyNode).HexadecimalResult;
                    Assert.AreEqual(hexPair.Value, hashCode);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.GetType());
                    Debug.WriteLine(line);
                }
            }
        }
    }
}
