using EventChecker.Domain.Models;
using System.Threading.Channels;

namespace EventChecker.Workers
{
    public class MatcherWorker : BackgroundService
    {
        private readonly ILogger<MatcherWorker> _logger;
        private readonly ChannelReader<EventModel> _channelReader;

        public MatcherWorker(ILogger<MatcherWorker> logger, ChannelReader<EventModel> channelReader)
        {
            _logger = logger;
            _channelReader = channelReader;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var messages = await _channelReader.ReadAllAsync(stoppingToken).ToListAsync();
                    _logger.LogInformation($"Read {messages.Count} events");


                }
                catch (ChannelClosedException)
                {
                    _logger.LogWarning("Channel was closed");
                }
            }
        }
    }
}
