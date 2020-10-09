using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {

            /*ViewBag.WomenLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();
            

            ViewBag.HockeyLeagues =_context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();

            ViewBag.NotFootball =_context.Leagues
                .Where(l => !l.Sport.Contains("Football"))
                .ToList();

            ViewBag.ConferenceLeagues =_context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();

            ViewBag.AtlanticLeagues =_context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();

            ViewBag.DallasTeams = _context.Teams
                .Where(t => t.Location == "Dallas")
                .ToList();

            ViewBag.RaptorsTeams =_context.Teams
                .Where(t => t.TeamName == "Raptors")
                .ToList();
            
            ViewBag.CityTeams =_context.Teams
                .Where(t => t.Location.Contains("City"))
                .ToList();
            
            ViewBag.TTeams =_context.Teams
                .Where(t => t.TeamName.StartsWith("T"))
                .ToList();
            
            ViewBag.SortTeams = _context.Teams
                .OrderBy(t => t.Location)
                .ToList();
            
            ViewBag.ReverseTeams = _context.Teams
                .OrderByDescending(t => t.Location)
                .ToList();
            
            ViewBag.CooperP =_context.Players
                .Where(p => p.LastName == "Cooper")
                .ToList();
        
            ViewBag.JoshuaP =_context.Players
                .Where(p => p.FirstName == "Joshua")
                .ToList();
            
            ViewBag.CJP =_context.Players
                .Where(p => p.LastName == "Cooper" && p.FirstName != "Joshua")
                .ToList();
        
            ViewBag.AWP =_context.Players
                .Where(p => p.FirstName == "Alexander" || p.FirstName == "Wyatt")
                .ToList();   

            return View(); */
            dynamic mymodel = new ExpandoObject();
            mymodel.CJPP = _context.Players
                .Where(p => p.LastName == "Cooper" && p.FirstName != "Joshua")
                .ToList();                

            mymodel.AWPP =_context.Players
                .Where(p => p.FirstName == "Alexander" || p.FirstName == "Wyatt")
                .ToList();
            
            mymodel.WomenLeaguesP = _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();
               
            return View("Level1", mymodel);
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            ViewBag.TinASC =_context.Teams
                .Include(t => t.CurrLeague)
                .Where(t => t.CurrLeague.Name == "Atlantic Soccer Conference")
                .ToList();

            ViewBag.PinBP = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.Location == "Boston" && p.CurrentTeam.TeamName == "Penguins")
                .ToList();

            ViewBag.PinICBC = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference")
                .ToList();
            
            ViewBag.PinAC =_context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.CurrLeague.Name == "American Conference of Amateur Football")
                .Where(p => p.LastName == "Lopez")
                .ToList();
            
            ViewBag.FootPlayers =_context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.CurrLeague.Sport == "Football")
                .ToList();
            
            ViewBag.TS = _context.Players
                .Where(p => p.LastName == "Sophia" || p.FirstName == "Sophia")
                .Include(p => p.CurrentTeam)
                .Select(p => p.CurrentTeam)
                .ToList();

            ViewBag.LS = _context.Players
                .Where(p => p.LastName == "Sophia" || p.FirstName == "Sophia")
                .Include(p => p.CurrentTeam)
                .Select(p => p.CurrentTeam.CurrLeague)
                .ToList();

            ViewBag.Flo = _context.Players
                .Where(p => p.LastName == "Flores")
                .Include(p => p.CurrentTeam)
                .Where(p => p.CurrentTeam.Location != "Washington" && p.CurrentTeam.TeamName != "Roughriders")
                .ToList();         
            return View("Level2");

        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}