using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class LikeService : ILikeService {
    private readonly IRepository<Like> repository;

    public LikeService(IRepository<Like> repository) {
        this.repository = repository;
    }

    public async Task<int> GetLikesCountAsync(Guid templateId) {
        var likes = await repository.GetManyByFieldAsync(l => l.TemplateId == templateId && l.IsLike);
        return likes.Count();
    }

    public async Task<bool> HasUserLikedTemplateAsync(Guid userId, Guid templateId) {
        var like = await repository.GetByFieldAsync(l => l.UserId == userId && l.TemplateId == templateId && l.IsLike);
        return like != null;
    }

    public async Task<bool> LikeTemplateAsync(Guid userId, Guid templateId) {
        var existingLike = await repository.GetByFieldAsync(l => l.UserId == userId && l.TemplateId == templateId);
        if (existingLike != null) {
            return false;
        }

        var like = new Like {
            Id = Guid.NewGuid(),
            UserId = userId,
            TemplateId = templateId,
            IsLike = true
        };

        await repository.AddAsync(like);
        return true;
    }

    public async Task<bool> UnlikeTemplateAsync(Guid userId, Guid templateId) {
        var like = await repository.GetByFieldAsync(l => l.UserId == userId && l.TemplateId == templateId && l.IsLike);
        if (like == null) {
            return false;
        }

        await repository.DeleteAsync(like.Id);
        return true;
    }
}