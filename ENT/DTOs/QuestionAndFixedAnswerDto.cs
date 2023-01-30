using ENT.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT.DTOs
{
    public class QuestionAndFixedAnswerDto : IDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int QuestionOrder { get; set; }
        public string FixedAnswer { get; set; }
    }
}
