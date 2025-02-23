using ProjectMain.Models;

namespace ProjectMain.Services.Interfaces;

public interface ICommentService {
    Task<IEnumerable<Comment>> GetCommentsByTemplateIdAsync(Guid templateId);
    Task<Guid> AddCommentAsync(Comment comment);
    Task<bool> UpdateCommentAsync(Guid commentId, string newText);
    Task<bool> DeleteCommentAsync(Guid commentId);
}