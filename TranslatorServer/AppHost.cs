using Funq;
using ServiceStack;
using ServiceStack.Api.OpenApi;

namespace TranslatorService
{
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("Translator Server", typeof(TranslatorService).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            this.Plugins.Add(new OpenApiFeature());
        }
    }
}
