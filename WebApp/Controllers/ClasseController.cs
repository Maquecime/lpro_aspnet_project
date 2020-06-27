using BusinessLayer.ProjectNet.Commands;
using BusinessLayer.ProjectNet.Queries;
using Model.ProjectNet;
using Model.ProjectNet.Entities;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ClasseController : Controller
    {
        private ProNetDbContext db;
        private ClasseQuery classeQuery;
        private ClasseCommand classeCommand;

        public ClasseController()
        {
            db = new ProNetDbContext();
            classeQuery = new ClasseQuery(db);
            classeCommand = new ClasseCommand(db);
        }

        public ActionResult Index()
        {
            var classes = classeQuery.GetAll().ToList().OrderByDescending(c => c.Eleves.Count);

            return Json(JsonConvert.SerializeObject(classes, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Detail(int id)
        {
            Classe classe = classeQuery.GetById(id).FirstOrDefault();

            return Json(JsonConvert.SerializeObject(classe, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Classe classe)
        {

            classeCommand.Ajouter(classe);


            return Json(null);
        }

        [HttpPost]
        public JsonResult Edit([Bind(Include = "Id,NomEtablissement,Niveau")] Classe classe)
        {
            classeCommand.Modifier(classe);
            return Json(null);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            classeCommand.Supprimer(id);
            return Json(null);
        }
    }
}