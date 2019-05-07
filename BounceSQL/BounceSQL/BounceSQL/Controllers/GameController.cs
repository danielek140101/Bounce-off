using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BounceSQL.Models;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}