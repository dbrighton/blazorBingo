using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bingo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BingoGameController : ControllerBase
    {
        private readonly ILogger<BingoGameController> _logger;

        public BingoGameController(ILogger<BingoGameController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("start")]
        public void StartNewGame()
        {
            _logger.LogInformation($"In StartNewGame");
        }
    }
}
