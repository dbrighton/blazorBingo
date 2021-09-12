using Bingo.Common.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Bingo.Common.Services
{
    public class SignalRClientBingoService
    {
        private HubConnection _hub;

        public BingoBalls BingoBalls { get; private set; }

        public SignalRClientBingoService()
        {
            BingoBalls = new BingoBalls();
        }

        public async Task<bool> RegisterHubConnectionAsync(string url)
        {
            var success = false;

            try
            {
                _hub = new HubConnectionBuilder().WithUrl(url)
                    .WithAutomaticReconnect()
                    .Build();

                _hub.On<BingoBalls>(Constants.Constants.BALL_COLLECTION_UPDATED, (bingoBalls) =>
                {
                    BingoBalls = bingoBalls;
                });

                await _hub.StartAsync();
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                success = false;
            }

            return success;
        }
    }
}