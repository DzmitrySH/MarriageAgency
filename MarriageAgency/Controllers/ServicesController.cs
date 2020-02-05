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
    public class ServicesController : Controller
    {
        private readonly MarriageAgencyContext _context;

        public ServicesController(MarriageAgencyContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string currentFilter2,
            string searchString, string searchString2, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null || searchString2 != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
                searchString2 = currentFilter2;
            }

            ViewData["CurrentFilter"] = searchString;
            var services = from s in _context.Services.Include(s => s.Clients).Include(s => s.Employee)
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                services = services.Where(c => c.Cost < Convert.ToInt32(searchString));
            }

            ViewData["CurrentFilter2"] = searchString2;
            if (!String.IsNullOrEmpty(searchString2))
            {
                services = services.Where(c => c.Cost > Convert.ToInt32(searchString2));
            }

            switch (sortOrder)
            {
                case "Date":
                    services = services.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    services = services.OrderByDescending(s => s.Date);
                    break;
            }

            int pageSize = 10;
            return View(await PageViewModel<Service>.CreateAsync(services.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Clients)
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.ServiseID == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "FirsLastMidName");
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirsLastMidName");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiseID,Date,Cost,ClientID,EmployeeID")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "FirsLastMidName", service.ClientID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirsLastMidName", service.EmployeeID);
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "FirsLastMidName", service.ClientID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirsLastMidName", service.EmployeeID);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiseID,Date,Cost,ClientID,EmployeeID")] Service service)
        {
            if (id != service.ServiseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "FirsLastMidName", service.ClientID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirsLastMidName", service.EmployeeID);
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Clients)
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.ServiseID == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiseID == id);
        }
    }
}
