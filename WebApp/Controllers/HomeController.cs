using BusinessLayer.ProjectNet.Queries;
using Model.ProjectNet;
using Model.ProjectNet.Entities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ProNetDbContext db;
        private EleveQuery eleveQuery;
        private AbsenceQuery absenceQuery;

        public HomeController()
        {
            db = new ProNetDbContext();
            eleveQuery = new EleveQuery(db);
            absenceQuery = new AbsenceQuery(db);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBestEleves()
        {

            var eleves = eleveQuery.GetAll().ToList();

            var elevesSorted = (from e in eleves
                                where e.Notes.Count > 0
                                orderby e.Notes.Average(n => n.NoteValue)
                                select e).ToList();

            if(elevesSorted.Count > 5 )
            {
                elevesSorted = elevesSorted.GetRange(0, 5);
            }

            foreach (Eleve e in elevesSorted)
            {
                e.Classe.Eleves = null;

            }

            return Json(JsonConvert.SerializeObject(elevesSorted, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLatestAbsences()
        {
            var absences = absenceQuery.GetAll().OrderBy(a => a.DateAbsence).Take(5).ToList();


            return Json(JsonConvert.SerializeObject(absences, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), JsonRequestBehavior.AllowGet);
        }
    }
}