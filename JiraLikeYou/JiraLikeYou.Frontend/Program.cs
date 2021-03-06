using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace JiraLikeYou.Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(opt => { opt.ListenAnyIP(52001); });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
