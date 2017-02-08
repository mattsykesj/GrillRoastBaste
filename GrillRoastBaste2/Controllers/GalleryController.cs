using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrillRoastBaste2.Controllers
{
    public class GalleryController : Controller
    {
        //TO-DO: add list of url strings which is passed to the view to populate the gallery
        //and add an associated view model to validate strings etc
        public ActionResult Index()
        {
            return View();
        }
    }
}