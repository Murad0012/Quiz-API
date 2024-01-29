using FluentValidation;
using WebApplication1.DTOs.Option;
using WebApplication1.DTOs.Quiz;

namespace WebApplication1.DTOs.Question
{
    public class QuestionPostDto
    {
        public string Name { get; set; }
        public decimal Points { get; set; }
        public List<OptionPostDto>? Options { get; set; }


        public class QuestionPostDtoValidator : AbstractValidator<QuestionPostDto>
        {
            public QuestionPostDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty").MinimumLength(4).WithMessage("Minimum length is 5 chars!");
            }
        }
    }
}
