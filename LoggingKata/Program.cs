using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();                         //this will allow us to LOG or call LOGGER METHODS ie. logger.LogWarning or (line 18)...
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one
            // another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized.....");

            // COMPLETED - use File.ReadAllLines(path) to grab all the lines
            // from your csv file
            // COMPLETED - Log and error if you get 0 lines and a warning if
            // you get 1 line
            string[] lines = File.ReadAllLines(csvPath);                        //Grabs each lines from csv file and turns them into a collection of strings 
            if(lines.Length == 0)
            {
                logger.LogError("file has no input");
            }

            if(lines.Length == 1)
            {
                logger.LogInfo($"file only has one line of input");
            }

            logger.LogInfo($"Lines: {lines[0]}");


            

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();                                      //this is a new INSTANCE of TacoParser class

            // Grab an IEnumerable of locations using the Select command:
            // var locations = lines.Select(parser.Parse);
            // \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/
            var locations = lines.Select(line => parser.Parse(line)).ToArray(); //This is where we call the PARSE METHOD using LINQ
            //               ^for each 'line' in 'linse' we are going to parse
            //               that line into an ARRAY and store it into file
            //               'Locations'^
            // SINCE PARSE IS AN ITRACKABLE WE WILL STORE IT INTO A COLLECTION OF ITRACKABLES OR TACO BELLS
            // /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // COMPLETED - TODO: Create two `ITrackable` variables with initial values of
            // COMPLETED - `null`. These will be used to store your two taco bells that are
            // COMPLETED - the farthest from each other.
            // COMPLETED - Create a `double` variable to store the distance
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double distance = 0;

            // DONE Include the Geolocation toolbox, so you can compare
            // locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            for (int i = 0; i < locations.Length; i++)
            {
                // Do a loop for your locations to grab each location as the
                // origin (perhaps: `locA`)
                
                var runLocalA = locations[i];


                // Create a new corA Coordinate with your locA's lat and long
                var corA = new GeoCoordinate();
                corA.Latitude = runLocalA.Location.Latitude;
                corA.Longitude = runLocalA.Location.Longitude;
                // /\ /\ /\ /\GONNA USE THIS TO COMPARE TO OTHER LOCATIONS/\ /\ 
                // Now, do another loop on the locations with the scope of your
                // first loop, so you can grab the "destination" location
                // (perhaps: `locB`)
                for (int j = 0; j < locations.Length; j++)                      //use j because i used in initial for loop (line 70) 
                {
                    // Create a new Coordinate with your locB's lat and long

                    var runLocalB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = runLocalB.Location.Latitude;
                    corB.Longitude = runLocalB.Location.Longitude;

                    // Now, compare the two using `.GetDistanceTo()`, which returns
                    // a double

                    // If the distance is greater than the currently saved distance,
                    // update the distance and the two `ITrackable` variables you
                    // set above
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = runLocalA;
                        tacoBell2 = runLocalB;
                    }
                }


            }


            // Once you've looped through everything, you've found the two Taco
            // Bells farthest away from each other.

            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are the farthest apart");

        }
    }
}
