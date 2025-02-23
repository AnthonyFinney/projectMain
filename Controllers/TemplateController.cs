using Microsoft.AspNetCore.Mvc;
using ProjectMain.ViewModels;

namespace ProjectMain.Controllers;

public class TemplateController : Controller {
    [Route("Template/Index")]
    public IActionResult Index() {
        return View();
    }

    [Route("Template/Details/{id:guid}")]
    public IActionResult Details(Guid id) {
        return View();
    }

    [Route("Template/Create")]
    public IActionResult Create() {
        return View();
    }

    [HttpPost("Template/Create")]
    public IActionResult Create(TemplateViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    [Route("Template/Edit/{id:guid}")]
    public IActionResult Edit(Guid id) {
        return View();
    }

    [HttpDelete("Template/Delete/{id:guid}")]
    public IActionResult Delete(Guid id) {
        return RedirectToAction("Index", "Template");
    }

}