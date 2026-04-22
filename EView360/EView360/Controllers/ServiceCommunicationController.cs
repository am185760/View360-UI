using EView360.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EView360.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCommunicationController : ControllerBase
    {
        private readonly IHubContext<BroadcastHub> _hubContext;
        private BroadcastHub _broadcastHub;

        public ServiceCommunicationController(IHubContext<BroadcastHub> hubContext, BroadcastHub broadcastHub)
        {
            _hubContext = hubContext;
            _broadcastHub = broadcastHub;
        }

        // GET: api/<ServiceCommunicationController>
        [HttpGet]
        public async Task<string> Get()
        {
            await _broadcastHub.SendMessage();
            //_hubContext.Clients.All.SendAsync("SendMessage");
            return "success";
        }
    }
}
