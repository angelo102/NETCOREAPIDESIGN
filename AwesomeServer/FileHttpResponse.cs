using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AwesomeSauce
{
    internal class FileHttpResponse : HttpResponse
    {

        public PathString Path { get; set; }

        public FileHttpResponse(HttpContext httpContext, string path)
        {
            var lines = File.ReadAllText(path).Split('\n');
            var request = lines[0].Split("");
            this.Path = path;
            this.HttpContext = httpContext;
        }

        public override HttpContext HttpContext { get; }

        public override int StatusCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override IHeaderDictionary Headers => throw new NotImplementedException();

        public override Stream Body { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override long? ContentLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string ContentType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override IResponseCookies Cookies => throw new NotImplementedException();

        public override bool HasStarted => throw new NotImplementedException();

        public override void OnCompleted(Func<object, Task> callback, object state)
        {
            using (var reader = new StreamReader(this.Body))
            {
                this.Body.Position = 0;
                var text = reader.ReadToEnd();
                File.WriteAllText(this.Path, $"{this.StatusCode}-{text}");
                this.Body.Flush();
                this.Body.Dispose();
            }
        }

        public override void OnStarting(Func<object, Task> callback, object state)
        {
            throw new NotImplementedException();
        }

        public override void Redirect(string location, bool permanent)
        {
            throw new NotImplementedException();
        }


    }
    
}