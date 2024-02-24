namespace OllamaFrontend.App.Models;

public class ChatEntry
{
    public bool User { get; set; }
    public string Message { get; set; }

    public ChatEntry(bool user, string message)
    {
        User = user;
        Message = message;
    }
}