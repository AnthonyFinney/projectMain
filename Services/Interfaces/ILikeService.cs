namespace ProjectMain.Services.Interfaces;

public interface ILikeService {
    Task<Guid> GetLikesCoundAsync(Guid templateId);
    Task<bool> LikeTemplateAsync(Guid userId, Guid templateId);
    Task<bool> UnlikeTempateAsync(Guid userId, Guid templateId);
    Task<bool> HasUserLikedTemplateAsync(Guid userId, Guid TemplateId);
}