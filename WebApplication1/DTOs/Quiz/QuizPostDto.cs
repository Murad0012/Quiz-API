using FluentValidation;
using WebApplication1.DTOs.Question;

namespace WebApplication1.DTOs.Quiz
{
    public class QuizPostDto
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionPostDto> Questions { get; set; }
    }

    public class QuizPostDtoValidator : AbstractValidator<QuizPostDto>
    {
        public QuizPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty").MinimumLength(4).WithMessage("Minimum length is 5 chars!");
        }
    }
}
