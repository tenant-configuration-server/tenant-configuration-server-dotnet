using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tenant_Configuration_Server_Dotnet.Models;

namespace Tenant_Configuration_Server_Dotnet.Controllers {
    [Route ("api/tenant")]
    [ApiController]
    public class TenantController : ControllerBase {
        private readonly TenantContext _context;

        public TenantController (TenantContext context) {
            _context = context;

            if (_context.Tenants.Count () == 0) {
                // Create a new Tenant if collection is empty,
                // which means you can't delete all Tenants.
                _context.Tenants.Add (new Tenant { Name = "Tenant1" });
                _context.SaveChanges ();
            }
        }

        // GET: api/Tenant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tenant>>> GetTenats () {
            return await _context.Tenants.ToListAsync ();
        }

        // GET: api/Tenant/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<Tenant>> GetTenant (long id) {
            var tenant = await _context.Tenants.FindAsync (id);

            if (tenant == null) {
                return NotFound ();
            }

            return tenant;
        }

        // POST: api/Tenant
        [HttpPost]
        public async Task<ActionResult<Tenant>> PostTenant (Tenant tenant) {
            _context.Tenants.Add (tenant);
            await _context.SaveChangesAsync ();

            return CreatedAtAction (nameof (GetTenant), new { id = tenant.Id }, tenant);
        }

        // PUT: api/Tenant/5
        [HttpPut ("{id}")]
        public async Task<IActionResult> PutTenant (long id, Tenant tenant) {
            if (id != tenant.Id) {
                return BadRequest ();
            }

            _context.Entry (tenant).State = EntityState.Modified;
            await _context.SaveChangesAsync ();

            return NoContent ();
        }

        // DELETE: api/Tenant/5
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteTenant (long id) {
            var tenant = await _context.Tenants.FindAsync (id);

            if (tenant == null) {
                return NotFound ();
            }

            _context.Tenants.Remove (tenant);
            await _context.SaveChangesAsync ();

            return NoContent ();
        }
    }
}