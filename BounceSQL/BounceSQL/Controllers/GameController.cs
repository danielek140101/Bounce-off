using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BounceSQL.Models;
using BounceSQL.Models.Entities;
using BounceSQL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BounceSQL.Controllers
{
    public class GameController : Controller
    {
      

        HighScoresService service;
        private readonly IConfiguration configuration;

        public GameController(HighScoresService service, IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }


        [Route("SubmitScore")]
        public async Task<IActionResult> SubmitHighScore([FromBody]HighScoreVM hs)
        {
            
           await service.SetScore(hs);
           var result = await service.GetScore();

            return Json(result);
        }


        [Route("")]
        public IActionResult Index()
        {
            return Content("OK");
            //var connString = configuration.GetConnectionString("defaultConnection");
            //return Content("connstring:" + connString);
        }

    }
}