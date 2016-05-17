using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ThoughtWorksRovers.Program.FileParser.ParsedData;

namespace ThoughtWorksRovers.Program.FileParser
{
    /// <summary>
    /// The TextFileParser is an implementation of IParser designed to parse text file input into 
    /// meaningful objects that contain the data of the aforementioned file. These objects are 
    /// available via get Properties.
    /// </summary>
    public class TextFileParser : IParser
    {
        private IParsedCoordinatesData _parsedCoordinatesData;
        private readonly IList<IParsedRoverData> _parsedRoverDataObjects = new List<IParsedRoverData>();

        /// <summary>
        /// The TextFileParser constructor.
        /// </summary>
        /// <param name="strFilePath">The windows path (relative or absolute) to the input text file.</param>
        public TextFileParser(string strFilePath)
        {
            _parsedRoverDataObjects = DoReadFile(strFilePath);
        }

        /// <summary>
        /// Reads the input text file sequentially and passes the rover information to a Parse function 
        /// which parses the data into meaningful representative objects. Does all error checking 
        /// regarding the input file.
        /// </summary>
        /// <param name="strFilePath">The windows path (relative or absolute) to the input text file.</param>
        /// <returns>An IList of IParsedRoverData objects representing rover information.</returns>
        private IList<IParsedRoverData> DoReadFile(string strFilePath)
        {
            IList<IParsedRoverData> parsedRoverDataObjects = new List<IParsedRoverData>();
            StreamReader streamReader;

            try
            {
                using (streamReader = File.OpenText(strFilePath))
                {
                    // The first line is the top-right coordinates
                    string currentLine = streamReader.ReadLine();
                    if (currentLine == null)
                    {
                        throw new Exception("Input file is empty");
                    }
                    Regex properCoordinatesInputPattern = new Regex("^[0-9]+ [0-9]+$");
                    if (!properCoordinatesInputPattern.IsMatch(currentLine))
                    {
                        throw new Exception("Mal-formed or missing top-right coordinates data encountered in input file");
                    }
                    string[] result = currentLine.Trim().Split(' ');
                    int xCoord = Convert.ToInt32(result[0]);
                    int yCoord = Convert.ToInt32(result[1]);
                    _parsedCoordinatesData = new ParsedCoordinatesData(xCoord, yCoord);

                    // Now handle all other lines per usual for rover data
                    string roverInitialLocation;
                    string roverControlCommands;
                    bool isRoverDataPresent = false;
                    while ((roverInitialLocation = streamReader.ReadLine()) != null)
                    {
                        isRoverDataPresent = true;
                        if ((roverControlCommands = streamReader.ReadLine()) == null)
                        {
                            throw new Exception("Missing rover data encountered in input file");
                        }
                        parsedRoverDataObjects.Add(Parse(roverInitialLocation.ToUpper(), roverControlCommands.ToUpper()));
                    }

                    if (!isRoverDataPresent)
                    {
                        throw new Exception("No rover data encountered in input file");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("The input file cannot be found.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("The input file cannot be read (" + ex.Message + ")", ex);
            }

            return parsedRoverDataObjects;
        }

        /// <summary>
        /// Parse validates the rover's initial coordinates information as well as the control commands. 
        /// It will throw exceptions as necessary to advise the user of mal-formed input. If the input 
        /// passes inspection, it is encapsulated within an IParsedRoverData object which is returned by 
        /// this function.
        /// </summary>
        /// <param name="roverInitialLocation">The input file line representing the rover's initial coordinates.</param>
        /// <param name="roverControlCommands">The input file line representing the rover's control command.</param>
        /// <returns></returns>
        private IParsedRoverData Parse(string roverInitialLocation, string roverControlCommands)
        {
            Regex properRoverInitialLocationInputPattern = new Regex("^[0-9]+ [0-9]+ [NESW]$");
            Regex properRoverControlCommandsInputPattern = new Regex("^[LRM]+$");
            roverInitialLocation = roverInitialLocation.ToUpper().Trim();
            roverControlCommands = roverControlCommands.ToUpper().Trim();
            
            if (!properRoverInitialLocationInputPattern.IsMatch(roverInitialLocation))
            {
                throw new Exception("Mal-formed rover initial location data encountered in input file: " + roverInitialLocation);
            }
            if (!properRoverControlCommandsInputPattern.IsMatch(roverControlCommands))
            {
                throw new Exception("Mal-formed rover control commands data encountered in input file: " + roverControlCommands);
            }

            string[] result = roverInitialLocation.Split(' ');
            int xCoord = Convert.ToInt32(result[0]);
            int yCoord = Convert.ToInt32(result[1]);
            string startingOrientation = result[2];

            if (xCoord < 0
                || xCoord > _parsedCoordinatesData.CoordinatesX)
            {
                throw new Exception("Rover coordinates are outside of the grid."
                    + " Grid: " + _parsedCoordinatesData
                    + " Coordinates: " + xCoord + "," + yCoord);
            }
            else if (yCoord < 0
                || yCoord > _parsedCoordinatesData.CoordinatesY)
            {
                throw new Exception("Rover coordinates are outside of the grid."
                    + " Grid: " + _parsedCoordinatesData
                    + " Coordinates: " + xCoord + "," + yCoord);
            }

            return new ParsedRoverData(xCoord, yCoord, startingOrientation, roverControlCommands);
        }

        /// <summary>
        /// A Property to get the parsed upper-right bound coordinates as an object.
        /// </summary>
        public IParsedCoordinatesData ParsedCoordinatesData
        {
            get { return _parsedCoordinatesData; }
        }

        /// <summary>
        /// A Property to get a list of objects representing parsed rover data.
        /// </summary>
        public IList<IParsedRoverData> ParsedRoverDataObjects
        {
            get { return _parsedRoverDataObjects; }
        }
    }
}
