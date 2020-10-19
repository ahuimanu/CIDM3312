using System;

namespace VatsimLibrary.VatsimClient
{
    public class VatsimClientPilotSnapshot : VatsimClient
    {
        public DateTime TimeStamp { get; set; }
        public string Altitude { get; set; }
        public string Groundspeed { get; set; }
        public string Transponder { get; set; }
        public string Heading { get; set; }
        public string QNH_iHg { get; set; }
        public string QNH_Mb { get; set; }

        public override string ToString()
        {
            return $"{this.Cid} - {this.Callsign} - {this.Latitude} - {this.Longitude}";
        }

    }
}