namespace CarterApp
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            //dotnet run --urls http://localhost:80
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
