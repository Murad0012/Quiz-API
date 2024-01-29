using WebApplication1.DTOs.Option;
using WebApplication1.DTOs.Quiz;

namespace WebApplication1.DTOs.Question
{
    public class QuestionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Points { get; set; }
        public List<OptionGetDto> Options { get; set; }

    }
}
