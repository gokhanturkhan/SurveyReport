using BLL.Abstract;
using DAL.Abstract;
using ENT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class FixedAnswerManager : IFixedAnswerService
    {
        IFixedAnswerDal _fixedAnswerDal;

        public FixedAnswerManager(IFixedAnswerDal fixedAnswerDal)
        {
            _fixedAnswerDal= fixedAnswerDal;
        }

        public List<FixedAnswer> GetFixedAnswersByQuestionId(int QuestionId)
        {
            return _fixedAnswerDal.GetAll(a => a.QuestionId == QuestionId);
        }
    }
}
