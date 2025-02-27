using Microsoft.AspNetCore.Mvc;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Controllers;

public class AdminController : Controller {
    private readonly IAdminService adminService;

    public AdminController(IAdminService adminService) {
        this.adminService = adminService;
    }

    [Route("Admin/Index")]
    public IActionResult Index() {
        return View();
    }

    [Route("Admin/ManageTemplate")]
    public IActionResult ManageTemplate() {
        return View();
    }

    [Route("Admin/ManageUser")]
    public IActionResult ManageUser() {
        return View();
    }

    [HttpGet("Admin/GetAllUsers")]
    public async Task<IActionResult> GetAllUsers() {
        var userList = await adminService.GetAllUsersAsync();
        if (userList == null || !userList.Any()) {
            return NotFound(new { message = "User List Not Found" });
        }

        return Ok(userList);
    }

    [HttpGet("Admin/GetAllTemplates")]
    public async Task<IActionResult> GetAllTemplates() {
        var templateList = await adminService.GetAllTemplatesAsync();
        if (templateList == null || !templateList.Any()) {
            return NotFound(new { message = "Template List Not Found" });
        }

        return Ok(templateList);
    }
}