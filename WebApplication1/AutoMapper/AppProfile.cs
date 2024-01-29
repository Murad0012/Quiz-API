using AutoMapper;
using WebApplication1.DTOs.Option;
using WebApplication1.DTOs.Question;
using WebApplication1.DTOs.Quiz;
using WebApplication1.Entities;

namespace WebApplication1.AutoMapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Quiz, QuizDetailedGetDto>();
            CreateMap<Quiz, QuizGetDto>();
            CreateMap<QuizPostDto, Quiz>();
            CreateMap<QuestionPostDto, Question>();
            CreateMap<OptionPostDto, Option>();
            CreateMap<QuestionPutDto, Question>();
            CreateMap<OptionPutDto, Option>();
            CreateMap<Option, OptionGetDto>();
            CreateMap<Question, QuestionGetDto>();
            CreateMap<QuizPutDto, Quiz>();
        }
    }
}
