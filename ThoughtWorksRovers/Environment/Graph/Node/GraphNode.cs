using System;
using System.Collections.Generic;

namespace ThoughtWorksRovers.Program.Environment.Graph.Node
{
    /// <summary>
    /// GraphNode is an implementation of IGraphNode designed to represent a graph node.
    /// Various properties defined by the IGraphNode interface allow for information to 
    /// be set and get regarding the graph node.
    /// </summary>
    public class GraphNode : IGraphNode
    {
        private readonly int _xCoord;
        private readonly int _yCoord;
        private readonly IDictionary<int, IGraphNode> _adjacentNodes;

        /// <summary>
        /// The GraphNode constructor. Assigns the X and Y coordinates of the graph node and 
        /// initializes the adjacent nodes IDictionary.
        /// </summary>
        /// <param name="xCoord">The X coordinate of the graph node.</param>
        /// <param name="yCoord">The Y coordinate of the graph node.</param>
        public GraphNode(int xCoord, int yCoord)
        {
            _xCoord = xCoord;
            _yCoord = yCoord;
            _adjacentNodes = new Dictionary<int, IGraphNode>();
        }

        /// <summary>
        /// A Property that gets the X coordinate of the graph node.
        /// </summary>
        public int XCoord
        {
            get { return _xCoord; }
        }

        /// <summary>
        /// A Property that gets the Y coordinate of the graph node.
        /// </summary>
        public int YCoord
        {
            get { return _yCoord; }
        }

        /// <summary>
        /// A Property that gets the Id of the graph node.
        /// </summary>
        public string Id
        {
            get { return _xCoord.ToString() + _yCoord; }
        }

        /// <summary>
        /// Sets an IGraphNode as an adjacent node to this IGraphNode at the specified direction.
        /// </summary>
        /// <param name="direction">The direction, in integer format, at which the adjacent node is to be placed.</param>
        /// <param name="adjacentNode">The IGraphNode to set as the adjacent node.</param>
        public void PutAdjacentNode(int direction, IGraphNode adjacentNode)
        {
            if (_adjacentNodes.ContainsKey(direction))
            {
                throw new Exception("Attempted to add an adjacent node in a direction that was already assigned");
            }
            _adjacentNodes.Add(direction,adjacentNode);
        }

        /// <summary>
        /// Gets the adjacent IGraphNode at the specified direction.
        /// </summary>
        /// <param name="direction">The direction, in integer format, at which the adjacent node exists.</param>
        /// <returns>The IGraphNode that is adjacent to the current IGraphNode at the specified direction.</returns>
        public IGraphNode GetAdjacentNode(int direction)
        {
            if (!_adjacentNodes.ContainsKey(direction))
            {
                throw new Exception("Attempted to get an adjacent node in a direction that has not been assigned");
            }
            return _adjacentNodes[direction];
        }
    }
}
