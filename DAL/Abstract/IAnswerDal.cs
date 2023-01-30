using ENT.Concrete;
using ENT.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IAnswerDal : IEntityRepository<Answer>
    {
        List<QuestionAndAnswerDto> questionAndAnswerDtos(int UserId);
    }
}
