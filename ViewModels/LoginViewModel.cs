using System.ComponentModel.DataAnnotations;

namespace ProjectMain.ViewModels;

public class LoginViewModel {
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}