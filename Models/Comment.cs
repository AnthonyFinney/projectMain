namespace ProjectMain.Models;

public class Comment {
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public Guid UserId { get; set; }
    public string? Text { get; set; }
    public DateTime CreateAt { get; set; }

    public Template? Template { get; set; }
    public User? User { get; set; }
}