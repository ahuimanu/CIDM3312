using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;

using WebApp.Models;

namespace WebApp.Controllers {

    public class HomeController : Controller {
        private VatsimDbContext db;

        // dependency injection of the DbContext from the Service
        public HomeController(VatsimDbContext db) {
            this.db = db;
        }

        public async Task<IActionResult> Index(string cid = "1") {

            VatsimClientPilotV1 pilot = await db.Pilots.FindAsync(cid);
            return View(pilot);
        }

        public IActionResult Common() {
            return View();
        }

        public IActionResult List() {
            return View(db.Pilots);
        }
    }
}