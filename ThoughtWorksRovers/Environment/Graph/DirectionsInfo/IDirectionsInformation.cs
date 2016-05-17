namespace ThoughtWorksRovers.Program.Environment.Graph.DirectionsInfo
{
    /// <summary>
    /// IDirectionsInformation provides an interface defining the attributes of a directions 
    /// information object. The object stores a human-friendly direction as well as the offset 
    /// in terms of an object upon which the directions will be used.
    /// </summary>
    public interface IDirectionsInformation
    {
        /// <summary>
        /// A Property that gets the human-friendly name of the direction.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// A Property that gets the X offset of the direction.
        /// </summary>
        int XOffset { get; }
        /// <summary>
        /// A Property that gets the Y offset of the direction.
        /// </summary>
        int YOffset { get; }
    }
}
