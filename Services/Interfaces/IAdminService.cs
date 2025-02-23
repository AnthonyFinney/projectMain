using ProjectMain.Models;

namespace ProjectMain.Services.Interfaces;

public interface IAdminService {
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<bool> BanUserAsync(Guid userId);
    Task<bool> UnbanUserAsync(Guid userId);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<IEnumerable<Template>> GetAllTemplatesAsync();
    Task<bool> DeleteTemplateAsync(Guid templateId);
}