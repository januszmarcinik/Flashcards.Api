using Flashcards.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Api
{
    public class HostingInfo : IHostingInfo
    {
        private readonly IWebHostEnvironment _environment;

        public HostingInfo(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string WebRootPath => _environment.WebRootPath;
    }

    public static class HostingInfoExtensions
    {
        public static IServiceCollection AddHostingInfo(this IServiceCollection services) =>
            services.AddScoped<IHostingInfo, HostingInfo>();
    }
}