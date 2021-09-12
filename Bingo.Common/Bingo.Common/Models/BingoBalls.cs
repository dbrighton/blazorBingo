using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo.Common.Models
{
    public class BingoBalls
    {
        public ICollection<BingoBall> Balls { get; private set; }

        public BingoBalls()
        {
            this.Init();
        }

        private void Init()
        {
            int ballNumber = 0;
            Balls = new List<BingoBall>();
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
                for (int row = 0; row < 15; row++)
                {
                    Balls.Add(new BingoBall() { Letter = letter, BallNumber = ++ballNumber });
                }
            }
        }

        public BingoBall DrawRandomBall()
        {
            BingoBall returnBall = null;

            var sample = (from i in Balls
                          where i.Drawn == false
                          select i).ToList();

            if (sample.Any())
            {
                Random rnd = new Random();
                int idx = rnd.Next(0, sample.Count);

                returnBall = (from i in Balls
                              where i.BallNumber == sample[idx].BallNumber
                              select i).First();

                returnBall.Drawn = true;
            }

            return returnBall;
        }
    }
}