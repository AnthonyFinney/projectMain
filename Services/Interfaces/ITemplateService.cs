using ProjectMain.Models;

namespace ProjectMain.Services.Interfaces;

public interface ITemplateService {
    Task<IEnumerable<Template>> GetAllTemplatesAsync();
    Task<Template?> GetTemplateByIdAsync(Guid templateId);
    Task<Guid> CreateTemplateAsync(Template template);
    Task<bool> UpdateTemplateAsync(Guid templateId, Template updatedTemplate);
    Task<bool> DeleteTemplateAsync(Guid templateId);
    Task<IEnumerable<Template>> GetTemplatesByUserIdAsync(Guid userId);
}