using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUrlShortener.Actions
{
    public class PermanentRedirectResult : ActionResult
    {
        private string url;

        public PermanentRedirectResult(string url)
        {
            this.url = url;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = 301;
            context.HttpContext.Response.RedirectLocation = this.url;
        }
    }
}