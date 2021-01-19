using System;
using System.Security.Principal;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace Olive.Symptoms
{
    partial class Source : IHttpHandler
    {
        static string MakeAbsolute(string url) => HttpContext.Current.Request.GetAbsoluteUrl(url);

        bool IHttpHandler.IsReusable => false;

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            Discover().GetAwaiter().GetResult();
            var response = new JavaScriptSerializer().Serialize(Results);
            context.Response.ContentType = "text/json";
            context.Response.Write(response);
        }

        /// <summary>
        /// Performs the analysis to find current warnings.
        /// </summary>
        public abstract Task Discover();
    }
}