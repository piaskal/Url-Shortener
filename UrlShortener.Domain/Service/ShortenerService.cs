using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlShortener.Domain.Model;

namespace UrlShortener.Domain.Service
{
    public class ShortenerService : IShortenerService
    {
        readonly IRepository repository;

        public ShortenerService(IRepository repository)
        {
            this.repository = repository;
        }


        public string CreateUrlIdentifier(string url)
        {
            var urlEntity = (from u in repository.Urls
                             where u.Value == url
                             select u
                                ).FirstOrDefault();

            if (urlEntity == null)
            {
                urlEntity = new Url() { Value = url };
                repository.InsertUrl(urlEntity);
            }

            return IdEncoder.Encode(urlEntity.Id);

        }

        public string ResolveUrlIdentifier(string urlShort)
        {
            var id = IdEncoder.Decode(urlShort);
            var urlEntity = (from u in repository.Urls
                             where u.Id == id
                             select u
                    ).FirstOrDefault();

            if (urlEntity == null)
            {
                throw new Exception("Id not found");
            }
            return urlEntity.Value;
        }


        public void UpdateUrlStatistics(string encodedId, System.Collections.Specialized.NameValueCollection nameValueCollection)
        {
            repository.IncreaseUrlHitCount(IdEncoder.Decode(encodedId));

   
        }
    }
}
