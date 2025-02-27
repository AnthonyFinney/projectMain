using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class AnswerService : IAnswerService {
    private readonly IRepository<Answer> repository;

    public AnswerService(IRepository<Answer> repository) {
        this.repository = repository;
    }

    public async Task<bool> AddAnswerAsync(Answer answer) {
        if (answer == null) {
            return false;
        }

        await repository.AddAsync(answer);
        return true;
    }

    public async Task<bool> DeleteAnswerAsync(Guid id) {
        var answer = await repository.GetByIdAsync(id);
        if (answer == null) {
            return false;
        }

        await repository.DeleteAsync(id);
        return true;
    }

    public async Task<Answer?> GetAnswerByIdAsync(Guid id) {
        return await repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Answer>> GetAnswersByFormIdAsync(Guid formId) {
        var answers = await repository.GetManyByFieldAsync(a => a.FormId == formId);
        if (answers == null) {
            return Enumerable.Empty<Answer>();
        }

        return answers;
    }

    public async Task<bool> UpdateAnswerAsync(Guid id, Answer answer) {
        var existingAnswer = await repository.GetByIdAsync(id);
        if (existingAnswer == null) {
            return false;
        }

        existingAnswer = answer;

        await repository.UpdateAsync(existingAnswer);
        return true;
    }
}