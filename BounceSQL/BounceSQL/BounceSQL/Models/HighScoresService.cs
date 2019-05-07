using BounceSQL.Models.Entities;
using BounceSQL.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounceSQL.Models
{
    public class HighScoresService
    {
        readonly BounceOffDBContext context;

        public HighScoresService(BounceOffDBContext context)
        {
            this.context = context;
        }

        public async Task SetScore(HighScoreVM scoreVM)
        {
            context.HighScore.Add(new HighScore
            {
                Name = scoreVM.Name,
                Score = scoreVM.Score
            });

            await context.SaveChangesAsync(); 
        }

        public async Task<HighScoreVM[]> GetScore()
        {
            return await context.HighScore
                .Select(o => new HighScoreVM
                {
                    Name = o.Name,
                    Score = o.Score
                }
                ).ToArrayAsync();

            //var scoreList = new List<HighScore>();
            //foreach (var item in context.HighScore)
            //{
            //    scoreList.Add(item);
            //}

            //return await scoreList.ToArrayAsync();
        }
      
        }
    }

