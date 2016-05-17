namespace ThoughtWorksRovers.Program.FileParser.ParsedData
{
    /// <summary>
    /// IParsedCoordinatesData provides an interface defining the attributes of objects that will 
    /// encapsulate the upper-right coordinates of the grid.
    /// </summary>
    public interface IParsedCoordinatesData
    {
        /// <summary>
        /// A Property to get the X coordinate of the upper-right coordinates of the grid.
        /// </summary>
        int CoordinatesX { get; }
        /// <summary>
        /// A Property to get the Y coordinate of the upper-right coordinates of the grid.
        /// </summary>
        int CoordinatesY { get; }
        /// <summary>
        /// A ToString overload to output the upper-right coordinates information as desired 
        /// in a simple manner when the object is referenced in string output, such as to console.
        /// </summary>
        /// <returns>The desired output for the upper-right coordinates information in the desired format.</returns>
        string ToString();
    }
}
