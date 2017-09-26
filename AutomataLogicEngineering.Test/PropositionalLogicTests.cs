namespace AutomataLogicEngineering.Test
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Exceptions;
    using PropositionalLogic;

    [TestClass]
    public class PropositionalLogicTests
    {
        [TestMethod]
        [Ignore]
        public void ValidPropositions_Test()
        {
            var validPropostions = new List<string>
            {
                @">(A,B)",
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

        [TestMethod]
        [Ignore]
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
