using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenant_Configuration_Server_Dotnet.Models;

namespace Tenant_Configuration_Server_Dotnet.Controllers
{
    [Route("api/tenant")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TenantContext _context;

        public TodoController(TenantContext context)
        {
            _context = context;

            if (_context.Tenants.Count() == 0)
            {
                // Create a new Tenant if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Tenants.Add(new Tenant { Name = "Tenant1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Tenant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tenant>>> GetTenats()
        {
            return await _context.Tenants.ToListAsync();
        }

        // GET: api/Tenant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tenant>> GetTodoItem(long id)
        {
            var todoItem = await _context.Tenants.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}