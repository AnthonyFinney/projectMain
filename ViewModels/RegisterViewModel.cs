using System.ComponentModel.DataAnnotations;

namespace ProjectMain.ViewModels;

public class RegisterViewModel {
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+={}\[\]|\\:;\""<>,.?/-]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one number, and one special character.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string? Email { get; set; }
}