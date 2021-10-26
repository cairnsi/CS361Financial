using CS361Financial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CS361Financial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string stockTicker)
        {
            StockGeneralInfo info = new StockGeneralInfo();
            info.name = "MICROSOFT CORPORATION";
            info.ticker = "MSFT";
            info.previousClose = 309.05M;
            info.week52high = 311.03M;
            info.week52low = 302.01M;
            info.ptoe = 38.20M;
            info.marketCap = 2.31M;
            return View("StockLanding",info);
        }

        [HttpGet]
        public IActionResult HistoricalReturns(string stockTicker)
        {
            StockGeneralInfo info = new StockGeneralInfo();
            info.name = "MICROSOFT CORPORATION";
            info.ticker = "MSFT";
            info.previousClose = 309.05M;
            info.week52high = 311.03M;
            info.week52low = 302.01M;
            info.ptoe = 38.20M;
            info.marketCap = 2.31M;
            info.returnsYTD = 20.03M;
            info.returns1Y = 70.98M;
            info.returns2Y = 150.56M;
            info.returns5Y = 347.32M;
            info.returns10Y = 649.43M;
            return View("HistoricalReturns", info);
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
