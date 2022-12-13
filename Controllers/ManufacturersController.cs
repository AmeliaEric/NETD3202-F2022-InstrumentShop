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
    public class ManufacturersController : Controller
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
        public ManufacturersController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a list of all instruments
        /// </summary>
        /// <returns></returns>
        // GET: Manufacturers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manufacturers.ToListAsync());
        }

        /// <summary>
        /// Returns the details of the manufacturer with the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Manufacturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.manufacturerID == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        /// <summary>
        /// Returns the view for creating a new manufacturer
        /// </summary>
        /// <returns></returns>
        // GET: Manufacturers/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Adds the manufacturer to the database
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns></returns>
        // POST: Manufacturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("manufacturerID,name,owner,phone,email,address,city,province,postalCode")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        /// <summary>
        /// Edits the manufacturer based off the manufacturer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Manufacturers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        /// <summary>
        /// Edits the fields of the manufacturer in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instrument"></param>
        /// <returns></returns>
        // POST: Manufacturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("manufacturerID,name,owner,phone,email,address,city,province,postalCode")] Manufacturer manufacturer)
        {
            if (id != manufacturer.manufacturerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturer.manufacturerID))
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
            return View(manufacturer);
        }

        /// <summary>
        /// Ask if the delete should occur of an manufacturer in the database by the id number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Manufacturers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.manufacturerID == id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        /// <summary>
        /// Deletes the manufacturer from the database by using the manufacturers id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Manufacturers/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if the manufacturer exists in the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ManufacturerExists(int id)
        {
            return _context.Manufacturers.Any(e => e.manufacturerID == id);
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
        /// Seaches through the database based on the manufacturer name provided
        /// </summary>
        /// <param name="SearchInstrument"></param>
        /// <returns></returns>
        public async Task<IActionResult> ShowSearchManufacturer(string SearchMan)
        {
            return View("Index", await _context.Manufacturers.Where(s => s.name.Contains(SearchMan)).ToListAsync());
        }
        #endregion
    }
}
