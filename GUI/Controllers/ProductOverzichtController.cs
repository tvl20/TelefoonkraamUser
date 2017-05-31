using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GUI.Models;

namespace GUI.Controllers
{
    public class ProductOverzichtController : Controller
    {
        // GET: ProductOverzicht
        public ActionResult Index()
        {
            return View(new WebshopModel());
        }

        public ActionResult ToestelOverzicht(string merknaam)
        {
            if (merknaam == null)
            {
                return RedirectToAction("Index", "ProductOverzicht");
            }
            ViewBag["Merk"] = merknaam;
            return View(new WebshopModel());
        }
    }
}