using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabWebSite.Areas.Api.Controllers
{
    public class StockDataController : Controller
    {
        //
        // GET: /Api/StockData/
        /// <summary>
        /// Returns X days of stock price history
        /// </summary>
        /// <param name="Days">Number of days of history</param>
        /// <returns></returns>
        public ActionResult History(int? Days)
        {
            Days = Days ?? 30;
            var rand = new Random();
            var history = new List<double>();
            for (var i = 0 ; i < Days ; i++)
            {
                // Random number between 30 and 45 that increases by 1/10th a point per day rounded to 2 digits.
                history.Add(Math.Round(rand.NextDouble() * 15.0 + 30.0 + (i * 0.1), 2));
            }
            return Json(new { history = history.ToArray()}, JsonRequestBehavior.AllowGet);
        }

    }
}
