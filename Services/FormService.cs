using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class FormService : IFormService {
    private readonly IRepository<Form> repository;

    public FormService(IRepository<Form> repository) {
        this.repository = repository;
    }

    public Task<bool> DeleteFormAsync(Guid formId) {
        throw new NotImplementedException();
    }

    public Task<Form?> GetFormByIdAsync(Guid formId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Form>> GetFormsByTemplateIdAsync(Guid templateId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Form>> GetFormsByUserIdAsync(Guid userId) {
        throw new NotImplementedException();
    }

    public Task<bool> SubmitFormAsync(Form form) {
        throw new NotImplementedException();
    }
}