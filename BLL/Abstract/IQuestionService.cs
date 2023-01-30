using ENT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        Question GetById(int id);
    }
}
