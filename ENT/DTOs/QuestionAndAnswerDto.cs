using ENT.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT.DTOs
{
    public class QuestionAndAnswerDto : IDto
    {
        public int AnswerId { get; set; }

        public int QuestId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionOrder { get; set; }
        public string AnswerText { get; set; }
    }
}
