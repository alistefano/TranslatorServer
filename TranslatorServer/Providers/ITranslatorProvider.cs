using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorService.Providers
{
    public enum Provider {Google, Bing}

    public interface ITranslatorProvider
    {
        Task<string> Translate(string from, string to, string text);
    }
}
