using Microsoft.SemanticKernel;
using SmartHome.Blazor.Models;
using SmartHome.Blazor.Plugins;

namespace SmartHome.Blazor.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSemanticKernel(this IServiceCollection services, IConfiguration configuration)
        {
            var model = configuration["model"];
            var apiKey = configuration["apiKey"];

            EmailInbox emailInbox = new();
            HomeDevices homeDevices = new();

            services.AddSingleton(emailInbox);
            services.AddSingleton(homeDevices);

            var kernelBuilder = Kernel.CreateBuilder();
            kernelBuilder.Plugins.AddFromType<TimePlugin>();
            kernelBuilder.Plugins.AddFromObject(new EmailPlugin(emailInbox));
            kernelBuilder.Plugins.AddFromObject(new HomePlugin(homeDevices));

            kernelBuilder.Services.AddLogging(c => c.SetMinimumLevel(LogLevel.Information));
            kernelBuilder.Services.AddOpenAIChatCompletion(modelId: model!, apiKey: apiKey!, orgId: "", serviceId: model);

            Kernel kernel = kernelBuilder.Build();
            services.AddSingleton(kernel);

            return services;
        }
    }
}
