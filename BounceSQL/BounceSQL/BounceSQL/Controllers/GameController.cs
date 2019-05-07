using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BounceSQL.Models;
using BounceSQL.Models.Entities;
using BounceSQL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BounceSQL.Controllers
{
    public class GameController : Controller
    {
      

        HighScoresService service;
        public GameController(HighScoresService service)
        {
            this.service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Index(HighScoreVM hs)
        {
            if (!ModelState.IsValid)
                return View(hs);

            await service.SetScore(hs);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}