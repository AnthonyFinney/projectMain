namespace ProjectMain.Models;

public class Answer {
    public Guid Id { get; set; }
    public Guid FormId { get; set; }
    public Guid QuestionId { get; set; }
    public string? Value { get; set; }

    public Form? Form { get; set; }
    public FormQuestion? FormQuestion { get; set; }
}
