namespace WebApplication1.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isCorrect { get; set; }

        public Question question { get; set; }
    }
}
