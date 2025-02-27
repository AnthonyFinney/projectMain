using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class LikeService : ILikeService {
    private readonly IRepository<Like> repository;

    public LikeService(IRepository<Like> repository) {
        this.repository = repository;
    }

    public Task<int> GetLikesCountAsync(Guid templateId) {
        throw new NotImplementedException();
    }

    public Task<bool> HasUserLikedTemplateAsync(Guid userId, Guid templateId) {
        throw new NotImplementedException();
    }

    public Task<bool> LikeTemplateAsync(Guid userId, Guid templateId) {
        throw new NotImplementedException();
    }

    public Task<bool> UnlikeTemplateAsync(Guid userId, Guid templateId) {
        throw new NotImplementedException();
    }
}