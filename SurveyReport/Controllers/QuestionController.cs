using BLL.Abstract;
using ENT.Concrete;
using Microsoft.AspNetCore.Mvc;
using SurveyReport.Models;
using System.Text.Json;

namespace SurveyReport.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionService _questionService;
        IFixedAnswerService _fixedAnswerService;
        IAnswerService _answerService;
        IUserService _userService;

        public QuestionController(IQuestionService questionService, IFixedAnswerService fixedAnswerService, 
            IAnswerService answerService,IUserService userService)
        {
            _questionService = questionService;
            _fixedAnswerService = fixedAnswerService;
            _answerService = answerService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var UserId = HttpContext.Session.GetString("UserId");
            var user = _userService.GetById(Convert.ToInt32(UserId));
    
            var QuestionId = user.QuestionOrderCount;

            if(QuestionId > 5) {
                TempData["AnsweredMessage"] = "Tüm soruları yanıtladınız.";
                return RedirectToAction("Index","User");
            }
            var question = _questionService.GetById(QuestionId);
            var questionFixedAnswer = _fixedAnswerService.GetFixedAnswersByQuestionId(QuestionId);
            var model = new QuestionPageModel() { FixedAnswers= questionFixedAnswer,Question = question };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAnswers(int QuestionId,List<string> FixedAnswers)
        {
            var UserId = HttpContext.Session.GetString("UserId");
      
            if(UserId != null)
            {
                _answerService.SaveAnswers(QuestionId, FixedAnswers, UserId);
            }

            return RedirectToAction("Index");
        }
    }
}
