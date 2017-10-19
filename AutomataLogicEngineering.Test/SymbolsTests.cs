namespace AutomataLogicEngineering.Test
{
    using System;
    using System.Linq;
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Symbols;

    /// <summary>
    /// A test class for <see cref="Symbol"/>.
    /// </summary>
    [TestClass]
    public class SymbolTests
    {
        /// <summary>
        /// A test method, verifying that symbol identifiers are assigned as expected.
        /// </summary>
        [TestMethod]
        public void Symbol_UniqueIdentifiers_Test()
        {
            var input = "&(a,%(=(|(~(|(B,C)),%(~(~(=(&(~(D),=(E,=(%(F,G),|(%(=(H,I),J),%(>(=(>(|(=(K,L),=(=(M,N)," +
                        "O)),P),Q),R),%(S,|(~(T),~(>(=(>(>(~(~(U)),V),W),X),Y))))))))),Z))),0)),1),b))";
            var symbols = Parser.ParseToSymbols(input);
            var nodeGraphIds = symbols.Select(x => x.NodeGraphId).ToList();
            // Verify there are no duplicates in the node graph ids.
            Assert.AreEqual(nodeGraphIds.Count, nodeGraphIds.Distinct().Count());
            // Verify that all IDs are assigned in order, comparing the current symbol to the previous one.
            Assert.IsTrue(symbols.Skip(1).Zip(symbols.ToList(), (x, y) => new { X = x, Y = y })
                .All(x => x.X.Id != x.Y.Id));
        }

        /// <summary>
        /// A test method, verifying that symbol duplicate identifiers are assigned as expected.
        /// </summary>
        [TestMethod]
        public void Symbol_DuplicateIdentifiers_Test()
        {
            var input = "&(A,%(=(|(~(|(A,A)),%(~(~(=(&(~(A),=(A,=(%(A,A),|(%(=(A,A),A),%(>(=(>(|(=(A,A),=(=(A,A)," +
                        "A)),A),A),A),%(A,|(~(A),~(>(=(>(>(~(~(A)),A),A),A),A))))))))),A))),A)),A),A))";
            var symbols = Parser.ParseToSymbols(input);
            var predicates = symbols.Where(x => x is Predicate).ToList();
            var nodeGraphIds = symbols.Select(x => x.NodeGraphId).ToList();
            // Verify there are no duplicates in the node graph ids.
            Assert.AreEqual(nodeGraphIds.Count, nodeGraphIds.Distinct().Count());
            Assert.IsTrue(predicates.Skip(1).Zip(predicates.ToList(), (x, y) => new { X = x, Y = y })
                .All(x => x.X.Id == x.Y.Id));
        }

        /// <summary>
        /// A test method, verifying that the value for a predicate that is not a digit can be set.
        /// </summary>
        [TestMethod]
        public void Predicate_IsDigit_Test()
        {
            var validPredicate = new Predicate('A', 1, 1);
            Assert.IsFalse(validPredicate.IsDigit);
            Assert.IsFalse(validPredicate.Value);
            Assert.AreEqual(validPredicate.ValueRepresentation, 0);
            validPredicate.Value = true;
            Assert.IsTrue(validPredicate.Value);
            Assert.AreEqual(validPredicate.ValueRepresentation, 1);
        }

        /// <summary>
        /// A test method, verifying that the trying to set the value for a predicate that is a digit
        /// will result in an exception.
        /// </summary>
        [TestMethod]
        public void Predicate_InvalidIsDigit_Test()
        {
            var validPredicate = new Predicate('1', 1, 1);
            Assert.IsTrue(validPredicate.IsDigit);
            TestExtensions.Throws<InvalidOperationException>(
                () => validPredicate.Value = true,
                "Cannot set value for Predicate.Value since the char is a digit.");
        }
    }
}
