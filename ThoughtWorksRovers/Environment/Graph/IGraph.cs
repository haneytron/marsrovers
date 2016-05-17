using System.Collections.Generic;
using ThoughtWorksRovers.Program.Environment.Graph.Node;
using ThoughtWorksRovers.Program.FileParser.ParsedData;

namespace ThoughtWorksRovers.Program.Environment.Graph
{
    /// <summary>
    /// IGraph provides an interface defining the attributes of a graph.
    /// </summary>
    public interface IGraph
    {
        /// <summary>
        /// A Property that gets the IDictionary of IGraphNode graph nodes data, indexed by a string.
        /// </summary>
        IDictionary<string, IGraphNode> GraphData { get; }
    }
}
