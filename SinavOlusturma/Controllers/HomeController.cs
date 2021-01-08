using BusinessLogicLayer;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SinavOlusturma.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace SinavOlusturma.Controllers
{
    public class HomeController : Controller
    {
        int userid;

        [Authorize]
        public IActionResult Index()
        {
            SetViewBags();

            List<Test> tests=new List<Test>();

            List<string> links = ArticleBusiness.getLinks("https://www.wired.com/most-recent", "/html/body/div[3]/div/div[3]/div/div[2]/div/div[1]/div/div/ul/li", "https://www.wired.com");

          
            for (int i = 0; i < 5; i++)
            {
                HtmlNode[] header = ArticleBusiness.getNodesByXPath(links[i], "//h1");

                HtmlNode[] content = ArticleBusiness.getNodesByXPath(links[i], "//article//p");
                string a = "";
                for (int j = 0; j < content.Length; j++)
                {
                    a += "<p>" + content[j].InnerHtml + "</p>";
                }
                tests.Add(new Test { title = header[0].InnerHtml.ToString(), content = a});
            }
            var model = new HomeViewModel { Tests = tests.ToArray() };
            return View(model);


        }
        [Authorize]
        [HttpPost]
        public IActionResult Index(HomeViewModel model)
        {
            string key = Guid.NewGuid().ToString();
            Test test = new Test { title = model.title, content = model.content, userId = Convert.ToInt32(HttpContext.Session.GetInt32("userId")), key = key, createdDate=DateTime.Now
            };
            TestBusiness.AddTest(test);
            Test currentTest = TestBusiness.GetTest(key);
            QuestionBusiness.SaveQuestions(model.Questions, currentTest);
            return RedirectToAction("Index","Test");
        }
        [Authorize]
        public void SetViewBags()
        {

            List<SelectListItem> options = new List<SelectListItem> {

                new SelectListItem { Text="Doğru Cevabı Seçiniz", Value="", Selected=true},
                new SelectListItem { Text="A", Value="One"},
                new SelectListItem { Text="B", Value="Two"},
                new SelectListItem { Text="C", Value="Three"},
                new SelectListItem { Text="D", Value="Four"}
            };
            ViewBag.options = options;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
