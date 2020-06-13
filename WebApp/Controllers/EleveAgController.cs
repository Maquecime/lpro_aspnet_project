using Model.ProjectNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class EleveAgController : Controller
    {
        private ProNetDbContext db;

        public EleveAgController()
        {
            db = new ProNetDbContext();
        }

        // GET: EleveAg
        public JsonResult Index()
        {
            var eleves = db.Eleves.ToList();
            return Json(eleves, JsonRequestBehavior.AllowGet);
        }
    }
}