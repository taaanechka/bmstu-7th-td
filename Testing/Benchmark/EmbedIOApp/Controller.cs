#nullable disable

using EmbedIO;
using EmbedIO.WebApi;
using EmbedIO.Routing;

using System.Text;

namespace EmbedIOApp
{
    #region Supporting data structures

    public class JsonResult
    {
        public string Message { get; set; }
    }

    #endregion   

    public class Controller : WebApiController
    {
        //GET http://localhost:80/api/plaintext
        [Route(HttpVerbs.Get, "/plaintext")]
        public async Task GetPlainText()
        {
            var bytes = Encoding.UTF8.GetBytes("Hello, World!");

            var ctx = HttpContext;
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentEncoding = Encoding.UTF8;
            ctx.Response.ContentLength64 = bytes.Length;

            await ctx.Response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
        }

        //GET http://localhost:80/api/json
        [Route(HttpVerbs.Get, "/json")]
        public async Task GetJson()
        {
            var data = new JsonResult() { Message = "Hello, World!" };
            var serialized = Swan.Formatters.Json.Serialize(data);

            var bytes = Encoding.UTF8.GetBytes(serialized);

            var ctx = HttpContext;
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentEncoding = Encoding.UTF8;
            ctx.Response.ContentLength64 = bytes.Length;

            await ctx.Response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
        }

        //GET http://localhost:80/api/heavy
        [Route(HttpVerbs.Get, "/heavy")]
        public async Task GetHeavyRequest()
        {
            string filename = Path.GetFullPath(@"Data/text_heavy.txt");
            byte[] content = HelperIO.GetDataBytes(filename);
            int content_len = content.Length;

            var ctx = HttpContext;
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentEncoding = Encoding.UTF8;
            ctx.Response.ContentLength64 = content_len;

            await ctx.Response.OutputStream.WriteAsync(content, 0, content_len);
        }

        //GET http://localhost:80/api/middle
        [Route(HttpVerbs.Get, "/middle")]
        public async Task GetMiddleRequest()
        {
            string filename = Path.GetFullPath(@"Data/text_middle.txt");
            byte[] content = HelperIO.GetDataBytes(filename);
            int content_len = content.Length;

            var ctx = HttpContext;
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "text/plain";
            ctx.Response.ContentEncoding = Encoding.UTF8;
            ctx.Response.ContentLength64 = content_len;

            await ctx.Response.OutputStream.WriteAsync(content, 0, content_len);
        }
    }
}