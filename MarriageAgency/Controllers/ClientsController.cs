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
    public class ClientsController : Controller
    {
        private readonly MarriageAgencyContext _context;

        public ClientsController(MarriageAgencyContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var clients = from s in _context.Clients.Include(c => c.Nationalitie).Include(c => c.Relation).Include(c => c.ZodiacSign)
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {                
                clients = clients.Where(s => s.ZodiacSign.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    clients = clients.OrderByDescending(s => s.FirsLastMidName);
                    break;
                case "Date":
                    clients = clients.OrderBy(s => s.DateofBirth);
                    break;
                case "date_desc":
                    clients = clients.OrderByDescending(s => s.DateofBirth);
                    break;
                default:
                    clients = clients.OrderBy(s => s.FirsLastMidName);
                    break;
            }

            int pageSize = 5;
            return View(await PageViewModel<Client>.CreateAsync(clients.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Nationalitie)
                .Include(c => c.Relation)
                .Include(c => c.ZodiacSign)
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["NationalID"] = new SelectList(_context.Nationalities, "NationalID", /*"NationalID"*/"Name");
            ViewData["RelationID"] = new SelectList(_context.Relations, "RelationID", /*"RelationID"*/"Name");
            ViewData["ZodiacSignID"] = new SelectList(_context.ZodiacSigns, "ZodiacSignID", /*"ZodiacSignID"*/"Name");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientID,FirsLastMidName,Age,Gender,DateofBirth," +
            "Height,Weight,Children,MaritalStatus,BadHabits,Hobby,Description," +
            "ZodiacSignID,RelationID,NationalID,Addres,Phone,Passport")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NationalID"] = new SelectList(_context.Nationalities, "NationalID", /*"NationalID"*/"Name", client.NationalID);
            ViewData["RelationID"] = new SelectList(_context.Relations, "RelationID", /*"RelationID"*/"Name", client.RelationID);
            ViewData["ZodiacSignID"] = new SelectList(_context.ZodiacSigns, "ZodiacSignID", /*"ZodiacSignID"*/"Name", client.ZodiacSignID);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["NationalID"] = new SelectList(_context.Nationalities, "NationalID", /*"NationalID"*/"Name", client.NationalID);
            ViewData["RelationID"] = new SelectList(_context.Relations, "RelationID", /*"RelationID"*/"Name", client.RelationID);
            ViewData["ZodiacSignID"] = new SelectList(_context.ZodiacSigns, "ZodiacSignID", /*"ZodiacSignID"*/"Name", client.ZodiacSignID);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,FirsLastMidName,Age,Gender,DateofBirth," +
            "Height,Weight,Children,MaritalStatus,BadHabits,Hobby,Description," +
            "ZodiacSignID,RelationID,NationalID,Addres,Phone,Passport")] Client client)
        {
            if (id != client.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientID))
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
            ViewData["NationalID"] = new SelectList(_context.Nationalities, "NationalID", /*"NationalID"*/"Name", client.NationalID);
            ViewData["RelationID"] = new SelectList(_context.Relations, "RelationID", /*"RelationID"*/"Name", client.RelationID);
            ViewData["ZodiacSignID"] = new SelectList(_context.ZodiacSigns, "ZodiacSignID", /*"ZodiacSignID"*/"Name", client.ZodiacSignID);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Nationalitie)
                .Include(c => c.Relation)
                .Include(c => c.ZodiacSign)
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientID == id);
        }
    }
}
