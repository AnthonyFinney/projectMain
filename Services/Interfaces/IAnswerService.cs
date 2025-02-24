using ProjectMain.Models;

namespace ProjectMain.Services.Interfaces;

public interface IAnswerService {
    Task<Answer?> GetAnswerByIdAsync(Guid id);
    Task<IEnumerable<Answer>> GetAnswersByFormIdAsync(Guid formId);
    Task<bool> AddAnswerAsync(Answer answer);
    Task<bool> UpdateAnswerAsync(Guid id, Answer answer);
    Task<bool> DeleteAnswerAsync(Guid id);
}