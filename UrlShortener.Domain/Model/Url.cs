using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;

namespace UrlShortener.Domain.Model
{
    [Table(Name = "Urls")]
    public class Url
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set; }

        [Column(Name="Url")]
        public string Value { get; set; }

        [Column]
        public int HitCount { get; set; }
    }
}
