using System;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimData;
using VatsimLibrary.VatsimUtils;

namespace client
{
    class Program
    {
        private static readonly int MAX_MINUTES = 10;
        public static void Main(string[] args)
        {
            // setup serilog - https://github.com/serilog/serilog/wiki/Getting-Started
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                // .WriteTo.Console()
                .WriteTo.File(@"logs\vatsimdata_log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            string message = "VATSIM Library";

            int minutes = GetMinutesValue(args);

            if(minutes == -999)
            {
                return;
            }
            else
            {
                Log.Information(message);
                Console.WriteLine(message);
                
                DateTime stop = GetStopTime(minutes);

                VatsimDataHarvester.Run(stop);

                // close out logging
                Log.CloseAndFlush();

            }
        }

        private static int GetMinutesValue(string[] args)
        {

            int value = -999;

            if(args.Length > 0){
                try
                {
                    value = Convert.ToInt32(args[0]);
                    if(value > MAX_MINUTES)
                    {
                        return MAX_MINUTES;
                    }
                }
                catch(Exception exp)
                {
                    Log.Error($"{exp.Message}");
                }
            } 
            return value;
        }

        private static DateTime GetStopTime(int minutes)
        {
            return DateTime.Now.AddMinutes(minutes);
        }
    }
}