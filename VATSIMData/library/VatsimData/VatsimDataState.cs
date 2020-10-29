using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using VatsimLibrary.VatsimClient;
using VatsimLibrary.VatsimDb;
using VatsimLibrary.VatsimUtils;

namespace VatsimLibrary.VatsimData
{
    public class VatsimDataState
    {

        private const bool IFRONLY = true;

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

        public static DateTime GetDateTimeFromVatsimTimeStamp(string vatsimtimestamp)
        {

            int year = Convert.ToInt32(vatsimtimestamp.Substring(0,4));
            int month = Convert.ToInt32(vatsimtimestamp.Substring(4,2));
            int day = Convert.ToInt32(vatsimtimestamp.Substring(6,2));
            int hour = Convert.ToInt32(vatsimtimestamp.Substring(8,2));
            int minute = Convert.ToInt32(vatsimtimestamp.Substring(10,2));
            int second = Convert.ToInt32(vatsimtimestamp.Substring(12,2));
            
            return new DateTime(year, month, day, hour, minute, second);

        }        

        /// <summary>
        /// Run through the list of clients to parse out ATC and Pilots
        /// </summary>
        public void ProcessVatsimClientRecords()
        {
            // are there any clients to process?
            if(VatsimClientRecords != null && VatsimClientRecords.Count > 0)
            {
                Console.Write("Writing Vatsim Objects to Database... ");
                // progress bar
                using(var progress = new ConsoleProgressBar())
                {                
                    // get total count
                    int count = 0;
                    int total = VatsimClientRecords.Count;
                    try
                    {
                        foreach (VatsimClientRecord record in VatsimClientRecords)
                        {
                            progress.Report((double)count++ / total);
                            Thread.Sleep(20);

                            switch(record.Clienttype)
                            {
                                case "ATC":
                                    VatsimDbHepler.UpdateOrCreateATC(record.GetVatsimClientATCFromRecord());
                                    break;

                                case "PILOT":
                                    // only process IFR flights
                                    if(IFRONLY)
                                    {
                                        // check to see that this pilot has an IFR Plan Active
                                        if(IFRFlightPlanActive(record))
                                        {
                                            VatsimDbHepler.UpdateOrCreatePilot(record.GetVatsimClientPilotFromRecord());
                                            VatsimDbHepler.UpdateOrCreateFlight(record.GetVatsimClientPlannedFlightFromRecord());
                                            VatsimDbHepler.CreatePosition(record.GetVatsimClientPilotSnapshotFromRecord());
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    catch(Exception exp)
                    {
                        Console.WriteLine($"{exp.Message}");
                    }
                }

                Console.WriteLine("Done.");                
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
    }
}            
