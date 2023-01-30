using DAL.Abstract;
using ENT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryDal<User>, IUserDal
    {
        public EfUserDal(SurveyReportDbContext surveyReportDbContext) : base(surveyReportDbContext)
        {
        }
    }
}
