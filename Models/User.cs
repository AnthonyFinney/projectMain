using System.ComponentModel.DataAnnotations;
using ProjectMain.Enums;

namespace ProjectMain.Models;

public class User {
    public Guid Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? PasswordHash { get; set; }
    public string Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public UserStatus Status { get; set; } = UserStatus.Active;

    public ICollection<Template> Templates { get; set; } = new List<Template>();
    public ICollection<Form> Forms { get; set; } = new List<Form>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<UserTemplateAccess> UserTemplateAccesses { get; set; } = new List<UserTemplateAccess>();
}
