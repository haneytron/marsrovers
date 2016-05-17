namespace ThoughtWorksRovers.Program.Environment.Graph.Node
{
    /// <summary>
    /// Provides an interface defining the attributes of a graph node.
    /// </summary>
    public interface IGraphNode
    {
        /// <summary>
        /// A Property that gets the X coordinate of the graph node.
        /// </summary>
        int XCoord { get; }
        /// <summary>
        /// A Property that gets the Y coordinate of the graph node.
        /// </summary>
        int YCoord { get; }
        /// <summary>
        /// A Property that gets the Id of the graph node.
        /// </summary>
        string Id { get; }
        /// <summary>
        /// Sets an IGraphNode as an adjacent node to this IGraphNode at the specified direction.
        /// </summary>
        /// <param name="direction">The direction, in integer format, at which the adjacent node is to be placed.</param>
        /// <param name="adjacentNode">The IGraphNode to set as the adjacent node.</param>
        void PutAdjacentNode(int direction, IGraphNode adjacentNode);
        /// <summary>
        /// Gets the adjacent IGraphNode at the specified direction.
        /// </summary>
        /// <param name="direction">The direction, in integer format, at which the adjacent node exists.</param>
        /// <returns>The IGraphNode that is adjacent to the current IGraphNode at the specified direction.</returns>
        IGraphNode GetAdjacentNode(int direction);
    }
}
