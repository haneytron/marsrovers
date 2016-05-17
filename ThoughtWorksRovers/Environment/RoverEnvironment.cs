using System;
using System.Collections.Generic;
using ThoughtWorksRovers.Environment.Graph.DirectionsInfo;
using ThoughtWorksRovers.Program.Environment.Graph;
using ThoughtWorksRovers.Program.Environment.Graph.DirectionsInfo;
using ThoughtWorksRovers.Program.Environment.Rover;
using ThoughtWorksRovers.Program.FileParser;
using ThoughtWorksRovers.Program.FileParser.ParsedData;

namespace ThoughtWorksRovers.Program.Environment
{
    /// <summary>
    /// RoverEnvironment is an implementation of IEnvironment designed to contain and control 
    /// IRoverControllers  as well as an IGraph and the IDirectionsInfoContainer. It basically 
    /// encapsulates all of the key ingredients to the solution of the mars rover problem, 
    /// while allowing the grid and rover controllers (and thus rovers) to remain mutually 
    /// exclusive. Constructor injection is used to  pass the IDirectionsInfoContainer to 
    /// the IRoverController and IGraph objects.
    /// </summary>
    public class RoverEnvironment : IEnvironment
    {
        private readonly IGraph _roverGraph;
        private readonly IList<IRoverController> _roverControllers;
        private readonly IDirectionsInfoContainer _directionsInfoContainer;

        /// <summary>
        /// The RoverEnvironment constructor creates the IDirectionsInfoContainer and then 
        /// populates the IRoverControllers and IGraph by passing them the IParser and 
        /// IDirectionsInfoContainer objects. Finally, it does the movement and output for all 
        /// rovers sequentially.
        /// </summary>
        /// <param name="fileParser">The IParser containing the graph and rover information.</param>
        public RoverEnvironment(IParser fileParser)
        {
            _directionsInfoContainer = PopulateDirectionsInformation();
            _roverGraph = new RoverGraph(fileParser, _directionsInfoContainer);
            _roverControllers = CreateRoverControllers(fileParser.ParsedRoverDataObjects);

            MoveAndOutputAllRovers();

        }

        /// <summary>
        /// Sequentially executives each rover's movement commands and then outputs the 
        /// resulting coordinates to the console.
        /// </summary>
        private void MoveAndOutputAllRovers()
        {
            foreach (IRoverController roverController in _roverControllers)
            {
                roverController.PlaceRoverOnGraph(_roverGraph);
                roverController.ExecuteRoverMovementCommands();
                Console.Out.WriteLine(roverController.GetRoverLocation());
            }
        }

        /// <summary>
        /// Creates and populates an IList of IRoverControllers. There is one IRoverController 
        /// per IRover, and the IRoverController is used to affect the IRover.
        /// </summary>
        /// <param name="parsedRoverData">An IList of IParsedRoverData objects container rover information.</param>
        /// <returns></returns>
        private IList<IRoverController> CreateRoverControllers(IList<IParsedRoverData> parsedRoverData)
        {
            IList<IRoverController> roverControllers = new List<IRoverController>();
            foreach (IParsedRoverData parsedRoverDataObject in parsedRoverData)
            {
                roverControllers.Add(new RoverController(parsedRoverDataObject, _directionsInfoContainer));
            }
            return roverControllers;
        }

        /// <summary>
        /// Creates and populates an IDirectionsInfoContainer of possible movement directions. 
        /// This container is used to connect the grid (graph) nodes, as well as provide a key for IRover 
        /// orientation options. This container allows for scalability, thereby allowing future versions 
        /// of this solution to accomodate alternative movement such as 8 directional 
        /// (N, NE, E, SE, S, SW, W, NW). The IGraph and IRovers would be able to operate accordingly and 
        /// automatically.
        /// </summary>
        /// <returns>An instantiated DirectionsInfoContainer class which contains movement information.</returns>
        private IDirectionsInfoContainer PopulateDirectionsInformation()
        {
            IDictionary<int, IDirectionsInformation> directionsInformation = new Dictionary<int, IDirectionsInformation>();
            directionsInformation.Add(0, new DirectionsInformation("N", 0, 1));
            directionsInformation.Add(1, new DirectionsInformation("E", 1, 0));
            directionsInformation.Add(2, new DirectionsInformation("S", 0, -1));
            directionsInformation.Add(3, new DirectionsInformation("W", -1, 0));
            return new DirectionsInfoContainer(directionsInformation);
        }
    }
}
