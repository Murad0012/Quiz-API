using WebApplication1.DTOs.Option;

namespace WebApplication1.DTOs.Question
{
    public class QuestionPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Points { get; set; }
        public List<OptionGetDto> Options { get; set; }
    }
}
