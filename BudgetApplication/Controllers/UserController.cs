using BudgetApplication.Model;
using BudgetApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public UserController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Invalid user data");
                }
                await _budgetService.AddUser(user);

                return Ok("User added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
