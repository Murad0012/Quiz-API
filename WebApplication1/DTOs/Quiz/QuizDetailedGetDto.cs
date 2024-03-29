﻿using WebApplication1.DTOs.Question;

namespace WebApplication1.DTOs.Quiz
{
    public class QuizDetailedGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionGetDto> Questions { get; set; }
    }
}
