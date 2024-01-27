using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs.Quiz;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    public class QuizController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
    
        public QuizController(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, QuizPutDto model)
        {
            var foundQuiz = _dbContext.Quizzes.FirstOrDefault(x => x.Id == id);

            if (foundQuiz is null) return NotFound();

            _mapper.Map(model, foundQuiz);

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var quizzes = _dbContext.Quizzes.Select(x=>_mapper.Map<Quiz,QuizGetDto>(x)).ToList();

            return Ok(quizzes);
        }
    }
}
