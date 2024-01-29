using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs.Question;

namespace WebApplication1.Controllers
{
    public class QuestionController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public QuestionController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, QuestionPutDto dto)
        {
            var question = _dbContext.Questions.FirstOrDefault(x => x.Id == id);

            if (question == null) return NotFound();

            _mapper.Map(dto, question);

            _dbContext.Update(question);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
