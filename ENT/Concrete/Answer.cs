using ENT.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT.Concrete
{
    public class Answer : IEntity
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public Question Question { get; set; }
        public User User { get; set; }

    }
}
