using Bingo.Common.Constants;
using Bingo.Common.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Bingo.API.Hubs
{
    public class BingoHub : Hub
    {
        private readonly ILogger<BingoHub> _logger;
        public static BingoHub Instance = new BingoHub();

        public static BingoBalls Balls { get; private set; }

        // public BingoHub(ILogger<BingoHub> logger)
        // {
        //     _logger = logger;
        //     if (Instance == null)
        //     {
        //         Instance = this;
        //     }
        //
        // }

        [HubMethodName(Constants.DRAW)]
        public Task Draw()
        {
            Balls ??= new BingoBalls();
            var ball = Balls.DrawRandomBall();
          return  Clients.All.SendAsync(Constants.BALL_COLLECTION_UPDATED, Balls);
           // Clients.All.SendAsync(Constants.BALL_DRAWED, ball);

          
        }

        public static void DrawRandomBall()
        {
            Instance ??= new BingoHub();
            Instance.Draw();
        }
    }
}