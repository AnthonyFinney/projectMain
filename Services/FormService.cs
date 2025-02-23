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

    public Task<IEnumerable<Form>> GetAllFormAsync() {
        throw new NotImplementedException();
    }

    public Task<Form> GetFormByIdAsync(Guid formId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Form>> GetFormByTemplateIdAsync(Guid templateId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Form>> GetFormByUserIdAsync(Guid userId) {
        throw new NotImplementedException();
    }

    public Task<Guid> SubmitFormAsync(Form form) {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateFormAsync(Guid formId, Form form) {
        throw new NotImplementedException();
    }
}