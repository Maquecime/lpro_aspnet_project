using BusinessLayer.ProjectNet.Commands;
using BusinessLayer.ProjectNet.Queries;
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
        private EleveQuery eleveQuery;
        private ClasseQuery classeQuery;
        private EleveCommand eleveCommand;
        private ClasseCommand classeCommand;

        public EleveAgController()
        {
            db = new ProNetDbContext();
            eleveQuery = new EleveQuery(db);
            classeQuery = new ClasseQuery(db);
            eleveCommand = new EleveCommand(db);
            classeCommand = new ClasseCommand(db);
        }

        // GET: EleveAg
        public JsonResult Index()
        {
            var eleves = eleveQuery.GetAll().ToList();
            ArrayList elevesFin = new ArrayList();

            foreach (Eleve e in eleves)
            {
                e.Classe.Eleves = null;
                elevesFin.Add(JsonConvert.SerializeObject(e, Formatting.Indented, new JsonSerializerSettings { 
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                })) ;
            }


            return Json(JsonConvert.SerializeObject(eleves, Formatting.Indented, new JsonSerializerSettings { 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Detail(int id)
        {
            Eleve eleve = eleveQuery.GetById(id).FirstOrDefault();

            return Json(JsonConvert.SerializeObject(eleve, Formatting.Indented, new JsonSerializerSettings { 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Eleve eleve)
        {

            eleveCommand.Ajouter(eleve);


            return Json(null);
        }

        [HttpPost]
        public JsonResult Edit([Bind(Include = "Id,Nom,Prenom,DateNaissance,ClasseId")] Eleve eleve)
        {
            eleveCommand.Modifier(eleve);
            return Json(null);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            eleveCommand.Supprimer(id);
            return Json(null);
        }

        public JsonResult GetClasses()
        {
            var classeList = classeQuery.GetAll().ToList();
            ArrayList classeListFin = new ArrayList();
            classeList.ForEach(e =>
                classeListFin.Add(JsonConvert.SerializeObject(e))
            );

            return Json(JsonConvert.SerializeObject(classeList), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddNote(Note n, int eleveId)
        {
            n.EleveId = eleveId;

            db.Notes.Add(n);

            db.SaveChanges();

            return Json(null);

        }
    }
}