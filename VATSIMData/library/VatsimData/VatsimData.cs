using System;
using System.Collections.Generic;

using VatsimLibrary.VatsimClient;

namespace VatsimLibrary.VatsimData
{
    public class VatsimData
    {

        private const bool IFRONLY = true;

        // List of Vatsim Client Records
        public List<VatsimClientRecord> VatsimClientRecords {get; set; } = new List<VatsimClientRecord>();

        // List of Vatsim Pilots
        public List<VatsimClientPilot> VatsimClientPilots { get; set; } = new List<VatsimClientPilot>();

        // List of Vatsim ATC
        public List<VatsimClientATC> VatsimClientATCs { get; set; } = new List<VatsimClientATC>();

        public string VatsimDataUrl {get; set;}
        public string VatsimServersUrl {get; set;}
        public string VatsimMetarUrl {get; set;}
        public string VatsimDataVersion {get; set;}
        public string VatsimDataReload {get; set;}
        public DateTime VatsimDataLastUpdated { get; set;}
        public string VatsimDataConnectedClients {get; set;}
        public string VatsimDataUniqueUsers {get; set;}

        /// <summary>
        /// Run through the list of clients to parse out ATC and Pilots
        /// </summary>
        public void ProcessVatsimClientRecords()
        {
            // are there any clients to process?
            if(VatsimClientRecords != null && VatsimClientRecords.Count > 0)
            {
                foreach (VatsimClientRecord record in VatsimClientRecords)
                {
                    switch(record.Clienttype)
                    {
                        case "ATC":
                            UpdateVatsimClientATCs(record);
                            break;

                        case "PILOT":

                            // only process IFR flights
                            if(IFRONLY)
                            {
                                // check to see that this pilot has an IFR Plan Active
                                if(IFRFlightPlanActive(record))
                                {
                                    UpdateVatsimClientPilots(record);
                                }
                            }
                            break;
                    }
                }
            }            
        }

        public bool IFRFlightPlanActive(VatsimClientRecord record)
        {
            // only filed/active IFR flight types
            if( record.PlannedDepairport != "" && 
                record.PlannedDestairport != "" &&
                record.PlannedFlighttype != "" &&
                record.PlannedFlighttype == "I")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determine if a pilot is new or has updated
        /// </summary>
        public void UpdateVatsimClientPilots(VatsimClientRecord record)
        {

            VatsimClientPilot pilot = VatsimClientPilots.Find(p => p.Cid == record.Cid);

            // the pilot exists in the list
            if(pilot != null)
            {
                pilot.ProcessVatsimClientPlannedFlight(record);
                pilot.ProcessVatsimClientPilotSnapshot(record);
            }
            // pilot not found and assumed to be new
            else
            {
                pilot = record.GetVatsimClientPilotFromRecord();
                VatsimClientPilots.Add(pilot);
            }
        }

        /// <summary>
        /// Determine if an ATC is new or has updated
        /// </summary>
        /// <param name="record">Raw VatsimClientRecord</param>
        public void UpdateVatsimClientATCs(VatsimClientRecord record)
        {
            VatsimClientATC atc = VatsimClientATCs.Find(a => a.Cid == record.Cid);

            // the atc exists in the list
            // TODO: since an additional ATIS logon is allowed, adjust code to allow for this
            // atc not found and assumed to be new                        
            if(atc == null)
            {
                atc = record.GetVatsimClientATCFromRecord();
                VatsimClientATCs.Add(atc);
            }
        }

        public DateTime GetDateTimeFromVatsimTimeStamp(string vatsimtimestamp)
        {
            return new DateTime();
        }
    }
}            
