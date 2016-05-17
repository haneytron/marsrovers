namespace ThoughtWorksRovers.Program.FileParser.ParsedData
{
    /// <summary>
    /// ParsedCoordinatesData is an implementation of IParsedCoordinatesData designed to represent 
    /// the upper-right boundaries of the grid received via input source to the application 
    /// in an object-oriented way. Various properties defined by the interface exist to allow 
    /// access to meaningful grid upper-right coordinate information.
    /// </summary>
    public class ParsedCoordinatesData : IParsedCoordinatesData
    {
        private readonly int _coordinatesX;
        private readonly int _coordinatesY;

        /// <summary>
        /// The ParsedCoordinatesData constructor populates all private readonly fields which 
        /// contain data from the input source. This entire class is read-only in effect.
        /// </summary>
        /// <param name="coordinatesX">The X coordinate of the upper-right coordinates of the grid.</param>
        /// <param name="coordinatesY">The Y coordinate of the upper-right coordinates of the grid.</param>
        public ParsedCoordinatesData(int coordinatesX, int coordinatesY)
        {
            _coordinatesX = coordinatesX;
            _coordinatesY = coordinatesY;
        }

        /// <summary>
        /// A Property to get the X coordinate of the upper-right coordinates of the grid.
        /// </summary>
        public int CoordinatesX
        {
            get { return _coordinatesX; }
        }

        /// <summary>
        /// A Property to get the Y coordinate of the upper-right coordinates of the grid.
        /// </summary>
        public int CoordinatesY
        {
            get { return _coordinatesY; }
        }

        /// <summary>
        /// A ToString overload to output the upper-right coordinates information as desired 
        /// in a simple manner when the object is referenced in string output, such as to console.
        /// </summary>
        /// <returns>The desired output for the upper-right coordinates information in the desired format.</returns>
        public override string ToString()
        {
            return "(" + _coordinatesX + "," + _coordinatesY + ")";
        }
    }
}
