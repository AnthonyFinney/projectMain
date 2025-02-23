using Microsoft.AspNetCore.Mvc;

namespace ProjectMain.Controllers;

public class FormController : Controller {
    [Route("Form/Index")]
    public IActionResult Index() {
        return View();
    }
}