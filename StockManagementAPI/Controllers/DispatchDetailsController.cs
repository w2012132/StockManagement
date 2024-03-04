using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagementAPI.Database;
using StockManagementAPI.Model;

namespace StockManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchDetailsController : ControllerBase
    {
        private readonly SM_DBContext _context;

        public DispatchDetailsController(SM_DBContext context)
        {
            _context = context;
        }

        // GET: api/DispatchDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DispatchDetail>>> GetDispatchDetails()
        {
            return await _context.DispatchDetails.ToListAsync();
        }

        // GET: api/DispatchDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DispatchDetail>> GetDispatchDetail(long id)
        {
            var dispatchDetail = await _context.DispatchDetails.FindAsync(id);

            if (dispatchDetail == null)
            {
                return NotFound();
            }

            return dispatchDetail;
        }

        // PUT: api/DispatchDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispatchDetail(long id, DispatchDetail dispatchDetail)
        {
            if (id != dispatchDetail.DispatchDetailID)
            {
                return BadRequest();
            }

            _context.Entry(dispatchDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispatchDetailExists(id))
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

        // POST: api/DispatchDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DispatchDetail>> PostDispatchDetail(DispatchDetail dispatchDetail)
        {
            _context.DispatchDetails.Add(dispatchDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDispatchDetail", new { id = dispatchDetail.DispatchDetailID }, dispatchDetail);
        }

        // DELETE: api/DispatchDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispatchDetail(long id)
        {
            var dispatchDetail = await _context.DispatchDetails.FindAsync(id);
            if (dispatchDetail == null)
            {
                return NotFound();
            }

            _context.DispatchDetails.Remove(dispatchDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DispatchDetailExists(long id)
        {
            return _context.DispatchDetails.Any(e => e.DispatchDetailID == id);
        }
    }
}
