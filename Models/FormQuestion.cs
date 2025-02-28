using ProjectMain.Enums;

namespace ProjectMain.Models;

public class FormQuestion {
    public Guid Id { get; set; }
    public Guid FormId { get; set; }
    public Guid QuestionId { get; set; }
    public QuestionType QuestionType { get; set; }
    public List<string>? Options { get; set; }
    public string? Title { get; set; }

    public Form? Form { get; set; }
    public Question? Question { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}