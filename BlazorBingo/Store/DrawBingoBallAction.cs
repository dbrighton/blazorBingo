using Bingo.Common.Models;

namespace BlazorBingo.Store
{
    public class DrawBingoBallAction
    {
        public record DrawBallAction
        {
            public BingoBall Ball;
        }
    }
}