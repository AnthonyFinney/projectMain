namespace ProjectMain.Models;

public class Like {
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public Guid UserId { get; set; }
    public bool IsLike { get; set; }

    public Template? Template { get; set; }
    public User? User { get; set; }
}