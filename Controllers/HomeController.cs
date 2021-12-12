/* Author: Kamrin Aubin
 * Last Modified: December 11, 2021
 * Description: Home Controller. Default home controller from creating web application.
 *              Includes some changes to better represent the my web application.
 * 
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETDLab5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETDLab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Home page of Play Unit Games Management Service site
        public IActionResult Index()
        {
            return View();
        }

        // Added About View, Displays information regarding Play Unit Games and assignment
        public IActionResult About()
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
