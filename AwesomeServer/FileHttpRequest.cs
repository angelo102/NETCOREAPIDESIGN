﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AwesomeServer
{
    internal class FileHttpRequest : HttpRequest
    {
     

        public FileHttpRequest(HttpContext httpContext, string path)
        {
            var lines = File.ReadAllText(path).Split('\n');
            var request = lines[0].Split(' ');
            this.Method = request[0];
            this.Path = request[1];
            this.HttpContext = httpContext;
        }

        public override HttpContext HttpContext { get; }

        public override string Method { get; set; }
        public override string Scheme { get; set; } = "file";
        public override bool IsHttps { get; set; }
        public override HostString Host { get; set; }
        public override PathString PathBase { get; set; }
        public override PathString Path { get; set; }
        public override QueryString QueryString { get; set; }
        public override IQueryCollection Query { get; set; }
        public override string Protocol { get; set; }

        public override IHeaderDictionary Headers => new HeaderDictionary();

        public override IRequestCookieCollection Cookies { get; set; }
        public override long? ContentLength { get; set; }
        public override string ContentType { get; set; }
        public override Stream Body { get; set; }

        public override bool HasFormContentType => throw new System.NotImplementedException();

        public override IFormCollection Form { get; set; }

        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}