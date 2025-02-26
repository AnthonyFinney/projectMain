using ProjectMain.Models;

namespace ProjectMain.Services.Interfaces;

public interface IAuthService {
    Task<bool> RegisterAsync(string username, string email, string password);
    Task<bool> LoginAsync(string username, string password);
    Task<bool> LogoutAsync();
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<bool> UpdateProfileAsync(Guid userId, string? newUsername, string? password, string? newRole);
}