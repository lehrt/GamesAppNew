using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicEightBall.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicEightBall.Controllers
{
    public class NumGuesserController : Controller
    {
        // GET: /<controller>/

        public IActionResult Index()
        {
            //NumGuesserData.computerGuessInstance.ResetGame();
            return View();
        }

        public IActionResult FirstGuess(int min = 1, int max = 1000)
        {
            Random rand = new Random();
            int firstGuess = rand.Next(min, max);
            NumGuesserData.StartNewGame(min, max);
            return View(firstGuess);
        }

        public IActionResult CustomNumbers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuessNumber(string feedback, int guess)
        {
            int num = NumGuesserData.computerGuessInstance.CheckGuessData(feedback, guess);
            return View(num);
        }

        public IActionResult WinSummary(int guess)
        {
            NumGuesserData.computerGuessInstance.SetCorrectGuess(guess);
            return View(NumGuesserData.computerGuessInstance);
        }

    }
}
