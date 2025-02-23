namespace ProjectMain.Services.Interfaces;

public interface ILikeService {
    Task<int> GetLikesCountAsync(Guid templateId);
    Task<bool> LikeTemplateAsync(Guid userId, Guid templateId);
    Task<bool> UnlikeTemplateAsync(Guid userId, Guid templateId);
    Task<bool> HasUserLikedTemplateAsync(Guid userId, Guid templateId);
}