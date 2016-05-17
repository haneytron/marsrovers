namespace ThoughtWorksRovers.Program.FileParser.ParsedData
{
    /// <summary>
    /// IParsedRoverData provides an interface defining the attributes and qualities of all objects 
    /// which will represent parsed rover data.
    /// </summary>
    public interface IParsedRoverData
    {
        /// <summary>
        /// A Property to get the starting X coordinate of the rover.
        /// </summary>
        int StartingX { get; }
        /// <summary>
        /// A Property to get the starting Y coordinate of the rover.
        /// </summary>
        int StartingY { get; }
        /// <summary>
        /// A property to get the starting orientation (in human terms ie: "N", "S", etc.) of the rover.
        /// </summary>
        string StartingOrientation { get; }
        /// <summary>
        /// A property to get the string of movement commands for the rover to perform.
        /// </summary>
        string RoverControlCommands { get; }
        /// <summary>
        /// A ToString overload to output the rover information as desired in a simple manner 
        /// when the object is referenced in string output, such as to console.
        /// </summary>
        /// <returns>The desired output for the rover's initial location in the desired format.</returns>
        string ToString();
    }
}
