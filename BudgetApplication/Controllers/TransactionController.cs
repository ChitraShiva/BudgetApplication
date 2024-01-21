using BudgetApplication.Model;
using BudgetApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public TransactionController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return BadRequest("Invalid transaction data");
                }
                await _budgetService.AddTransaction(transaction);

                return Ok("Transaction added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


    }
}
