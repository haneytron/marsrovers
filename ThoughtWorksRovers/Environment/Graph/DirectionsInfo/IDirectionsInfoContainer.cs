using System.Collections.Generic;
using ThoughtWorksRovers.Program.Environment.Graph.DirectionsInfo;

namespace ThoughtWorksRovers.Environment.Graph.DirectionsInfo
{
    /// <summary>
    /// IDirectionsInfoContainer provides an interface defining the attributes of a 
    /// directions information container object. This object contains multiple 
    /// IDirectionsInformation objects.
    /// </summary>
    public interface IDirectionsInfoContainer
    {
        /// <summary>
        /// Converts a direction that is in integer form into a human-friendly representation.
        /// </summary>
        /// <param name="direction">The direction to convert, in integer form.</param>
        /// <returns>A string representing the human-friendly direction.</returns>
        string GetDirectionPrinterFriendly(int direction);
        /// <summary>
        /// Converts a direction that is in a human-friendly string into integer form.
        /// </summary>
        /// <param name="direction">The human-friendly string representing the direction.</param>
        /// <returns>The direction, in integer form.</returns>
        int GetDirectionInteger(string direction);
        /// <summary>
        /// A Property that gets the IDictionary of IDirectionsInformation objects.
        /// </summary>
        IDictionary<int, IDirectionsInformation> DirectionsInformation { get; }
    }
}
