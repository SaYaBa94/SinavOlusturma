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

namespace SinavOlusturma.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ArticleBusiness ab = new ArticleBusiness();
            List<string> links = ab.getLinks("https://www.wired.com/most-recent", "/html/body/div[3]/div/div[3]/div/div[2]/div/div[1]/div/div/ul/li", "https://www.wired.com");
            List<string> headers = new List<string>();
            List<string> contents = new List<string>();

            for (int i = 0; i < links.Count; i++)
            {
                HtmlNode[] header = ab.getNodesByXPath(links[i], "/html/body/div[1]/div/main/article/div[1]/header/div/div[1]");
                HtmlNode[] content = ab.getNodesByXPath(links[i], "/html/body/div[1]/div/main/article/div[2]//p");

                headers.Add(header[0].LastChild.InnerHtml);
                string a = "";
                for (int j = 0; j < content.Length; j++)
                {
                    a += "<p>"+content[j].InnerHtml+"</p>";
                }
                contents.Add(a);

    }
    var model = new HomeViewModel { headers = headers, contents = contents };
            return View(model);
}

public IActionResult Privacy()
{
    return View();
}

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public IActionResult Error()
{
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
    }
}
