using System.Security.Claims;
using System.Threading.Tasks;

namespace Olive.Symptoms
{
    partial class Source
    {
        static string MakeAbsolute(string url) => Context.Current.Request().GetAbsoluteUrl(url);

        /// <summary>
        /// Performs the analysis on the database to find all current warnings.
        /// </summary>
        public abstract Task Discover();
    }
}
