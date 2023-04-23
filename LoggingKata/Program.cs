using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        //this is a project that is given multiple tocoBell locatins identified
        //by it LONGITUDE and LATITUDE in a .CSV file.
        //with this information the program will determine the fartest distance
        //between two taco bells.
        //TO PERFORM THIS WE WILL USE TWO NESTED FOR LOOPS with an IF STATEMENT
        //WHICH STOPS THE LOOP WHEN THE FARTEST DISTANCE IS IDENTEFIED. 
        static readonly ILog logger = new TacoLogger();                       //*0
        //thhis instance of the taco logger will allow us to LOG or call
        //LOGGER METHODS like a Warning...                                      *0
        //WE THEN SET THE CSV FILE AS A CONSTANT 
        const string csvPath = "TacoBell-US-AL.csv";                          //*0
        //THEN WE BEGIN IN THE MAIN 
        static void Main(string[] args)                                       //*0
        {                                                                     //*0
            logger.LogInfo("Log initialized.....");                           //*0                                                 
            string[] lines = File.ReadAllLines(csvPath);                      //*1
            //LINE ABOVE: "FILE.READALLLINES(CSVPATH)" using the FILE CLASS to  *1
            //readalllines" or Grabs each lines from                            *1
            //CSV FILE and turns them into a COLLECTION OF STRINGS.             *1
            //AND Log an error if you get 0 lines and a warning if              
            // you get 1 line 
            if (lines.Length == 0)
            {
                logger.LogError("file has no input");
            }
            if(lines.Length == 1)
            {
                logger.LogInfo($"file only has one line of input");
            }
            logger.LogInfo($"Lines: {lines[0]}");
            // Create a new instance of your TacoParser class
            var parser = new TacoParser();
            //ABOVE: is a new INSTANCE of TacoParser class

            // Grab an IEnumerable of locations using the Select command:       *3
            //This is where we call the PARSE METHOD using LINQ                 *3
            // \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/*3
            var locations = lines.Select(line => parser.Parse(line)).ToArray(); 
            //               ^for each 'line' in 'lineS' we are going to parse  *3
            //               that line into an ARRAY and store it into file     *3
            //               'Locations'^                                       *3
            // SINCE PARSE IS AN ITRACKABLE WE WILL STORE IT INTO A COLLECTION  *3
            // OF ITRACKABLES OR TACO BELLS                                     *3
            // /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\ /\*3
       
            // Now that your Parse method is completed, START BELOW ----------  *3
            
            //After creating strings we will create `ITRACKABLE` VARIABLES with *2
            //INITIAL VALUES of NULL for 2 LOCATIONS and 1 DOUBLE VARIABLE for  *2
            //DISTANCE                                                          *2
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double distance = 0;
            //AND GEO CORDINATES are used to get the DISTANCE betwEen LOCATIONS *2
           
            //NESTED LOOPS SECTION---------------------
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
