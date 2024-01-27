using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTOs.Question;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    public class QuestionController : Controller
    {
        private readonly AppDbContext _dbContext;
        public QuestionController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Put(int id,QuestionPutDto model)
        {
            var foundQuestion = _dbContext.Questions.FirstOrDefault(x => x.Id == id);

            if(foundQuestion is null) return NotFound();

            foundQuestion.Name = model.Name;
            foundQuestion.Points = model.Points ;

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
