using System;
using System.Net;
using System.Text;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder
{
    internal class DefaultHttpWebRequestBuilder : IHttpWebRequestBuilder
    {
        private readonly Context context;

        public DefaultHttpWebRequestBuilder(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public WebRequest Build(string command)
        {
            string uri = $"http://{context.IP}:{context.Port}/{command}";
            var request = (HttpWebRequest) WebRequest.Create(uri);
            
            AddAuthorizationHeader(request);

            return request;
        }
		
        private void AddAuthorizationHeader(WebRequest request)
        {
            if (!string.IsNullOrWhiteSpace(context.User) && !string.IsNullOrWhiteSpace(context.Password))
            {
                var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{context.User}:{context.Password}"));
                request.Headers.Add("Authorization", $"Basic {encoded}");
            }
        }
    }
}