using ExpenseManager.Data;
using ExpenseManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        static private List<ExpenseCreation> expenseDetails = new List<ExpenseCreation>
        {
            new ExpenseCreation
            {
                ExpenseName = "Vishnu",
                ExpenseType = "Entertainment",
                Description = "Movie",
                SalaryId = 3
            }
        };

        private readonly ExpenseManagerDbContext _expenseDBContext;

        public ExpenseController(ExpenseManagerDbContext expenseDBContext)
        {
            _expenseDBContext = expenseDBContext;
        }

        [HttpGet]
        public ActionResult GetAllExpense()
        {
            var result = new
            {
                status = 200,
                data = expenseDetails,
                count = _expenseDBContext.ExpenseCreations.Count()
            };
            return Ok(result);
        }

    }
}
