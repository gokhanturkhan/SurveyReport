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
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal= questionDal;  
        }
        public Question GetById(int id)
        {
            return _questionDal.Get(a => a.Id == id);
        }
    }
}
