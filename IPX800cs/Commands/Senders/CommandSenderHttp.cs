using System;
using System.Net;
using System.Text;
using software.elendil.IPX800.ipx800csV1.Exceptions;

namespace software.elendil.IPX800.Commands.Senders
{
	/// <summary>
	/// Class CommandSenderHttp.
	/// Provides methods to send HTTP command to an IPX800 v3
	/// </summary>
	public class CommandSenderHttp : ICommandSender
	{
		private readonly Context context;

        public CommandSenderHttp(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public string ExecuteCommand(string command)
		{
            var uri = $"http://{context.IP}:{context.Port}/{command}"; 
			var request = (HttpWebRequest) WebRequest.Create(uri);
            
			AddAuthorizationHeader(request);

			try
			{
				using (var response = (HttpWebResponse) request.GetResponse())
				{
                    if (HttpStatusCode.OK.Equals(response.StatusCode) && "text/xml".Equals(response.ContentType))
                    {
                        var encoding = ASCIIEncoding.ASCII;
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                        {
                            string responseText = reader.ReadToEnd();
                            return responseText;
                        }
                    }
					else
					{
						throw new Exception(response.StatusDescription);
					}
				}
			}
			catch (WebException e)
			{
				throw new IPX800ConnectionException("Unable to connect to IPX800 : " + e.Message, e);
			}
		}

		protected void AddAuthorizationHeader(WebRequest request)
		{
			if (!String.IsNullOrWhiteSpace(context.User) && !String.IsNullOrWhiteSpace(context.Password))
			{
				var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{context.User}:{context.Password}"));
				request.Headers.Add("Authorization", $"Basic {encoded}");
			}
		}
	}
}