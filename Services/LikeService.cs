using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class LikeService : ILikeService {
    private readonly IRepository<Like> repository;

    public LikeService(IRepository<Like> repository) {
        this.repository = repository;
    }

    public async Task<int> GetLikesCountAsync(Guid formId) {
        var likes = await repository.GetManyByFieldAsync(l => l.FormId == formId && l.IsLike);
        return likes.Count();
    }

    public async Task<bool> HasUserLikedTemplateAsync(Guid userId, Guid formId) {
        var like = await repository.GetByFieldAsync(l => l.UserId == userId && l.FormId == formId && l.IsLike);
        return like != null;
    }

    public async Task<bool> LikeTemplateAsync(Guid userId, Guid formId) {
        var existingLike = await repository.GetByFieldAsync(l => l.UserId == userId && l.FormId == formId);
        if (existingLike != null) {
            return false;
        }

        var like = new Like {
            Id = Guid.NewGuid(),
            UserId = userId,
            FormId = formId,
            IsLike = true
        };

        await repository.AddAsync(like);
        return true;
    }

    public async Task<bool> UnlikeTemplateAsync(Guid userId, Guid formId) {
        var like = await repository.GetByFieldAsync(l => l.UserId == userId && l.FormId == formId && l.IsLike);
        if (like == null) {
            return false;
        }

        await repository.DeleteAsync(like.Id);
        return true;
    }
}