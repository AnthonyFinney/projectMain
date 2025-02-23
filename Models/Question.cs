namespace ProjectMain.Models;

public class Question {
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? QuestionType { get; set; }
    public int Order { get; set; }

    public Template? Template { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}