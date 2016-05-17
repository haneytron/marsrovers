using System;
using System.Collections.Generic;
using ThoughtWorksRovers.Program.Environment.Graph.DirectionsInfo;

namespace ThoughtWorksRovers.Environment.Graph.DirectionsInfo
{
    /// <summary>
    /// DirectionsInfoContainer is an implementation of IDirectionsInfoContainer designed 
    /// to contain multiple IDirectionsInformation objects
    /// </summary>
    public class DirectionsInfoContainer : IDirectionsInfoContainer
    {
        private readonly IDictionary<int, IDirectionsInformation> _directionsInformation;

        /// <summary>
        /// The DirectionsInfoContainer constructor populates the IDictionary of 
        /// IDirectionsInformation objects.
        /// </summary>
        /// <param name="directionsInformation">The IDictionary of IDirectionsInformation objects.</param>
        public DirectionsInfoContainer(IDictionary<int, IDirectionsInformation> directionsInformation)
        {
            _directionsInformation = directionsInformation;
        }

        /// <summary>
        /// Converts a direction that is in integer form into a human-friendly representation.
        /// </summary>
        /// <param name="direction">The direction to convert, in integer form.</param>
        /// <returns>A string representing the human-friendly direction.</returns>
        public string GetDirectionPrinterFriendly(int direction)
        {
            if (!_directionsInformation.ContainsKey(direction))
            {
                throw new Exception("Attempted to retrieve a direction that does not exist in the graph node");
            }
            return _directionsInformation[direction].Name;
        }

        /// <summary>
        /// Converts a direction that is in a human-friendly string into integer form.
        /// </summary>
        /// <param name="direction">The human-friendly string representing the direction.</param>
        /// <returns>The direction, in integer form.</returns>
        public int GetDirectionInteger(string direction)
        {
            ICollection<int> keyList = _directionsInformation.Keys;
            foreach (int key in keyList)
            {
                if (_directionsInformation[key].Name == direction)
                {
                    return key;
                }
            }
            throw new Exception("Attempted to retrieve a direction that does not exist in the graph node");
        }

        /// <summary>
        /// A Property that gets the IDictionary of IDirectionsInformation objects.
        /// </summary>
        public IDictionary<int, IDirectionsInformation> DirectionsInformation
        {
            get { return _directionsInformation; }
        }
    }
}
