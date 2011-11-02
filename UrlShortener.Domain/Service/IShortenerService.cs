using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlShortener.Domain.Service
{
    public interface IShortenerService 
    {
        string CreateUrlIdentifier(string url);
        string ResolveUrlIdentifier(string ulrShort);

        void UpdateUrlStatistics(string encodedId, System.Collections.Specialized.NameValueCollection nameValueCollection);
    }
}
