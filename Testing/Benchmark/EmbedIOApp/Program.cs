using EmbedIO;
using EmbedIO.WebApi;
using EmbedIO.Actions;
using EmbedIO.WebSockets;
using System;
using System.Threading.Tasks;

namespace EmbedIOApp
{
    public class Program
    {
        private static readonly ManualResetEvent _WaitEvent = new ManualResetEvent(false);

        public static async Task<int> Main(string[] args)
        {
            string url = "http://localhost:80";

            if (args.Length > 0)
                url = args[0];

            var server = CreateWebServer(url);

            try
            {
                AppDomain.CurrentDomain.ProcessExit += (_, __) =>
                {
                    _WaitEvent.Set();
                };

                //dotnet run http://localhost:80
                await server.RunAsync();

                _WaitEvent.WaitOne();

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return -1;
            }
        }

        private static WebServer CreateWebServer(string url)
        {
            var server = new WebServer(o => o
                .WithUrlPrefix(url)
                .WithMode(HttpListenerMode.EmbedIO))
                .WithLocalSessionManager()
                .WithWebApi("/api", m => m.WithController<Controller>())
                .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Hello from EmbedIO!" })))
                .PreferNoCompressionFor("text/*");
            return server;
        }
    }
}
