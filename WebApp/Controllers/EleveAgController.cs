using Model.ProjectNet;
using Model.ProjectNet.Entities;
using Newtonsoft.Json;
using System.Collections;
using System.Data.Entity;
using System.Linq;
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
            var eleves = db.Eleves.Include(e => e.Classe).ToList();
            ArrayList elevesFin = new ArrayList();
            eleves.ForEach(e =>
                elevesFin.Add(JsonConvert.SerializeObject(e, Formatting.Indented, new JsonSerializerSettings {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }))
            );

            return Json(JsonConvert.SerializeObject(eleves, Formatting.Indented, new JsonSerializerSettings { 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Details(int id)
        {
            var eleve = db.Eleves.Find(id);

            return Json(eleve, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Eleve eleve)
        {
  
            db.Eleves.Add(eleve);
            db.SaveChanges();


            return Json(null);
        }

        [HttpPost]
        public JsonResult Edit(Eleve eleve)
        {
            db.Entry(eleve).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json(null);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var eleve = db.Eleves.Find(id);
            db.Eleves.Remove(eleve);
            db.SaveChanges();
            return Json(null);
        }

        public JsonResult GetClasses()
        {
            var classeList = db.Classes.ToList();
            ArrayList classeListFin = new ArrayList();
            classeList.ForEach(e =>
                classeListFin.Add(JsonConvert.SerializeObject(e))
            );

            return Json(JsonConvert.SerializeObject(classeList), JsonRequestBehavior.AllowGet);
        }
    }
}