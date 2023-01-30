using BLL.Abstract;
using ENT.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyReport.Models;
using System.Security.Claims;
using System.Text.Json;

namespace SurveyReport.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        IAnswerService _answerService;
        IQuestionService _questionService;
        public UserController(IUserService userService, IAnswerService answerService,IQuestionService questionService)
        {
            _userService = userService;
            _answerService = answerService;
            _questionService = questionService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (TempData["RegisterResult"] != null)
            {
                return View(TempData["RegisterResult"]);
            }
            return View();
        }

        public IActionResult Profile()
        {
            var UserId = HttpContext.Session.GetString("UserId");
            var user = _userService.GetById(Convert.ToInt32(UserId));
            var questionAndAnswers = _answerService.GetQuestionAndAnswers(Convert.ToInt32(UserId));
            var questions = _questionService.GetAll();

            var model = new QuestionAndUserModel()
            {
                QuestionAndAnswerDtos = questionAndAnswers,
                User = user,
                Questions = questions
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = _userService.GetUser(userName, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userName),
                    new Claim(ClaimTypes.Upn,password)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                HttpContext.Session.SetString("UserId", user.Id.ToString());

                return RedirectToAction("Index", "User");
            }
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (TempData["RegisterResult"] != null)
            {
                return View(TempData["RegisterResult"]);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var result = _userService.AddUser(user);
            TempData["RegisterResult"] = result.Values.FirstOrDefault();
            if (result.Keys.FirstOrDefault())
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Register");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            if (TempData["AnsweredMessage"] != null)
            {
                ViewBag.AnsweredMessage = TempData["AnsweredMessage"];
            }
            var users = _userService.GetUsers().ToList();

            return View(users);
        }
    }
}
