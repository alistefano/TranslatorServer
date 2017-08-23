using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Configuration;

namespace TranslatorService.Providers
{
    public class AzureTranslatorProvider : ITranslatorProvider
    {
        private readonly string _endpointUrl = "https://api.microsofttranslator.com/v2/http.svc/Translate";
        public async Task<string> Translate(string from, string to, string text)
        {
            //Get the authToken from Azure Auth Service
            var authTokenSource = new AzureAuthToken(new AppSettings().GetString("AzureApiKey"));
            var token = await authTokenSource.GetAccessTokenAsync();

            var url = _endpointUrl
                .AddQueryParam("from", from)
                .AddQueryParam("to", to)
                .AddQueryParam("text", text);

            var client = new WebClient();
            client.Headers.Add("Authorization", token);
            return client.DownloadString(url).FromXml<string>();
        }
    }
}
