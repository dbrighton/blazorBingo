using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.Common;
using Bingo.Common.Models;
using Fluxor;


namespace BlazorBingo.Store
{
    public static class BingoBallReducer
    {
        [ReducerMethod]
        public static BingBallsState OnDrawBall(BingBallsState state, DrawBingoBallAction.DrawBallAction action)
        {

            // TS => {...state, sate.BingoBalls}
            return state with
            {
                BingoBalls = DrawBall(state.BingoBalls, action.Ball)
            };
        }

        private static List<BingoBall> DrawBall(List<BingoBall> balls, BingoBall actionBall)
        {
            var bingoBall = (from i in balls
                where i.BallNumber == actionBall.BallNumber
                      && i.Letter == actionBall.Letter
                select i).FirstOrDefault();

            if (bingoBall != null)
            {
                bingoBall.Drawn = true;
            }

            return balls;
        }
    }
}
