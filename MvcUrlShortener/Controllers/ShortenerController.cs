using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUrlShortener.Models;
using UrlShortener.Domain.Service;

namespace MvcUrlShortener.Controllers
{
    public class ShortenerController : Controller
    {
        IShortenerService service;

        public ShortenerController(IShortenerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ViewResult ShortenUrl()
        {
            return View(new ShortenUrlViewModel() { Url = "http://" });
        }

        [HttpPost]
        public ViewResult ShortenUrl(ShortenUrlViewModel request)
        {
            
            if (!request.Url.Contains(":"))
                request.Url = @"http://" + request.Url;

            var urlId = service.CreateUrlIdentifier(request.Url);
            var shortUrl = Request.Url.Scheme + @"://" + Request.Url.Authority + @"/" + urlId;

            request.ShortenedUrl = shortUrl;
            return View(request);
        }

        public ActionResult RedirectUrl(string encodedId)
        {
            var url = service.ResolveUrlIdentifier(encodedId);

            service.UpdateUrlStatistics(encodedId, Request.Headers);

            return Redirect(url);
        }

    }
}
