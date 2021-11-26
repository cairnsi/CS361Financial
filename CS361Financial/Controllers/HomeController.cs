using CS361Financial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CS361Financial.Clients;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace CS361Financial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient teammateClient;

        public HomeController(ILogger<HomeController> logger, AngelaFinance angelaFinance)
        {
            _logger = logger;
            this.teammateClient = angelaFinance.Client;
        }

        [HttpGet]
        public IActionResult Index()
        {
            errorMessage error = new errorMessage();
            return View(error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockTicker"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(string stockTicker)
        {
            StockGeneralInfo info = new StockGeneralInfo();
            using (HttpResponseMessage response = await teammateClient.GetAsync($"/{stockTicker}"))
            {
                //check if response is successuful
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        //get content from response
                        string content = await response.Content.ReadAsStringAsync();
                        //convert to json
                        var json = JObject.Parse(content);
                        string valueString = json["price"].ToString();
                        decimal price = decimal.Parse(valueString);
                        info.value = price;
                        info.description = json["description"].ToString();
                        info.name = json["name"].ToString();
                    }
                    catch
                    {
                        errorMessage error = new errorMessage();
                        error.message = "Could not parse api response";
                        return View("Index", error);
                    }

                }
                else
                {
                    errorMessage error = new errorMessage();
                    error.message = "Ticker not found";
                    return View("Index", error);
                }
            }
            info.ticker = stockTicker.ToUpper();
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
