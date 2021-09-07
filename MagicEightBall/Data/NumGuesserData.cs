using System;
using MagicEightBall.Models;

namespace MagicEightBall.Data
{
    public class NumGuesserData
    {
        public static Guess computerGuessInstance { get; set; }

        public static void StartNewGame(int min = 1, int max = 1000)
        {
            computerGuessInstance = new Guess();
            computerGuessInstance.Min = min;
            computerGuessInstance.Max = max;
        }

        public static int NewGuess()
        {
            Random randomizer = new Random();
            int randomNum = randomizer.Next(computerGuessInstance.Min, computerGuessInstance.Max);
            return randomNum;
        }

        public NumGuesserData()
        {
        }
    }
}
