using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicEightBall.Models;

namespace MagicEightBall.Data
{
    public class HangManData
    {
        public static List<string> answers = new List<string> { "banana", "apple" };
        //"peach", "grape", "canteloupe", "watermelon", "jackfruit", "honeydew", "nectarine", "mango", "orange"
        public static List<char> emptySpaces = new List<char> { };
        public static List<Hangman> ourHangman = new List<Hangman> { };
        public static Hangman HangmanGameInstance { get; set; }

        public static void Add(char input, Hangman newHangman)
        {

            foreach (char i in newHangman.Answer)
            {
                if (i == input)
                {
                    int num = newHangman.Answer.IndexOf(input);

                    if (emptySpaces[num] != '_')
                    {
                        int start = num + 1;
                        int secondIndex = newHangman.GetIndexOf(newHangman.Answer, input, start);

                        if (emptySpaces[secondIndex] != '_')
                        {
                            int nextStart = secondIndex + 1;
                            int thirdIndex = newHangman.GetIndexOf(newHangman.Answer, input, nextStart);
                            emptySpaces[thirdIndex] = input;
                        }

                        emptySpaces[secondIndex] = input;

                    }
                    emptySpaces[num] = input;
                }
            }
        }

        public static void StartNewGame()
        {
            emptySpaces = new List<char> { };
            HangmanGameInstance = new Hangman();
            HangmanGameInstance.RoundCap = 6;
        }
    }
}
