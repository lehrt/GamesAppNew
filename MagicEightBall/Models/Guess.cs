using System;
namespace MagicEightBall.Models
{
    public class Guess
    {
        public int Min { get; set; } = 1;
        public int Max { get; set; } = 1000;
        public int TotalGuesses { get; set; } = 1;
        public int UserGuess { get; set; }

        public void UpdateMin(int min)
        {
            this.Min = min;
            TotalGuesses++;
        }

        public void UpdateMax(int max)
        {
            this.Max = max;
            TotalGuesses++;
        }

        public int NewGuess()
        {
            Random randomizer = new Random();
            int randomNum = randomizer.Next(this.Min, this.Max);
            return randomNum;
        }

        public void SetCorrectGuess(int guess)
        {
            UserGuess = guess;
        }

        public void ResetGame()
        {
            Min = 1;
            Max = 1000;
        }

        public int CheckGuessData(string feedback, int guess)
        {
            if (feedback == "up")
            {
                UpdateMin(guess);
            }
            else if (feedback == "down")
            {
                UpdateMax(guess);
            }

            int num = NewGuess();
            return num;
        }

        public Guess(int min = 1, int max = 1000)
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
