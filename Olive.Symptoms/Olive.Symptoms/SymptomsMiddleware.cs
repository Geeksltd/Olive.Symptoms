namespace Olive.Symptoms
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    internal static class SymptomsMiddleware
    {
        internal static async Task Discover<T>(HttpContext context) where T : Source, new()
        {
            var keywords = context.Request.Param("searcher").OrEmpty().Split(' ');
            if (keywords.None()) return;

            var searchInstance = new T { };
            await searchInstance.Discover();
            var response = JsonConvert.SerializeObject(searchInstance.Results);
            await context.Response.WriteAsync(response);
        }
    }
}
