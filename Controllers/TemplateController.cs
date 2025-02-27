using Microsoft.AspNetCore.Mvc;
using ProjectMain.ViewModels;

namespace ProjectMain.Controllers;

public class TemplateController : Controller {
    [Route("Template/Index")]
    public IActionResult Index() {
        var templates = new List<TemplateViewModel> {
            new() {
                Title = "Sample Title",
                Description = "Sample Description",
                Topic = "Sample Topic",
                IsPublic = true,
                QuestionTypes = new List<string> { "Multiple Choice", "Short Answer" }
            },
            new() {
                Title = "Another Template",
                Description = "Another Description",
                Topic = "Another Topic",
                IsPublic = false,
                QuestionTypes = new List<string> { "Essay", "True/False" }
            }
        };

        return View(templates);
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