namespace AutomataLogicEngineering.Test
{
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Nodes;
    using Validation;

    /// <summary>
    /// A test class for <see cref="Validator"/>.
    /// </summary>
    [TestClass]
    public class ValidationTests
    {
        /// <summary>
        /// A test method, verifying that the given valid propositions will not thrown
        /// an exception and will be properly parsed.
        /// </summary>
        [TestMethod]
        public void ValidPropositions_Test()
        {
            List<string> collection;
            using (var r = new StreamReader("../../../validPropositions.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<List<string>>(json);
                // TODO PREGER temporarily skip nandify until implemented.
                // TODO PREGER what to do with single digit inputs?.
                collection = collection
                    .Where(x => !x.Contains("%") && !x.Any(char.IsDigit))
                    .ToList();
            }
            foreach (var value in collection)
            {
                NodeTreeCreator.Initialize(value);
            }
        }

        /// <summary>
        /// A test method, verifying that the given valid propositions will throw an
        /// <see cref="InvalidInputException"/>.
        /// </summary>
        [TestMethod]
        public void InvalidPropositions_Test()
        {
            List<string> collection;
            using (var r = new StreamReader("../../../invalidPropositions.json"))
            {
                var json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<List<string>>(json);
                // TODO PREGER temporarily skip nandify until implemented.
                // TODO PREGER what to do with single digit inputs?.
                collection = collection
                    .Where(x => !x.Contains("%") && !x.Any(char.IsDigit))
                    .ToList();
            }
            foreach (var input in collection)
            {
                TestExtensions.Throws<InvalidInputException>(() => NodeTreeCreator.Initialize(input));
            }
        }
    }
}
