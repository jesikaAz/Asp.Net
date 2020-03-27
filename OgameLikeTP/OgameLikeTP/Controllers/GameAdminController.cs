using OgameLikeTP.Data;
using OgameLikeTP.Models;
using OgameLikeTPClassLibrary.Entities;
using OgameLikeTPClassLibrary.Extensions;
using System.Web.Mvc;

namespace OgameLikeTP.Controllers
{
    public class GameAdminController : Controller
    {
        private OgameLikeTPContext db = new OgameLikeTPContext();

        public ActionResult Configure()
        {
            GameAdminVM vm = new GameAdminVM();
            var globalConf = db.Configurations.Find(ConfigurationKeys.GlobalGameConfiguration.GetName());
            var planetConf = db.Configurations.Find(ConfigurationKeys.GlobalPlanetConfiguration.GetName());

            return View(vm);
        }

        [HttpPost]
        public ActionResult Configure(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}