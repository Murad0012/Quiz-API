using WebApplication1.DTOs.Option;

namespace WebApplication1.DTOs.Question
{
    public class QuestionPostDto
    {
        public string Name { get; set; }
        public decimal Points { get; set; }
        public List<OptionPostDto> Options { get; set; }
    }
}
