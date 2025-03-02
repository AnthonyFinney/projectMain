using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectMain.Services.Interfaces;
using ProjectMain.ViewModels;

namespace ProjectMain.Controllers;

public class FormController : Controller {
    private readonly IFormService formService;
    private readonly ITemplateService templateService;

    public FormController(IFormService formService, ITemplateService templateService) {
        this.formService = formService;
        this.templateService = templateService;
    }

    [Route("Form/Index")]
    public IActionResult Index() {
        return View();
    }

    [HttpPost("Form/CreateForm")]
    public async Task<IActionResult> CreateForm() {
        System.Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(Request.Form));
        return RedirectToAction("Index", "Form");
    }

    [Route("Form/Create/{id}")]
    public async Task<IActionResult> Create(Guid id) {
        var template = await templateService.GetTemplateByIdAsync(id);
        var templateVM = new TemplateViewModel {
            Id = template.Id,
            Description = template.Description,
            Title = template.Title,
            Topic = template.Topic,
            QuestionTypes = template.Questions.Select(q => q.QuestionType.ToString()).ToList()
        };

        System.Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(templateVM));

        return View(templateVM);
    }
}