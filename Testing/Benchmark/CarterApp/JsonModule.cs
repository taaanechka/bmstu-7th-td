using Carter;
using System.Threading.Tasks;
using Utf8Json;

namespace CarterApp
{
    public class JsonModule : ICarterModule
    {
        private const int _bufferSize = 27;

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //GET http://localhost:80/json
            app.MapGet("/json", (HttpResponse res) =>
            {
                res.StatusCode = 200;
                res.ContentType = "application/json";
                res.ContentLength = _bufferSize;

                var msg = new JsonMessage { message = "Hello, World!" };

                return JsonSerializer.SerializeAsync(res.Body, msg);
            });
        }

        public struct JsonMessage
        {
            public string message;
        }
    }
}