using WebApplication1.DTOs.Question;

namespace WebApplication1.DTOs.Quiz
{
    public class QuizPostDto
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionPostDto> Questions { get; set; }
    }
}
