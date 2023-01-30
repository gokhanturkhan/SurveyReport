using ENT.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string? CvDoc { get; set; }

        public DateTime CreationDate { get; set; }

        public bool? IsAnsweredSurvey { get; set; }

        public int QuestionOrderCount { get; set; }

        public ICollection<Answer> Answers { get; set; }

    }
}
