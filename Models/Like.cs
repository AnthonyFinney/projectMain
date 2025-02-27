namespace ProjectMain.Models;

public class Like {
    public Guid Id { get; set; }
    public Guid FormId { get; set; }
    public Guid UserId { get; set; }
    public bool IsLike { get; set; }

    public Form? Form { get; set; }
    public User? User { get; set; }
}