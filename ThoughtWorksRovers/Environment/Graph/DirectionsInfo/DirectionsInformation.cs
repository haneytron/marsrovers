namespace ThoughtWorksRovers.Program.Environment.Graph.DirectionsInfo
{
    /// <summary>
    /// DirectionsInformation is an implementation of IDirectionsInformation designed to store 
    /// a human-friendly direction as well as the offset in terms of a grid. For example, 
    /// a "N" direction might be offset X = 0, Y = 1.
    /// </summary>
    public class DirectionsInformation : IDirectionsInformation
    {
        private readonly string _name;
        private readonly int _xOffset;
        private readonly int _yOffset;

        /// <summary>
        /// The DirectionsInformation constructor populates the name and X and Y offsets of 
        /// the direction.
        /// </summary>
        /// <param name="name">The human-friendly name of the direction.</param>
        /// <param name="xOffset">The X offset of the direction.</param>
        /// <param name="yOffset">The Y offset of the direction.</param>
        public DirectionsInformation(string name, int xOffset, int yOffset)
        {
            _name = name;
            _xOffset = xOffset;
            _yOffset = yOffset;
        }

        /// <summary>
        /// A Property that gets the human-friendly name of the direction.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// A Property that gets the X offset of the direction.
        /// </summary>
        public int XOffset
        {
            get { return _xOffset; }
        }

        /// <summary>
        /// A Property that gets the Y offset of the direction.
        /// </summary>
        public int YOffset
        {
            get { return _yOffset; }
        }
    }
}
