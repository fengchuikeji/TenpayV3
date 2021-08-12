
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TenpayV3APIDemoService;

namespace TenpayV3APIDemo.Controllers
{
    public class HomeController : Controller
    {
        private static HomeService Service { get; }
        static HomeController()
        {
            Service = new HomeService();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Transactions()
        {
            return Content(Service.Transactions().Result);
        }

        
    }
}
