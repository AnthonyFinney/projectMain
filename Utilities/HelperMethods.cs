using Microsoft.AspNetCore.Http;
using ProjectMain.Enums;

namespace ProjectMain.Utilities;

public static class HelperMethods {
    public static QuestionType MapQuestionType(string qt) {
        if (string.IsNullOrEmpty(qt)) {
            throw new ArgumentNullException(nameof(qt), "Question type cannot be null or empty.");
        }

        return qt switch {
            "Short Answer Question" => QuestionType.ShortAnswer,
            "Paragraph Question" => QuestionType.Paragraph,
            "Multiple Choice Question" => QuestionType.MultipleChoice,
            "Checkbox Question" => QuestionType.Checkbox,
            "Dropdown Question" => QuestionType.Dropdown,
            _ => throw new ArgumentException("Error")
        };
    }
}