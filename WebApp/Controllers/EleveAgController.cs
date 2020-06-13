using Model.ProjectNet;
using Newtonsoft.Json;
using System.Collections;
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
            var eleves = db.Eleves.ToList();
            ArrayList elevesFin = new ArrayList();
            eleves.ForEach(e =>
                elevesFin.Add(JsonConvert.SerializeObject(e))
            );

            return Json(JsonConvert.SerializeObject(eleves), JsonRequestBehavior.AllowGet);
        }
    }
}