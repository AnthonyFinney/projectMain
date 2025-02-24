using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class CommentService : ICommentService {
    private readonly IRepository<Comment> repository;

    public CommentService(IRepository<Comment> repository) {
        this.repository = repository;
    }

    public async Task<bool> AddCommentAsync(Comment comment) {
        if (comment == null) {
            return false;
        }

        await repository.AddAsync(comment);
        return true;
    }

    public async Task<bool> DeleteCommentAsync(Guid commentId) {
        var comment = await repository.GetByIdAsync(commentId);
        if (comment == null) {
            return false;
        }

        await repository.DeleteAsync(commentId);
        return true;
    }

    public async Task<IEnumerable<Comment>> GetCommentsByTemplateIdAsync(Guid templateId) {
        var comment = await repository.GetManyByFieldAsync(c => c.TemplateId == templateId);

        if (comment == null) {
            return Enumerable.Empty<Comment>();
        }
        return comment;
    }

    public async Task<bool> UpdateCommentAsync(Guid commentId, string newText) {
        var existingComment = await repository.GetByIdAsync(commentId);
        if (existingComment == null) {
            return false;
        }

        existingComment.Text = newText;

        await repository.UpdateAsync(existingComment);
        return true;
    }
}