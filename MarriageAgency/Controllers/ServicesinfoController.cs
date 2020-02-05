using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarriageAgency.Data;
using MarriageAgency.Models;

namespace MarriageAgency.Controllers
{
    public class ServicesinfoController : Controller
    {
        private readonly MarriageAgencyContext _context;

        public ServicesinfoController(MarriageAgencyContext context)
        {
            _context = context;
        }

        // GET: Servicesinfo
        public async Task<IActionResult> Index(string sortOrder, string currentFilter)
        {
            ViewData["CurrentFilter"] = currentFilter;
            ViewData["CostSortParm"] = sortOrder == "Cost" ? "cost_desc" : "Cost";

            var services = from s in _context.Services.Include(s => s.Clients).Include(s => s.Employee)
                           select s;

                services =
                from service in services
                group service by service.Employee into playerGroup
                    select new Service
                     {
                        Employee = playerGroup.Key,
                        Cost = playerGroup.Sum(x => x.Cost),
                     };

            switch (sortOrder)
            {
                case "Cost":
                    services = services.OrderBy(s => s.Cost);
                    break;
                case "cost_desc":
                    services = services.OrderByDescending(s => s.Cost);
                    break;
            }
            //services = services.Select(s => s.Cost).GroupBy(s => s.ID == id);
            //services = services.Where(s => s.Employee);
            //services = services.Sum(s => s.Cost).GroupBy(s => s.EmployeeID);
            //services = services.GroupBy(s => s.EmployeeID).Sum(s => s.Cost);
            //services = services.GroupBy(s => s.EmployeeID).Select(c => new { c.Key, Cost = c.Sum() });

            return View(await services.AsNoTracking().ToListAsync());
        }
    }
}
