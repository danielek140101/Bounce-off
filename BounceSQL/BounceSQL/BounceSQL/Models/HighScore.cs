using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounceSQL.Models
{
    public class HighScore
    {
        public HighScore(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }
    }
}
