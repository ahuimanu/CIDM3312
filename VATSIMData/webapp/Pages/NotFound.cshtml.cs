using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;

namespace VATSIMData.WebApp.Pages
{
    public class NotFoundModel : PageModel
    {
        private VatsimDbContext db;

        public IEnumerable<VatsimClientPilotV1> Pilots { get; set; }

        public NotFoundModel(VatsimDbContext db) {
            this.db = db;
        }
        public void OnGet()
        {
            Pilots = db.Pilots.Take(30);
        }
    }
}