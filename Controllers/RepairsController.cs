#region USING STATEMENTS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETD3202_F2022_InstrumentShop.Data;
using NETD3202_F2022_InstrumentShop.Models;
using Microsoft.AspNetCore.Authorization;
#endregion
namespace NETD3202_F2022_InstrumentShop.Controllers
{
    public class RepairsController : Controller
    {
        #region Private Fields
        /// <summary>
        /// Database context
        /// </summary>
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize the database context
        /// </summary>
        /// <param name="context"></param>
        public RepairsController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a list of all the repairs
        /// </summary>
        /// <returns></returns>
        // GET: Repairs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repairs.ToListAsync());
        }

        /// <summary>
        /// Returns the details of the repair with the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Repairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Repairs
                .FirstOrDefaultAsync(m => m.repairID == id);
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        /// <summary>
        /// Returns the view for creating a new repair log
        /// </summary>
        /// <returns></returns>
        // GET: Repairs/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Adds the repair log to the database
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        // POST: Repairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("repairID,instrumentID,owner,phone,email,address,city,province,postalCode")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repair);
        }
        /// <summary>
        /// Edits the repair based off the repair id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Repairs/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Repairs.FindAsync(id);
            if (repair == null)
            {
                return NotFound();
            }
            return View(repair);
        }

        /// <summary>
        /// Edits the fields of the repair in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instrument"></param>
        /// <returns></returns>
        // POST: Repairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("repairID,instrumentID,owner,phone,email,address,city,province,postalCode")] Repair repair)
        {
            if (id != repair.repairID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairExists(repair.repairID))
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
            return View(repair);
        }

        /// <summary>
        /// Ask if the delete should occur of a repair in the database by the id number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Repairs/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Repairs
                .FirstOrDefaultAsync(m => m.repairID == id);
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        /// <summary>
        /// Deletes the repair log from the database by using the repair id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Repairs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repair = await _context.Repairs.FindAsync(id);
            _context.Repairs.Remove(repair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if the repair log exists in the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool RepairExists(int id)
        {
            return _context.Repairs.Any(e => e.repairID == id);
        }

        /// <summary>
        /// Displays the searching view, the text box and button
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Searching()
        {
            return View();
        }

        /// <summary>
        /// Seaches through the database based on the owner provided
        /// </summary>
        /// <param name="SearchInstrument"></param>
        /// <returns></returns>
        public async Task<IActionResult> ShowSearchRepair(string SearchRepair)
        {
            return View("Index", await _context.Repairs.Where(s => s.owner.Contains(SearchRepair)).ToListAsync());
        }
        #endregion
    }
}
