namespace QuizApplication.Application.DataTransferObjects.Authentication;

public record AuthenticationDto(
     string email ,
     string password);