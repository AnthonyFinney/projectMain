using System.ComponentModel.DataAnnotations;

namespace ProjectMain.ViewModels;

public class TemplateViewModel {
    [Required(ErrorMessage = "Title required")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Description required")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Topic required")]
    public string? Topic { get; set; }

    [Required(ErrorMessage = "Select Visibility")]
    public bool? IsPublic { get; set; }

    public int? Order { get; set; }
    public List<string> QuestionTypes { get; set; } = [];
}