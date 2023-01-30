using DAL.Abstract;
using ENT.Concrete;
using ENT.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework
{
    public class EfQuestionDal : EfEntityRepositoryDal<Question> , IQuestionDal
    {
        public EfQuestionDal(SurveyReportDbContext surveyReportDbContext) : base(surveyReportDbContext)
        {
        }

    }
}
