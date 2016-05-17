using ThoughtWorksRovers.Program.Environment.Graph;

namespace ThoughtWorksRovers.Program.Environment.Rover
{
    /// <summary>
    /// IRoverController provides an interface defining the attributes of rover controller objects. 
    /// Rover controllers are responsible for controlling an encapsulated IRover object.
    /// </summary>
    public interface IRoverController
    {
        /// <summary>
        /// Places the IRover encapsulated within the IRoverController on the desired IGraph object.
        /// </summary>
        /// <param name="graph">The target IGraph object to place the IRover upon.</param>
        /// <returns>true is the rover is placed, false is the rover has already been placed.</returns>
        bool PlaceRoverOnGraph(IGraph graph);
        /// <summary>
        /// Executes the IRover movement commands against the IRover encapsulated in this IRoverController.
        /// </summary>
        void ExecuteRoverMovementCommands();
        /// <summary>
        /// Outputs the rover information as desired in a simple manner.
        /// </summary>
        /// <returns>The desired output for the rover's current location in the desired format.</returns>
        string GetRoverLocation();
    }
}
