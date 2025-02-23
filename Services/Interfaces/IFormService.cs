using ProjectMain.Models;

namespace ProjectMain.Services.Interfaces;

public interface IFormService {
    Task<IEnumerable<Form>> GetAllFormAsync();
    Task<Form> GetFormByIdAsync(Guid formId);
    Task<Guid> SubmitFormAsync(Form form);
    Task<bool> UpdateFormAsync(Guid formId, Form form);
    Task<bool> DeleteFormAsync(Guid formId);
    Task<IEnumerable<Form>> GetFormByUserIdAsync(Guid userId);
    Task<IEnumerable<Form>> GetFormByTemplateIdAsync(Guid templateId);
}