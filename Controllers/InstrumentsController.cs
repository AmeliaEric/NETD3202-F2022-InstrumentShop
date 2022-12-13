#region USING STATEMENTS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
    public class InstrumentsController : Controller
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
        public InstrumentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a list of all instruments
        /// </summary>
        /// <returns></returns>
        // GET: Instruments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instruments.ToListAsync());
        }

        /// <summary>
        /// Returns the details of the instrument with the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Instruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instruments
                .FirstOrDefaultAsync(m => m.instrumentID == id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        /// <summary>
        /// Returns the view for creating a new instrument
        /// </summary>
        /// <returns></returns>
        // GET: Instruments/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Adds the instrument to the database
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns></returns>
        // POST: Instruments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("instrumentID,name,manufacturerID,type,color,quantityBought,priceSold")] Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrument);
        }

        /// <summary>
        /// Edits the instrument based off the instrument id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Instruments/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }
            return View(instrument);
        }
        
        /// <summary>
        /// Edits the fields of the instrument in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instrument"></param>
        /// <returns></returns>
        // POST: Instruments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("instrumentID,name,manufacturerID,type,color,quantityBought,priceSold")] Instrument instrument)
        {
            if (id != instrument.instrumentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentExists(instrument.instrumentID))
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
            return View(instrument);
        }

        /// <summary>
        /// Ask if the delete should occur of an instrument in the database by the id number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Instruments/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instruments
                .FirstOrDefaultAsync(m => m.instrumentID == id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        /// <summary>
        /// Deletes the instrument from the database by using the instrument id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Instruments/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrument = await _context.Instruments.FindAsync(id);
            _context.Instruments.Remove(instrument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if the instrument exists in the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool InstrumentExists(int id)
        {
            return _context.Instruments.Any(e => e.instrumentID == id);
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
        /// Seaches through the database based on the instrument name provided
        /// </summary>
        /// <param name="SearchInstrument"></param>
        /// <returns></returns>
        public async Task<IActionResult> ShowSearchInstruments(string SearchInstrument)
        {
            return View("Index", await _context.Instruments.Where(s => s.name.Contains(SearchInstrument)).ToListAsync());
        }
        #endregion
    }
}
