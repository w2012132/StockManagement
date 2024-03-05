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
    public class StockTransactionsController : ControllerBase
    {
        private readonly SM_DBContext _context;
        private readonly ILogger<StockTransactionsController> _logger;
        public StockTransactionsController(SM_DBContext context, ILogger<StockTransactionsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/StockTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockTransaction>>> GetStockTransactions()
        {
            return await _context.StockTransactions.ToListAsync();
        }

        // GET: api/StockTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockTransaction>> GetStockTransaction(long id)
        {
            var stockTransaction = await _context.StockTransactions.FindAsync(id);

            if (stockTransaction == null)
            {
                _logger.LogError("Stock Transaction not found");

                return NotFound();
            }

            return stockTransaction;
        }

        // PUT: api/StockTransactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockTransaction(long id, StockTransaction stockTransaction)
        {
            if (id != stockTransaction.StockTransactionId)
            {
                return BadRequest();
            }

            _context.Entry(stockTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockTransactionExists(id))
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

        // POST: api/StockTransactions

        [HttpPost]
        public async Task<ActionResult<StockTransaction>> PostStockTransaction(StockTransaction stockTransaction)
        {
            _context.StockTransactions.Add(stockTransaction);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Stock Transaction added. Id {stockTransaction.StockTransactionId}");

            return CreatedAtAction("GetStockTransaction", new { id = stockTransaction.StockTransactionId }, stockTransaction);
        }

        // DELETE: api/StockTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockTransaction(long id)
        {
            var stockTransaction = await _context.StockTransactions.FindAsync(id);
            if (stockTransaction == null)
            {
                return NotFound();
            }

            _context.StockTransactions.Remove(stockTransaction);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Stock Transaction deleted. Id {id}");
            return NoContent();
        }

        private bool StockTransactionExists(long id)
        {
            return _context.StockTransactions.Any(e => e.StockTransactionId == id);
        }
    }
}
