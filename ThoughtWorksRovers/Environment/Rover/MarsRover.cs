using ThoughtWorksRovers.Program.Environment.Graph.Node;

namespace ThoughtWorksRovers.Program.Environment.Rover
{
    /// <summary>
    /// MarsRover is an implementation of IRover designed for the Mars Rover solution.
    /// MarsRovers are placed upon a grid/graph at which point they can move and output information.
    /// </summary>
    public class MarsRover : IRover
    {
        private int _currentOrientation;
        private IGraphNode _currentGraphNode;

        /// <summary>
        /// The MarsRover constructor populates the initial orientation (in integer form) as 
        /// well as the IGraphNode upon which to initially place the MarsRover.
        /// </summary>
        /// <param name="currentOrientation">The initial orientation of the MarsRover, in integer form.</param>
        /// <param name="startingGraphNode">The initial IGraphNode upon which to initially place the MarsRover.</param>
        public MarsRover(int currentOrientation, IGraphNode startingGraphNode)
        {
            _currentOrientation = currentOrientation;
            _currentGraphNode = startingGraphNode;
        }

        /// <summary>
        /// Sets the orientation of the rover at its current location.
        /// </summary>
        /// <param name="newOrientation">The direction for the rover to face, in integer format.</param>
        public void SetOrientation(int newOrientation)
        {
            _currentOrientation = newOrientation;
        }

        /// <summary>
        /// Moves the rover.
        /// </summary>
        public void Move()
        {
            if (!(_currentGraphNode.GetAdjacentNode(_currentOrientation) == null))
            {
                _currentGraphNode = _currentGraphNode.GetAdjacentNode(_currentOrientation);
            }
        }

        /// <summary>
        /// A Property that gets the current orientation of the rover, in integer format.
        /// </summary>
        public int CurrentOrientation
        {
            get { return _currentOrientation; }
        }

        /// <summary>
        /// A Property that gets the current IGraphNode object that the rover is situation upon.
        /// </summary>
        public IGraphNode CurrentGraphNode
        {
            get { return _currentGraphNode; }
        }
    }
}
