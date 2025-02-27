using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class AnswerService : IAnswerService {
    private readonly IRepository<Answer> repository;

    public AnswerService(IRepository<Answer> repository) {
        this.repository = repository;
    }

    public Task<bool> AddAnswerAsync(Answer answer) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAnswerAsync(Guid id) {
        throw new NotImplementedException();
    }

    public Task<Answer?> GetAnswerByIdAsync(Guid id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Answer>> GetAnswersByFormIdAsync(Guid formId) {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAnswerAsync(Guid id, Answer answer) {
        throw new NotImplementedException();
    }
}