using ENT.Concrete;

namespace SurveyReport.Models
{
    public class QuestionPageModel
    {
        public Question Question { get; set; }

        public List<FixedAnswer> FixedAnswers { get; set; }
    }
}
