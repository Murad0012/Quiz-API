using AutoMapper;
using WebApplication1.DTOs.Quiz;
using WebApplication1.Entities;

namespace WebApplication1.AutoMapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Quiz, QuizGetDto>();
            CreateMap<Quiz, QuizGetDto>();

        }
    }
}
