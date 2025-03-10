using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class TemplateService : ITemplateService {
    private readonly IRepository<Template> repository;

    public TemplateService(IRepository<Template> repository) {
        this.repository = repository;
    }

    public async Task<bool> CreateTemplateAsync(Template template) {
        if (template == null) {
            return false;
        }

        await repository.AddAsync(template);
        return true;
    }

    public async Task<bool> DeleteTemplateAsync(Guid templateId) {
        var template = await repository.GetByIdAsync(templateId);
        if (template == null) {
            return false;
        }

        await repository.DeleteAsync(templateId);
        return true;
    }

    public async Task<IEnumerable<Template>> GetAllTemplatesAsync() {
        return await repository.GetAllAsync();
    }

    public async Task<Template?> GetTemplateByIdAsync(Guid templateId) {
        var template = await repository.GetByFieldAsync(t => t.Id == templateId, t => t.Questions);
        foreach (var question in template.Questions) {
            question.Template = null;
        }

        return template;
    }

    public async Task<IEnumerable<Template>> GetTemplatesByUserIdAsync(Guid userId) {
        var templates = await repository.GetManyByFieldAsync(t => t.UserId == userId, t => t.Questions);

        foreach (var template in templates) {
            foreach (var question in template.Questions) {
                question.Template = null;
            }
        }

        if (templates == null) {
            return Enumerable.Empty<Template>();
        }
        return templates;
    }

    public async Task<bool> UpdateTemplateAsync(Guid templateId, Template updatedTemplate) {
        var existingTemplete = await repository.GetByIdAsync(templateId);
        if (existingTemplete == null) {
            return false;
        }

        existingTemplete.Title = updatedTemplate.Title;

        await repository.UpdateAsync(existingTemplete);
        return true;
    }
}