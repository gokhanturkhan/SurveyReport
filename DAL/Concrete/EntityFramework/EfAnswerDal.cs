using DAL.Abstract;
using ENT.Concrete;
using ENT.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework
{
    public class EfAnswerDal : EfEntityRepositoryDal<Answer> , IAnswerDal
    {
        SurveyReportDbContext _surveyReportDbContext;
        public EfAnswerDal(SurveyReportDbContext surveyReportDbContext) : base(surveyReportDbContext)
        {
            _surveyReportDbContext = surveyReportDbContext; 
        }

        public List<QuestionAndAnswerDto> questionAndAnswerDtos(int UserId)
        {

                var result = from a in _surveyReportDbContext.Answers
                             join q in _surveyReportDbContext.Questions
                             on a.QuestionId equals q.Id
                             where a.UserId == UserId
                             select new QuestionAndAnswerDto
                             {
                                 AnswerId = a.Id,
                                 AnswerText = a.AnswerText,
                                 QuestionText = q.QuestionText,
                                 QuestionOrder = q.QuestionOrder,
                                 QuestId = q.Id
                             };

                return result.ToList();
            
                
            
        }
    }
}
