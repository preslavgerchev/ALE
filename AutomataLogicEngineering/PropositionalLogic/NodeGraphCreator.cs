namespace AutomataLogicEngineering.PropositionalLogic
{
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Nodes;

    public static class NodeGraphCreator
    {
        private const string FileName = "NodeGraph.dot";

        private const string ImageName = "NodeGraph.png";

        public static string CreateNodeTreeImage(Node rootNode)
        {
            PrepareDotFile(rootNode);
            CreateNodeGraph();
            return FileName;
        }

        private static void PrepareDotFile(Node rootNode)
        {
            using (var writer = new StreamWriter($"../../../{FileName}", false))
            {
                writer.WriteLine("graph logic {");
                writer.WriteLine("node [ fontname = \"Arial\" ]");
                WriteRootNode(writer, rootNode);
                writer.WriteLine("}");
            }
        }

        private static void CreateNodeGraph()
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\Program Files (x86)\Graphviz2.38\bin",
                    Arguments = $"-Tpng -o{ImageName} {FileName}",
                    UseShellExecute = true
                },
            };
            process.Start();
        }

        private static void WriteRootNode(StreamWriter writer, Node node)
        {
            writer.WriteLine($"node{node.Symbol.Id} [label = \"{node.Symbol.CharSymbol}\"]");

            if (!node.Children.Any()) return;

            foreach (var child in node.Children)
            {
                writer.WriteLine($"node{node.Symbol.Id} -- node{child.Symbol.Id}");
            }

            foreach (var child in node.Children)
            {
                WriteRootNode(writer, child);
            }
        }
    }
}
