namespace Bingo.Common.Models
{
    public record BingoBall()
    {
        public int BallNumber { get; set; }
        public char Letter { get; set; }
        public bool Drawn { get; set; }
    }
}