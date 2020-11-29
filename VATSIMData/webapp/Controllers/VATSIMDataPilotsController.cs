using Microsoft.AspNetCore.Mvc;
using VatsimLibrary.VatsimClientV1;
using VatsimLibrary.VatsimDb;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

using WebApp.Models;

namespace WebApp.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class PilotsController : ControllerBase {
        private VatsimDbContext db;

        //depency injection
        public PilotsController(VatsimDbContext db) {
            this.db = db;
        }

        [HttpGet]
        public IAsyncEnumerable<VatsimClientPilotV1> GetPilots() {
            return db.Pilots;
        }

        [HttpGet("{cid}/{callsign}/{timelogon}")]
        public async Task<IActionResult> GetPilot(string cid, string callsign, string timelogon) {
            VatsimClientPilotV1 pilot = await db.Pilots.FindAsync(cid, callsign, timelogon);
            if (pilot == null) {
                return NotFound();
            }
            // this is a projection as it is a subset of pilot properties
            return Ok(new {
                Cid = pilot.Cid, 
                Realname = pilot.Realname,
                Callsign = pilot.Callsign, 
                Latitude = pilot.Latitude,
                Longitude = pilot.Longitude, 
                TimeLogon = pilot.TimeLogon,
            });
        }

        [HttpPost]
        public async Task<IActionResult> SavePilot(VatsimClientPilotV1BindingTarget target) {
            VatsimClientPilotV1 pilot = target.ToVatsimClientPilotV1();
            await db.Pilots.AddAsync(pilot);
            await db.SaveChangesAsync();
            return Ok(pilot);
        }

        [HttpPut]
        public async Task UpdateVatsimClientPilotV1(VatsimClientPilotV1 pilot) {
            db.Update(pilot);
            await db.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteVatsimClientPilotV1(string cid) {
            db.Pilots.Remove(new VatsimClientPilotV1() { Cid = cid });
            await db.SaveChangesAsync();
        }

        [HttpGet("redirect")]
        public IActionResult Redirect() {
            return RedirectToAction(nameof(GetPilot), new { Id = 1 });
        }
    }
}