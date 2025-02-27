using ProjectMain.Enums;

namespace ProjectMain.Models;

public class Question {
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public QuestionType QuestionType { get; set; }
    public int Order { get; set; }

    public Template? Template { get; set; }
}