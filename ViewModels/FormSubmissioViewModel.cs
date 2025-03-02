using ProjectMain.Enums;

namespace ProjectMain.ViewModels;

public class FormSubmissionViewModel {
    public string FormTitle { get; set; }
    public string FormDescription { get; set; }
    public string FormTopic { get; set; }
    public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();

    public class QuestionViewModel {
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }
}
