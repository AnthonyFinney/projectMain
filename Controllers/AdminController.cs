using Microsoft.AspNetCore.Mvc;

namespace ProjectMain.Controllers;

public class AdminController : Controller {
    [Route("Admin/Index")]
    public IActionResult Index() {
        return View();
    }

    [Route("Admin/ManageTemplates")]
    public IActionResult ManageTemplates() {
        return View();
    }

    [Route("Admin/ManageUsers")]
    public IActionResult ManageUsers() {
        return View();
    }
}