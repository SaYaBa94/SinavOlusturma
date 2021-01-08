using Microsoft.AspNetCore.Mvc;
using SinavOlusturma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;

namespace SinavOlusturma.Controllers
{
    public class TestController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var model = new TestViewModel {
                TestList = TestBusiness.GetTestList(Convert.ToInt32(HttpContext.Session.GetInt32("userId")))
            };
            return View(model);
        }
        [Authorize]
        public IActionResult DeleteTest(int id)
        {
            var test = TestBusiness.GetTest(id);
            TestBusiness.DeleteTest(test);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult SolveTest(int id)
        {
            var test = TestBusiness.GetTest(id);
            List<Question> questions = QuestionBusiness.GetTestQuestion(id);
            var model = new TestViewModel { QuestionList = questions, Test = test };
            return View(model);
        }

    }
}
