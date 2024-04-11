using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleBank.Data;
using SimpleBank.Models;

namespace SimpleBank.Controllers
{
    [ApiController]
    [Route("simpleBank/api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly SimpleBankDBContext _context;

        public TransactionController(SimpleBankDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        [Route("receiveHistory/{idAccount}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetHistoryReceive(int idAccount)
        {
            var query = _context.Transactions.Where(tr => tr.AccountReceiver == idAccount);
            var result = await query.ToListAsync();
            return Ok(result);
        }

        [Route("sentHistory/{idAccount}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetHistorySent(int idAccount)
        {
            var query = _context.Transactions.Where(tr => tr.AccountSender == idAccount);
            var result = await query.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        [Route("makeTransaction")]
        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTransaction", new { id = transaction.TransactionId }, transaction);
        }
    }
}
