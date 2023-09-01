using EventChecker.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;

namespace EventChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly ChannelWriter<EventModel> _channelWriter;

        public EventsController(ILogger<EventsController> logger, ChannelWriter<EventModel> channelWriter)
        {
            _logger = logger;
            _channelWriter = channelWriter;
        }

        [HttpPost(Name = "BrowserEvents")]
        public async Task<ActionResult> PostBrowserEvents([FromBody] EventModel browserEvent)
        {
            _logger.LogInformation($"Writes new event {browserEvent.Id}");
            await _channelWriter.WriteAsync(browserEvent);

            return Ok();
        }
    }
}