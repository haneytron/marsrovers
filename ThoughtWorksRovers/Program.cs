using System;
using ThoughtWorksRovers.Program.Environment;
using ThoughtWorksRovers.Program.FileParser;

namespace ThoughtWorksRovers.Program
{
    /// <summary>
    /// The Program class serves as the initial launch point of the application. It houses the statis Main
    /// function which serves to launch the application and validate input arguments.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The Main method serves to launch the application. It validates the input arguments, 
        /// calls the IParser responsible for parsing them, and then creates the IEnvironment 
        /// which houses all objects necessary for this solution (both the Rover and Grid components).
        /// NOTE: The exception handling method implemented is to throw all Exception to Main's catch
        /// NOTE: block, which will output error information in a friendly way to the user and then exit.
        /// </summary>
        /// <param name="args">The command-line arguments passed to the application</param>
        static void Main(string[] args)
        {
            string strInputFile = "None specified";
            // Do not execute program if arguments are not appropriate
            if (!IsArgsValid(args))
            {
                Console.Out.Write("usage: ThoughtWorksRovers <input_file_path>\n");
                return;
            }
            
            try
            {
                strInputFile = args[0];
                IParser textFileParser = new TextFileParser(strInputFile);
                IEnvironment roverEnvironment = new RoverEnvironment(textFileParser);
            }
            catch (Exception ex)
            {
                Console.Out.Write("An error has been encountered\n");
                Console.Out.Write("\tInput File: " + strInputFile + "\n");
                Console.Out.Write("\tReason: " + ex.Message + "\n");
                System.Environment.Exit(-1);
            }
        }

        /// <summary>
        /// IsArgsValid verifies that the correct number of arguments were passed in to the 
        /// command-line application.
        /// </summary>
        /// <param name="args">The array of arguments passed to the application.</param>
        /// <returns>true if number of arguments is proper, false otherwise.</returns>
        private static bool IsArgsValid(string[] args)
        {
            if (args.Length != 1)
            {                
                return false;
            }
            return true;
        }
    }
}
