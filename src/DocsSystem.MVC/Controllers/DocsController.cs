using DocsSystem.MVC.Models;
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
    [Route("gethtml/{pageName}")]
    public string GetHtmlData(string pageName, string lang = "")
    {
        if (!string.IsNullOrEmpty(lang))
        {
            pageName = $"{lang}/{pageName}";
        }
        var markdownPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dist/html", pageName + ".html");
        var markdownContent = System.IO.File.ReadAllText(markdownPath);
        return markdownContent;
    }
    [HttpPost("savehtml")]
    public IActionResult SaveHtml([FromBody] SavehtmlModel model)
    {
        try
        {
            if (model == null || string.IsNullOrWhiteSpace(model.FileName) || string.IsNullOrWhiteSpace(model.Content))
            {
                return BadRequest("Invalid input data.");
            }

            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dist/html");

            var fp = model.FileName.Split('?');
            var filename = fp[0];
            if (fp.Length > 1)
            {
                savePath = $"{savePath}/{model.Language}";
            }
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            var filePath = Path.Combine(savePath, filename + ".html");

            System.IO.File.WriteAllText(filePath, model.Content, System.Text.Encoding.UTF8);

            return Ok(new { message = "File saved successfully", filePath });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [Route("docs/{pageName}")]
    public IActionResult showMd(string pageName, string plugin = "prism")
    {
        ViewBag.PageName = pageName;
        ViewBag.Lang = "";
        if (plugin == "shiki")
            return View("showmdShiki");
        return View();
    }

    [Route("docs/{lang}/{pageName}")]
    public IActionResult showMd(string lang, string pageName = "", string plugin = "prism")
    {
        if (string.IsNullOrEmpty(pageName) && !string.IsNullOrEmpty(lang))
        {
            pageName = lang;
            lang = "";
        }
        ViewBag.PageName = pageName;
        ViewBag.Lang = lang;
        if (plugin == "shiki")
            return View("showmdShiki");

        return View();
    }

    [Route("html/{pageName}")]
    public IActionResult showHtml(string pageName = "")
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\dist\\html", pageName + ".html");
        var htmlContent = System.IO.File.ReadAllText(filePath);

        ViewBag.PageName = pageName;
        ViewBag.Lang = "en";
        ViewBag.HtmlContent = htmlContent;
        return View();
    }

    [Route("html/{lang}/{pageName}")]
    public IActionResult showHtml(string lang, string pageName = "")
    {
        if (string.IsNullOrEmpty(pageName) && !string.IsNullOrEmpty(lang))
        {
            pageName = lang;
            lang = "";
        }
        if (!string.IsNullOrEmpty(lang))
        {
            pageName = $"{lang}/{pageName}";
        }
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\dist\\html", pageName + ".html");
        var htmlContent = System.IO.File.ReadAllText(filePath);

        ViewBag.PageName = pageName;
        ViewBag.Lang = lang;
        ViewBag.HtmlContent = htmlContent;
        return View();
    }
}

