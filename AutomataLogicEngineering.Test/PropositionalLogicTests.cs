namespace AutomataLogicEngineering.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Exceptions;
    using PropositionalLogic;

    [TestClass]
    public class PropositionalLogicTests
    {
        [TestMethod]
        public void ValidPropositions_Test()
        {
            var validPropostions = new List<string>
            {
                @">(A,B)",
                @"~(A)",
                @">(=(A,B),~(C))",
                @"&(A,B)",
                @"~(0)",
                @"&(A,~(B))",
                @">(=(D,A),~(B))",
                @"T",
                @"&(&(=(A,B),>(&(A,B),~(C))),>(A,~(&(A,B))))",
                @"1",
                @"0",
                @"~(A)",
                @"A"
            };

            foreach (var input in validPropostions)
            {
                NodeTreeCreator.Initialize(input);
            }
        }

        [TestMethod]
        public void InvalidPropositions_Test()
        {
            var invalidPropositions = new List<string>
            {
                @"&(A,B",
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
                Throws<InvalidInputException>(() => NodeTreeCreator.Initialize(input));
            }
        }

        private static void Throws<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
                throw new AssertFailedException(
                    $"The action did not throw expected exception of type {typeof(TException)}");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType(), typeof(TException));
            }
        }
    }
}
