using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseSockets()
                .UseUrls("http://localhost:12345")
                .UseEnvironment(EnvironmentName.Development)
                .CaptureStartupErrors(true)
                .SuppressStatusMessages(false)
                .UseShutdownTimeout(TimeSpan.FromSeconds(10d))
                .Build().RunAsync();
        }
    }
}
