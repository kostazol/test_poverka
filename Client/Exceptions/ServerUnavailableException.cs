namespace PoverkaWinForms.Exceptions;

public class ServerUnavailableException : Exception
{
    public ServerUnavailableException(string? message = null, Exception? inner = null)
        : base(message ?? "Сервер недоступен, попробуйте позже или сообщите администратору", inner)
    {
    }
}
