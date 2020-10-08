using System;
using System.Collections.Generic;

namespace VatsimLibrary
{
    public class VatsimData
    {
        // List of Vatsim Client Records
        public List<VatsimClientRecord> VatsimClientRecords {get; set; } = new List<VatsimClientRecord>();
        public string VatsimDataUrl {get; set;}
        public string VatsimServersUrl {get; set;}
        public string VatsimMetarUrl {get; set;}
        public string VatsimDataVersion {get; set;}
        public string VatsimDataReload {get; set;}
        public DateTime VatsimDataLastUpdated { get; set;}
        public string VatsimDataConnectedClients {get; set;}
        public string VatsimDataUniqueUsers {get; set;}        
    }
}            
