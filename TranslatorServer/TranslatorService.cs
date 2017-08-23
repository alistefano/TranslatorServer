using ServiceStack;
using TranslatorService.Model;
using TranslatorService.Providers;

namespace TranslatorService
{
    public class TranslatorService : Service
    {
        public object Any(TranslateRequest request)
        {
            ITranslatorProvider provider = null;

            switch (request.Provider)
            {                
                case Provider.Bing:
                    provider = new AzureTranslatorProvider();
                    break;

                case Provider.Google:
                default:
                    provider = new GoogleTranslatorProvider();
                    break;
            }

            return new TranslateResponse()
            {
                Translation = provider.Translate(request.From, request.To, request.Text).Result
            };
        }
    }
}
