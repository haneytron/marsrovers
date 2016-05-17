namespace ThoughtWorksRovers.Program.FileParser.ParsedData
{
    /// <summary>
    /// ParsedRoverData is an implementation of IParsedRoverData designed to represent the rover data 
    /// received via input source to the application in an object-oriented way. Various properties defined by 
    /// the interface exist to allow access to meaningful rover information.
    /// </summary>
    public class ParsedRoverData : IParsedRoverData
    {
        private readonly int _startingX;
        private readonly int _startingY;
        private readonly string _startingOrientation;
        private readonly string _roverControlCommands;

        /// <summary>
        /// The ParsedRoverData constructor populates all private readonly fields which contain data from 
        /// the input source. This entire class is read-only in effect.
        /// </summary>
        /// <param name="startingX">The starting X coordinate of the rover.</param>
        /// <param name="startingY">The starting Y coordinate of the rover.</param>
        /// <param name="startingOrientation">The starting orientation (in human terms ie: "N", "S", etc.) of the rover.</param>
        /// <param name="roverControlCommands">The string of movement commands for the rover to perform.</param>
        public ParsedRoverData(int startingX, int startingY, string startingOrientation, string roverControlCommands)
        {
            _startingX = startingX;
            _roverControlCommands = roverControlCommands;
            _startingOrientation = startingOrientation;
            _startingY = startingY;
        }

        /// <summary>
        /// A Property to get the starting X coordinate of the rover.
        /// </summary>
        public int StartingX
        {
            get { return _startingX; }
        }

        /// <summary>
        /// A Property to get the starting Y coordinate of the rover.
        /// </summary>
        public int StartingY
        {
            get { return _startingY; }
        }

        /// <summary>
        /// A property to get the starting orientation (in human terms ie: "N", "S", etc.) of the rover.
        /// </summary>
        public string StartingOrientation
        {
            get { return _startingOrientation; }
        }

        /// <summary>
        /// A property to get the string of movement commands for the rover to perform.
        /// </summary>
        public string RoverControlCommands
        {
            get { return _roverControlCommands; }
        }

        /// <summary>
        /// A ToString overload to output the rover information as desired in a simple manner 
        /// when the object is referenced in string output, such as to console.
        /// </summary>
        /// <returns>The desired output for the rover's initial location in the desired format.</returns>
        public override string ToString()
        {
            return "(" + _startingX + "," + _startingY + ")";
        }
    }
}
