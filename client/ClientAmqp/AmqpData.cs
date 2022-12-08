namespace ClientAmqp
{
    public class AmqpData : BackgroundService
    {
        private readonly ILogger<AmqpData> _logger;

        public AmqpData(ILogger<AmqpData> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}