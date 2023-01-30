using DAL.Abstract;
using ENT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework
{
    public class EfFixedAnswerDal : EfEntityRepositoryDal<FixedAnswer>,IFixedAnswerDal
    {
        public EfFixedAnswerDal(SurveyReportDbContext surveyReportDbContext) : base(surveyReportDbContext)
        {
        }
    }
}
