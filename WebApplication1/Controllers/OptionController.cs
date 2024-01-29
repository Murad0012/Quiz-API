using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("UpdateOption/{id}")]
        public IActionResult UpdateOption(int id, OptionPutDto dto)
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
