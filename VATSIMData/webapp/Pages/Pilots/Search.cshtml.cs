using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;

namespace VATSIMData.WebApp.Pages {
    public class PilotSearchModel : PageModel {
        private VatsimDbContext db;
        public PilotSearchModel(VatsimDbContext db) {
            this.db = db;
        }

        public string RealnameSort { get; set; }
        public string CallsignSort { get; set; }
        public string TimelogonSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<VatsimClientPilotV1> Pilots { get; set; }

        public async Task OnGetAsync(string sortOrder) {

            // setup sorts
            RealnameSort = string.IsNullOrEmpty(sortOrder) ? "realname_desc" : "";
            CallsignSort = sortOrder == "Callsign" ? "callsign_desc" : "Callsign";
            TimelogonSort = sortOrder == "Timelogon" ? "timelogon_desc" : "Timelogon";

            IQueryable<VatsimClientPilotV1> pilotsIQ = db.Pilots;

            //determine sort
            switch(sortOrder) {
                case "realname_desc":
                    pilotsIQ = pilotsIQ.OrderByDescending(p => p.Realname);
                    break;
                case "Callsign":
                    pilotsIQ = pilotsIQ.OrderBy(p => p.Callsign);
                    break;
                case "callsign_desc":
                    pilotsIQ = pilotsIQ.OrderByDescending(p => p.Callsign);
                    break;
                case "Timelogon":
                    pilotsIQ = pilotsIQ.OrderBy(p => p.TimeLogon);
                    break;
                case "timelogon_desc":
                    pilotsIQ = pilotsIQ.OrderByDescending(p => p.TimeLogon);
                    break;
                default:
                    pilotsIQ = pilotsIQ.OrderBy(p => p.Realname);
                    break;
            }

            //AsNoTracking prevents database update tracking as this is a read-only situation
            Pilots = await pilotsIQ.AsNoTracking().ToListAsync();

        }

        // public async Task<IActionResult> OnPostAsync(string callsign) {
            
        //     // requires that the EntityFrameworkCore namespace is used
        //     //Pilots = await db.Pilots.Where(p => p.Callsign.Contains(callsign)).ToListAsync();
        //     return RedirectToPage();
        // }
    }
}