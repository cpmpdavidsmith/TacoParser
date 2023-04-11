namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^     <- THIS METHOD WILL RETURN AN ITRACKABLE
            // EVERY TIME A STRING IS 'PARSED' AN TURNED 'INTO AN ITRACKABLE'                       AND
            //---------------------       THEN      -------------------------        ANYTHING THAT 'CONFORMS' TO ITRACKABLE


            //  \/\/\/\/\/  LOGGER TAKES "STRING" AND LOGGS IT   \/\/\/\/\/\/
            logger.LogInfo("Begin parsing");
            //  -------------------       THEN      -------------------------


            // Take your line and use line.Split(',') to split it up into an
            // array of strings, separated by the char ','
            //  \/\/\/\/\/\/\/\/    SPLIT BY 'CHAR' (,)    \/\/\/\/\/\/\/\/\/
            var cells = line.Split(',');
            //  /\ /\ /\ /\ /\ /\  PLACE IN FILE CALLED "CELLS"   /\ /\ /\ /\
            //---------------------       THEN       ------------------------


            // If your array.Length is less than 3, something went wrong
            //  \/\/\/\/\/\/\/\/  RETURN 'NULL' IF    \/\/\/\/\/\/\/\/\/\/\/\/
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogWarning("LESS THAN 3 ITEMS IN THIS LINE..." +
                                    "MISSING NECESSARY INFORMATION");
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }
            //--------------------      THEN        --------------------------


            // grab the latitude from your array at index 0
            // \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/
            // \/ LATITUDE IS A 'DOUBLE' THEN "LINQ" WITH 'PARSE' @ INDEX [0] \/ 
            var latitude = double.Parse(cells[0]);
            // /\ /\ /\ /\         STORE IN FILE LATITUDE          /\ /\ /\ /\ 
            //--------------------      THEN        --------------------------


            // grab the longitude from your array at index 1
            // \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/
            // LONGITUDE IS ALSO A 'DOUBLE' THEN "LINQ" WITH 'PARSE' @ INDEX [1]
            var longitude = double.Parse(cells[1]);
            // /\ /\ /\ /\         STORE IN FILE LONGITUDE         /\ /\ /\ /\ 
            //--------------------      THEN        --------------------------


            // grab the name from your array at index 2
            // \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/ \/
            // NAME IS A STRING @ INDEX [2]
            var name = cells[2];
            // COMPLETED - Your going to need to parse your string as a `double`
            // COMPLETED - which is similar to parsing a string as an `int`
            // /\ /\ /\         STORE IN FILE "NAME"              /\ /\ /\ /\
            //--------------------      THEN        --------------------------


            // COMPLETED - You'll need to create a TacoBell class
            // COMPLETED - that conforms to ITrackable
            //--------------------      THEN        --------------------------


            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            // \/ \/ \/ \/ INSTANCE \/ \/ \/ \/ \/ \/
            // WE USE A 'STRUC' WHICH IS LIKE A CLASS BUT INSTEAD OF A REFERENCE
            // TYPE IT IS A VALUE TYPE
            //1. WE STORE THE LAT AND LONG IN POINT
            //2. THEN WE STORE THE POINT IN LOCATION
            //3. \/ \/SO WE CREATE A NEW INSTANCE OF THE POINT STRUCT
            var point = new Point();//<- THIS IS AN INSTANCE OF LOCATION PROPERTY TYPE POINT
            point.Latitude = latitude;
            point.Longitude = longitude;
            // [(LINES; 83+84) PUT IN POINT @ (LINE 82)] 
            // /\ /\ /\ TOOK ALL THIS /\ /\ /\
            //THEN STROREDS IT IN LOCATON \/ \/ \/  (LINE 89)
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;
            //'LOCATION IS A 'POINT' WHICH IS A 'STRUCT' CLASS CALLED 'POINT' 
            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell;
        }
    }
}