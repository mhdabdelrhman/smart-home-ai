using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace SmartHome.Blazor.Plugins;

public class TimePlugin
{
    [KernelFunction("GetCurrentTime")]
    [Description("Get current date and time.")]
    public string GetCurrentTime()
    {
        return DateTime.Now.ToString("f");
    }
}
