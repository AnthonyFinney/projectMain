using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectMain.Models;
using ProjectMain.Services.Interfaces;
using ProjectMain.Utilities;
using ProjectMain.ViewModels;

namespace ProjectMain.Controllers;

public class TemplateController : Controller {
    private readonly ITemplateService templateService;

    public TemplateController(ITemplateService templateService) {
        this.templateService = templateService;
    }

    [Route("Template/Index")]
    public async Task<IActionResult> Index() {
        var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
        var templates = await templateService.GetTemplatesByUserIdAsync(userId);

        var templateVM = new List<TemplateViewModel>();

        foreach (var template in templates) {
            if (template.IsPublic) {
                templateVM.Add(new TemplateViewModel {
                    Id = template.Id,
                    Title = template.Title,
                    Description = template.Description,
                    IsPublic = template.IsPublic,
                    Topic = template.Topic,
                    QuestionTypes = template.Questions.Select(q => q.QuestionType.ToString()).ToList()
                });
            }
        }

        return View(templateVM);
    }

    [Route("Template/Create")]
    public IActionResult Create() {
        return View();
    }

    [HttpPost("Template/Create")]
    public async Task<IActionResult> Create(TemplateViewModel model) {
        if (!ModelState.IsValid) {
            return View(model);
        }

        System.Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(model));

        var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
        var templateId = Guid.NewGuid();
        var questions = model.QuestionTypes.Select((qt, index) => new Question {
            Id = Guid.NewGuid(),
            TemplateId = templateId,
            QuestionType = HelperMethods.MapQuestionType(qt),
            Order = index + 1
        }).ToList();
        var template = new Template {
            Id = templateId,
            Title = model.Title,
            Description = model.Description,
            Topic = model.Topic,
            IsPublic = model.IsPublic,
            UpdateAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            UserId = userId,
            Questions = questions
        };

        System.Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(template));

        await templateService.CreateTemplateAsync(template);

        return RedirectToAction("Index", "Template");
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