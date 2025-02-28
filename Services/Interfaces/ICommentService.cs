using ProjectMain.Models;

namespace ProjectMain.Services.Interfaces;

public interface ICommentService {
    Task<IEnumerable<Comment>> GetCommentsByTemplateIdAsync(Guid formId);
    Task<bool> AddCommentAsync(Comment comment);
    Task<bool> UpdateCommentAsync(Guid commentId, string newText);
    Task<bool> DeleteCommentAsync(Guid commentId);
}