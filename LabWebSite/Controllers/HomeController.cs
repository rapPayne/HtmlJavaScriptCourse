using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LabWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "HTML, CSS, JavaScript, and jQuery Labs";
            var rawHtml = new StringBuilder("<div id='accordion'>");
            var di = new DirectoryInfo(Server.MapPath("~/Pages"));
            di.GetDirectories(@"*Lab*").ToList().ForEach(d =>
                {
                    rawHtml.AppendFormat("<h3>{0}</h3><div><ul>", d.Name);
                    var files = d.GetFiles("*.html");
                    files.ToList().ForEach(f => rawHtml.AppendFormat("<li><a href='/Pages/{0}/{1}'>{1}</a></li>", d.Name, f.Name));
                    rawHtml.Append("</ul></div>");
                });
            rawHtml.Append("</div>");
            ViewBag.HtmlFilesLists = rawHtml.ToString();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Chapter11LoginService(string username, string password)
        {
            string returnValue;

            //var user=isset($_GET['username']) ? $_GET['username'] : $_POST['username'];
            //$pass=isset($_GET['password']) ? $_GET['password'] : $_POST['password'];

            if (username == "007" && password == "secret")
            {
                returnValue = "pass";
            }
            else
            {
                returnValue = "fail";
            }

            var result = new JsonResult() { Data = returnValue, ContentEncoding = Encoding.UTF8 };
            return result;
        }
    }
}
