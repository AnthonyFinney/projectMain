using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectMain.ViewModels;

namespace ProjectMain.Controllers;

public class HomeController : Controller {
    [Route("")]
    [Route("Home")]
    [Route("Home/Index")]
    public IActionResult Index() {
        return View();
    }

    [Route("Home/Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
