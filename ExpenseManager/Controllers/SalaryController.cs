using ExpenseManager.Data;
using ExpenseManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ExpenseManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        //static private List<SalaryModel> salary = new List<SalaryModel>
        //{
        //    new SalaryModel
        //    {
        //        Salary_Id = 101,
        //        Salary_Source = "IT",
        //        Salary_Type = "Month",
        //        Description = "Boring",
        //        Amount = 50000
        //    },
        //    new SalaryModel
        //    {
        //        Salary_Id = 102,
        //        Salary_Source = "PhotoGrapher",
        //        Salary_Type = "Month",
        //        Description = "Exploring",
        //        Amount = 15000
        //    },
        //    new SalaryModel
        //    {
        //        Salary_Id = 103,
        //        Salary_Source = "Travel Guide",
        //        Salary_Type = "Month",
        //        Description = "Enjoying",
        //        Amount = 10000
        //    }
        //};

        private readonly SalaryDbContext _context;

        public SalaryController(SalaryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSalary()
        {
            var result = new
            {
                status = 200,
                data = await _context.Salaries.ToListAsync(),
                count = _context.Salaries.Count()
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryModel>> GetSalaryById(int id)
        {
            var salaryDetails = await _context.Salaries.FindAsync(id);
            if(salaryDetails == null)
            {
                return NotFound("Salary Not Found");
            }
            return Ok(salaryDetails);
        }

        [HttpPost]

        public async Task<ActionResult<SalaryModel>> AddSalary(SalaryModel newSalary)
        {
            if (newSalary is null) 
            { 
                return BadRequest("Error in Data"); 
            }
            _context.Salaries.Add(newSalary);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSalaryById), new { id = newSalary.Salary_Id}, newSalary);
        }

        //[HttpPut("{id}")]

        //public IActionResult UpdateSalaryDetailsById(int id, SalaryModel updateSalary)
        //{
        //    var sal = salary.FirstOrDefault(s => s.Salary_Id == id);
        //    if (sal is null)
        //        return NotFound("Salary Not Found");

        //    sal.Salary_Id = id;
        //    sal.Salary_Source = updateSalary.Salary_Source;
        //    sal.Salary_Type = updateSalary.Salary_Type;
        //    sal.Description = updateSalary.Description;
        //    sal.Amount = updateSalary.Amount;

        //    return NoContent();
        //}

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteSalaryById(int id)
        {
            var sal = await _context.Salaries.FindAsync(id);
            if (sal is null)
            {
                return NotFound();
            }
            _context.Salaries.Remove(sal);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
