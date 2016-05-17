using System.Collections.Generic;
using ThoughtWorksRovers.Program.FileParser.ParsedData;

namespace ThoughtWorksRovers.Program.FileParser
{
    /// <summary>
    /// IParser provides an interface defining the attributes and qualities of all parsers.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// A Property to get the parsed upper-right bound coordinates as an object.
        /// </summary>
        IParsedCoordinatesData ParsedCoordinatesData { get; }
        /// <summary>
        /// A Property to get a list of objects representing parsed rover data.
        /// </summary>
        IList<IParsedRoverData> ParsedRoverDataObjects { get; }
    }
}
