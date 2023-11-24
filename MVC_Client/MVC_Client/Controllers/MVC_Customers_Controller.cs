using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Client.Controllers
{
    public class MVC_Customers_Controller : Controller
    {
        // GET: MVC_Customers_
        public ActionResult Index()
        {
            return View();
        }
    }
}