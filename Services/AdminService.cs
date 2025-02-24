using ProjectMain.Enums;
using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class AdminService : IAdminService {
    private readonly IRepository<User> userRepository;
    private readonly IRepository<Template> templateRepository;

    public AdminService(IRepository<User> userRepository, IRepository<Template> templateRepository) {
        this.userRepository = userRepository;
        this.templateRepository = templateRepository;
    }

    public async Task<bool> BanUserAsync(Guid userId) {
        var user = await userRepository.GetByIdAsync(userId);
        if (user == null) {
            return false;
        }

        user.Status = UserStatus.Banned;
        await userRepository.UpdateAsync(user);
        return true;
    }

    public async Task<bool> DeleteTemplateAsync(Guid templateId) {
        var template = await templateRepository.GetByIdAsync(templateId);
        if (template == null) {
            return false;
        }

        await templateRepository.DeleteAsync(template.Id);
        return true;
    }

    public async Task<bool> DeleteUserAsync(Guid userId) {
        var user = await userRepository.GetByIdAsync(userId);
        if (user == null) {
            return false;
        }

        await userRepository.DeleteAsync(user.Id);
        return true;
    }

    public async Task<bool> UnbanUserAsync(Guid userId) {
        var user = await userRepository.GetByIdAsync(userId);
        if (user == null) {
            return false;
        }

        user.Status = UserStatus.Active;
        await userRepository.UpdateAsync(user);
        return true;
    }

    public async Task<IEnumerable<Template>> GetAllTemplatesAsync() {
        return await templateRepository.GetAllAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync() {
        return await userRepository.GetAllAsync();
    }

    public async Task<bool> AssignRoleAsync(Guid userId, string role) {
        var user = await userRepository.GetByIdAsync(userId);

        if (user == null) {
            return false;
        }

        user.Role = role;

        await userRepository.UpdateAsync(user);
        return true;
    }
}