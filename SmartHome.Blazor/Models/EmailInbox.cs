namespace SmartHome.Blazor.Models;

public class EmailInbox
{
    public ICollection<string> Emails { get; } = new List<string>();

    public string? GetLastEmailOrNull()
    {
        return Emails?.LastOrDefault();
    }

    public void AddEmail(string subject, string body)
    {
        var email = $"<b>{subject}</b><br/>{body}";
        Emails.Add(email);
    }
}
