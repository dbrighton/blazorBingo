using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.API.Hubs;
using Bingo.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Bingo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BingoGameController : ControllerBase
    {
        private readonly ILogger<BingoGameController> _logger;
        private readonly IHubContext<BingoHub> _hub;

        public BingoGameController(ILogger<BingoGameController> logger, IHubContext<BingoHub> hub)
        {
            _logger = logger;
            _hub = hub;
        }

        [HttpGet]
        [Route("draw")]
        public void Draw()
        {
            _logger.LogInformation($"In Draw");
            BingoHub.DrawRandomBall();
        }

        
    }
}
