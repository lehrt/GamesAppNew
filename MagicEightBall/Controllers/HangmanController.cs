using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicEightBall.Models;
using MagicEightBall.Data;
using Microsoft.AspNetCore.Mvc;


namespace MagicEightBall.Controllers
{
    
    public class HangmanController : Controller
    {
        public Hangman HangmanGameInstance { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HangmanInitialize()
        {
            HangManData.StartNewGame();
            return View();
        }

        public IActionResult Hangman(string Input)
        {
            var gameInstance = HangManData.HangmanGameInstance;

            if (Input != null)
            {
                gameInstance.CheckInput(Input, gameInstance);

                if (gameInstance.RoundCap == 0)
                {
                    return View("~/Views/Hangman/LoseView.cshtml", HangManData.emptySpaces);
                }

                else if (!HangManData.emptySpaces.Contains('_'))
                {

                    return View("~/Views/Hangman/WinView.cshtml", HangManData.emptySpaces);
                }
            }
            ViewBag.roundCap = gameInstance.RoundCap;
            return View(HangManData.emptySpaces);
        }

        public IActionResult GuessAnswer(string Input)
        {
            var gameInstance = HangManData.HangmanGameInstance;
            

            if (Input.ToLower() == gameInstance.Answer.ToLower())
            {
               
                return View("~/Views/Hangman/WinView.cshtml", HangManData.emptySpaces);
            }
            else
            {
                return View("~/Views/Hangman/LoseView.cshtml", HangManData.emptySpaces);
            }
        }
    }

    }

