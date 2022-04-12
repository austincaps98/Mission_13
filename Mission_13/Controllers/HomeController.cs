using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission_13.Models;
using Mission_13.Models.ViewModels;

namespace Mission_13.Controllers
{
    public class HomeController : Controller
    {
        private BowlersDbContext _context { get; set; }

        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var bowlers = _context.Bowlers.Include(x => x.Team).ToList();
            //ViewBag.Bowlers = _context.Teams.ToList();
            //var bowlers = _repo.Bowlers;

            ViewBag.Teams = _context.Teams
                .Where(x => x.TeamName != "")
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var x = new BowlersViewModel
            {
                Bowlers = _context.Bowlers.Include(x => x.Team)
                .OrderBy(x => x.BowlerLastName)
                .ThenBy(x => x.BowlerFirstName),

                filter = new Filter
                {
                    TeamName = null
                }
            };

            return View(x);
        }

        [HttpPost]
        public IActionResult Index(BowlersViewModel model)
        {
            ViewBag.Teams = _context.Teams
                .Where(x => x.TeamName != "")
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            string teamName = model.filter.TeamName;

            var x = new BowlersViewModel
            {
                Bowlers = _context.Bowlers.Include(x => x.Team)
                .Where(x => x.Team.TeamName == teamName)
                .OrderBy(x => x.BowlerLastName)
                .ThenBy(x => x.BowlerFirstName),

                filter = new Filter
                {
                    TeamName = teamName
                }
            };

            return View(x);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = _context.Teams.ToList();

            Bowler b = new Bowler();

            return View(b);
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            if (ModelState.IsValid)
            {
                if (b.BowlerID == 0)
                {
                    _context.Add(b);
                    _context.SaveChanges();

                }
                else
                {
                    _context.Update(b);
                    _context.SaveChanges();
                }

                return View("Confirmation", b);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerID)
        {
            ViewBag.Teams = _context.Teams.ToList();

            var bowler = _context.Bowlers.Single(b => b.BowlerID == bowlerID);

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _context.Update(b);
                _context.SaveChanges();

                return View("Confirmation");
            }
            else
            {
                return View(b);
            }
        }

        [HttpGet]
        public IActionResult Delete(int bowlerID)
        {
            var bowler = _context.Bowlers.Single(b => b.BowlerID == bowlerID);

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {

            _context.Bowlers.Remove(b);
            _context.SaveChanges();

            return View("Confirmation");
        }
    }
}
