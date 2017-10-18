namespace AutomataLogicEngineering.Test
{
    using System.IO;
    using System.Collections.Generic;
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    
    /// <summary>
    /// A test class for converting binary to hexadecimal.
    /// </summary>
    [TestClass]
    public class BinaryToHexadecimalTests
    {
        /// <summary>
        /// A test method, verifying that converting binary to hexadecimal works properly.
        /// </summary>
        [TestMethod]
        public void BinaryToHexadecimal_Test()
        {
            Dictionary<string, string> collection;
            using (var r = new StreamReader("../../../binToHashcode.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            foreach (var pair in collection)
            {
                Assert.AreEqual(pair.Value, pair.Key.ToHexString());
            }
        }

        /// <summary>
        /// A test method, verifying that converting binary to hexadecimal throws exception if the
        /// binary input is invalid.
        /// </summary>
        [TestMethod]
        public void BinaryToHexadecimal_Invalid_Test()
        {
            var invalidBinary = "1000111A";
            TestExtensions.Throws<System.Exception>(() => invalidBinary.ToHexString());
        }
    }
}
