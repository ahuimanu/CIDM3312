using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;

namespace VATSIMData.WebApp.Pages {
    public class ListModel : PageModel { 
        private VatsimDbContext db;
        public IEnumerable<string> Pilots { get; set; } 
        public ListModel(VatsimDbContext db) { 
            this.db = db; 
        } 
        public void OnGet() { 
            Pilots = db.Pilots.Select(p => p.Realname);
        } 
    }
}