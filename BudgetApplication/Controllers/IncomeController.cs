using BudgetApplication.Model;
using BudgetApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public IncomeController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet("totalincome/{userId}")]
        public async Task<IActionResult> GetTotalIncome(int userId)
        {
            try
            {
                var totalIncome = await _budgetService.GetTotalIncome(userId);
                return Ok(totalIncome);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


        [HttpGet("monthlyincome/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetMonthlyIncome(int userId)
        {
            try
            {
                var result = await _budgetService.GetMonthlyIncome(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("quarterlyincome/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetQuarterlyIncome(int userId)
        {
            try
            {
                var result = await _budgetService.GetQuarterlyIncome(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpGet("halfyearlyincome/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetHalfYearlyIncome(int userId)
        {
            try
            {
                var result = await _budgetService.GetHalfYearlyIncome(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("yearlyincome/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetYearlyIncome(int userId)
        {
            try
            {
                var result = await _budgetService.GetYearlyIncome(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("incometransactions/{userId}")]
        public async Task<ActionResult<List<Transaction>>> GetIncomeTransactions(int userId)
        {
            try
            {
                var incomeTransactions = await _budgetService.GetIncomeTransactions(userId);
                return Ok(incomeTransactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
