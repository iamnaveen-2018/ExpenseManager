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
        //static private List<ExpenseCreation> expenseDetails = new List<ExpenseCreation>
        //{
        //    new ExpenseCreation
        //    {
        //        ExpenseName = "Vishnu",
        //        ExpenseType = "Entertainment",
        //        Description = "Movie",
        //        SalaryId = 3
        //    }
        //};

        private readonly ExpenseManagerDbContext _expenseDBContext;

        public ExpenseController(ExpenseManagerDbContext expenseDBContext)
        {
            _expenseDBContext = expenseDBContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllExpense()
        {
            var result = new
            {
                status = 200,
                data = await _expenseDBContext.ExpenseCreations.ToListAsync(),
                count = _expenseDBContext.ExpenseCreations.Count()
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salary>> GetExpenseById(int id)
        {
            var expenseDetails = await _expenseDBContext.ExpenseCreations.FindAsync(id);
            if (expenseDetails == null)
            {
                return NotFound("Expense Not Found");
            }
            return Ok(expenseDetails);
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseCreation>> AddNewExpense(ExpenseCreation expenseCreation)
        {
            if (expenseCreation == null)
            {
                return BadRequest("Error in Data");
            }
            var salary = await _expenseDBContext.Salaries.FirstOrDefaultAsync(s => s.SalaryId == expenseCreation.SalaryId);
            if(salary == null)
            {
                return BadRequest("Salary Not Found");
            }
            expenseCreation.Salary = salary;
            await _expenseDBContext.ExpenseCreations.AddAsync(expenseCreation);
            await _expenseDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExpenseById), new { id = expenseCreation.ExpenseId }, expenseCreation);
        }
    }
}
