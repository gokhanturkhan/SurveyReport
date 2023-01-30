using BLL.Abstract;
using BLL.Concrete;
using DAL.Abstract;
using DAL.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DependencyResolvers
{
    public static  class BLLServiceRegistration
    {
        public static void BLLAddDataAccessService(this IServiceCollection services)
        {   
            services.AddScoped<IUserService, UserManager>();    
            services.AddScoped<IAnswerService,AnswerManager>();
            services.AddScoped<IFixedAnswerService,FixedAnswerManager>();
            services.AddScoped<IQuestionService,QuestionManager>();
    
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IAnswerDal,EfAnswerDal>();
            services.AddScoped<IFixedAnswerDal,EfFixedAnswerDal>();
            services.AddScoped<IQuestionDal,EfQuestionDal>();

        }
    }
}
