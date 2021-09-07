using System;
using MagicEightBall.Data;

namespace MagicEightBall.Models
{
    public class Hangman
    {

        public string Answer { get; }
        private static int _roundCap = 6;
        public int RoundCap { get { return _roundCap; } set { _roundCap = value; } }

        public Hangman()
        {
            Answer = SetAnswer();
            SetEmptySpaces();
            //RoundCap = _roundCap;
        }

        public void DecreaseRoundCap()
        {
            _roundCap--;
        }

        public string SetAnswer()
        {
            Random wordPicker = new Random();
            string thisAnswer = HangManData.answers[wordPicker.Next(HangManData.answers.Count)];
            return thisAnswer;
        }

        public void CheckInput(string Input, Hangman newHangman)
        {
            if (Answer.Contains(Input) == true)
            {
                char input = Input[0];
                HangManData.Add(input, newHangman);
            }

            else
            {
                DecreaseRoundCap();
            }
        }

        public void SetEmptySpaces()
        {
            int answerLength = this.Answer.Length;
            for (int i = 0; i < answerLength; i++)
            {
                HangManData.emptySpaces.Add('_');
            }
        }

        public int GetIndexOf(string str, char c, int startPosition)
        {
            int index = str.IndexOf(c, startPosition);
            return index;
        }

    }
    
}
