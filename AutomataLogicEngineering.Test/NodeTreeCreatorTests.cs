namespace AutomataLogicEngineering.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PropositionalLogic;
    using Symbols;

    /// <summary>
    /// A test class for <see cref="NodeTreeCreator.Initialize"/>.
    /// </summary>
    [TestClass]
    public class NodeTreeCreatorTests
    {
        /// <summary>
        /// Verifies whether the given input is properly converted to a node tree.
        /// </summary>
        [TestMethod]
        public void NodeTree_Test1()
        {
            var input = "&(A,B)";
            var rootNode = NodeTreeCreator.Initialize(input);

            Assert.IsTrue(rootNode.Symbol is Connective);
            Assert.AreEqual(2, rootNode.Children.Count);
            Assert.AreEqual('&', rootNode.Symbol.CharSymbol);
            Assert.AreEqual('A', rootNode.Children[0].Symbol.CharSymbol);
            Assert.AreEqual('B', rootNode.Children[1].Symbol.CharSymbol);
            Assert.AreEqual(0, rootNode.Children[0].Children.Count);
            Assert.AreEqual(0, rootNode.Children[1].Children.Count);
        }

        /// <summary>
        /// Verifies whether the given input is properly converted to a node tree.
        /// </summary>
        [TestMethod]
        public void NodeTree_Test2()
        {
            var input = "&(~(A),B)";
            var rootNode = NodeTreeCreator.Initialize(input);

            Assert.IsTrue(rootNode.Symbol is Connective);
            Assert.AreEqual(2, rootNode.Children.Count);
            Assert.AreEqual('&', rootNode.Symbol.CharSymbol);
            Assert.AreEqual('~', rootNode.Children[0].Symbol.CharSymbol);
            Assert.AreEqual('B', rootNode.Children[1].Symbol.CharSymbol);
            Assert.AreEqual(1, rootNode.Children[0].Children.Count);
            Assert.AreEqual(0, rootNode.Children[1].Children.Count);
            Assert.AreEqual('A', rootNode.Children[0].Children[0].Symbol.CharSymbol);
        }

        /// <summary>
        /// Verifies whether the given input is properly converted to a node tree.
        /// </summary>
        [TestMethod]
        public void NodeTree_Test3()
        {
            var input = "~(A)";
            var rootNode = NodeTreeCreator.Initialize(input);

            Assert.IsTrue(rootNode.Symbol is Connective);
            Assert.AreEqual('~', rootNode.Symbol.CharSymbol);
            Assert.AreEqual(1, rootNode.Children.Count);
            Assert.AreEqual('A', rootNode.Children[0].Symbol.CharSymbol);
        }

        /// <summary>
        /// Verifies whether the given input is properly converted to a node tree.
        /// </summary>
        [TestMethod]
        public void NodeTree_Test4()
        {
            var input = "&(|(~(A),B),C)";
            var rootNode = NodeTreeCreator.Initialize(input);

            Assert.IsTrue(rootNode.Symbol is Connective);
            Assert.AreEqual('&', rootNode.Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children.Count);
            Assert.AreEqual('|', rootNode.Children[0].Symbol.CharSymbol);
            Assert.AreEqual('C', rootNode.Children[1].Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children[0].Children.Count);
            Assert.AreEqual(0, rootNode.Children[1].Children.Count);
            Assert.AreEqual('~', rootNode.Children[0].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('B', rootNode.Children[0].Children[1].Symbol.CharSymbol);
            Assert.AreEqual(1, rootNode.Children[0].Children[0].Children.Count);
            Assert.AreEqual('A', rootNode.Children[0].Children[0].Children[0].Symbol.CharSymbol);
        }

        /// <summary>
        /// Verifies whether the given input is properly converted to a node tree.
        /// </summary>
        [TestMethod]
        public void NodeTree_Test5()
        {
            var input = ">(~(~(A)),B)";
            var rootNode = NodeTreeCreator.Initialize(input);

            Assert.IsTrue(rootNode.Symbol is Connective);
            Assert.AreEqual('>', rootNode.Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children.Count);
            Assert.AreEqual('~', rootNode.Children[0].Symbol.CharSymbol);
            Assert.AreEqual('B', rootNode.Children[1].Symbol.CharSymbol);
            Assert.AreEqual(1, rootNode.Children[0].Children.Count);
            Assert.AreEqual(0, rootNode.Children[1].Children.Count);
            Assert.AreEqual('~', rootNode.Children[0].Children[0].Symbol.CharSymbol);
            Assert.AreEqual(1, rootNode.Children[0].Children[0].Children.Count);
            Assert.AreEqual('A', rootNode.Children[0].Children[0].Children[0].Symbol.CharSymbol);
        }

        /// <summary>
        /// Verifies whether the given input is properly converted to a node tree.
        /// </summary>
        [TestMethod]
        public void NodeTree_Test6()
        {
            var input = "A";
            var rootNode = NodeTreeCreator.Initialize(input);

            Assert.IsTrue(rootNode.Symbol is Predicate);
            Assert.AreEqual('A', rootNode.Symbol.CharSymbol);
            Assert.AreEqual(0, rootNode.Children.Count);
        }

        /// <summary>
        /// Verifies whether the given input is properly converted to a node tree.
        /// </summary>
        [TestMethod]
        public void NodeTree_Test7()
        {
            var input = "&(>(A,B),|(~(C),~(D)))";
            var rootNode = NodeTreeCreator.Initialize(input);

            Assert.IsTrue(rootNode.Symbol is Connective);
            Assert.AreEqual('&', rootNode.Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children.Count);
            Assert.AreEqual('>', rootNode.Children[0].Symbol.CharSymbol);
            Assert.AreEqual('|', rootNode.Children[1].Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children[0].Children.Count);
            Assert.AreEqual(2, rootNode.Children[1].Children.Count);
            Assert.AreEqual('A', rootNode.Children[0].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('B', rootNode.Children[0].Children[1].Symbol.CharSymbol);
            Assert.AreEqual('~', rootNode.Children[1].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('~', rootNode.Children[1].Children[1].Symbol.CharSymbol);
            Assert.AreEqual(1, rootNode.Children[1].Children[0].Children.Count);
            Assert.AreEqual(1, rootNode.Children[1].Children[1].Children.Count);
            Assert.AreEqual('C', rootNode.Children[1].Children[0].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('D', rootNode.Children[1].Children[1].Children[0].Symbol.CharSymbol);
        }

        /// <summary>
        /// Verifies whether the given input is properly converted to a node tree.
        /// </summary>
        [TestMethod]
        public void NodeTree_Test8()
        {
            var input = "|(=(A,B),&(~(A),~(A)))";
            var rootNode = NodeTreeCreator.Initialize(input);

            Assert.IsTrue(rootNode.Symbol is Connective);
            Assert.AreEqual('|', rootNode.Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children.Count);
            Assert.AreEqual('=', rootNode.Children[0].Symbol.CharSymbol);
            Assert.AreEqual('&', rootNode.Children[1].Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children[0].Children.Count);
            Assert.AreEqual(2, rootNode.Children[1].Children.Count);
            Assert.AreEqual('A', rootNode.Children[0].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('B', rootNode.Children[0].Children[1].Symbol.CharSymbol);
            Assert.AreEqual('~', rootNode.Children[1].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('~', rootNode.Children[1].Children[1].Symbol.CharSymbol);
            Assert.AreEqual(1, rootNode.Children[1].Children[0].Children.Count);
            Assert.AreEqual(1, rootNode.Children[1].Children[1].Children.Count);
            Assert.AreEqual('A', rootNode.Children[1].Children[0].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('A', rootNode.Children[1].Children[1].Children[0].Symbol.CharSymbol);
        }

        /// <summary>
        /// Verifies whether the given input is properly converted to a node tree.
        /// </summary>
        [TestMethod]
        public void NodeTree_Test9()
        {
            var input = "|(=(|(A,~(F)),B),&(~(A),~(A)))";
            var rootNode = NodeTreeCreator.Initialize(input);

            Assert.IsTrue(rootNode.Symbol is Connective);
            Assert.AreEqual('|', rootNode.Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children.Count);
            Assert.AreEqual('=', rootNode.Children[0].Symbol.CharSymbol);
            Assert.AreEqual('&', rootNode.Children[1].Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children[0].Children.Count);
            Assert.AreEqual(2, rootNode.Children[1].Children.Count);
            Assert.AreEqual('|', rootNode.Children[0].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('B', rootNode.Children[0].Children[1].Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children[0].Children[0].Children.Count);
            Assert.AreEqual('A', rootNode.Children[0].Children[0].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('~', rootNode.Children[0].Children[0].Children[1].Symbol.CharSymbol);
            Assert.AreEqual(1, rootNode.Children[0].Children[0].Children[1].Children.Count);
            Assert.AreEqual('F', rootNode.Children[0].Children[0].Children[1].Children[0].Symbol.CharSymbol);
            Assert.AreEqual(2, rootNode.Children[0].Children[0].Children.Count);
            Assert.AreEqual('~', rootNode.Children[1].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('~', rootNode.Children[1].Children[1].Symbol.CharSymbol);
            Assert.AreEqual(1, rootNode.Children[1].Children[0].Children.Count);
            Assert.AreEqual(1, rootNode.Children[1].Children[1].Children.Count);
            Assert.AreEqual('A', rootNode.Children[1].Children[0].Children[0].Symbol.CharSymbol);
            Assert.AreEqual('A', rootNode.Children[1].Children[1].Children[0].Symbol.CharSymbol);
        }
    }
}
