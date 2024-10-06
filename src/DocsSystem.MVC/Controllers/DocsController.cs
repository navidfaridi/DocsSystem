using Microsoft.AspNetCore.Mvc;

namespace DocsSystem.MVC.Controllers;

public class DocsController : Controller
{

    [Route("md/{pageName}")]
    public string GetData(string pageName, string lang = "")
    {
        if (!string.IsNullOrEmpty(lang))
        {
            pageName = $"{lang}/{pageName}";
        }
        var markdownPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/docs", pageName + ".md");
        var markdownContent = System.IO.File.ReadAllText(markdownPath);
        return markdownContent;
    }

    [Route("docs/{pageName}")]
    public IActionResult Index(string pageName)
    {

        ViewBag.PageName = pageName;
        ViewBag.Lang = "";
        return View();
    }

    [Route("docs/{lang}/{pageName}")]
    public IActionResult Index(string lang, string pageName = "")
    {
        if (string.IsNullOrEmpty(pageName) && !string.IsNullOrEmpty(lang))
        {
            pageName = lang;
            lang = "";
        }
        ViewBag.PageName = pageName;
        ViewBag.Lang = lang;
        return View();
    }
}

