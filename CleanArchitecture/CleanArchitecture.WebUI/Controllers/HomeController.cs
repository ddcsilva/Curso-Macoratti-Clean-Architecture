using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}