using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using TranslatorService.Providers;

namespace TranslatorService.Model
{
    [Route("/translate")]
    public class TranslateRequest : IReturn<TranslateResponse>
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public Provider Provider { get; set; }
    }
}
