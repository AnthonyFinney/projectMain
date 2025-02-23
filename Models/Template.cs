namespace ProjectMain.Models;

public class Template {
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Topic { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsPublic { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public User? User { get; set; }
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<Form> Forms { get; set; } = new List<Form>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<UserTemplateAccess> UserTemplateAccesses { get; set; } = new List<UserTemplateAccess>();
}