using System;

using VatsimLibrary.VatsimData;

namespace VatsimLibrary.VatsimClient
{

    public class VatsimClientATC : VatsimClient
    {
        public string ATCCallsign { get; set; }
        public string AtisMessage { get; set; }                
        public string Frequency { get; set; }
        public string Facilitytype { get; set; }
        public string Rating { get; set; }        
        public string Visualrange { get; set; }
    }
}