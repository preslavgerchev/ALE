namespace AutomataLogicEngineering.Test
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Exceptions;
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
            var validPropostions = new List<string>
            {
                @"&(>(A,B),C)",
                @"~(A)",
                @">(=(A,B),~(C))",
                @"&(A,B)",
                @"~(A)",
                @"&(A,~(B))",
                @">(=(D,A),~(B))",
                @"T",
                @"&(&(=(A,B),>(&(A,B),~(C))),>(A,~(&(A,B))))",
                @"~(A)",
                @"A"
            };

            foreach (var input in validPropostions)
            {
                NodeTreeCreator.Initialize(input);
            }
        }

        /// <summary>
        /// A test method, verifying that the given valid propositions will throw an
        /// <see cref="InvalidInputException"/>.
        /// </summary>
        [TestMethod]
        public void InvalidPropositions_Test()
        {
            var invalidPropositions = new List<string>
            {
                @"~(A,B)",
                @"&(A,|(B))",
                @">",
                @"~",
                @"=",
                @"3",
                @"4",
                @"11",
                @"~(,B)",
                @">(,B)",
                @"=(A,)",
                @">(,)",
                @"=(,)",
                @"~()",
                @">(,",
                @",,",
                @" "
            };

            foreach (var input in invalidPropositions)
            {
                TestExtensions.Throws<InvalidInputException>(() => NodeTreeCreator.Initialize(input));
            }
        }
    }
}
