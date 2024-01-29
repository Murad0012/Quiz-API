using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs.Quiz;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
    
        public QuizController(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var quiz = _dbContext.Quizzes.AsNoTracking().Select(x => _mapper.Map<Quiz,QuizGetDto>(x)).ToList();
            
            return Ok(quiz);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var quiz = _dbContext.Quizzes.Include(q => q.Questions).ThenInclude(q => q.Options).SingleOrDefault(x => x.Id == id);

            if (quiz == null) return NotFound();

            var dto = _mapper.Map<Quiz, QuizDetailedGetDto>(quiz);

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] QuizPostDto dto)
        {
            var quiz = _mapper.Map<QuizPostDto, Quiz>(dto);

            _dbContext.Quizzes.Add(quiz);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] QuizPutDto dto, int id)
        {
            var quiz = _dbContext.Quizzes.FirstOrDefault(x => x.Id == id);
            if (quiz == null) return NotFound();

            _mapper.Map(dto, quiz);

            _dbContext.Update(quiz);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quiz = _dbContext.Quizzes.Include(q => q.Questions).ThenInclude(q => q.Options).SingleOrDefault(x => x.Id == id);

            if (quiz == null) return NotFound();

            _dbContext.Quizzes.Remove(quiz);

            _dbContext.SaveChanges();

            return Ok();
        }
    }   
}
