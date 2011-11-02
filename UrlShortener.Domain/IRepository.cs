using System;
namespace UrlShortener.Domain
{
    public interface IRepository
    {
        UrlShortener.Domain.Model.Url InsertUrl(UrlShortener.Domain.Model.Url url);
        System.Linq.IQueryable<UrlShortener.Domain.Model.Url> Urls { get; }

        void IncreaseUrlHitCount(int p);
    }
}
