namespace ProjectMain.Services.Interfaces;

public interface ILikeService {
    Task<int> GetLikesCountAsync(Guid formId);
    Task<bool> LikeTemplateAsync(Guid userId, Guid formId);
    Task<bool> UnlikeTemplateAsync(Guid userId, Guid formId);
    Task<bool> HasUserLikedTemplateAsync(Guid userId, Guid formId);
}