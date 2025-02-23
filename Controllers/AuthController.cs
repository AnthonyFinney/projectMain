using Microsoft.AspNetCore.Mvc;
using ProjectMain.ViewModels;

namespace ProjectMain.Controllers;

public class AuthController : Controller {
    [Route("Auth/Login")]
    public IActionResult Login() {
        return View();
    }

    [HttpPost("Auth/Login")]
    public IActionResult Login(LoginViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    [Route("Auth/Register")]
    public IActionResult Register() {
        return View();
    }

    [HttpPost("Auth/Register")]
    public IActionResult Register(RegisterViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);
        }



        return RedirectToAction("Login", "Auth");
    }

    [Route("Auth/Profile")]
    public IActionResult Profile() {
        return View();
    }
}