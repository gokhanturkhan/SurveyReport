using ENT.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT.Concrete
{
    public class Question : IEntity
    {
        public int Id { get; set; }

        public String QuestionText { get; set; }

        public int QuestionOrder { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<FixedAnswer> FixedAnswers { get; set; }
    }
}
