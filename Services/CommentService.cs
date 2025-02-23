using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class CommentService : ICommentService {
    private readonly IRepository<Comment> repository;

    public CommentService(IRepository<Comment> repository) {
        this.repository = repository;
    }

    public Task<Guid> AddCommentAsync(Comment comment) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCommentAsync(Guid commentId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Comment>> GetCommentsByTemplateIdAsync(Guid templateId) {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCommentAsync(Guid commentId, string newText) {
        throw new NotImplementedException();
    }
}