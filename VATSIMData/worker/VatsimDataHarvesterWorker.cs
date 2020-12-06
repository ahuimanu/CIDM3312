using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using VatsimLibrary.VatsimData;

namespace VATSIMData.Worker
{
    public class VatsimDataHarvesterWorker : BackgroundService
    {

        private const int INTERVAL = 120 * 1000;        
        private readonly ILogger<VatsimDataHarvesterWorker> _logger;

        public VatsimDataHarvesterWorker(ILogger<VatsimDataHarvesterWorker> logger)
        {
            _logger = logger;
        }

        public async Task DoHarvest()
        {
            _logger.LogInformation($"Starting VATSIM Harvester: {DateTime.UtcNow.ToLongTimeString()}");

            await VatsimDataReader.ProcessVatsimData();
            await VatsimDataReader.CurrentVatsimData.BatchProcessVatsimClientRecords();
            
            _logger.LogInformation($"Completed VATSIM Harvesting: {DateTime.UtcNow.ToLongTimeString()}");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try{
                    _logger.LogInformation("Vatsim DataHarvester Worker running at: {time}", DateTimeOffset.Now);
                    await DoHarvest();
                    await Task.Delay(INTERVAL, stoppingToken);
                } 
                catch(OperationCanceledException exp){
                    Console.Error.WriteLine(exp.Message);
                    _logger.LogInformation(
                        "VATSIMData Harvester Service Hosted Service was interrupted.");
                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "VATSIMData Harvester Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
