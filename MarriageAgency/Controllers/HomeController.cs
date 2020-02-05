using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MarriageAgency.Models;
using MarriageAgency.Models.ViewModels;
using MarriageAgency.Data;

namespace MarriageAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly MarriageAgencyContext _context;

        public HomeController(MarriageAgencyContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> About()
        {
            IQueryable<DateClient> data =
                from client in _context.Clients
                group client by client.DateofBirth into dateGroup

                select new DateClient()
                {
                    DateofBirth = dateGroup.Key,
                    ClientCount = dateGroup.Count(),
                };

            return View(await data.AsNoTracking().ToListAsync());
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
