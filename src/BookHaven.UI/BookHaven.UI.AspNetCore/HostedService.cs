using BookHaven.Core.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace BookHaven.UI.AspNetCore
{
    public class HostedService : IHostedService
    {
        IApplicationBuilder Builder { get; }
        IWebHostEnvironment Environment { get; }


        public HostedService(IApplicationBuilder builder, IWebHostEnvironment environment)
        {
            Builder = builder;
            Environment = environment;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Builder.UseCoreMigrations();
            if (Environment.IsDevelopment())
            {
                Builder.UseCoreSeeding();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
