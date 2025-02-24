using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectMain.Services.Interfaces;
using ProjectMain.ViewModels;

namespace ProjectMain.Controllers;

public class AuthController : Controller {
    private readonly IAuthService authService;

    public AuthController(IAuthService authService) {
        this.authService = authService;
    }

    [Route("Auth/Login")]
    public IActionResult Login() {
        return View();
    }

    [HttpPost("Auth/Login")]
    public async Task<IActionResult> Login(LoginViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);
        }

        var result = await authService.LoginAsync(model.Name, model.Password);
        if (result == false) {
            ModelState.AddModelError("Name", "Invalid username");
            ModelState.AddModelError("Password", "Invalid password");
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    [Route("Auth/Register")]
    public IActionResult Register() {
        return View();
    }

    [HttpPost("Auth/Register")]
    public async Task<IActionResult> Register(RegisterViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);
        }

        var result = await authService.RegisterAsync(model.Name, model.Email, model.Password);
        if (result == false) {
            ModelState.AddModelError("", "User already exists");
            return View(model);
        }

        return RedirectToAction("Login", "Auth");
    }

    [Route("Auth/Profile/{id}")]
    public IActionResult Profile(string id) {
        return View();
    }
}