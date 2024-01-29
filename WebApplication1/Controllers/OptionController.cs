using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs.Option;

namespace WebApplication1.Controllers
{
    public class OptionController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public OptionController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, OptionPutDto dto)
        {
            var option = _dbContext.Options.FirstOrDefault(x => x.Id == id);
                    
            if (option == null) return NotFound();

            _mapper.Map(dto, option);

            _dbContext.Update(option);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
