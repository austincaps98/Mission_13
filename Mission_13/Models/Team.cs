using System;
using System.Collections.Generic;

namespace Mission_13.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public List<Bowler> Bowlers { get; set; }
    }
}
