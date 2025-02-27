namespace ProjectMain.Models;

public class Form {
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreateAt { get; set; }

    public Template? Template { get; set; }
    public User? User { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Like> Likes { get; set; } = new List<Like>();
    public ICollection<FormQuestion> FormQuestions { get; set; } = new List<FormQuestion>();
}