namespace AutomataLogicEngineering.PropositionalLogic
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Nodes;

    /// <summary>
    /// A static class, responsible for creating a node graph image out of a root node.
    /// </summary>
    public static class NodeGraphCreator
    {
        /// <summary>
        /// The file name of the .dot file that will be used to create the image.
        /// </summary>
        private const string DotFileName = "NodeGraph.dot";

        /// <summary>
        /// The file name of the image where the node graph will be created.
        /// </summary>
        private const string ImageFileName = "NodeGraph.png";

        /// <summary>
        /// Creates a node graph image for the given node tree, represented by its <paramref name="rootNode"/>.
        /// </summary>
        /// <param name="rootNode">The root node of the node tree.</param>
        /// <returns>The file name of the node graph image</returns>
        public static string CreateNodeGraphImage(Node rootNode)
        {
            PrepareDotFile(rootNode);
            return CreateNodeGraph();
        }

        /// <summary>
        /// Creates a .dot file for the given <paramref name="rootNode"/> that contains all connections in the
        /// node graph.
        /// </summary>
        /// <param name="rootNode">The root node of the node tree.</param>
        private static void PrepareDotFile(Node rootNode)
        {
            using (var writer = new StreamWriter($"../../../{DotFileName}", false))
            {
                writer.WriteLine("graph logic {");
                writer.WriteLine("node [ fontname = \"Arial\" ]");
                WriteNodes(writer, rootNode);
                writer.WriteLine("}");
            }
        }

        /// <summary>
        /// Creates the node graph image with file name of <see cref="ImageFileName"/>, using the .dot file with file name 
        /// of <see cref="DotFileName"/> and returns the full path of where the image is located.
        /// </summary>
        /// <returns></returns>
        private static string CreateNodeGraph()
        {
            var relativeFolderPath = Path.GetFullPath(
                new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")).LocalPath);
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = relativeFolderPath,
                FileName = "dot.exe",
                Arguments = $"-Tpng -o{ImageFileName} {DotFileName}"
            };
            Process.Start(startInfo)?.WaitForExit();
            return relativeFolderPath + ImageFileName;
        }

        /// <summary>
        /// Writes the connection between the given <paramref name="node"/> and its children, using
        /// the <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The text writer.</param>
        /// <param name="node">The node.</param>
        private static void WriteNodes(TextWriter writer, Node node)
        {
            writer.WriteLine($"node{node.Symbol.Id} [label = \"{node.Symbol.CharSymbol}\"]");

            if (!node.Children.Any()) return;

            foreach (var child in node.Children)
            {
                writer.WriteLine($"node{node.Symbol.Id} -- node{child.Symbol.Id}");
                WriteNodes(writer, child);
            }
        }
    }
}
