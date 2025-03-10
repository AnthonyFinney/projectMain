using Microsoft.AspNetCore.Mvc;
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

    [Route("Auth/Logout")]
    public async Task<IActionResult> Logout() {
        bool result = await authService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }

    [Route("Auth/Profile")]
    public IActionResult Profile(string id) {
        return View();
    }

    [HttpPost("Auth/Profile")]
    public async Task<IActionResult> Profile(ProfileViewModel model) {
        var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
        var result = await authService.UpdateProfileAsync(userId, model.Name, model.Password);
        if (result == false) {
            ModelState.AddModelError("", "User already exists");
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("Auth/GetUserById/{id}")]
    public async Task<IActionResult> GetUserById(string id) {
        var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
        var user = await authService.GetUserByIdAsync(userId);
        if (user == null) {
            return NotFound(new { message = "User Not Found" });
        }

        return Ok(user);
    }

    [HttpGet("Auth/GetUserByUsername/{username}")]
    public async Task<IActionResult> GetUserByUsername(string username) {
        var user = await authService.GetUserByUsernameAsync(username);
        if (user == null) {
            return NotFound(new { message = "User Not Found" });
        }

        return Ok(user);
    }
}