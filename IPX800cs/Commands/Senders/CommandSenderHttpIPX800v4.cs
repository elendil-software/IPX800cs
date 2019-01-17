using System;
using System.IO;
using System.Net;
using System.Text;
using software.elendil.IPX800.ipx800csV1.Exceptions;

namespace software.elendil.IPX800.Commands.Senders
{
    public class CommandSenderHttpIPX800V4 : ICommandSender
    {
        private readonly Context context;

        public CommandSenderHttpIPX800V4(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string ExecuteCommand(string command)
        {
            var uri = GetUri(command);
            var request = (HttpWebRequest) WebRequest.Create(uri);

            try
            {
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    if (HttpStatusCode.OK.Equals(response.StatusCode))
                    {
                        string jsonResponse;

                        using (var responseStream = response.GetResponseStream())
                        {
                            if (responseStream == null)
                            {
                                throw new IPX800ConnectionException(
                                    "Unable to connect to IPX800, responseStream is null");
                            }

                            var reader = new StreamReader(responseStream);
                            jsonResponse = reader.ReadToEnd();
                            responseStream.Close();
                            response.Close();
                        }

                        return jsonResponse;
                    }
                    else
                    {
                        return response.StatusDescription;
                    }
                }
            }
            catch (WebException e)
            {
                throw new IPX800ConnectionException("Unable to connect to IPX800 : " + e.Message, e);
            }
        }


        private string GetUri(string command)
        {
            var uri = new StringBuilder($"http://{context.IP}:{context.Port}/api/xdevices.json?");

            if (!string.IsNullOrWhiteSpace(context.Password))
            {
                uri.Append("key=").Append(context.Password).Append("&");
            }

            uri.Append(command);
            return uri.ToString();
        }
    }
}