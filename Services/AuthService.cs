using ProjectMain.Models;
using ProjectMain.Repositories;
using ProjectMain.Services.Interfaces;

namespace ProjectMain.Services;

public class AuthService : IAuthService {
    private readonly IRepository<User> repository;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AuthService(IRepository<User> repository, IHttpContextAccessor httpContextAccessor) {
        this.repository = repository;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> AssignRoleAsync(Guid userId, string role) {
        var user = await repository.GetByIdAsync(userId);

        if (user == null) {
            return false;
        }

        user.Role = role;

        await repository.UpdateAsync(user);
        return true;
    }

    public async Task<User?> GetUserByIdAsync(Guid userId) {
        return await repository.GetByIdAsync(userId);
    }

    public async Task<User?> GetUserByUsernameAsync(string username) {
        return await repository.GetByFieldAsync(user => user.Username == username);
    }

    public async Task<string?> LoginAsync(string username, string password) {
        var user = await repository.GetByFieldAsync(user => user.Username == username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) {
            return "Invalid name or password";
        }

        var session = httpContextAccessor?.HttpContext?.Session;
        session?.SetString("UserId", user.Id.ToString());
        session?.SetString("Username", username);
        session?.SetString("Role", user.Role);

        return user.Username;
    }

    public Task LogoutAsync() {
        httpContextAccessor?.HttpContext?.Session.Clear();
        return Task.CompletedTask;
    }

    public async Task<bool> RegisterAsync(string username, string email, string password) {
        var existingUser = await repository.GetByFieldAsync(user => user.Username == username || user.Email == email);
        if (existingUser != null) {
            return false;
        }

        var user = new User {
            Id = Guid.NewGuid(),
            Username = username,
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Role = "Admin",
            CreatedAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow
        };

        await repository.AddAsync(user);
        return true;
    }

    public async Task<bool> UpdateProfileAsync(Guid userId, string? newUsername, string? password, string? newRole) {
        var user = await repository.GetByIdAsync(userId);
        if (user == null) {
            return false;
        }

        var existingUser = await repository.GetByFieldAsync(u => u.Username == newUsername && u.Id != userId);
        if (existingUser != null) {
            return false;
        }

        if (!string.IsNullOrEmpty(newUsername)) {
            user.Username = newUsername;
        }
        if (!string.IsNullOrEmpty(password)) {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }
        if (!string.IsNullOrEmpty(newRole)) {
            user.Role = newRole;
        }

        await repository.UpdateAsync(user);

        var session = httpContextAccessor?.HttpContext?.Session;
        if (!string.IsNullOrEmpty(user.Username)) {
            session?.SetString("Username", user.Username);
        }
        if (!string.IsNullOrEmpty(user.Role)) {
            session?.SetString("Role", user.Role);
        }

        return true;
    }
}