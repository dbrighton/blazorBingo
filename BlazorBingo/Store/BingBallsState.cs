using Bingo.Common;
using System.Collections.Generic;
using Fluxor;

namespace BlazorBingo.Store
{
    public class BingBallsState
    {
       
        public List<BingoBall> BingoBalls { get; init; }
    }

    public class BingBallsFeatureState : Feature<BingBallsState>
    {
        public List<BingoBall>Balls { get; set; }
        public override string GetName() => nameof(BingBallsState);

        protected override BingBallsState GetInitialState()
        {
            var listOfBalls = new List<BingoBall>();
            var letters = new List<char>
            {
                'B',
                'I',
                'N',
                'G',
                'O'
            };
            
            foreach (var letter in letters)
            {
                for (int i = 1; i <= 15; i++)
                {
                    var ball = new BingoBall
                    {
                        Letter = letter,
                        BallNumber = i
                    };
                    listOfBalls.Add(ball);
                }
            }
            
          

            return new BingBallsState()
            {
                BingoBalls = listOfBalls
            };
        }
    }
}