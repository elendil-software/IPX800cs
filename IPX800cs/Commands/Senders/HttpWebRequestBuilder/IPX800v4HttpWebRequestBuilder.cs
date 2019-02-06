using System;
using System.Net;
using System.Text;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder
{
    internal class IPX800v4HttpWebRequestBuilder : IHttpWebRequestBuilder
    {
        private readonly Context context;

        public IPX800v4HttpWebRequestBuilder(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public WebRequest Build(string command)
        {
            string uri = BuildRequestUriString(command);
            var request = (HttpWebRequest) WebRequest.Create(uri);

            return request;
        }
        
        private string BuildRequestUriString(string command)
        {
            var uri = new StringBuilder($"http://{context.IP}:{context.Port}{command}");

            if (!string.IsNullOrWhiteSpace(context.Password))
            {
                uri.Append($"&key={context.Password}");
            }

            return uri.ToString();
        }
    }
}