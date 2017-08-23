using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Configuration;
using ServiceStack.Text;

namespace TranslatorService.Providers
{
    public class GoogleTranslatorProvider : ITranslatorProvider
    {
        private readonly string _endpointUrl = "https://translation.googleapis.com/language/translate/v2";

        public async Task<string> Translate(string from, string to, string text)
        {
            var url = _endpointUrl
                .AddQueryParam("source", from)
                .AddQueryParam("target", to)
                .AddQueryParam("q", text)
                .AddQueryParam("format", "text")
                .AddQueryParam("key", new AppSettings().GetString("GoogleApiKey"));

            var response = await url.GetJsonFromUrlAsync();
            var translations = JsonObject.Parse(response).Object("data").ArrayObjects("translations");
            return !translations.IsNullOrEmpty() ? translations[0]["translatedText"] : "";
        }
    }
}
