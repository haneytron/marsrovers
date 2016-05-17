using ThoughtWorksRovers.Program.Environment.Graph.Node;

namespace ThoughtWorksRovers.Program.Environment.Rover
{
    /// <summary>
    /// IRover provides an interface defining the attributes of rover objects. 
    /// Rovers are placed upon a grid/graph at which point they can move and output information.
    /// </summary>
    public interface IRover
    {
        /// <summary>
        /// Sets the orientation of the rover at its current location.
        /// </summary>
        /// <param name="newOrientation">The direction for the rover to face, in integer format.</param>
        void SetOrientation(int newOrientation);
        /// <summary>
        /// Moves the rover.
        /// </summary>
        void Move();
        /// <summary>
        /// A Property that gets the current orientation of the rover, in integer format.
        /// </summary>
        int CurrentOrientation { get; }
        /// <summary>
        /// A Property that gets the current IGraphNode object that the rover is situation upon.
        /// </summary>
        IGraphNode CurrentGraphNode { get; }
    }
}
