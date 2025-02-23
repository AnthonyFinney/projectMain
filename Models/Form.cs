namespace ProjectMain.Models;

public class Form {
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreateAt { get; set; }

    public Template? Template { get; set; }
    public User? User { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}