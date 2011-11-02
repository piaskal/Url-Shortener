using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using UrlShortener.Domain.Model;

namespace UrlShortener.Domain
{
    public class SqlRepository : UrlShortener.Domain.IRepository
    {

        private Table<Url> urlsTable;
        private DataContext dc;

        public SqlRepository(string connectionString)
        {
            dc = new DataContext(connectionString);
            urlsTable = dc.GetTable<Url>();
        }

        public IQueryable<Url> Urls
        {
            get { return urlsTable; }
        }

        public Url InsertUrl(Url url)
        {
            urlsTable.InsertOnSubmit(url);
            urlsTable.Context.SubmitChanges();
            return url;
        }


        public void IncreaseUrlHitCount(int urlId)
        {
            dc.ExecuteCommand("UPDATE urls SET hitcount = hitcount + 1 WHERE id = {0} ", urlId);
        }
    }
}
