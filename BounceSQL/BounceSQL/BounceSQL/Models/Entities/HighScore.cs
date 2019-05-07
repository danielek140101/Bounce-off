using System;
using System.Collections.Generic;

namespace BounceSQL.Models.Entities
{
    public partial class HighScore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
