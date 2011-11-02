using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcUrlShortener.Models
{
    public class ShortenUrlViewModel
    {
        [Required(ErrorMessage = "Enter url")]
        public string Url { get; set; }

        public string ShortenedUrl { get; set; }
    }
}