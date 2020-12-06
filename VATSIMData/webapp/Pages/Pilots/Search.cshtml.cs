using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;

namespace VATSIMData.WebApp.Pages {
    public class PilotSearchModel : PageModel {
        private VatsimDbContext db;

        private readonly ILogger _logger;
        public PilotSearchModel(VatsimDbContext db, ILogger<PilotSearchModel> logger) {
            this.db = db;
            this._logger = logger;
        }

        public string RealnameSort { get; set; }
        public string CallsignSort { get; set; }
        public string TimelogonSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<VatsimClientPilotV1> Pilots { get; set; }

        public async Task OnGetAsync(string sortOrder, 
                                     string currentFilter,
                                     string searchString,
                                     int? pageIndex) {

            _logger.LogInformation($"The submitted search string: {searchString}");

            // setup sorts
            RealnameSort = string.IsNullOrEmpty(sortOrder) ? "realname_desc" : "";
            CallsignSort = sortOrder == "Callsign" ? "callsign_desc" : "Callsign";
            TimelogonSort = sortOrder == "Timelogon" ? "timelogon_desc" : "Timelogon";

            //pagination
            if(searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<VatsimClientPilotV1> pilotsIQ = db.Pilots;

            if(!string.IsNullOrEmpty(searchString)) {
                pilotsIQ = pilotsIQ.Where(s => s.Cid.Contains(searchString) ||
                                               s.Realname.Contains(searchString) ||
                                               s.Callsign.Contains(searchString));
            }

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

            int pageSize = 30;

            //AsNoTracking prevents database update tracking as this is a read-only situation
            // Pilots = await pilotsIQ.AsNoTracking().ToListAsync();
            Pilots = await PaginatedList<VatsimClientPilotV1>.CreateAsync(
                pilotsIQ.AsNoTracking(),
                pageIndex ?? 1, 
                pageSize
            );

        }

        // public async Task<IActionResult> OnPostAsync(string callsign) {
            
        //     // requires that the EntityFrameworkCore namespace is used
        //     //Pilots = await db.Pilots.Where(p => p.Callsign.Contains(callsign)).ToListAsync();
        //     return RedirectToPage();
        // }
    }
}