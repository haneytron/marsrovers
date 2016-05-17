using System;
using System.Collections.Generic;
using ThoughtWorksRovers.Environment.Graph.DirectionsInfo;
using ThoughtWorksRovers.Program.Environment.Graph.DirectionsInfo;
using ThoughtWorksRovers.Program.Environment.Graph.Node;
using ThoughtWorksRovers.Program.FileParser;
using ThoughtWorksRovers.Program.FileParser.ParsedData;

namespace ThoughtWorksRovers.Program.Environment.Graph
{
    /// <summary>
    /// RoverGraph is an implementation of IGraph designed for the Mars Rover solution. 
    /// It defines the grid upon which the IRover objects are placed. This grid is a 
    /// directed graph. 
    /// </summary>
    public class RoverGraph : IGraph
    {
        private readonly IDictionary<string,IGraphNode> _graphData;
        private readonly IParsedCoordinatesData _upperRightCoordinateBoundary;
        private readonly IDirectionsInfoContainer _directionsInfoContainer;

        /// <summary>
        /// The RoverGraph constructor stores the injected IDirectionsInfoContainer as well as 
        /// the ParsedCoordinatesData of the IParser.
        /// </summary>
        /// <param name="fileParser">The IParsed containing the grid and rover data.</param>
        /// <param name="directionsInfoContainer">The injected IDirectionsInfoContainer object that defines the directions in which the IGraphNodes are connected.</param>
        public RoverGraph(IParser fileParser, IDirectionsInfoContainer directionsInfoContainer)
        {
            _directionsInfoContainer = directionsInfoContainer;
            // Set the upper right boundary
            _upperRightCoordinateBoundary = fileParser.ParsedCoordinatesData;
            _graphData = PopulateGraphNodes();
            ConnectAllNodes();
        }

        /// <summary>
        /// Creates and populates all of the IGraphNodes of the graph.
        /// </summary>
        /// <returns>An IDictionary of IGraphNode graph nodes data, indexed by a string.</returns>
        private IDictionary<string,IGraphNode> PopulateGraphNodes()
        {
            IDictionary<string, IGraphNode> graphNodes = new Dictionary<string, IGraphNode>();
            for (int x = 0; x <= _upperRightCoordinateBoundary.CoordinatesX; x++)
            {
                for (int y = 0; y <= _upperRightCoordinateBoundary.CoordinatesY; y++)
                {
                    IGraphNode newNode = FactoryCreateIGraphNode(x, y);
                    graphNodes.Add(newNode.Id,newNode);
                }
            }
            return graphNodes;
        }

        /// <summary>
        /// Connects all adjacent nodes. Adjacencies are defined by the injected IDirectionsInfoContainer 
        /// which describes the directions in which the IGraphNodes can be connected, and the X and Y 
        /// offsets that each human-friendly direction defines in terms of a grid. Grid/graph boundaries are 
        /// determined by null adjacent IGraphNodes.
        /// </summary>
        private void ConnectAllNodes()
        {
            for (int x = 0; x <= _upperRightCoordinateBoundary.CoordinatesX; x++)
            {
                for (int y = 0; y <= _upperRightCoordinateBoundary.CoordinatesY; y++)
                {
                    IGraphNode currentNode = _graphData[x.ToString() + y];
                    foreach (IDirectionsInformation directionsInformation in _directionsInfoContainer.DirectionsInformation.Values)
                    {
                        int xTotal = currentNode.XCoord + directionsInformation.XOffset;
                        int yTotal = currentNode.YCoord + directionsInformation.YOffset;
                        if (xTotal < 0 || xTotal > _upperRightCoordinateBoundary.CoordinatesX)
                        {
                            currentNode.PutAdjacentNode(_directionsInfoContainer.GetDirectionInteger(directionsInformation.Name),null);
                        }
                        else if (yTotal < 0 || yTotal > _upperRightCoordinateBoundary.CoordinatesY)
                        {
                            currentNode.PutAdjacentNode(_directionsInfoContainer.GetDirectionInteger(directionsInformation.Name), null);
                        }
                        else
                        {
                            currentNode.PutAdjacentNode(
                                _directionsInfoContainer.GetDirectionInteger(directionsInformation.Name), 
                                _graphData[xTotal.ToString()+yTotal]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// A standard factory pattern to create a newly instantiated IGraphNode object.
        /// </summary>
        /// <param name="xCoord">The X coordinate of the IGraphNode.</param>
        /// <param name="yCoord">The Y coordinate of the IGraphNode.</param>
        /// <returns>A newly instantiated GraphNode object.</returns>
        private IGraphNode FactoryCreateIGraphNode(int xCoord, int yCoord)
        {
            if (_directionsInfoContainer.DirectionsInformation.Count == 4)
            {
                return new GraphNode(xCoord, yCoord);
            }
                throw new Exception("Number of directions in IDirectionsInfoContainer "
                                        + "was invalid, should be 4 (N,E,S,W)");
        }

        /// <summary>
        /// A Property that gets the IDictionary of IGraphNode graph nodes data, indexed by a string.
        /// </summary>
        public IDictionary<string, IGraphNode> GraphData
        {
            get { return _graphData; }
        }
    }
}
