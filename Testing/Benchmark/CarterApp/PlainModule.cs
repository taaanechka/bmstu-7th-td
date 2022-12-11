namespace CarterApp
{
    using Carter;
    using System.Text;

    public class PlainModule : ICarterModule
    {
        private static readonly byte[] _helloWorldPayload = Encoding.UTF8.GetBytes("Hello, World!");

        private byte[] GetDataBytes(string filename = @"Data/text_heavy.txt")
        {
            string content = File.ReadAllText(filename);

            return Encoding.UTF8.GetBytes(content);
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //GET http://localhost:80/plaintext
            app.MapGet("/plaintext", (HttpResponse res) =>
            {
                var payloadLength = _helloWorldPayload.Length;
                res.StatusCode = 200;
                res.ContentType = "text/plain";
                res.ContentLength = payloadLength;

                return res.Body.WriteAsync(_helloWorldPayload, 0, payloadLength);
            });

            //GET http://localhost:80/heavy
            app.MapGet("/heavy", (HttpResponse res) =>
            {
                string filename = Path.GetFullPath(@"Data/text_heavy.txt");
                byte[] content = GetDataBytes(filename);
                int content_len = content.Length;

                res.StatusCode = 200;
                res.ContentType = "text/plain";
                res.ContentLength = content_len;

                return res.Body.WriteAsync(content, 0, content_len);
            });

            //GET http://localhost:80/middle
            app.MapGet("/middle", (HttpResponse res) =>
            {
                string filename = Path.GetFullPath(@"Data/text_middle.txt");
                byte[] content = GetDataBytes(filename);
                int content_len = content.Length;

                res.StatusCode = 200;
                res.ContentType = "text/plain";
                res.ContentLength = content_len;

                return res.Body.WriteAsync(content, 0, content_len);
            });
        }
    }
}