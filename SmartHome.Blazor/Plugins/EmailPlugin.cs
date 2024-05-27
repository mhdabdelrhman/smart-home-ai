using Microsoft.SemanticKernel;
using SmartHome.Blazor.Models;
using System.ComponentModel;

namespace SmartHome.Blazor.Plugins;

public class EmailPlugin
{
    private readonly EmailInbox _inbox;

    public EmailPlugin(EmailInbox inbox)
    {
        _inbox = inbox;
    }

    [KernelFunction("SendEmail")]
    [Description("Send an email with subject and body reporting the devices.")]
    public string SendEmail(string subject, string body)
    {
        _inbox.AddEmail(subject, body);

        return _inbox.GetLastEmailOrNull() ?? "";
    }
}
