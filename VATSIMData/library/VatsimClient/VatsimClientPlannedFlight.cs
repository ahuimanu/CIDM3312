using System;

namespace VatsimLibrary.VatsimClient
{
    public class VatsimClientPlannedFlight : VatsimClient
    {
        public string PlannedAircraft { get; set; }
        public string PlannedAltitude { get; set; }        
        public string PlannedAltairport { get; set; }        
        public string PlannedDepairport { get; set; }
        public string PlannedDepairportLat { get; set; }
        public string PlannedDestairportLon { get; set; }        
        public string PlannedDestairport { get; set; }
        public string PlannedDepairportLon { get; set; }
        public string PlannedDestairportLat { get; set; }        
        public string PlannedFlighttype { get; set; }
        public string PlannedDeptime { get; set; }
        public string PlannedActdeptime { get; set; }
        public string PlannedHrsenroute { get; set; }
        public string PlannedMinenroute { get; set; }
        public string PlannedHrsfuel { get; set; }
        public string PlannedMinfuel { get; set; }
        public string PlannedRemarks { get; set; }
        public string PlannedRevision { get; set; }        
        public string PlannedRoute { get; set; }
        public string PlannedTascruise { get; set; }

    }
}