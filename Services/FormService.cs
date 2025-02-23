using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class FormService : IFormService {
    private readonly IRepository<Form> repository;

    public FormService(IRepository<Form> repository) {
        this.repository = repository;
    }

    public async Task<bool> DeleteFormAsync(Guid formId) {
        var form = await repository.GetByIdAsync(formId);
        if (form == null) {
            return false;
        }

        await repository.DeleteAsync(formId);
        return true;
    }

    public async Task<Form?> GetFormByIdAsync(Guid formId) {
        return await repository.GetByIdAsync(formId);
    }

    public async Task<IEnumerable<Form>> GetFormsByTemplateIdAsync(Guid templateId) {
        return await repository.GetManyByFieldAsync(f => f.TemplateId == templateId);
    }

    public async Task<IEnumerable<Form>> GetFormsByUserIdAsync(Guid userId) {
        return await repository.GetManyByFieldAsync(f => f.UserId == userId);
    }

    public async Task<bool> SubmitFormAsync(Form form) {
        if (form == null) {
            return false;
        }

        await repository.AddAsync(form);
        return true;
    }
}