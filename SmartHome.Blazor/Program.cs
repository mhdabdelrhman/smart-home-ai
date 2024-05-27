using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartHome.Blazor;
using SmartHome.Blazor.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var configuration = builder.Configuration;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSemanticKernel(configuration);

await builder.Build().RunAsync();
