using System;
using System.Linq;

namespace Mission_13.Models.ViewModels
{
    public class BowlersViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }

        public Filter filter { get; set; }
    }
}
