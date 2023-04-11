using System;
namespace LoggingKata
{
	public class TacoBell : ITrackable//conform to ITrackable
	{//THIS CLASS I A MODEL TO AN INSTANCE...
		public TacoBell()
		{
		}
		//CONFORMED
        public string Name { get; set; }
		//CONFORMED
        public Point Location { get; set; }
   }
}

