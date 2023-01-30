using ENT.Concrete;
using ENT.DTOs;

namespace SurveyReport.Models
{
    public class QuestionAndUserModel
    {
        public User User { get; set; }
        public List<QuestionAndAnswerDto> QuestionAndAnswerDtos { get; set; }

        public List<Question> Questions { get; set; }
    }
}
