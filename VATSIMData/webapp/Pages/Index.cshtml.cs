using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;

namespace VATSIMData.WebApp.Pages{
    public class IndexModel : PageModel {
        private VatsimDbContext db;

        public VatsimClientPilotV1 Pilot { get; set; }

        //dependency injection
        public IndexModel(VatsimDbContext db) {
            this.db = db;
        }

        public async Task<IActionResult> OnGetAsync(string cid, string callsign, string timelogon) {

            Pilot = await db.Pilots.FindAsync(cid, callsign, timelogon);
            if(Pilot == null) {
                return RedirectToPage("NotFound");
            }
            return Page();
        }
    }
}