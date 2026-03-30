using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WorkerLoging
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DoWork(string mess);
            }
        }

        public Task DoWork(string mess)
        {
            var data = JsonSerializer.Deserialize<Param>(mess);

            if (data.Type == enumtype.loger)
            {
                handleLoger(data);

                data
            }
        }

    }
}
