using BudgetApplication.Model;
using BudgetApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public ExpenseController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet("totalexpense/{userId}")]
        public async Task<ActionResult<double>> GetTotalExpenses(int userId)
        {
            try
            {
                var totalExpenses = await _budgetService.GetTotalExpenses(userId);
                return Ok(totalExpenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("monthlyexpense/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetMonthlyExpenses(int userId)
        {
            try
            {
                var monthlyExpenses = await _budgetService.GetMonthlyExpenses(userId);
                return Ok(monthlyExpenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("quarterlyexpense/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetQuarterlyExpense(int userId)
        {
            try
            {
                var result = await _budgetService.GetQuarterlyExpense(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("halfyearlyexpense/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetHalfYearlyExpenses(int userId)
        {
            try
            {
                var halfYearlyExpenses = await _budgetService.GetHalfYearlyExpenses(userId);
                return Ok(halfYearlyExpenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("yearlyexpense/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetYearlyExpenses(int userId)
        {
            try
            {
                var yearlyExpenses = await _budgetService.GetYearlyExpenses(userId);
                return Ok(yearlyExpenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("expensetransactions/{userId}")]
        public async Task<ActionResult<List<Transaction>>> GetExpenseTransactions(int userId)
        {
            try
            {
                var expenseTransactions = await _budgetService.GetExpenseTransactions(userId);
                return Ok(expenseTransactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
