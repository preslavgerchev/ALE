namespace AutomataLogicEngineering.Test.HexadecimalTests
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using PropositionalLogic;

    [TestClass]
    public class HexadecimalTests
    {
        [TestMethod]
        public void TruthTable_HexadecimalValues_Test()
        {
            HexCollection collection;
            using (var r = new StreamReader("../../../truthTableVectors.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<HexCollection>(json);
            }
            foreach (var hexPair in collection.Values)
            {
                var node = NodeTreeCreator.Initialize(hexPair.Input);
                var truthTable = TruthTableGenerator.GenerateTruthTable(node);
                truthTable.Calculate(node);
                Assert.AreEqual(hexPair.Hex, truthTable.HexadecimalResult);
            }
        }
    }
}
