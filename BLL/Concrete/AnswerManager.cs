using BLL.Abstract;
using DAL.Abstract;
using ENT.Concrete;
using ENT.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class AnswerManager : IAnswerService
    {
        IAnswerDal _answerDal;
        IUserDal _userDal;
        public AnswerManager(IAnswerDal answerDal, IUserDal userDal)
        {
            _answerDal = answerDal;
            _userDal = userDal;
        }

        public List<QuestionAndAnswerDto> GetQuestionAndAnswers(int UserId)
        {
            return _answerDal.questionAndAnswerDtos(UserId).ToList();
        }

        public Dictionary<bool, string> SaveAnswers(int QuestionId, List<string> answers, string UserId)
        {
            var user = _userDal.Get(a => a.Id == Convert.ToInt32(UserId));
            foreach (var item in answers)
            {
                var answer = new Answer() { AnswerText= item, QuestionId = QuestionId,UserId = Convert.ToInt32(UserId) };
                _answerDal.Add(answer);       
            }
            user.QuestionOrderCount++;
            _userDal.Update(user);
            var result = new Dictionary<bool, string>();
            result.Add(true, "İşlem başarılı");
            return result;
        }
    }
}
