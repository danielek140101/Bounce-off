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


        [Route("SubmitScore")]
        public async Task<IActionResult> SubmitHighScore([FromBody]HighScoreVM hs)
        {

            //await service.SetScore(hs);

            var result = await service.GetScore();

            return Json(result);
        }

       
    }
}