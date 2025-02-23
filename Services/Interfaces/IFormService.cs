using ProjectMain.Models;

namespace ProjectMain.Services.Interfaces;

public interface IFormService {
    Task<Form?> GetFormByIdAsync(Guid formId);
    Task<IEnumerable<Form>> GetFormsByTemplateIdAsync(Guid templateId);
    Task<IEnumerable<Form>> GetFormsByUserIdAsync(Guid userId);
    Task<bool> SubmitFormAsync(Form form);
    Task<bool> DeleteFormAsync(Guid formId);
}