namespace ProjectMain.Models;

public class UserTemplateAccess {
    public Guid TemplateId { get; set; }
    public Guid UserId { get; set; }

    public Template? Template { get; set; }
    public User? User { get; set; }
}