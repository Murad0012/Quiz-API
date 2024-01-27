using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTOs.Option;

namespace WebApplication1.Controllers
{
    public class OptionController : Controller
    {
        private readonly AppDbContext _dbContext;
        public OptionController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Put(int id, OptionPutDto model)
        {
            var foundOption = _dbContext.Options.FirstOrDefault(x => x.Id == id);

            if (foundOption is null) return NotFound();

            foundOption.Name = model.Name;
            foundOption.isCorrect = model.isCorrect;

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
