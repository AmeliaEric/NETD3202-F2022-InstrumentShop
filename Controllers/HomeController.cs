#region USING STATEMENTS
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETD3202_F2022_InstrumentShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
#endregion
namespace NETD3202_F2022_InstrumentShop.Controllers
{
    public class HomeController : Controller
    {
        #region Private Fields
        /// <summary>
        /// Logger for logging messages
        /// </summary>
        private readonly ILogger<HomeController> _logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize the logger
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return the Index view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Return the Privacy view
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Return the Error view, along with the request ID
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
