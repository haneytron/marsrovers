using System;
using ThoughtWorksRovers.Environment.Graph.DirectionsInfo;
using ThoughtWorksRovers.Program.Environment.Graph;
using ThoughtWorksRovers.Program.Environment.Graph.Node;
using ThoughtWorksRovers.Program.FileParser.ParsedData;

namespace ThoughtWorksRovers.Program.Environment.Rover
{
    /// <summary>
    /// RoverController is an implementation of IRoverController responsible for acting as the 
    /// control mechanism for the IRover which is encapsulated within this class. It offers 
    /// functionality to place an IRover on a desired IGraph, execute the IRover's movement command 
    /// string, and output the IRover's current location.
    /// </summary>
    public class RoverController : IRoverController
    {
        private IRover _rover;
        private readonly IParsedRoverData _parsedRoverData;
        private readonly IDirectionsInfoContainer _directionsInfoContainer;
        
        /// <summary>
        /// The RoverController constructor stores the IParsedRoverData object as well as the 
        /// injected IDirectionsInfoContainer object.
        /// </summary>
        /// <param name="parsedRoverData">The IParsedRoverData object containing info for the IRover to be controlled.</param>
        /// <param name="directionsInfoContainer">The injected IDirectionsInfoContainer object that defines the orientation options for the IRover.</param>
        public RoverController(IParsedRoverData parsedRoverData, IDirectionsInfoContainer directionsInfoContainer)
        {
            _parsedRoverData = parsedRoverData;
            _directionsInfoContainer = directionsInfoContainer;
        }

        /// <summary>
        /// A standard factory pattern to create a newly instantiated IRover object.
        /// </summary>
        /// <param name="startingGraphNode">The initial IGraphNode to place the IRover upon.</param>
        /// <returns>A newly instantiated MarsRover object.</returns>
        private IRover CreateIRoverFactory(IGraphNode startingGraphNode)
        {
            return new MarsRover(_directionsInfoContainer.GetDirectionInteger(_parsedRoverData.StartingOrientation), startingGraphNode);
        }

        /// <summary>
        /// Places the IRover encapsulated within the IRoverController on the desired IGraph object.
        /// </summary>
        /// <param name="graph">The target IGraph object to place the IRover upon.</param>
        /// <returns>true is the rover is placed, false is the rover has already been placed.</returns>
        public bool PlaceRoverOnGraph(IGraph graph)
        {
            if (_rover != null)
            {
                return false;
            }

            _rover = CreateIRoverFactory(graph
                .GraphData[_parsedRoverData.StartingX.ToString() + _parsedRoverData.StartingY]);
            return true;
        }

        /// <summary>
        /// Executes the IRover movement commands against the IRover encapsulated in this IRoverController.
        /// </summary>
        public void ExecuteRoverMovementCommands()
        {
            if (_rover.CurrentGraphNode == null)
            {
                throw new Exception("Rover must be placed on a grid before movement can execute");
            }
            foreach (char command in _parsedRoverData.RoverControlCommands)
            {
                if (command == 'L')
                {
                    _rover.SetOrientation(((_rover.CurrentOrientation +
                                                  _directionsInfoContainer.DirectionsInformation.Count) - 1)%
                                                _directionsInfoContainer.DirectionsInformation.Count);
                }
                else if (command == 'R')
                {
                    _rover.SetOrientation(((_rover.CurrentOrientation +
                                                  _directionsInfoContainer.DirectionsInformation.Count) + 1) %
                                                _directionsInfoContainer.DirectionsInformation.Count);
                }
                else if (command == 'M')
                {
                    _rover.Move();
                }
                else
                {
                    throw new Exception("Mal-formed rover control commands data encountered");
                }
            }
        }

        /// <summary>
        /// Outputs the rover information as desired in a simple manner.
        /// </summary>
        /// <returns>The desired output for the rover's current location in the desired format.</returns>
        public string GetRoverLocation()
        {
            return _rover.CurrentGraphNode.XCoord + " " + _rover.CurrentGraphNode.YCoord + " " +
                   _directionsInfoContainer.GetDirectionPrinterFriendly(_rover.CurrentOrientation);
        }
    }
}
