using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagementAPI.Database;
using StockManagementAPI.Model;

namespace StockManagementAPI.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class DispatchesController : ControllerBase
    {
        private readonly SM_DBContext _context;
        private readonly ILogger<DispatchesController> _logger;
        public DispatchesController(SM_DBContext context, ILogger<DispatchesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Dispatches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dispatch>>> GetDispatches()
        {
            return await _context.Dispatches.ToListAsync();
        }

        // GET: api/Dispatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dispatch>> GetDispatch(Guid id)
        {
            var dispatch = await _context.Dispatches.FindAsync(id);

            if (dispatch == null)
            {
                return NotFound();
            }

            return dispatch;
        }

        // PUT: api/Dispatches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispatch(Guid id, Dispatch dispatch)
        {
            if (id != dispatch.DispatchId)
            {
                return BadRequest();
            }

            _context.Entry(dispatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dispatches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dispatch>> PostDispatch(Dispatch dispatch)
        {
            _context.Dispatches.Add(dispatch);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Dispatch added. Id {dispatch.DispatchId}");

            return CreatedAtAction("GetDispatch", new { id = dispatch.DispatchId }, dispatch);
        }

        // DELETE: api/Dispatches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispatch(Guid id)
        {
            var dispatch = await _context.Dispatches.FindAsync(id);
            if (dispatch == null)
            {
                return NotFound();
            }

            _context.Dispatches.Remove(dispatch);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Dispatch deleted. Id {id}");

            return NoContent();
        }

        private bool DispatchExists(Guid id)
        {
            return _context.Dispatches.Any(e => e.DispatchId == id);
        }
    }
}
