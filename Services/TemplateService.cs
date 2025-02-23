using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class TemplateService : ITemplateService {
    private readonly IRepository<Template> repository;

    public TemplateService(IRepository<Template> repository) {
        this.repository = repository;
    }

    public Task<Guid> CreateTemplateAsync(Template template) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTemplateAsync(Guid templateId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Template>> GetAllTemplatesAsync() {
        throw new NotImplementedException();
    }

    public Task<Template?> GetTemplateByIdAsync(Guid templateId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Template>> GetTemplatesByUserIdAsync(Guid userId) {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateTemplateAsync(Guid templateId, Template updatedTemplate) {
        throw new NotImplementedException();
    }
}