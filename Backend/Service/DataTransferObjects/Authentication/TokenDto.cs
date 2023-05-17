namespace QuizApplication.Application.DataTransferObjects.Authentication;

public record TokenDto(
    string name,
    string accessToken,
    DateTime expireDate);