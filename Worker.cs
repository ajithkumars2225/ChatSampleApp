using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using ChatApp.Grpc;

namespace ChatServer
{
    public class Worker : BackgroundService
    {
        private readonly IHost _webHost;

        public Worker()
        {
            _webHost = new HostBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel()
                              .UseUrls("http://localhost:5000")
                              .ConfigureServices(services => services.AddGrpc())
                              .Configure(app =>
                              {
                                  app.UseRouting();
                                  app.UseEndpoints(endpoints =>
                                  {
                                      endpoints.MapGrpcService<ChatServiceImpl>();
                                  });
                              });
                }).Build();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return _webHost.RunAsync(stoppingToken);
        }
    }
}
