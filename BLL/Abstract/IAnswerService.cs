using ENT.Concrete;
using ENT.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IAnswerService
    {
        Dictionary<bool, string> SaveAnswers(int CategoryId,List<string> answers,string UserId);

        List<QuestionAndAnswerDto> GetQuestionAndAnswers(int UserId);
    }
}
