using System.Web.Mvc;

namespace LabWebSite.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Api_StockDataHistory",
                "Api/StockData/History/{Days}",
                new { controller= "StockData", action="History", Days = UrlParameter.Optional }
            );
            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
